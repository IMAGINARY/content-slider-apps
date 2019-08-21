idle=1;
mousedown=0;
colrot=0;
rad0=5;
rad1=5;
rad2=7;
sel=-1;
reset():=(
rad0=5;
rad1=5;
rad2=7;
sel=-1;
A.homog=(1.485714, -4, 1.408163);
B.homog=(-1.2, 9, 1);
C.homog=(12.043333, 6.035, 1);
D.homog=(3,3,1);
E.homog=(13, -3, 1);
pendanimation=true;

);
reset();

resume():=(
   if(pendanimation,playanimation(), pauseanimation());
);

pendanimation=true;
playanimation();
