if(dragging,

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

startx=xx;
starty=yy;

);

if(|(wx,wy)|>0.0,playanimation());
