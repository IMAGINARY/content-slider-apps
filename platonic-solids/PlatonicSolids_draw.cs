
//fillpoly(((-100,-100),(-14,-100),(-14,100),(-100,100)),color->(1,1,1)*.2);
//fillpoly(((100,-100),(14,-100),(14,100),(100,100)),color->(1,1,1)*.2);
//clrscr();
Dummy.xy=(0,0);
if(S.x>=R.x,S.xy=R.xy);
if(S.x<=Q.x,S.xy=Q.xy);


last=sequenz_(-1);

if(sequenz!=oldsequenz,
  processseq(sequenz);
);
oldsequenz=sequenz;


par7=|R,S|/|R,Q|;
dist=1/((1-par7)+0.01)*35;


col1=[0,0,1];
col2=[.1,1,0]*0;
col3=[1,0,1]*0;
actcol=(1,1,1);


col1=[.9,.9,1]*.5;
col2=[1,.9,.9]*.5;
col3=[1,1,1]*0;
actcol=(.5,.8,1);


amb=0.2;

lights=[
   [[-cos(30°),-sin(30°),-.5],col1],
   [[-cos(150°),-sin(150°),-.5],col2],
   [[-cos(270°),-sin(270°),-.5],col3]
];
ambient=(1,1,1)*amb;



fd(d,z):=if(d<200,(d/(d+z)),1)*.8;

render3d();
highlight(a):=(
repeat(10,i,
  fillcircle(a,-i*.1+1.9,alpha->i/10,color->(0.6,0.6,.9)*.6);
 );
);








repeat(0,i,
d=i/25;
l=i/20;
fillpoly((
(12.5+d,-13+d),
 (19.5-d,-13+d),
 (19.5-d,11-d),
 (12.5+d,11-d)),color->l*(1,1,1.5)*.2+(1-l)*(0,0,0)

);
);

repeat(0,i,
d=i/25;
l=i/20;
fillpoly((
 (-12.5-d,-13+d),
 (-19.5+d,-13+d),
 (-19.5+d,11-d),
 (-12.5-d,11-d)),color->l*(1,1,1.5)*.2+(1-l)*(0,0,0)
);

);

drawtext(Q+(-.7,6.6),international("REMOVE_OUTER"),size->30,color->(1,1,1));
drawtext(Q+(-.7,1.9),international("REMOVE_INNER"),size->30,color->(1,1,1));
drawtext(Q+(-.7,-.9),international("PERSPECTIVE"),size->30,color->(1,1,1));

highlight(but):= connect(
    (
      off+but+(1,1)*w,
      off+but+(-1,1)*w,
      off+but+(-1,-1)*w,
      off+but+(1,-1)*w,
      off+but+(1,1)*w
  ),color->(1,1,1)
);

dehighlight(but):= fillpoly(
    (
      off+but+(1,1)*w,
      off+but+(-1,1)*w,
      off+but+(-1,-1)*w,
      off+but+(1,-1)*w,
      off+but+(1,1)*w
  ),color->(1,1,1.5)*.0,alpha->0.7

);


//clrscr();






off=(0,0.05);
w=2.1;
if(edges,highlight(YesEdges),highlight(NoEdges));



drawimage(C4.xy,"image11",scale->2.5);
drawimage(C6.xy,"image12",scale->2.5);
drawimage(C8.xy,"image13",scale->2.5);
drawimage(C12.xy,"image14",scale->2.5);
drawimage(C20.xy,"image15",scale->2.5);
drawimage(DelIn.xy,"image17",scale->2.5);
drawimage(DelOut.xy,"image16",scale->2.5);

drawimage(NoEdges.xy,"image19",scale->2.5);
drawimage(YesEdges.xy,"image20",scale->2.5);



if(sequenz_(-1)==1,dehighlight(C4));
if(sequenz_(-1)==2,dehighlight(C6));
if(sequenz_(-1)==3,dehighlight(C8));
if(sequenz_(-1)==4,dehighlight(C12));
if(sequenz_(-1)==5,dehighlight(C20));

if(length(sequenz)==1,dehighlight(DelOut);dehighlight(DelIn));


















;
