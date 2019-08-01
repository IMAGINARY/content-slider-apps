
if(|(wx,wy)|>=0.08,
  playanimation(),
  pauseanimation();stopanimation();
)
;




if(|mouse().xy-NoEdges|<3,edges=false);
if(|mouse().xy-YesEdges|<3,edges=true);


addseq(i):=if(i!=sequenz_(-1),sequenz=sequenz++[i]);

if(|mouse().xy-C4|<3,addseq(1));
if(|mouse().xy-C6|<3,addseq(2));
if(|mouse().xy-C8|<3,addseq(3));
if(|mouse().xy-C12|<3,addseq(4));
if(|mouse().xy-C20|<3,addseq(5));


if((|mouse().xy-DelOut|<3)&(length(sequenz)>1),sequenz=apply(2..length(sequenz),sequenz_#));
if((|mouse().xy-DelIn|<3)&(length(sequenz)>1),sequenz=apply(1..length(sequenz)-1,sequenz_#));


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
