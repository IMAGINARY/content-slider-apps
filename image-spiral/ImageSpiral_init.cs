sel=1;
ss=1.6;
pendanimation=true;
images=[
[(21,1),"test1",.9/ss],
[(26,1),"test2",.7/ss],
[(21,-4.5),"test3",.8/ss],
[(26,-4.5),"test4",.7/ss],
[(21,-10),"test5",.7/ss],
[(26,-10),"test6",.5/ss]];

pause():=(
   stopanimation();
      sel=ceil(random()*6);
   if(sel>6,sel=6);
   if(sel<1,sel=1);
);

resume():=(
   if(pendanimation,playanimation());

);

reset():=(
B.homog=(4, -0.3346613, 0.39840637);
C.homog=(4, 1.22893871, 0.43593195);
D.homog=(4, 1.9, 0.179533);
E.homog=(5, 3.1, 0.2085930);
G.homog=(4, 1.8, 0.1488095);
//sel=1;
pendanimation=true;

    );
playanimation();
