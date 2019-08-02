wx=wx*damping;
wy=wy*damping;

if(|(wx,wy)|<0.001,pauseanimation();stopanimation(););
sp=0.3;
mmmx=[
  [1,0,0],
  [0,cos(wx*sp),sin(wx*sp)],
  [0,-sin(wx*sp),cos(wx*sp)]
];

mmmy=[
  [cos(wy*sp),0,-sin(wy*sp)],
  [0,1,0],
  [sin(wy*sp),0,cos(wy*sp)]
];

mat=mmmx*mmmy*mat;
