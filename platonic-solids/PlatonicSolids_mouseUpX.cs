if(|(wx,wy)|>=0.08,
  playanimation(),
  pauseanimation();stopanimation();
)
;



if(|mouse().xy,presspos|<1&seconds()-presstime<0.2,

if(|presstime-seconds()|<0.3,
xx=mouse().x;
yy=mouse().y;

if(|xx|<13,

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




//mat=mmmx*mmmy*mat;


 startx=xx;
 starty=yy;



 pauseanimation();stopanimation();

);
)
;
 if(dragging&false,

 xx=mouse().x;
 yy=mouse().y;
 wy=(startx-xx)*.3;
 wx=-(starty-yy)*.3;

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





);
