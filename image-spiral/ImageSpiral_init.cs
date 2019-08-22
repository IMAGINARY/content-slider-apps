ss = 1;
images=[
[(21,1),"test1",.9/ss],
[(26,1),"test2",.7/ss],
[(21,-4.5),"test3",.8/ss],
[(26,-4.5),"test4",.7/ss],
[(21,-10),"test5",.7/ss],
[(26,-10),"test6",.5/ss]];

resume():=(
  if(pendanimation,
    playanimation(),
    pauseanimation()
   );
);

reset():=(
  sel=ceil(random()*6);
  if(sel>6,sel=6);
  if(sel<1,sel=1);
  pendanimation=true;
  pinall = false;
);
reset();
playanimation();
