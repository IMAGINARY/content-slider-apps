  idle=0;
  mousedown=1;
// pauseanimation();
pendanimation=false;
sel=-1;
diffr=0;

mou=mouse().xy;
sel=-1;
if(abs(|A,mou|-rad0)<1,sel=0;diffr=(|A,mou|-rad0));
if(abs(|B,mou|-rad1)<1,sel=1;diffr=(|B,mou|-rad1));
if(abs(|C,mou|-rad2)<1,sel=2;diffr=(|C,mou|-rad2));
