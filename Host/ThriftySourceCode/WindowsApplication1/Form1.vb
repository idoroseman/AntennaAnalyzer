Public Class Form1
    '
    '   Thrifty Antenna Sweeper
    '
    '   Beric Dunn K6BEZ
    '
    '   PC Software to go with the $20 Antenna Analyser presented at Pacificon 2013 and hosted at
    '   http://hamstack.com/project_home.html
    '

    'Define global variables.
    ' Yes, I know global variables are not good practice, but moving on....

    Dim fStart As Double    'Start Frequency for sweep
    Dim fStop As Double     'Stop Frequency for sweep

    Dim BandMarkers(3) As Double  'Frequencies for band markers - used to hold top, middle and bottom of each band
    Dim MarkerFreq As Double      'Freq of user defined marker
    Dim SweepFreqs(101) As Double 'List of VSWR values from sweep
    Dim SweepSWR(101) As Double   'List of frequencies from sweep
    Dim bSerialOpen As Boolean    'True if serial comms are open
    '    Dim recString As String       '
    Dim current_index As Long
    Dim numSteps As Integer
    Dim minPoint As Double
    Dim minPointFreq As Double
    Dim TimeOutTimer As ULong
    Dim bSweepParamsChanged As Boolean
 
    Dim CommPorts As Array
    Dim bSweeping As Boolean
    Dim bNeedsUpdate As Boolean
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim i As Integer
        'Set up default form values
        txtStartFreq.Text = "1"
        fStart = Val(txtStartFreq.Text)
        txtStopFreq.Text = "30"
        fStop = Val(txtStopFreq.Text)
        txtNumSteps.Text = "50"
        chkContSweep.Checked = False
        bSerialOpen = False
        lblMinPointFreq.Text = "99.999"
        lblVSWR.Text = "--:1"

        'Get list of available serial ports
        CommPorts = IO.Ports.SerialPort.GetPortNames()

        'Populate a comboBox with these names
        For i = 0 To UBound(CommPorts)
            cmbPort.Items.Add(CommPorts(i))
        Next
        'If there are any com ports in the list then select the first one.
        If cmbPort.Items.Count > 0 Then
            cmbPort.Text = cmbPort.Items.Item(0)
        End If
        'Declare that the sweep params have changed and will need to be sent before the sweep
        bSweepParamsChanged = True
    End Sub

    Private Sub doSweep()
        'If the serial port is not open then don't do the sweep
        If SerialPort1.IsOpen = False Then Return

        bSweeping = True
        numSteps = Val(txtNumSteps.Text) + 1

        'More than 100 steps takes a while
        If numSteps > 101 Then
            numSteps = 101
            txtNumSteps.Text = numSteps
        End If
        'Get sweep params from form
        fStart = Val(txtStartFreq.Text)
        fStop = Val(txtStopFreq.Text)
        Dim deltaF As Double
        deltaF = (fStop - fStart) / 10

        'Populate Frequency axis values
        lblF0.Text = fStart.ToString
        lblF1.Text = fStart + 1 * deltaF
        lblF2.Text = fStart + 2 * deltaF
        lblF3.Text = fStart + 3 * deltaF
        lblF4.Text = fStart + 4 * deltaF
        lblF5.Text = fStart + 5 * deltaF
        lblF6.Text = fStart + 6 * deltaF
        lblF7.Text = fStart + 7 * deltaF
        lblF8.Text = fStart + 8 * deltaF
        lblF9.Text = fStart + 9 * deltaF
        lblF10.Text = fStop.ToString

        'Serial Comms can be risky, so trap the function in a try
        Try
            'If bSweepParamsChanged = True Then
            'If the parameters have changed since the last sweep then send the new ones.
            'Wait between lines to allow the PIC to process them without over-running.
            'Buffer size is 20 bytes in the PIC right now but this might change if more variable space is needed
            SerialPort1.WriteLine(Int(fStart * 1000000) & "A" & vbLf) 'Set start frequency
            System.Threading.Thread.Sleep(100)
            SerialPort1.WriteLine(Int(fStop * 1000000) & "B" & vbLf) 'Set stop frequency
            System.Threading.Thread.Sleep(100)
            SerialPort1.WriteLine(numSteps & "N" & vbLf)  'Set number of steps
            System.Threading.Thread.Sleep(100)
            'Now sweep data has been resent, clear the flag
            bSweepParamsChanged = False
            'End If
            'Start the sweep
            SerialPort1.WriteLine("S" & vbLf)


        Catch ex As TimeoutException
            MessageBox.Show("Timeout")
            SerialPort1.Close()
            bSerialOpen = False
        Catch ex As Exception
            MessageBox.Show("Failed to send config data to Sweeper Hardware")
            SerialPort1.Close()
            bSerialOpen = False
        End Try
        TimeOutTimer = TimeOfDay.Millisecond
    End Sub

    Private Sub btnSweep_Click(sender As Object, e As EventArgs) Handles btnSweep.Click
        'Start sweeping
        btnSweep.Text = "Sweeping"
        doSweep()
        'If Continuous sweeps are requested then keep sweeping
        '        While chkContSweep.Checked = True
        '       If bSweeping = False Then
        'doSweep()
        'End If
        'End While
        'btnSweep.Text = "Sweep"

    End Sub
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        If chkContSweep.Checked = True And bSweeping = False Then
            'btnSweep.Text = "Sweeping"
            doSweep()
            'btnSweep.Text = "Sweep"
        End If
    End Sub
    Private Sub PictureBox1_paint(sender As Object, e As System.Windows.Forms.PaintEventArgs) Handles PictureBox1.Paint
        'Draw clear graph area
        Dim g As Graphics = e.Graphics
        Dim pn As New Pen(Color.White) '~~~ color of the lines

        Dim x As Integer
        Dim y As Integer
        pn.Color = Color.Black
        pn.DashStyle = Drawing2D.DashStyle.Dot
        x = PictureBox1.Width
        y = PictureBox1.Height

        Dim intSpacing As Integer = 50  '~~~ spacing between adjacent lines

        '~~~ Draw the horizontal lines
        x = PictureBox1.Width
        For y = 0 To PictureBox1.Height Step intSpacing
            g.DrawLine(pn, New Point(0, y), New Point(x, y))
        Next

        '~~~ Draw the vertical lines
        y = PictureBox1.Height
        intSpacing = 50
        For x = 0 To PictureBox1.Width Step intSpacing
            g.DrawLine(pn, New Point(x, 0), New Point(x, y))
        Next

    End Sub

    Private Sub txtStartFreq_TextChanged(sender As Object, e As EventArgs) Handles txtStartFreq.TextChanged
        'The frequency in the text box has been changed, so set the flag to say that the sweep parameters need changing
        bSweepParamsChanged = True
    End Sub

    Private Sub ComboBandSelect_SelectedIndexChanged(sender As Object, e As EventArgs) Handles ComboBandSelect.SelectedIndexChanged
        'A different band has been selected so change the sweep parameters to reflect it
        '  Start Freq and stop freq are set to extend beyond the end of the band
        '  BandMarkers is a list of fixed markers showing the top, bottom and CW/Voice switch-over frequency

        Select Case ComboBandSelect.SelectedIndex
            Case 0 & vbLf '160m
                txtStartFreq.Text = "1.7"
                txtStopFreq.Text = "2.1"
                ReDim BandMarkers(3)
                BandMarkers(0) = 1.8
                BandMarkers(1) = 1.9
                BandMarkers(2) = 2.0
            Case 1 '80m
                txtStartFreq.Text = "3.4"
                txtStopFreq.Text = "4.1"
                ReDim BandMarkers(3)
                BandMarkers(0) = 3.5
                BandMarkers(1) = 3.6
                BandMarkers(2) = 4
            Case 2 '60m
                txtStartFreq.Text = "5.2"
                txtStopFreq.Text = "5.5"
                ReDim BandMarkers(5)
                BandMarkers(0) = 5.3305
                BandMarkers(1) = 5.3465
                BandMarkers(2) = 5.357
                BandMarkers(3) = 5.3715
                BandMarkers(4) = 5.5035
            Case 3 '40m
                txtStartFreq.Text = "6.9"
                txtStopFreq.Text = "7.4"
                ReDim BandMarkers(3)
                BandMarkers(0) = 7
                BandMarkers(1) = 7.125
                BandMarkers(2) = 7.3
            Case 4 '30m
                txtStartFreq.Text = "10"
                txtStopFreq.Text = "10.25"
                ReDim BandMarkers(2)
                BandMarkers(0) = 10.1
                BandMarkers(1) = 10.15
            Case 5 '20m
                txtStartFreq.Text = "13.9"
                txtStopFreq.Text = "14.45"
                ReDim BandMarkers(3)
                BandMarkers(0) = 14
                BandMarkers(1) = 14.15
                BandMarkers(2) = 14.35
            Case 6 '17m
                txtStartFreq.Text = "18"
                txtStopFreq.Text = "18.2"
                ReDim BandMarkers(3)
                BandMarkers(0) = 18.068
                BandMarkers(1) = 18.11
                BandMarkers(2) = 18.168
            Case 7 '15m
                txtStartFreq.Text = "20.9"
                txtStopFreq.Text = "21.55"
                ReDim BandMarkers(3)
                BandMarkers(0) = 21
                BandMarkers(1) = 21.2
                BandMarkers(2) = 21.45
            Case 8 '12m
                txtStartFreq.Text = "24.8"
                txtStopFreq.Text = "25"
                ReDim BandMarkers(3)
                BandMarkers(0) = 24.89
                BandMarkers(1) = 24.93
                BandMarkers(2) = 24.99
            Case 9 '10m
                txtStartFreq.Text = "27.9"
                txtStopFreq.Text = "29.8"
                ReDim BandMarkers(3)
                BandMarkers(0) = 28
                BandMarkers(1) = 28.3
                BandMarkers(2) = 29.7
            Case 10 'Full sweep 1-30 MHz
                txtStartFreq.Text = "1"
                txtStopFreq.Text = "30"
                ' One marker for each band
                ReDim BandMarkers(10)
                BandMarkers(0) = 1.9
                BandMarkers(1) = 3.75
                BandMarkers(2) = 5.357
                BandMarkers(3) = 7.15
                BandMarkers(4) = 10.125
                BandMarkers(5) = 14.2
                BandMarkers(6) = 18.1
                BandMarkers(7) = 21.225
                BandMarkers(8) = 24.9
                BandMarkers(9) = 29
        End Select
        'Parameters have been changed, so set the flag so they are rewritten
        bSweepParamsChanged = True
    End Sub


    Private Sub btnConnect_Click(sender As Object, e As EventArgs) Handles btnConnect.Click
        'Connect to the Serial Port

        If cmbPort.Text = "" Then
            ' No port selected, so exit the routine
            Return
        End If
        'Set parameters for serial port
        With SerialPort1
            '.BaudRate = 57600
            .BaudRate = 115200
            .PortName = cmbPort.Text
            .DataBits = 8
            .Parity = IO.Ports.Parity.None
            .StopBits = IO.Ports.StopBits.One
            .RtsEnable = True 'Needed for Arduino Micro. PIC doesn't mind
            .DtrEnable = True 'Needed for Arduino Micro. PIC doesn't mind
        End With

        'Hide the risky serial port behaviour in a Try statement
        Try
            SerialPort1.Open()
            bSerialOpen = True
        Catch ex As Exception
            SerialPort1.Close()
            MessageBox.Show("Serial port failed to open")
            bSerialOpen = False
        End Try
        'If the port opened then send a single character to trigger the auto-sweeping version of the hardware into computer controlled mode
        '  before bombarding it with sweep data
        If SerialPort1.IsOpen Then
            'Send '.' char, which has no meaning to the sweep controller MCU, but will catch the attention.
            SerialPort1.WriteLine(".")
            'Sleep for 1 second to allow a sweep to finish
            System.Threading.Thread.Sleep(1000)
            'Now trigger a sweep
            doSweep()
        End If
    End Sub

    Private Sub PictureBox1_MouseDown(sender As Object, e As MouseEventArgs) Handles PictureBox1.MouseDown
        'The mouse has been clicked inside the graph area.
        'Determine the frequency corresponding to the mouse position and set the user marker to that frequency
        MarkerFreq = e.X * (fStop - fStart) / 500 + fStart
        txtMarkerFreq.Text = MarkerFreq.ToString
    End Sub

    Private Sub SerialPort1_DataReceived(sender As Object, e As IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        'The return data from the PIC/Arduino is handled by a DataReceived listener so the GUI can get on with its stuff
        Dim sString As String
        Dim params() As String
        Dim VSWR As Double
        Dim currentFreq As Double

        While SerialPort1.BytesToRead > 0

            'Read line of data
            Try
            sString = SerialPort1.ReadLine
        Catch ex As Exception
            SerialPort1.Close()
            bSweeping = False
            Plot_Data()
            Return
        End Try

            '        If TimeOfDay.Millisecond - TimeOutTimer > 10000 Then
            'sString = "End"
            'End If

            If sString.Contains("End") Then
                'If the line received contains 'End' then the sweep has finished
                ' Plot the data received so far
                Plot_Data()

                'Reset sweeping parameters ready for the next sweep
                bSweeping = False
                numSteps = current_index
                current_index = 0


            Else
                'Data line - extract Frequency and VSWR values and store them in the sweep arrays
                params = sString.Split(",")
                If params.Length > 1 Then
                    VSWR = Val(params(1)) / 1000
                    currentFreq = Val(params(0)) / 1000000
                    If current_index >= SweepFreqs.Length Then
                        'Expand the size of the arrays if needed
                        ReDim Preserve SweepFreqs(current_index + 1)
                        ReDim Preserve SweepSWR(current_index + 1)
                    End If
                    'Store the received data in the sweep arrays
                    SweepFreqs(current_index) = currentFreq
                    SweepSWR(current_index) = VSWR
                    'Set the index ready for the next sweep
                    current_index += 1
                End If
            End If
        End While

    End Sub
    Private Sub Plot_Data()
        'Plot the graph.
        'The chart area is set up again here. It is a dupicate of the refresh, but needs to be done here as it occurs in a different thread
        Dim g As Graphics = PictureBox1.CreateGraphics
        Dim pn As New Pen(Color.White) '~~~ color of the lines
        Dim x As Integer
        Dim y As Integer

        g.Clear(Color.White)
        pn.Color = Color.Black
        pn.DashStyle = Drawing2D.DashStyle.Dot

        x = PictureBox1.Width
        y = PictureBox1.Height

        Dim intSpacing As Integer = 50  '~~~ spacing between adjacent lines

        '~~~ Draw the horizontal lines
        x = PictureBox1.Width
        For y = 0 To PictureBox1.Height Step intSpacing
            g.DrawLine(pn, New Point(0, y), New Point(x, y))
        Next

        '~~~ Draw the vertical lines
        y = PictureBox1.Height
        intSpacing = 50
        For x = 0 To PictureBox1.Width Step intSpacing
            g.DrawLine(pn, New Point(x, 0), New Point(x, y))
        Next

        'Me.PictureBox1.Refresh()
        Dim myPen As Pen = New Pen(Color.Blue)
        myPen.Width = 5
        Dim minPointIndex As Integer
        minPoint = SweepSWR(0)
        minPointFreq = SweepFreqs(0)
        minPointIndex = 0

        Dim fAxisGain As Double
        If (fStop - fStart) < 0.000001 Then
            fAxisGain = 0.000001
        Else
            fAxisGain = 500 / (fStop - fStart)
        End If

        'Limit the number of steps to avoid index issues at run-time
        If numSteps > 101 Then
            numSteps = 101
        End If

        For i = 1 To numSteps
            'Points where VSWR < 2 are green. Other points are blue
            If SweepSWR(i) < 2 Then
                myPen.Color = Color.Green
            Else
                myPen.Color = Color.Blue
            End If

            'Draw a line between the previous and current point
            g.DrawLine(myPen, New Point((SweepFreqs(i - 1) - fStart) * fAxisGain, 550 - SweepSWR(i - 1) * 50), New Point((SweepFreqs(i) - fStart) * fAxisGain, 550 - SweepSWR(i) * 50))
            If SweepSWR(i) < minPoint Then
                'New low point found - store new values
                minPoint = SweepSWR(i)
                minPointFreq = SweepFreqs(i)
                minPointIndex = i
            End If
        Next

        'Draw a big red cross-hair on the Point of minimum VSWR
        myPen.Color = Color.Red
        myPen.Width = 2
        g.DrawLine(myPen, New Point((minPointFreq - fStart) * fAxisGain, 0), New Point((minPointFreq - fStart) * fAxisGain, 500))
        g.DrawLine(myPen, New Point(0, 550 - minPoint * 50), New Point(500, 550 - minPoint * 50))

        'Draw the band related markers in blue
        myPen.Color = Color.Blue
        For i = 0 To BandMarkers.Count - 1
            g.DrawLine(myPen, New Point((BandMarkers(i) - fStart) * fAxisGain, 0), New Point((BandMarkers(i) - fStart) * fAxisGain, 500))
        Next

        'Draw a big thick dotted line on the user marker frequency.
        ' This acts as a visual target for tuning across the room
        myPen.Color = Color.Black
        myPen.Width = 8
        myPen.DashStyle = Drawing2D.DashStyle.Dot
        g.DrawLine(myPen, New Point((MarkerFreq - fStart) * fAxisGain, 0), New Point((MarkerFreq - fStart) * fAxisGain, 500))

        bNeedsUpdate = True
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        'A 100 ms timer to do some housekeeping.
        ' Mainly to get around the threading behaviour of the serial istener
        If bNeedsUpdate = True Then
            'Update the VSWR and min frequency labels in the GUI
            lblMinPointFreq.Text = minPointFreq.ToString("F3") & "MHz"
            lblVSWR.Text = minPoint.ToString("F2") & ":1"
            bNeedsUpdate = False
        End If
        If SerialPort1.IsOpen = True Then
            'If the serial port is open then diable the connect button and enable the sweep buttons
            btnConnect.Enabled = False
            btnSweep.Enabled = True

            btnZoom.Enabled = True
        Else
            'If the serial port is not open the enable the connect button and disable the sweep buttons
            btnConnect.Enabled = True
            btnSweep.Enabled = False
            btnZoom.Enabled = False
            chkContSweep.Checked = False
        End If
    End Sub

    Private Sub btnZoom_Click(sender As Object, e As EventArgs) Handles btnZoom.Click
        'The zoom button should create a new span centred on the current low point
        ' The new span should be half of the current span, or twice the low point frequency.
        ' This avoids the span going through 0 Hz
        Dim Current_span As Double
        Dim New_span As Double
        Current_span = fStop - fStart

        New_span = Current_span / 2
        If minPointFreq < New_span / 2 Then New_span = 2 * minPointFreq


        txtStartFreq.Text = Int(100 * (minPointFreq - New_span / 2)) / 100
        txtStopFreq.Text = Int(100 * (minPointFreq + New_span / 2)) / 100

        If chkContSweep.Checked = False Then
            doSweep()
        End If
    End Sub

    Private Sub txtMarkerFreq_TextChanged(sender As Object, e As EventArgs) Handles txtMarkerFreq.TextChanged
        'If the user marker has been changed then check the frequency bounds and udate the graph
        MarkerFreq = Val(txtMarkerFreq.Text)
        If MarkerFreq > 40 Then MarkerFreq = 40
        Plot_Data()
    End Sub

    Private Sub btnSerialPortScan_Click(sender As Object, e As EventArgs) Handles btnSerialPortScan.Click
        'Scan for the serial port list and populate the combo box

        CommPorts = IO.Ports.SerialPort.GetPortNames()

        cmbPort.Items.Clear()
        For i = 0 To UBound(CommPorts)
            cmbPort.Items.Add(CommPorts(i))
        Next
        If UBound(CommPorts) > 0 Then
            cmbPort.Text = cmbPort.Items.Item(0)
        Else
            cmbPort.Text = ""
        End If
    End Sub

    Private Sub txtStopFreq_TextChanged(sender As Object, e As EventArgs) Handles txtStopFreq.TextChanged
        'The frequency in the text box has been changed, so set the flag to say that the sweep parameters need changing
        bSweepParamsChanged = True
    End Sub

    Private Sub txtNumSteps_TextChanged(sender As Object, e As EventArgs) Handles txtNumSteps.TextChanged
        'The frequency in the text box has been changed, so set the flag to say that the sweep parameters need changing
        bSweepParamsChanged = True
    End Sub

    Private Sub lblVSWR_Click(sender As Object, e As EventArgs) Handles lblVSWR.Click

    End Sub

    Private Sub btnSave_Click(sender As Object, e As EventArgs) Handles btnSave.Click
        Dim sWrite As String
        SaveFileDialog1.Filter = "CSV Files (*.csv)|*.csv"
        If SaveFileDialog1.ShowDialog = Windows.Forms.DialogResult.OK _
        Then
            Dim file As System.IO.StreamWriter
            Dim i As Integer
            file = My.Computer.FileSystem.OpenTextFileWriter(SaveFileDialog1.FileName, False)
            file.WriteLine("MHz,VSWR")
            For i = 1 To numSteps - 1
                sWrite = SweepFreqs(i).ToString + "," + SweepSWR(i).ToString
                file.WriteLine(sWrite)
            Next
            file.Close()
        End If

    End Sub

    Private Sub btnCW_Click(sender As Object, e As EventArgs) Handles btnCW.Click
        chkContSweep.Checked = False
        bSweeping = False

        'Serial Comms can be risky, so trap the function in a try
        Try
            SerialPort1.WriteLine(Int(Val(txtCWFreq.Text) * 1000000) & "C" & vbLf) 'Set start frequency
            System.Threading.Thread.Sleep(100)
            'Now sweep data has been resent, clear the flag
            bSweepParamsChanged = True
        Catch ex As TimeoutException
            MessageBox.Show("Timeout")
            SerialPort1.Close()
            bSerialOpen = False
        Catch ex As Exception
            MessageBox.Show("Failed to send config data to Sweeper Hardware")
            SerialPort1.Close()
            bSerialOpen = False
        End Try

    End Sub
End Class
