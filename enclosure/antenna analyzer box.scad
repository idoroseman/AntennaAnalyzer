w = 2.5;
dt = 1;
mistake = 1.5;


//       _________h1_____________
//      |                       | ___
//      |                      /   |
//   d1 |                     /    d2
//      |____________________/    _|_
//              h2
w1 = 93+2*w+2*dt;
h1 = 87.2+2*w+mistake;
d1 = 40+2*w;
h2 = 68+2*w+mistake;
d2 = 15+2*w-1;

difference() {
    union() {
        difference() {
            linear_extrude(w1)
                polygon([[0,0], [h2,0], [h1, d2], [h1,d1], [0,d1]]); 
            // cavity
            translate([0, 0, w]) linear_extrude(w1-2*w)
                polygon([[w,0], [h2,0], [h1, d2], [h1,d1-w], [w,d1-w]]); 
        }
        // reset guide 
        translate([ 78+w+mistake+1, d1-((7-w)/2), 48-(10/2)+w+dt-1]) 
            cube([10+2*w,7-w,10+2*w], center=true);
        // screw holders
        translate([h1-2*w,d1-w-9,20]) cube([w,9,w1-40]);
        
    }
    // window
   translate([9.5+w+mistake,d1-w, 7+w+dt])  cube([51+1,w,78+1]);
   // knob
   translate([ 78+w+mistake+0.75, d1-w, 10+w+dt-1]) rotate([-90, 0, 0]) cylinder(h=w, d=14);
   // reset
   translate([ 78+w+mistake+0.75, d1/2 /*d1-w+w/2*/, 48-(10/2)+w+dt-1]) 
      cube([10,d1,10], center=true);
   // antenna
   translate([0, 11, 16+dt]) rotate([0, 90, 0]) cylinder(h=10, d=13);
   translate([0, 0, 16-6.5+dt]) cube([w, 11, 13]);
   //screws
   translate([2+w+mistake, 0, 2.5+w+dt]) rotate([-90, 0, 0]) cylinder(h=d1, d=3, $fn=10);
   translate([2+w+mistake, 0, w1-w-2.5+dt]) rotate([-90, 0, 0]) cylinder(h=d1, d=3, $fn=10);
   translate([2+w+mistake+65, 0, 2.5+w+dt]) rotate([-90, 0, 0]) cylinder(h=d1, d=3, $fn=10);
   translate([2+w+mistake+65, 0, w1-w-2.5+dt]) rotate([-90, 0, 0]) cylinder(h=d1, d=3, $fn=10);
    
   translate([0, 2+w+mistake, 2.5+w+dt]) rotate([0, 90, 0]) cylinder(h=d1, d=3, $fn=10);
   translate([0, 2+w+mistake, w1-w-2.5+dt]) rotate([0, 90, 0]) cylinder(h=d1, d=3, $fn=10);
    
   // usb
   translate([  12+mistake, /*d1-w-37*/0, w1-w]) cube([8, 4+d1-w-37, w]);
   translate([ 39+mistake, /*d1-w-37*/0, w1-w]) cube([8, 4+d1-w-37, w]);
    // logo
 #   translate([0.5,33,50]) rotate([0,-90,0]) linear_extrude(height = 0.5) 
       text(text = "4X6UB", font = "Liberation Mono:style=Bold", size = 8);
#    translate([0.5,25,50]) rotate([0,-90,0]) linear_extrude(height = 0.5) 
       text(text = "Antenna", font = "Liberation Sans:style=Bold", size = 7);
#    translate([0.5,17,50]) rotate([0,-90,0]) linear_extrude(height = 0.5) 
       text(text = "Analyzer", font = "Liberation Sans:style=Bold", size = 7);
    // on off switch
    // tbd    
}