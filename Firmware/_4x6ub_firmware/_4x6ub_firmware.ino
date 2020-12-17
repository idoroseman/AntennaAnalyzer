/*
  AntennaAnalyzer.ino

  This file contains parts of the K6BEZ Antenna Analyzer project.
  Universal 8bit Graphics Library (https://github.com/olikraus/u8g2/)

*/

#include <Arduino.h>
#include <U8g2lib.h>
#include <RotaryEncoder.h>

#define LCD_E   7
#define LCD_D4  15
#define LCD_RS  A2

#define DDS_RESET 2
#define DDS_SDAT 3
#define DDS_UPDATE 4
#define DDS_SCLK 5

#define MODE A2
#define BAND A3

#define SW_RST  6
#define SW_E1   9
#define SW_E2   8
#define SW_BTN  A3

#define BUZZER  10
#define LED_INTERNAL 17

#define AREV A0
#define AFWD A1

#define ROTARYMIN 0
#define ROTARYMAX 99
#define DEBOUNCE 10

// initialize the library with the numbers of the interface pins
U8G2_ST7920_128X64_1_SW_SPI u8g2(U8G2_R0, /* clock=*/ LCD_D4, /* data=*/ LCD_E, /* CS=*/ LCD_RS, /* reset=*/ U8X8_PIN_NONE);
RotaryEncoder encoder(SW_E2, SW_E1);

long num_steps = 100;      // Number of steps to use in the sweep
long Fstart = 5000000;      // Start Frequency for sweep
long Fstop = 30000000;      // Stop Frequency for sweep
long Fstep = (Fstop - Fstart) / num_steps;
unsigned long current_freq; // Temp variable used during sweep

long serial_input_number;   // Used to build number from serial stream
char incoming_char;         // Character read from serial stream
byte mode_pressed = 0;

bool isHostConnected = false;
bool isSweeping = false;     // sweep running flag
int sweepIndex = 0;
double minVSWR;
long minFreq;
unsigned long start_time;
int activeBand = 0;
double dispMinVSWR;
long dispMinFreq;
int runMode = 0; // 0= Auto Stop 1=Manual 2= Auto Run
int uiMode = 0;  // 0=about 1=graph 2=menu
byte graph[100];

long bandStart[12] = { 5000000,  1500000, 2000000, 5000000, 6000000,  9000000, 13000000, 17000000, 20000000, 24000000, 28000000, 49500000 };
long bandStop[12]  = { 30000000, 2300000, 5000000, 6000000, 8000000, 11000000, 16000000, 19000000, 23000000, 26000000, 30000000, 51000000 };
String bandMenu[12] =  {"Full Range", "160m / 1.8MHz", "80m / 3.5MHz", "60m / 5MHz", "40m / 7MHz", "30m / 9MHz", "20m / 14MHz", "17m / 17MHz", "15m / 20MHz", "12m / 24MHz", "10m / 28MHz", "6m / 50MHz" }; 
String mainMenu[4] = {"Back", "Select Band", "Run Mode", "About" };
String runMenu[2] = {"Auto", "Manual"};

int switchButton;
int switchReset;
int lastPos = -1;
int savedPos = -1;
String* activeMenu = mainMenu;
int sizeofMenu = 4;//sizeof(*activeMenu) / sizeof(String);
unsigned long previousMillis = 0;        // will store last time LED was updated
const long interval = 5000;           // interval at which to blink (milliseconds)

//-------------------------------------------------------------------------
//                             S E T U P
//-------------------------------------------------------------------------
void setup() {

  // Print a message to the LCD.
  u8g2.begin();  
  updateUI();


  // initialize serial communication
  Serial.begin(115200);

  // Configure DDS control pins for digital output
  pinMode(DDS_UPDATE, OUTPUT);
  pinMode(DDS_SCLK, OUTPUT);
  pinMode(DDS_SDAT, OUTPUT);
  pinMode(DDS_RESET, OUTPUT);

  // Set up analog inputs on A0 and A1, internal reference voltage
  pinMode(AREV, INPUT);
  pinMode(AFWD, INPUT);
  analogReference(DEFAULT);

  pinMode(SW_RST, INPUT_PULLUP); 
  pinMode(SW_BTN, INPUT_PULLUP); 
  pinMode(SW_E1, INPUT_PULLUP); 
  pinMode(SW_E2, INPUT_PULLUP);
  pinMode(BUZZER, OUTPUT);
  
  // Reset the DDS
  digitalWrite(DDS_RESET, HIGH);
  digitalWrite(DDS_RESET, LOW);

  //Initialise the incoming serial number to zero
  serial_input_number = 0;
  activeBand = 0;
  uiMode = 1;
  for (int i=0; i<100; i++)
    graph[i]=100;
  setPos(50);
  updateUI();
}

//-------------------------------------------------------------------------
//                              L O O P
//-------------------------------------------------------------------------
void loop() {
  //Check for serial communication
  if (Serial.available() > 0) 
  {
    isHostConnected = true;
    //isSweeping = false;
    handle_comm();
  }
  else
  {
//    if (!isHostConnected) 
//      ///////////////////////////();
  }

  // encoder

  // get the current physical position and calc the logical position
  encoder.tick();
  int newPos = encoder.getPosition() ;
  
  if (newPos < ROTARYMIN) {
    encoder.setPosition(ROTARYMIN);
    newPos = ROTARYMIN;
  } else if (newPos > ROTARYMAX) {
    encoder.setPosition(ROTARYMAX);
    newPos = ROTARYMAX;
  } 

  if (lastPos != newPos) {
    lastPos = newPos;
    updateUI();
  } // if

  if (digitalRead(SW_BTN))
    switchButton = 0;
  else if (switchButton < DEBOUNCE)
    switchButton++;
  if (digitalRead(SW_RST))
    switchReset = 0;
  else if (switchReset < DEBOUNCE)
    switchReset++;

    // left click
  if (switchReset == DEBOUNCE - 1) {
    switch(uiMode) {
      case 1: // graph
        switch (runMode) {
          case 0:
            runMode = 2;
            updateUI();
            break;
          case 1:
            sweep_start();
            updateUI();
            break;
          case 2:
            runMode = 0;
            updateUI();
            break;
        }
        break;
      default:
        uiMode = 1;
        setPos(50);
        updateUI();
        break;   
    }
  }

  // right click
  if (switchButton == DEBOUNCE - 1) {
    switch(uiMode) {
      case 0: // about
        uiMode = 0;
        setPos(savedPos);
        updateUI();
        break;
      case 1: // graph
        savedPos =  encoder.getPosition();
        selectMenu(mainMenu, sizeof(mainMenu), 1);
        uiMode = 2;
        updateUI();
        break;
      case 2: // main menu
        switch (encoder.getPosition()) {
          case 0 : // back
            uiMode = 0;
            break;
          case 1 : // band menu
            selectMenu(bandMenu, sizeof(bandMenu), activeBand);
            uiMode = 3;
            break;
          case 2 : // run mode
            selectMenu(runMenu, sizeof(runMenu), runMode);
            uiMode = 4;
            break;
          case 3 : // about
            uiMode = 1;
            break;
        }
        updateUI();
        break;  
      case 3: // band menu
        activeBand =  encoder.getPosition();
        selectBand(activeBand);
        uiMode = 1;
        setPos(50);
        updateUI();
        break;
      case 4: // run mode
        runMode =  encoder.getPosition();
        uiMode = 1;
        setPos(savedPos);
        updateUI();
        break;
    }
  }

    // timer tick
    unsigned long currentMillis = millis();
    if (currentMillis - previousMillis >= interval) {
      // save the last time you blinked the LED
      previousMillis = currentMillis;
      if (runMode == 2) {
        sweep_start();
        updateUI();
      }
    }

  // freq sweep
  if (isSweeping)
  {
      sweep_step(sweepIndex);
      sweepIndex++;
      if (sweepIndex >= num_steps)
      {
       sweep_done();
       isSweeping = false;
       updateUI();
      }
  }
}

//-------------------------------------------------------------------------
//                             Signal gen
//-------------------------------------------------------------------------
void sweep_start() 
{
  minVSWR = 999;
  minFreq = Fstart;
  Fstep = (Fstop - Fstart) / num_steps;
  // Reset the DDS
  digitalWrite(DDS_RESET, HIGH);
  delay(1);
  digitalWrite(DDS_RESET, LOW);
  delay(10);
  SetDDSFreq(Fstart);
  delay(10);
  // dont know why but first time it needs to sent twice
  // other wise it don't settle
  SetDDSFreq(Fstart);
  delay(10);

  // Start loop
  start_time = millis();
  sweepIndex = 0;
  isSweeping = true;
}

void sweep_step(int i)
{
    int FWD = 0;
    int REV = 0;
    double VSWR;
  
    // Calculate current frequency
    current_freq = Fstart + i * Fstep;

    // Read the forawrd and reverse voltages
    REV = analogRead(AREV);
    FWD = analogRead(AFWD);

    // Set DDS to next frequency
    SetDDSFreq(current_freq + Fstep);
    // Wait a little for settling
    delay(1);

    // do the math
    if (REV >= FWD) {
      // To avoid a divide by zero or negative VSWR then set to max 999
      VSWR = 999;
    } else {
      // Calculate VSWR
      VSWR = ((double)FWD + (double)REV) / ((double)FWD - (double)REV);
    }

    if (VSWR <= minVSWR) {
      minFreq = current_freq;
      minVSWR = VSWR;
    }

    if (VSWR>10.0)
      graph[i] = 100;
    else
      graph[i] = (byte)(VSWR * 10.0) ;
    
    if (isHostConnected) {
      // Send current line back to PC over serial bus
      Serial.print(current_freq);
      Serial.print(",");
      Serial.print(long(VSWR * 1000)); // This *1000 is to make the system compatible with the PIC version
      Serial.print(",");
      Serial.print(FWD);
      Serial.print(",");
      Serial.println(REV);
      Serial.flush();
      //delay(100);
    }
}

void sweep_done()
{
  // Send "End" to PC to indicate end of sweep
  unsigned long end_time = millis();
  if (isHostConnected) {
    
    Serial.println("End");
    Serial.print("Freq ");
    Serial.print(minFreq);
    Serial.print(", VSWR ");
    Serial.println(minVSWR);
//    Serial.print("Time ");
//    Serial.println(end_time-start_time);
    Serial.flush();
  }

  dispMinFreq = minFreq;
  dispMinVSWR = minVSWR;
  
}

//-------------------------------------------------------------------------
void SetDDSFreq(long Freq_Hz) {
  // Calculate the DDS word - from AD9850 Datasheet
  int32_t f = Freq_Hz * 4294967295 / 125000000;

  // Send one byte at a time
  for (int b = 0; b < 4; b++, f >>= 8) {
    send_byte(f & 0xFF);
  }

  // 5th byte needs to be zeros
  send_byte(0);

  // Strobe the Update pin to tell DDS to use values
  digitalWrite(DDS_UPDATE, HIGH);
  delay(1);
  digitalWrite(DDS_UPDATE, LOW);
}

//-------------------------------------------------------------------------
void send_byte(byte data_to_send) {
  // Bit bang the byte over the SPI bus
  for (int i = 0; i < 8; i++, data_to_send >>= 1) {
    // Set Data bit on output pin
    digitalWrite(DDS_SDAT, data_to_send & 0x01);
    // Strobe the clock pin
    digitalWrite(DDS_SCLK, HIGH);
    digitalWrite(DDS_SCLK, LOW);
  }
}

//-------------------------------------------------------------------------
//                            Communication
//-------------------------------------------------------------------------
void handle_comm()
{
  /*
    lcd.clear();
    lcd.setCursor(14, 0);
    lcd.print("PC");
    */
    incoming_char = Serial.read();
    switch (incoming_char) {
      case '0':
      case '1':
      case '2':
      case '3':
      case '4':
      case '5':
      case '6':
      case '7':
      case '8':
      case '9':
        serial_input_number = serial_input_number * 10 + (incoming_char - '0');
        break;
      case 'A':
        //Turn frequency into FStart
        Fstart = serial_input_number;
        serial_input_number = 0;
        break;
      case 'B':
        //Turn frequency into FStop
        Fstop = serial_input_number;
        serial_input_number = 0;
        break;
      case 'C':
        //Turn frequency into FStart and set DDS output to single frequency
        Fstart = serial_input_number;
        SetDDSFreq(Fstart);
        serial_input_number = 0;
        break;
      case 'N':
        // Set number of steps in the sweep
        num_steps = serial_input_number;
        serial_input_number = 0;
        break;
      case 'S':
      case 's':
        sweep_start();
        updateUI();
    break;
      case '?':
        // Report current configuration to PC
        Serial.print("Start Freq:");
        Serial.println(Fstart);
        Serial.print("Stop Freq:");
        Serial.println(Fstop);
        Serial.print("Fre step:");
        Serial.println(Fstep);
        Serial.print("Num Steps:");
        Serial.println(num_steps);
        break;
      case '.':
        // host control
        break;
      case '~':
        // ui
        for (int i = 0; i<100; i++)
        { 
          Serial.print(Fstart+i*Fstep);
          Serial.print(", ");
          Serial.println(graph[i]/10.0);
        }
        break;
        
    }
    Serial.flush();
}

void selectBand(int band)
{
    Fstart = bandStart[band];
    Fstop = bandStop[band];
    Fstep = (Fstop - Fstart) / num_steps;
    activeBand = band;
    updateUI();
}

//-------------------------------------------------------------------------
//                                U I
//-------------------------------------------------------------------------
void setPos(int pos) {
  encoder.setPosition(pos); 
  lastPos = pos;
}

void selectMenu(String *menu, int menulen, int pos) {
  activeMenu = menu;
  sizeofMenu = menulen / sizeof(String);
  encoder.setPosition(pos); 
  lastPos = pos;
}

void updateUI()
{
    u8g2.firstPage();
    do {
        switch (uiMode) {
          case 0: // about
            drawLogo();
            break;
          case 1: // main screen
            drawGraph();
            break;
          case 2:
          case 3:
          case 4:
            drawMenu();
            break;
        }
    } while ( u8g2.nextPage() ); 
}

void drawLogo()
{
    u8g2.setFont(u8g2_font_ncenB10_tr);
    u8g2.drawStr(0,14,"4X6UB");
    u8g2.setFont(u8g2_font_profont12_tf);
    u8g2.drawStr(0,23,"Antenna Analyzer");
    u8g2.drawStr(0,32,"Derivative work based");
    u8g2.drawStr(0,41,"on Beric Dunn K6BEZ");
    u8g2.drawStr(0,50,"Antenna Analyzer project.");
}

void drawGraph()
{
    // min data
    u8g2.setCursor(0, 64);
    u8g2.print(dispMinVSWR, 1);
    u8g2.print(":1");
    u8g2.print(" @ ");
    u8g2.print(dispMinFreq/1000000.0, 3);

    // grid
    u8g2.drawVLine(9, 0, 46);
    for (int i=0; i<100; i+=20)
    {
      u8g2.drawHLine(9,46-i*46/100,100);
      // y axis label
      u8g2.setCursor(0,46+4-i*46/100);
      if (i>0)
        u8g2.print(i/10);
    }
    
    // x axis label
    u8g2.setCursor(5, 55);
    u8g2.print(Fstart/1000000.0,1);
    u8g2.setCursor(53, 55);
    u8g2.print((Fstart+Fstop)/2000000.0,1);
    u8g2.setCursor(95, 55);
    u8g2.print(Fstop/1000000.0,1);
    
    // data
    byte prev = graph[0]*46/100;
    for (int i=0; i<100; i++)
    {
      byte val = graph[i]*46/100;
      //u8g2.drawPixel(18+i, 46-val);
      u8g2.drawLine(10+i, 46-prev, 10+i, 46-val);
      prev = val;
    }
    
    // cursor
//    u8g2.setDrawColor(2);
    u8g2.drawVLine(10+ encoder.getPosition(),0,46);
//    u8g2.setDrawColor(1);

    // cursor data
    long f = Fstep;
    f *= encoder.getPosition();
    f += Fstart;
    u8g2.setCursor(92, 10);
    u8g2.print(f/1000000.0, 3);
    u8g2.setCursor(92, 19);
    u8g2.print(graph[encoder.getPosition()]/10.0, 1);
    u8g2.print(":1");

    // run mode
    switch(runMode) {
      case 0:
        u8g2.drawStr(100,64,"Stop");
        break;
      case 1:
        u8g2.drawStr(100,64,"Man");
        break;
      case 2:
      case 3:
        u8g2.drawStr(100,64,"Run");
        break;
      default:
        u8g2.drawStr(100,64,"Err");
        break;      
    }
    if (isSweeping)
        u8g2.drawStr(128-5, 65, "*");

}

void drawMenu()
{
  if ( encoder.getPosition() >= sizeofMenu) {
        encoder.setPosition(sizeofMenu-1);
        lastPos = sizeofMenu-1;
  }
  u8g2.drawStr(20, 9*4, ">");
  for (int line = 0; line < 7 ; line++) 
    if (( encoder.getPosition() + line -3 >=0) && ( encoder.getPosition() + line - 3 < sizeofMenu)) 
    {
      u8g2.setCursor(30, (line+1)*9);
      u8g2.print(activeMenu[ encoder.getPosition() + line -3]);      
    }

}



