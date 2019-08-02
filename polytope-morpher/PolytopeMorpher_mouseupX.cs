
if(|(wx,wy)|>0.05,
  playanimation();pendinganimation=true,
  pauseanimation();stopanimation(); pendinganimation=false
);


if(seconds()-presstime<0.2,

xx=mouse().x;
yy=mouse().y;
wy=(startx-xx)*.2;
wx=-(starty-yy)*.2;

mmmx=[
  [1,0,0],
  [0,cos(wx),sin(wx)],
  [0,-sin(wx),cos(wx)]

];


mmmy=[
  [cos(wy),0,-sin(wy)],
  [0,1,0],
  [sin(wy),0,cos(wy)]
];




mat=mmmx*mmmy*mat;
rmat=rmmmx*rmmmy*rmat;


startx=xx;
starty=yy;


pauseanimation();stopanimation();



);
