use8bittextures();//accellerate CindyGL
  offset = (0,0);
lastoffset = (0,0);
shiftedmouse() := (
mouse().xy-offset;
);
//createimage("WEBGL",1170,1170);
//use("WebGLExperiments");
//WebGLvariables(posa->"point",posb->"point",str->"point");
dragging=false;
setstr(x,y):=(
str=(x,y);
strx=(x,0);
stry=(0,y);
);
setstr(1,1);
//WebGLcode();

createimage("pen",300,300);

ncols=15;

precols=[
hue(0),
hue(0.12),
hue(0.16),
hue(0.33),

hue(0.5),
hue(0.56),
hue(0.65),
hue(0.75),

hue(0.85),
hue(0.92),

(1,1,1),
(1,1,1)*.75,

(1,1,1)*.5,
(1,1,1)*.25,
(0,0,0)

];
pp(v):=(v.y,-v.x);


draggingActionInLoop(st,en):=(

n=round(|en-st|*200)+1;
apply(1..(n),l=#/n;
 drawpt(l*st+(1-l)*en);
)
);



draggingAction(st,en):=(



if(dragging,
sc2=|D-F|;
canvas(A,B,C,"tile",
 n=round(|en-st|*200)+1;
 apply(1..(n),l=#/n;
   drawpt(l*st+(1-l)*en);

 )
 );
);
);

setcols(sat,dark):=(
cols=precols;
repeat(10,
 cols_#=(cols_#*sat+(1-sat)*(1,1,1))*dark;
);
);

pencolor=1;

groups=["p1","p2","pm","pg","cm","pmm","pmg","pgg","cmm","p4","p4m","p4g","p3","p3m1","p31m","p6","p6m"];

strokelist=[];
buttons=["fund","sym","glow","undo","redo","trash"];

group=12;


res=1000;



stroke=[];
frac(x):=x-floor(x);

drawsinglept(p):=(
p=(frac(p.x/str.x)*str.x,frac(p.y/str.y)*str.y);

//  p=(frac(p.x),frac(p.y));
sisc=size*.25;
drawsinglept2(p);
if(p.x<sisc, drawsinglept2(p+strx));
if(p.y<sisc, drawsinglept2(p+stry));
if(1-p.x<sisc, drawsinglept2(p-strx));
if(1-p.y<sisc, drawsinglept2(p-stry));
if(p.x<sisc & p.y<sisc, drawsinglept2(p+strx+stry));
if(1-p.x<sisc & p.y<sisc,drawsinglept2(p-strx+stry));
if(p.x<sisc & 1-p.y<sisc, drawsinglept2(p+strx-stry));
if(1-p.x<sisc & 1-p.y<sisc, drawsinglept2(p-strx-stry));
);


setdot():=(
        sc1=|A-B|;
        sc2=|D-F|;
        sc=sc1*.4;

clearimage("pen");
canvas((-1,-1),(1,-1),"pen",
  apply(-10..10,
    fillcircle((0,0),(.06+#*0.005*blur)*sc,color->color,alpha->.01+(1-blur)*.07);
  )
);
setglow();
if(color==(0,0,0),setglow(false);)
);

setdot2():=(
size=|X,Z|/|X,Y|;
        sc1=|A-B|;
        sc2=|D-F|;
        sc=sc1/sc2*(size*1+.1)*.5;

clearimage("pen");
canvas((-1,-1),(1,-1),"pen",
      fillcircle((0,0),.1*sc,color->cols_pencolor,alpha->1);
)
);



setdot();

drawsinglept2(p):=(
p=p*sc1+A.xy;
sc=sc1*(size*1+.1)*.025;

drawimage(p,"pen",alpha->alpha,scale->sc);
);

m1=((0,1),(-1,0));
m2=((-1,0),(0,-1));
m3=((0,-1),(1,0));
m4=((0,1),(1,0));
m5=((-1,0),(0,1));
m6=((1,0),(0,-1));
m7=((0,-1),(-1,0));
mid=(0.5,0.5);
midy=(0,0.5);
midx=(0.5,0);

mr6=((cos(60°),sin(60°)),(-sin(60°),cos(60°)));

mr31=((cos(120°),sin(120°)),(-sin(120°),cos(120°)));
mr32=mr31*mr31;


setgr(name):=(
tiletype="sq";

if(name=="p1",
gr():=(
  drawsinglept(p);
);
setstr(1,1);
);

if(name=="p2",
gr():=(
  drawsinglept(p);
  drawsinglept(m2*(p-mid)+mid);
);
setstr(1,1);
);

if(name=="pm",
gr():=(
  drawsinglept(p);
  drawsinglept(m5*(p-mid)+mid);
);
setstr(1,1);
);

if(name=="pg",
gr():=(
  drawsinglept(p);
  drawsinglept(m5*(p-mid)+midx);
);
setstr(1,1);
);


if(name=="cm",
gr():=(
  drawsinglept(p);
  drawsinglept(m4*(p-mid)+mid);
);
setstr(1,1);
);

if(name=="pmm",
gr():=(
  drawsinglept(p);
  drawsinglept(m2*(p-mid)+mid);
  drawsinglept(m5*(p-mid)+mid);
  drawsinglept(m6*(p-mid)+mid);
);
setstr(1,1);
);

if(name=="pmg",
gr():=(
  drawsinglept(p);
  drawsinglept(m2*(p-mid)+mid+midx);
  drawsinglept(m5*(p-mid)+mid);
  drawsinglept(m6*(p-mid)+mid+midx);
);
setstr(1,1);
);

if(name=="pgg",
gr():=(
  drawsinglept(p);
  drawsinglept(m2*(p-mid)+mid+midx+midy);
  drawsinglept(m5*(p-mid)+mid+midy);
  drawsinglept(m6*(p-mid)+mid+midx);
);
setstr(1,1);
);

if(name=="cmm",
gr():=(
  drawsinglept(p);
  drawsinglept(m2*(p-mid)+mid);
  drawsinglept(m4*(p-mid)+mid);
  drawsinglept(m7*(p-mid)+mid);
);
setstr(1,1);
);

if(name=="p4",
gr():=(
  drawsinglept(p);
  drawsinglept(m1*(p-mid)+mid);
  drawsinglept(m2*(p-mid)+mid);
  drawsinglept(m3*(p-mid)+mid);
);
setstr(1,1);
);



if(name=="p4m",

gr():=(
  drawsinglept(p);
  drawsinglept(m1*(p-mid)+mid);
  drawsinglept(m2*(p-mid)+mid);
  drawsinglept(m3*(p-mid)+mid);
  drawsinglept(m4*(p-mid)+mid);
  drawsinglept(m5*(p-mid)+mid);
  drawsinglept(m6*(p-mid)+mid);
  drawsinglept(m7*(p-mid)+mid);
);
setstr(1,1);
);

if(name=="p4g",

gr():=(
  drawsinglept(p);
  drawsinglept(m2*(p-mid)+mid);
  drawsinglept(m4*(p-mid)+mid);
  drawsinglept(m7*(p-mid)+mid);

  drawsinglept(m1*(p-mid));
  drawsinglept(m3*(p-mid));
  drawsinglept(m5*(p-mid));
  drawsinglept(m6*(p-mid));


);
setstr(1,1);
);

if(name=="p3",
tiletype="r60";

gr():=(
  drawsinglept(p);
  drawsinglept(mr31*p);
  drawsinglept(mr32*p);
  drawsinglept(p+str/2);
  drawsinglept(mr31*p+str/2);
  drawsinglept(mr32*p+str/2);

);
setstr(1,2*sqrt(3/4));
);

if(name=="p3m1",
tiletype="r60";

gr():=(
  drawsinglept(p);
  drawsinglept(mr31*p);
  drawsinglept(mr32*p);
  drawsinglept(p+str/2);
  drawsinglept(mr31*p+str/2);
  drawsinglept(mr32*p+str/2);
  drawsinglept(m5*p);
  drawsinglept(mr31*m5*p);
  drawsinglept(mr32*m5*p);
  drawsinglept(m5*p+str/2);
  drawsinglept(mr31*m5*p+str/2);
  drawsinglept(mr32*m5*p+str/2);

);
setstr(1,2*sqrt(3/4));
);

if(name=="p31m",
tiletype="r60";

gr():=(
  drawsinglept(p);
  drawsinglept(mr31*p);
  drawsinglept(mr32*p);
  drawsinglept(p+str/2);
  drawsinglept(mr31*p+str/2);
  drawsinglept(mr32*p+str/2);
  q=(m6*(p-strx/6)+strx/6);
  drawsinglept(q);
  drawsinglept(mr31*q);
  drawsinglept(mr32*q);
  drawsinglept(q+str/2);
  drawsinglept(mr31*q+str/2);
  drawsinglept(mr32*q+str/2);

);
setstr(1,2*sqrt(3/4));
);

if(name=="p6m",
tiletype="r60";

gr():=(
  drawsinglept(p);
  drawsinglept(mr31*p);
  drawsinglept(mr32*p);
  drawsinglept(p+str/2);
  drawsinglept(mr31*p+str/2);
  drawsinglept(mr32*p+str/2);
  q=mr6*p;
  drawsinglept(q);
  drawsinglept(mr31*q);
  drawsinglept(mr32*q);
  drawsinglept(q+str/2);
  drawsinglept(mr31*q+str/2);
  drawsinglept(mr32*q+str/2);

  p=m5*p;

  drawsinglept(p);
  drawsinglept(mr31*p);
  drawsinglept(mr32*p);
  drawsinglept(p+str/2);
  drawsinglept(mr31*p+str/2);
  drawsinglept(mr32*p+str/2);
  q=mr6*p;
  drawsinglept(q);
  drawsinglept(mr31*q);
  drawsinglept(mr32*q);
  drawsinglept(q+str/2);
  drawsinglept(mr31*q+str/2);
  drawsinglept(mr32*q+str/2);

);
setstr(1,2*sqrt(3/4));
);


if(name=="p6",
tiletype="r60";

gr():=(
  drawsinglept(p);
  drawsinglept(mr31*p);
  drawsinglept(mr32*p);
  drawsinglept(p+str/2);
  drawsinglept(mr31*p+str/2);
  drawsinglept(mr32*p+str/2);
  q=mr6*p;
  drawsinglept(q);
  drawsinglept(mr31*q);
  drawsinglept(mr32*q);
  drawsinglept(q+str/2);
  drawsinglept(mr31*q+str/2);
  drawsinglept(mr32*q+str/2);

);
setstr(1,2*sqrt(3/4));
);

C.xy=A-pp(B-A)*str_2;



);


setgr("p4g");

drawpt(p):=(
//  p=bas*(p-cell_1);
//  p=(p.x-floor(p.x),p.y-floor(p.y));
gr();
);

predrawing():=(

        sc1=|A-B|;
        sc2=|D-F|;
        FF=D+(0,|D-F|);

        EE=D+(|D-F|,0);
        tr=map(D.xy,F.xy,D.xy,FF);
        tri=inverse(tr);
        sc=sc1/sc2*(size*2+.2);

        shi=0.004;
        shi=0.0;

);

anpol2(p,n,w,col):=(
ww=360°/(2*n);
drawpoly(apply(0..2*n,p+(cos(#*ww+w),sin(#*ww+w))*.05*if(or(#==1,#==3),.7,1.4)),size->1.4*.5,color->(0,0,0));
drawpoly(apply(0..2*n,p+(cos(#*ww+w),sin(#*ww+w))*.05*if(or(#==1,#==3),.7,1.4)),size->.5,color->col);

);


anpol(p,n,w,col):=(
ww=360°/n;
w=w+45°;
drawpoly(apply(0..n,p+(cos(#*ww+w),sin(#*ww+w))*.05),size->1.4*.5,color->(0,0,0));

drawpoly(apply(0..n,p+(cos(#*ww+w),sin(#*ww+w))*.05),size->.5,color->col);

);

adashed(p1,p2,col,n):=(
d=1/n;
apply(0..n,l=#*d;
fillcircle(p1*l+p2*(1-l),.012,color->(0,0,0));
fillcircle(p1*l+p2*(1-l),.008,color->col)
);
);

afull(p1,p2,col):=(
draw(p1,p2,color->(0,0,0),size->.5*.5);
draw(p1,p2,color->col,size->.3*.5)
);

acolb1=(.6,0.6,1);
acolb2=(.3,0.3,1);

acolr1=(1,.6,0.6);
acolr2=(1,.3,0.3);

acolg1=(.6,1,0.6);
acolg2=(.3,1,0.3);

acolge1=(1,.8,0.2);
acolge2=(1,.8,0);
acoltu2=(0.7,1,1);

acolw1=(.8,.8,.8);


annotp1():=();
annotp2():=(
anpol2((0,0),2,45°,acolb1);
anpol2((0,1),2,45°,acolb1);
anpol2((1,0),2,45°,acolb1);
anpol2((1,1),2,45°,acolb1);
anpol2((.5,.5),2,45°,acolr1);
anpol2((0,.5),2,45°,acolg1);
anpol2((1,.5),2,45°,acolg1);
anpol2((.5,0),2,45°,acolge1);
anpol2((.5,1),2,45°,acolge1);

);
annotpm():=(
afull((0,0),(0,1),acolb2);
afull((1,0),(1,1),acolb2);
afull((.5,0),(.5,1),acolr2);

);
annotpg():=(
adashed((0,0),(0,1),acolb2,20);
adashed((1,0),(1,1),acolb2,20);
adashed((.5,0),(.5,1),acolr2,20);

);
annotcm():=(
afull((0,0),(1,1),acolb2);
adashed((.5,0),(1,.5),acolr2,10);
adashed((.5,1),(0,.5),acolr2,10);

);
annotpmm():=(
afull((0,1),(1,1),acolb2);
afull((0,0),(1,0),acolb2);
afull((0,.5),(1,.5),acolg2);
afull((.5,0),(.5,1),acolge2);
afull((1,0),(1,1),acolr2);
afull((0,0),(0,1),acolr2);
anpol2((.5,.5),2,0°,acolw1);
anpol2((0,.5),2,0°,acolw1);
anpol2((1,.5),2,0°,acolw1);
anpol2((.5,0),2,0°,acolw1);
anpol2((.5,1),2,0°,acolw1);
anpol2((0,0),2,0°,acolw1);
anpol2((1,0),2,0°,acolw1);
anpol2((0,1),2,0°,acolw1);
anpol2((1,1),2,0°,acolw1);

);
annotcmm():=(
afull((0,0),(1,1),acolr2);
afull((1,0),(0,1),acolg2);
adashed((.5,0),(1,.5),acolb2,13);
adashed((.5,1),(0,.5),acolb2,13);
adashed((1,.5),(.5,1),acolge2,13);
adashed((0,.5),(.5,0),acolge2,13);
anpol2((.5,.5),2,45°,acolg1);
anpol2((0,0),2,45°,acolb1);
anpol2((1,0),2,45°,acolb1);
anpol2((0,1),2,45°,acolb1);
anpol2((1,1),2,45°,acolb1);
anpol2((.5,1),2,45°,acolr1);
anpol2((.5,0),2,45°,acolr1);
anpol2((1,.5),2,45°,acolr1);
anpol2((0,.5),2,45°,acolr1);

);
annotpmg():=(
afull((0,0),(0,1),acolr2);
afull((1,0),(1,1),acolr2);
afull((.5,0),(.5,1),acolr2);
adashed((0,0),(1,0),acolg2,20);
adashed((0,1),(1,1),acolg2,20);
adashed((0,.5),(1,.5),acolb2,20);
anpol2((.25,0),2,90°,acoltu2);
anpol2((.25,1),2,90°,acoltu2);
anpol2((.75,0),2,90°,acoltu2);
anpol2((.75,1),2,90°,acoltu2);
anpol2((.25,.5),2,90°,acolge1);
anpol2((.75,.5),2,90°,acolge1);


);
annotpgg():=(
adashed((0,0),(1,0),acolg2,20);
adashed((0,1),(1,1),acolg2,20);
adashed((0,.5),(1,.5),acolg2,20);
adashed((0,0),(0,1),acolb2,20);
adashed((1,0),(1,1),acolb2,20);
adashed((.5,0),(.5,1),acolb2,20);
anpol2((.25,.25),2,90°,acolge1);
anpol2((.75,.75),2,90°,acolge1);
anpol2((.25,.75),2,90°,acolr1);
anpol2((.75,.25),2,90°,acolr1);

);
annotp4():=(
anpol((0,0),4,45°,acolr1);
anpol((1,0),4,45°,acolr1);
anpol((0,1),4,45°,acolr1);
anpol((1,1),4,45°,acolr1);
anpol((.5,.5),4,45°,acolb1);
anpol2((1,.5),2,0°,acolge1);
anpol2((0,.5),2,0°,acolge1);
anpol2((.5,1),2,90°,acolge1);
anpol2((.5,0),2,90°,acolge1);

);
annotp4m():=(

afull((0,0),(0,1),acolr2);
afull((1,0),(1,1),acolr2);
afull((0,0),(1,0),acolr2);
afull((0,1),(1,1),acolr2);
afull((.5,0),(.5,1),acolb2);
afull((0,.5),(1,.5),acolb2);

afull((0,0),(1,1),acolge2);
afull((0,1),(1,0),acolge2);

adashed((.5,0),(1,.5),acolg2,13);
adashed((.5,1),(1,.5),acolg2,13);
adashed((.5,1),(0,.5),acolg2,13);
adashed((.5,0),(0,.5),acolg2,13);


anpol((0,0),4,45°,acolr1);
anpol((1,0),4,45°,acolr1);
anpol((0,1),4,45°,acolr1);
anpol((1,1),4,45°,acolr1);
anpol((.5,.5),4,45°,acolb1);
anpol2((1,.5),2,0°,acolge1);
anpol2((0,.5),2,0°,acolge1);
anpol2((.5,1),2,90°,acolge1);
anpol2((.5,0),2,90°,acolge1);
);
annotp4g():=(
afull((0,0),(1,1),acolb2);
afull((0,1),(1,0),acolb2);
adashed((.5,1),(.5,0),acolr2,20);
adashed((1,.5),(0,.5),acolr2,20);
adashed((.5,0),(0,.5),acolg2,13);
adashed((.5,1),(0,.5),acolg2,13);
adashed((.5,1),(1,.5),acolg2,13);
adashed((.5,0),(1,.5),acolg2,13);

anpol((0,.5),4,45°,acolr1);
anpol((1,.5),4,45°,acolr1);
anpol((.5,0),4,45°,acolr1);
anpol((.5,1),4,45°,acolr1);
anpol2((0,0),2,45°,acolb1);
anpol2((0,1),2,45°,acolb1);
anpol2((1,0),2,45°,acolb1);
anpol2((1,1),2,45°,acolb1);
anpol2((.5,.5),2,90°+45°,acolb1);
);
annotp3():=(
tt=sqrt(3/4);
anpol((0,0),3,45°,acolr1);
anpol((1,0),3,45°,acolr1);
anpol((0,tt*2),3,45°,acolr1);
anpol((1,tt*2),3,45°,acolr1);
anpol((.5,tt),3,45°,acolr1);
anpol((0,tt*2/3),3,45°,acolg1);
anpol((1,tt*2/3),3,45°,acolg1);
anpol((.5,tt*5/3),3,45°,acolg1);
anpol((0.5,tt*1/3),3,45°,acolb1);
anpol((0,tt*4/3),3,45°,acolb1);
anpol((1,tt*4/3),3,45°,acolb1);


);
annotp3m1():=(
tt=sqrt(3/4);

afull((0,0),(0,2*tt),acolge2);
afull((1,0),(1,2*tt),acolge2);
afull((.5,0),(.5,2*tt),acolge2);
afull((0,0),(1,2/3*tt),acolge2);
afull((0,2/3*tt),(1,4/3*tt),acolge2);
afull((0,4/3*tt),(1,2*tt),acolge2);
afull((1,0),(0,2/3*tt),acolge2);
afull((1,2/3*tt),(0,4/3*tt),acolge2);
afull((1,4/3*tt),(0,2*tt),acolge2);

adashed((1/4,0),(1/4,2*tt),acolb2,30);
adashed((3/4,0),(3/4,2*tt),acolb2,30);
adashed((.5,0),(1,1/3*tt),acolb2,10);
adashed((.5,0),(0,1/3*tt),acolb2,10);
adashed((0,1/3*tt),(1,3/3*tt),acolb2,20);
adashed((1,1/3*tt),(0,3/3*tt),acolb2,20);
adashed((0,5/3*tt),(1,3/3*tt),acolb2,20);
adashed((1,5/3*tt),(0,3/3*tt),acolb2,20);
adashed((0,5/3*tt),(1,7/3*tt),acolb2,20);
adashed((1,5/3*tt),(0,7/3*tt),acolb2,20);


anpol((0,0),3,45°,acolr1);
anpol((1,0),3,45°,acolr1);
anpol((0,tt*2),3,45°,acolr1);
anpol((1,tt*2),3,45°,acolr1);
anpol((.5,tt),3,45°,acolr1);
anpol((0,tt*2/3),3,45°,acolg1);
anpol((1,tt*2/3),3,45°,acolg1);
anpol((.5,tt*5/3),3,45°,acolg1);
anpol((0.5,tt*1/3),3,45°,acolb1);
anpol((0,tt*4/3),3,45°,acolb1);
anpol((1,tt*4/3),3,45°,acolb1);


);
annotp31m():=(
tt=sqrt(3/4);
afull((0,0),(1,0),acolge2);
afull((0,2*tt),(1,2*tt),acolge2);
afull((0,tt),(1,tt),acolge2);
afull((0,0),(1,2*tt),acolge2);
afull((1,0),(0,2*tt),acolge2);
adashed((0,1/2*tt),(1,1/2*tt),acolb2,20);
adashed((0,3/2*tt),(1,3/2*tt),acolb2,20);
adashed((0.5,0),(0,tt),acolb2,20);
adashed((0.5,0),(1,tt),acolb2,20);
adashed((0.5,2*tt),(0,tt),acolb2,20);
adashed((0.5,2*tt),(1,tt),acolb2,20);


anpol((0,0),3,45°,acolr1);
anpol((1,0),3,45°,acolr1);
anpol((0,tt*2),3,45°,acolr1);
anpol((1,tt*2),3,45°,acolr1);
anpol((.5,tt),3,45°,acolr1);
anpol((0,tt*2/3),3,45°+180°,acolb1);
anpol((1,tt*2/3),3,45°+180°,acolb1);
anpol((.5,tt*5/3),3,45°+180°,acolb1);
anpol((0.5,tt*1/3),3,45°,acolb1);
anpol((0,tt*4/3),3,45°,acolb1);
anpol((1,tt*4/3),3,45°,acolb1);


);
annotp6():=(
tt=sqrt(3/4);
anpol((0,0),6,45°,acolr1);
anpol((1,0),6,45°,acolr1);
anpol((0,tt*2),6,45°,acolr1);
anpol((1,tt*2),6,45°,acolr1);
anpol((.5,tt),6,45°,acolr1);
anpol((0,tt*2/3),3,45°,acolb1);
anpol((1,tt*2/3),3,45°,acolb1);
anpol((.5,tt*5/3),3,45°,acolb1);
anpol((0.5,tt*1/3),3,45°,acolb1);
anpol((0,tt*4/3),3,45°,acolb1);
anpol((1,tt*4/3),3,45°,acolb1);

anpol2((0,tt),2,0°,acolg1);
anpol2((1,tt),2,0°,acolg1);
anpol2((.5,2*tt),2,0°,acolg1);
anpol2((.5,0),2,0°,acolg1);
anpol2((.25,tt/2),2,-120°,acolg1);
anpol2((.75,tt/2),2,120°,acolg1);
anpol2((.25,3*tt/2),2,120°,acolg1);
anpol2((.75,3*tt/2),2,-120°,acolg1);


);
annotp6m():=(

tt=sqrt(3/4);

afull((0,0),(0,2*tt),acolge2);
afull((1,0),(1,2*tt),acolge2);
afull((.5,0),(.5,2*tt),acolge2);
afull((0,0),(1,2/3*tt),acolge2);
afull((0,2/3*tt),(1,4/3*tt),acolge2);
afull((0,4/3*tt),(1,2*tt),acolge2);
afull((1,0),(0,2/3*tt),acolge2);
afull((1,2/3*tt),(0,4/3*tt),acolge2);
afull((1,4/3*tt),(0,2*tt),acolge2);

afull((0,0),(1,0),acolr2);
afull((0,2*tt),(1,2*tt),acolr2);
afull((0,tt),(1,tt),acolr2);
afull((0,0),(1,2*tt),acolr2);
afull((1,0),(0,2*tt),acolr2);

adashed((1/4,0),(1/4,2*tt),acolb2,30);
adashed((3/4,0),(3/4,2*tt),acolb2,30);
adashed((.5,0),(1,1/3*tt),acolb2,10);
adashed((.5,0),(0,1/3*tt),acolb2,10);
adashed((0,1/3*tt),(1,3/3*tt),acolb2,20);
adashed((1,1/3*tt),(0,3/3*tt),acolb2,20);
adashed((0,5/3*tt),(1,3/3*tt),acolb2,20);
adashed((1,5/3*tt),(0,3/3*tt),acolb2,20);
adashed((0,5/3*tt),(1,7/3*tt),acolb2,20);
adashed((1,5/3*tt),(0,7/3*tt),acolb2,20);

adashed((0,1/2*tt),(1,1/2*tt),acolg2,20);
adashed((0,3/2*tt),(1,3/2*tt),acolg2,20);
adashed((.5,0),(1,tt),acolg2,20);
adashed((.5,0),(0,tt),acolg2,20);
adashed((.5,2*tt),(1,tt),acolg2,20);
adashed((.5,2*tt),(0,tt),acolg2,20);



anpol((0,0),6,45°,acolr1);
anpol((1,0),6,45°,acolr1);
anpol((0,tt*2),6,45°,acolr1);
anpol((1,tt*2),6,45°,acolr1);
anpol((.5,tt),6,45°,acolr1);
anpol((0,tt*2/3),3,45°,acolb1);
anpol((1,tt*2/3),3,45°,acolb1);
anpol((.5,tt*5/3),3,45°,acolb1);
anpol((0.5,tt*1/3),3,45°,acolb1);
anpol((0,tt*4/3),3,45°,acolb1);
anpol((1,tt*4/3),3,45°,acolb1);

anpol2((0,tt),2,0°,acolg1);
anpol2((1,tt),2,0°,acolg1);
anpol2((.5,2*tt),2,0°,acolg1);
anpol2((.5,0),2,0°,acolg1);
anpol2((.25,tt/2),2,-120°,acolg1);
anpol2((.75,tt/2),2,120°,acolg1);
anpol2((.25,3*tt/2),2,120°,acolg1);
anpol2((.75,3*tt/2),2,-120°,acolg1);
);




drawsym():=(
if(symannot,
    canvas((0,0),(1,0),"annot",
      if(groups_group=="p1",annotp1());
      if(groups_group=="p2",annotp2());
      if(groups_group=="pm",annotpm());
      if(groups_group=="pg",annotpg());
      if(groups_group=="cm",annotcm());
      if(groups_group=="pmm",annotpmm());
      if(groups_group=="pmg",annotpmg());
      if(groups_group=="pgg",annotpgg());
      if(groups_group=="cmm",annotcmm());
      if(groups_group=="p4",annotp4());
      if(groups_group=="p4m",annotp4m());
      if(groups_group=="p4g",annotp4g());
    );
    canvas((0,0),(1,0),(0,sqrt(3/4)*2),"annot",
      if(groups_group=="p3",annotp3());
      if(groups_group=="p3m1",annotp3m1());
      if(groups_group=="p31m",annotp31m());
      if(groups_group=="p6",annotp6());
      if(groups_group=="p6m",annotp6m());
    );
  );

);

drawtile():=(
    clearimage("annot");
    drawsym();
    if(fundsel,
        if(tiletype=="sq",
          pol=polygon([D.xy,F.xy,E+F-D,E.xy]);
          fillbounds=polygon([lowerleft,upperleft,[10+offset.x,11],[10+offset.x,-11]])--pol;
          fill(fillbounds,alpha->0.5,color->(0,0,0));
          draw(pol,color->(1,1,1));
          canvas(D,F,"annot",
            draw(pol,color->(1,1,1),size->3,alpha->.7);
          );


        );

        if(tiletype=="r60",
          verx=F-D;
          very=E-D;
          tri=verx*0.5+sqrt(3/4)*very;
          pol=polygon([D.xy,F.xy,F+tri,D+tri]);
          fillbounds=polygon([lowerleft,upperleft,[10+offset.x,11],[10+offset.x,-11]])--pol;
          fill(fillbounds,alpha->0.5,color->(0,0,0));
          draw(pol,color->(1,1,1));
          canvas(D,F,"annot",
            draw(D,F,color->(1,1,1),size->2,alpha->.7);
            draw(D+(E-D)/2,F+(E-D)/2,color->(1,1,1),size->2,alpha->
            .7);
            draw(D,-D+E+F,color->(1,1,1),size->2,alpha->.7);
          );
         );
  D.visible=true;
  F.visible=true;
  D.pinned=false;
  F.pinned=false;
,
  D.visible=false;
  F.visible=false;
  D.pinned=true;
  F.pinned=true;

  );
);

drawtile2():=(
    if(fundsel,
        if(tiletype=="sq",
          pol=polygon([D.xy,F.xy,E+F-D,E.xy]);
          fillbounds=polygon([lowerleft,upperleft,[10+offset.x,11],[10+offset.x,-11]])--pol;
          fill(fillbounds,alpha->0.5,color->(0,0,0));
          draw(pol,color->(1,1,1));
        );

        if(tiletype=="r60",
          verx=F-D;
          very=E-D;
          tri=verx*0.5+sqrt(3/4)*very;
          pol=polygon([D.xy,F.xy,F+tri,D+tri]);
          fillbounds=polygon([lowerleft,upperleft,[10+offset.x,11],[10+offset.x,-11]])--pol;
          fill(fillbounds,alpha->0.5,color->(0,0,0));
          draw(pol,color->(1,,1,1));
         );
  );
);



drawing():=(
drawtile2();
      translate(offset);

        fillpoly([[10,-100],[20,-100],[20,100],[10,100]],color->(1,1,1)*.05);
        drawpoly([[10,-100],[20,-100],[20,100],[10,100]],color->(1,1,1)*.3);
        xx=0;
        yy=0;

        colpos=[];

        apply(1..ncols,y,
              pos=(xx*1.5+11,yy*1.5+10);
              apply(1..2,al,
                    fillcircle(pos,.5-.02*al,color->cols_y,alpha->.9)
                    );
              if(pencolor==y,
                 drawcircle(pos,.55,size->5,color->(1,1,1),alpha->1),
                 drawcircle(pos,.55,size->5,color->(1,1,1)*.3,alpha->1)

                 );

              colpos=colpos++[pos];

              xx=xx+1;
              if(xx==5,xx=0;yy=yy-1);
              );


              grouppos=[];
        xx=0;
        yy=0;
        apply(1..17,y,
              pos=(xx*1.5+11,yy*1.5-2.8);
              if(group==y,

                drawimage(pos,groups_y,scale->.5,alpha->1),
                drawimage(pos,groups_y,scale->.5,alpha->.4)
                );

              grouppos=grouppos++[pos];

              xx=xx+1;
              if(xx==5,xx=0;yy=yy-1);
              );

        buttonpos=[];

        xx=0;
        yy=0;
        apply(1..length(buttons),y,
              pos=(xx*1.35+10.8,yy*1.5-9.8);
                al=0.9;
                img=buttons_y;
                if( buttons_y=="redo" & redolist==[], al=0.4);
                if( buttons_y=="undo" & backind==0, al=0.4);
                if( buttons_y=="fund" & fundsel, img="fundh");
                if( buttons_y=="glow" & !glowing, img="noglow");
                if( buttons_y=="sym" & !symannot, img="nosym");
                drawimage(pos,img,scale->.9,alpha->al);


              buttonpos=buttonpos++[pos];

              xx=xx+1;
              if(xx==6,xx=0;yy=yy+1);
              );

greset();
        drawimage(X-(1,0),"size",scale->.7,alpha->.8);
        drawimage(Xsat-(1,0),"sat",scale->.7,alpha->.8);
        drawimage(Xdark-(1,0),"dark",scale->.7,alpha->.8);
        drawimage(Xalpha-(1,0),"alpha",scale->.7,alpha->.8);
        drawimage(Xblur-(1,0),"blur",scale->.7,alpha->.8);

        if(length(strokelist)<5,drawimage(lowerleft+(.5,.5),lowerleft+(7,.5),"iO",scale->.4,alpha->.8));
//draw((10,-8.4),(20,-8.4),color->(1,1,1)*.5);
        );


quadrat=[D.xy,F.xy,E.xy];

copyimage(a,b):=(
canvas((0,0),(1,0),b,
 drawimage((0,0),(1,0),a);
);
);

cell=quadrat;
bas=transpose([cell_2-cell_1,cell_3-cell_1]);
tilesize=512;
createimage("tile",tilesize,tilesize);
createimage("annot",tilesize,tilesize);


backind=0;
backs=["back1","back2","back3","back4","back5","back6","back7","back8","back9","back10"];

apply(backs,createimage(#,tilesize,tilesize));

backmax=length(backs);
strokeind=0;
redolist=[];


backup():=(
backind=backind+1;
if(backind>backmax,backind=backmax);
apply(reverse(1..(backmax-1)),copyimage(backs_#,backs_(#+1)));
copyimage("tile","back1");
);

undo():=(
if(backind>0,
 backind=backind-1;

 redolist=redolist++[strokelist_(-1)];
 strokelist=apply(1..(length(strokelist)-1),strokelist_#);
 noglow();
 copyimage("back1","tile");

 apply(1..(backmax-1),copyimage(backs_(#+1),backs_#));
 if(glowing,glow(),noglow());
);
);

clearredo():=(
redolist=[]
);

redo():=(
 if(redolist!=[],
  backup();
  strox=redolist_(-1);
  redolist=apply(1..(length(redolist)-1),redolist_#);
  strokelist=strokelist++[strox];
  size=strox_1_1;
  alpha=strox_1_2;
  color=strox_1_3;
  blur=strox_1_5;
  glowing=strox_1_4;
  setglow(strox_1_4);
  setdot();
  canvas(A,B,C,"tile",

    apply(1..length(strox_2)-1,
      draggingActionInLoop(strox_2_#,strox_2_(#+1));
    );
  );
 );
);


noglow():=
javascript("var ti=document.getElementById('tile');var context = ti.getContext('2d');context.globalCompositeOperation = 'source-over'");

glow():=
javascript("var ti=document.getElementById('tile');var context = ti.getContext('2d');context.globalCompositeOperation = 'lighter'");

setglow():=if(glowing,glow(),noglow());
setglow(glowing):=if(glowing,glow(),noglow());


//javascript("document.getElementById('back4').style.display='inline';");
//javascript("document.getElementById('back3').style.display='inline';");
//javascript("document.getElementById('back2').style.display='inline';");
//javascript("document.getElementById('back1').style.display='inline';");
//javascript("document.getElementById('tile').style.display='inline';");
//javascript("document.getElementById('annot').style.display='inline';");
//javascript("document.getElementById('pen').style.display='inline';");

reset():=(
err("RESET ORNAMENT");
backind=0;
redolist=[];
clearimage("tile");
canvas(A,B,"tile",
     fillcircle((0,0),100,color->(0,0,0));
    );

sc2=|D-F|;
C.xy=A-pp(B-A)*str_2;

canvas(A,B,C,"tile",

apply(strokelist,strox,
 size=strox_1_1;
 alpha=strox_1_2;
 color=strox_1_3;
  blur=strox_1_5;
  glowing=strox_1_4;
  setglow(strox_1_4);
 setdot();
 apply(1..(length(strox_2)-1),
   draggingActionInLoop(strox_2_#,strox_2_(#+1));
 );
);
);
resetdraw();
);
reset();

resume():= (
  pauseanimation();
);

resetdraw():=(
clearimage("tile");
backind=0;
redolist=[];
canvas(A,B,"tile",
     fillcircle((0,0),100,color->(0,0,0));
    );

sc2=|D-F|;
C.xy=A-pp(B-A)*str_2;
strokecount=1;
linecount=1;
playanimation();

);


fundsel=false;
glowing=false;
symannot=false;
pauseanimation();
