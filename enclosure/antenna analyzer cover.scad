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
w2 = w1 - 2*w;
h1 = 87.2+2*w+mistake;
d1 = 40+2*w;
h2 = 68+2*w+mistake;
d2 = 15+2*w-1;


dh =h1-h2;
alpha = atan(d2/dh);
l = sqrt(d2*d2+dh*dh);
difference()
{
    union()
    {
        cube([h2-w, w2, w]);
        translate([h2-w, 0, 0]) rotate([0, -alpha, 0]) 
        {
            cube([l,w2,w]);
            translate([l/2, w2/2, w+1]) rotate([0, 0, -90]) scale([ 1/2, 1/2, 1/128]) 
                #surface(file = "sig_bw.png", invert=true, center=true, convexity = 5);
        }
        translate([h1-2*w, 0, d2]) cube([w, w2, d1-d2-w]);
    }
        
     for (i=[35, w2-35])
         translate([h1-2*w, i, d2+7])
            rotate([0, 90, 0])  cylinder(h=w, d=3);
}   

// screws
for (i=[0, w2-7])
    translate([0, i, 0,])
        difference() 
        {
          cube([w, 7, 9]);
          translate([0, 3.5, 5.5]) rotate([0, 90, 0])  cylinder(h=w, d=3);
        }

//antenna
difference(){
    translate([-w, w2-(16-3+dt+(13/2)), 0]) cube([w, 13, 11]);        
    translate([-w, w2-(16-3+dt), 11]) rotate([0, 90, 0]) cylinder(h=w, d= 13);  
}    

// usb
translate([12+mistake-w, -w, 0]) cube([8, w, d1-w-37+4]);
translate([39+mistake-w, -w, 0]) cube([8, w, d1-w-37]);


