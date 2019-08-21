mou=mouse().xy;
if(sel==0,
  dist=|A,mou|-diffr;
  A.xy=olda;
  rad0=max(dist,2);
);
if(sel==1,
  dist=|B,mou|-diffr;
  B.xy=oldb;
  rad1=max(dist,2);
);
if(sel==2,
  dist=|C,mou|-diffr;
  C.xy=oldc;
  rad2=max(dist,2);
);


restrict(p,mi,ma):=(
  xx=max(min(p.x,ma.x),mi.x);
  yy=max(min(p.y,ma.y),mi.y);
  p.xy=(xx,yy);
);
minpt=(-16,-12);
maxpt=(26,19);
//draw(minpt,maxpt);
//draw(minpt);
//draw(maxpt);
restrict(D,minpt,maxpt);
restrict(A,minpt,maxpt);
restrict(B,minpt,maxpt);
restrict(C,minpt,maxpt);


E.xy=(E-D)/|E-D|*3+D;
if(mover()==D,E.xy=D+diff);
diff=E-D;
m1=A.xy;
r1=rad0;
m2=B.xy;
r2=rad1;
m3=C.xy;
r3=rad2;

fillcircle(m1,r1,color->(.1,.1,.1));
fillcircle(m2,r2,color->(.1,.1,.1));
fillcircle(m3,r3,color->(.1,.1,.1));

o1=["circ",m1,r1];
o2=["circ",m2,r2];
o3=["circ",m3,r3];

p=D.xy;
s=E-D;
s=s/|s|;




intersect(p,s,o):=(
ll=[];
if(o_1=="circ", (
m=o_2;
r=o_3;
q=p-m;
scal=s*q;
dist=q*q-r^2;

a=-scal+sqrt(scal^2-dist);
b=-scal-sqrt(scal^2-dist);

if(|im(a)|<0.00000001 & re(a)>0.00000001,ll=ll++[[o,re(a)]]);
if(|im(b)|<0.00000001 & re(b)>0.00000001,ll=ll++[[o,re(b)]]);
);
ll;
)
);

reflect(p,s,o,a):=(
pp=p+a*s;
ss=s;
if(o_1=="circ", (
   sp=pp-o_2;
   sp=sp/|sp|;
   ss=s-2*(s*sp)*sp;
);
);
[pp,ss];
);

stop=false;
count=0;
n=150;
alpha=1;
dim=0.985;
while(count<n & !stop,
count=count+1;
l=intersect(p,s,o1)++intersect(p,s,o2)++intersect(p,s,o3);

l=sort(l,#_2);

ahue=colrot+count;
if(ahue>150,ahue=ahue-150);
if(length(l)>0,(
 hit=l_1;
 erg=reflect(p,s,hit_1,hit_2);
//   draw(erg_1);
 draw(p,erg_1,color->(hue((ahue*(1/n)))),alpha->alpha,size->4);
//  draw(erg_1,erg_1+erg_2*.1,color->(1,0,0),size->2);
 p=re(erg_1);
 s=re(erg_2);
),(
 draw(p,p+100*s,color->(hue((ahue*(1/n)))),alpha->alpha,size->4);
 stop=true;
)
);
alpha=alpha*dim;
);

    drawcircle(A,rad0,color->(1,1,1),size->3);
    drawcircle(B,rad1,color->(1,1,1),size->3);
    drawcircle(C,rad2,color->(1,1,1),size->3);
//drawtext((-5,5),sel,color->(1,1,1));
olda=A.xy;
oldb=B.xy;
oldc=C.xy;
