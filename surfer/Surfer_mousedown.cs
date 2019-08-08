playanimation();

sx = mouse().x;
sy = mouse().y;
dragging = sx < .5 & sx > -.5 ;
br = 0.1;
if(|mouse().xy,poss_1|<br,
      sel=1;
   setzoom(0.7);
   seta(1);
   fun(x,y,z) := (x^2+y^2+a*z^2-1);
   init();
);
if(|mouse().xy,poss_2|<br,
       setzoom(.6);
   sel=2;
   seta(1);
   fun(x,y,z) := (x^2+a*y^2-1);
   init();
);
if(|mouse().xy,poss_3|<br,
   sel=3;
   setzoom(.9);
   seta(0);
   fun(x,y,z) := (x^2+z^2-1/3*(1+y)^3*(1-y)^3+a);
   init();
);

if(|mouse().xy,poss_4|<br,
   sel=4;
   setzoom(0.7);
   seta(1);
   fun(x,y,z) := ((x^2+y^2+z^2-(0.5+a)^2)^2-(3*((0.5+a)^2)-1)/(3-((0.5+a)^2))*(1-z-sqrt(2)*x)*(1-z+sqrt(2)*x)*(1+z+sqrt(2)*y)*(1+z-sqrt(2)*y));
   init();
);
if(|mouse().xy,poss_5|<br,
       setzoom(.6);
   sel=5;
   seta(1);
   fun(x,y,z) := (4*((a*(1+sqrt(5))/2)^2*x^2-y^2)*((a*(1+sqrt(5))/2)^2*y^2-z^2)*((a*(1+sqrt(5))/2)^2*z^2-x^2)-1*(1+2*(a*(1+sqrt(5))/2))*(x^2+y^2+z^2-a^2)^2);
   init();
);
if(|mouse().xy,poss_6|<br,
    sel=6;
   setzoom(.6);

   seta(0);
   fun(x,y,z) := (-2*a/125+x^8+y^8+z^8-2*x^6-2*y^6-2*z^6+1.25*x^4+1.25*y^4+1.25*z^4-0.25*x^2-0.25*y^2-0.25*z^2+0.03125);
   init();
);
if(|mouse().xy,poss_7|<br,
    sel=7;

   seta(1);
   setzoom(0.3);
   fun(x,y,z) := (a*(-1/4*(1-sqrt(2))*(x^2+y^2)^2+(x^2+y^2)*((1-1/sqrt(2))*z^2+1/8*(2-7*sqrt(2)))-z^4+(0.5+sqrt(2))*z^2-1/16*(1-12*sqrt(2)))^2-(cos(0*pi/4)*x+sin(0*pi/4)*y-1)*(cos(pi/4)*x+sin(pi/4)*y-1)*(cos(2*pi/4)*x+sin(2*pi/4)*y-1)*(cos(3*pi/4)*x+sin(3*pi/4)*y-1)*(cos(4*pi/4)*x+sin(4*pi/4)*y-1)*(cos(5*pi/4)*x+sin(5*pi/4)*y-1)*(cos(6*pi/4)*x+sin(6*pi/4)*y-1)*(cos(7*pi/4)*x+sin(7*pi/4)*y-1));
   init();
);
if(|mouse().xy,poss_8|<br,
    sel=8;

   setzoom(0.5);
   seta(0);
   fun(x,y,z) := (a+x^3+x^2*z^2-y^2);
   init();
);
if(|mouse().xy,poss_9|<br,
    sel=9;

   setzoom(.1);
   seta(.5);
   seta(0);

   fun(x,y,z) := (a+x^5-1*1*10*x^3*y^2+5*x*y^4-1*1*3*z^5-1*1*5*x^4-1*1*10*x^2*y^2-1*1*5*y^4+10*z^3+20*x^2+20*y^2-1*1*15*z-1*1*24);
   init();
);
