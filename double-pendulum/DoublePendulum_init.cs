button1=[[14+9,7],[20+9,7],[20+9,8.7],[14+9,8.7]];
button2=[[14+9,4],[20+9,4],[20+9,5.7],[14+9,5.7]];
pressed1=true;
pressed2=true;

oldb=B.xy;
oldc=C.xy;

playanimation();

n=300;
lastsimulationtime = 0;

reset():=(
lastsimulationtime = 0;
stopanimation();
A.homog=(4, -2.40740, 0.462962);
B.homog=(8, 4, 1);
C.homog=(9, 7, 1);
F.homog=(3.4, -4, -0.5);
G.homog=(4, -2.1882352, -0.588235);
l=[];
pressed1=true;
pressed2=true;
playanimation();

    );

pause():=(
  pauseanimation();
  l = [];
);
resume():=(
  if(pressed1, lastsimulationtime = 0; l=[]; playanimation(););
);
