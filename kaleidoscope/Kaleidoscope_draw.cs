restrict(p,mi,ma):=(
  xx=max(min(p.x,ma.x),mi.x);
  yy=max(min(p.y,ma.y),mi.y);
  p.xy=(xx,yy);
);
minpt=(-22,-17);
maxpt=(19,17);
//draw(minpt,maxpt);
//draw(minpt);
//draw(maxpt);
restrict(A,minpt,maxpt);
restrict(B,minpt,maxpt);
restrict(G,minpt,maxpt);
restrict(D,minpt,maxpt);
restrict(E,minpt,maxpt);

bild=images_sel_2;

if(M.x<=C.x,M.xy=C.xy);
if(M.x>=F.x,M.xy=F.xy);
if(L.y<=K.y,L.xy=K.xy);
if(L.y>=H.y,L.xy=H.xy);

alp=|C,M|/|C,F|/2;


aa=complex(A);
bb=complex(B);

if(type==1,
 cc=bb-(bb-aa)*exp(60°*i)*.5;
);


if(type==2,
 cc=bb-(bb-aa)*exp(60°*i)*1;
);


if(type==3,
 cc=bb-(bb-aa)*exp(45°*i)*sqrt(.5);
);




a=gauss(aa);
b=gauss(bb);
c=gauss(cc);


path=(gauss(aa),gauss(bb),gauss(cc));

d=0.1;
dd=(1/(1-2*d));
r(x,a):=max(0,min(1,(x-a-0.5)*dd+0.5));

//plot(r(x,2));

t1=Tr0.matrix;
t2=Tr1.matrix;
t3=Tr2.matrix;

t2=linereflect(join(gauss(aa),gauss(bb)));
t1=linereflect(join(gauss(aa),gauss(cc)));
t3=linereflect(join(gauss(cc),gauss(bb)));


t1=-t1/t1_3_3;
t2=-t2/t2_3_3;
t3=-t3/t3_3_3;

f(p,m):=m*p.homog;
id=((1,0,0),(0,1,0),(0,0,1));

drawimage(D,E,G,bild,alpha->alp);
drawme(m,al):=(
 gsave();
 fill(polygon((f(a,m),f(b,m),f(c,m))),color->(0,0,0));
 clip((f(a,m),f(b,m),f(c,m)));
 drawimage(f(D,m),f(E,m),f(G,m),bild,alpha->al);
 grestore();
 draw(f(a,m),f(b,m),size->3,color->(0,0,0),alpha->al);
 draw(f(b,m),f(c,m),size->3,color->(0,0,0),alpha->al);
 draw(f(a,m),f(c,m),size->3,color->(0,0,0),alpha->al);
);


drawme2(m,al):=(
 gsave();
// fill(polygon((f(A,m),f(B,m),f(F,m))),color->(0,0,0));
 clip((f(a,m),f(b,m),f(c,m)));
 drawimage(f(D,m),f(E,m),f(G,m),bild,alpha->al);
 grestore();
 draw(f(a,m),f(b,m),size->3,color->(0,0,0),alpha->al);
 draw(f(b,m),f(c,m),size->3,color->(0,0,0),alpha->al);
 draw(f(a,m),f(c,m),size->3,color->(0,0,0),alpha->al);
);


l=|K,L|/|K,H|-0.00001;

if(type==1,
 pre=12;
 list=(
  id,
  t1,
  t2,
  t1*t2,
  t1*t2*t1,
  t1*t2*t1*t2,
  t1*t2*t1*t2*t1,
  t1*t2*t1*t2*t1*t2,
  t1*t2*t1*t2*t1*t2*t1,
  t1*t2*t1*t2*t1*t2*t1*t2,
  t1*t2*t1*t2*t1*t2*t1*t2*t1,
  t1*t2*t1*t2*t1*t2*t1*t2*t1*t2);



  n=l*(12*12)/12+1;

  al=r(n,1);
  list=list
         ++apply(list,#*(-r(n,2)*t3+(1-r(n,2))*id))
         ++apply(list,#*t3*(-r(n,3)*t2+(1-r(n,3))*id))
         ++apply(list,#*t3*t2*(-r(n,4)*t1+(1-r(n,4))*id))
         ++apply(list,#*t3*t2*t1*(-r(n,5)*t2+(1-r(n,5))*id))
         ++apply(list,#*t3*t2*t1*t2*(-r(n,6)*t1+(1-r(n,6))*id))
         ++apply(list,#*t3*t2*t1*t2*t1*(-r(n,7)*t2+(1-r(n,7))*id))
         ++apply(list,#*t3*t2*t1*t2*t1*t2*(-r(n,8)*t3+(1-r(n,8))*id))
         ++apply(list,#*t3*t2*t1*t2*t1*t2*t3*(-r(n,9)*t2+(1-r(n,9))*id))
         ++apply(list,#*t3*t2*t1*t2*(-r(n,10)*t3+(1-r(n,10))*id))
         ++apply(list,#*t3*t2*t1*t2*t3*(-r(n,11)*t1+(1-r(n,11))*id))
         ++apply(list,#*t3*t2*t1*t2*t3*t1*(-r(n,12)*t2+(1-r(n,12))*id));

);



if(type==2,
 pre=6;

 list=(
  id,
  t1,
  t2,
  t1*t2,
  t1*t2*t1,
  t1*t2*t1*t2);



  n=l*(12*12)/12+1;

  al=r(n,1);
  list=list
         ++apply(list,#*(-r(n,2)*t3+(1-r(n,2))*id))
         ++apply(list,#*t3*(-r(n,3)*t1+(1-r(n,3))*id))
         ++apply(list,#*t3*(-r(n,4)*t2+(1-r(n,4))*id))
         ++apply(list,#*t3*t1*(-r(n,5)*t2+(1-r(n,5))*id))
         ++apply(list,#*t3*t2*(-r(n,6)*t1+(1-r(n,6))*id))
         ++apply(list,#*t3*t2*t1*(-r(n,7)*t2+(1-r(n,7))*id))
         ++apply(list,#*t3*t2*t1*(-r(n,8)*t3+(1-r(n,8))*id))
         ++apply(list,#*t3*t2*t1*t3*(-r(n,9)*t2+(1-r(n,9))*id))
         ++apply(list,#*t3*t2*t1*t2*(-r(n,10)*t3+(1-r(n,10))*id))
         ++apply(list,#*t3*t2*t1*t3*t2*(-r(n,11)*t3+(1-r(n,11))*id))
         ++apply(list,#*t3*t1*t2*(-r(n,12)*t3+(1-r(n,12))*id))


);






if(type==3,
 pre=8;

 list=(
  id,
  t1,
  t2,
  t1*t2,
  t1*t2*t1,
  t1*t2*t1*t2,
  t1*t2*t1*t2*t1,
  t1*t2*t1*t2*t1*t2

);



  n=l*(12*12)/12+1;

  al=r(n,1);
  list=list
         ++apply(list,#*(-r(n,2)*t3+(1-r(n,2))*id))
         ++apply(list,#*t3*(-r(n,3)*t2+(1-r(n,3))*id))
         ++apply(list,#*t3*t2*(-r(n,4)*t1+(1-r(n,4))*id))
         ++apply(list,#*t3*t2*(-r(n,5)*t3+(1-r(n,5))*id))
         ++apply(list,#*t3*t2*t1*(-r(n,6)*t2+(1-r(n,6))*id))
         ++apply(list,#*t3*t2*t3*(-r(n,7)*t1+(1-r(n,7))*id))
         ++apply(list,#*t3*t2*t3*t1*(-r(n,8)*t2+(1-r(n,8))*id))
         ++apply(list,#*t3*t2*t3*t1*t2*(-r(n,9)*t1+(1-r(n,9))*id))
         ++apply(list,#*t3*t2*t1*t2*(-r(n,10)*t3+(1-r(n,10))*id))
         ++apply(list,#*t3*t2*t1*t3*t2*(-r(n,11)*t3+(1-r(n,11))*id))
         ++apply(list,#*t3*t2*t1*t3*t2*t3*(-r(n,12)*t1+(1-r(n,12))*id))


);








l=pre*floor(n);
list=apply(1..l,list_#);
nn=length(list);
da(x):=1+x*(x-1)*3.5;


if(nn>12&false,
 forall(1..nn-pre,
  drawme(list_#,al);
 );


 forall(nn-pre+1..nn,
  drawme(list_#,al*da(r(n,floor(n))));
 ),
 forall(1..nn,
  drawme2(list_#,r(n,1));
 );

);


draw(gauss(aa),gauss(bb),size->4,color->(1,1,1));
draw(gauss(aa),gauss(cc),size->4,color->(1,1,1));
draw(gauss(cc),gauss(bb),size->4,color->(1,1,1));


//Grausamer Copy Code, aber ich bin gerade Faul
ty1(p):=(
 al=if(type!=1,.3,1);
 aa=complex(p);
 bb=complex(p+(-4,0));
 cc=bb-(bb-aa)*exp(60°*i)*.5;
 fillpolygon((gauss(aa),gauss(bb),gauss(cc)),color->(0.4,0.6,1)*al);
 draw(gauss(aa),gauss(bb),size->4,color->(1,1,1)*al);
 draw(gauss(aa),gauss(cc),size->4,color->(1,1,1)*al);
 draw(gauss(cc),gauss(bb),size->4,color->(1,1,1)*al);
 hot1=gauss((aa+bb)/2)+(0,2);
);


ty2(p):=(
 al=if(type!=2,.3,1);
 aa=complex(p);
 bb=complex(p+(-4,0));
 cc=bb-(bb-aa)*exp(60°*i);
 fillpolygon((gauss(aa),gauss(bb),gauss(cc)),color->(0.4,0.6,1)*al);
 draw(gauss(aa),gauss(bb),size->4,color->(1,1,1)*al);
 draw(gauss(aa),gauss(cc),size->4,color->(1,1,1)*al);
 draw(gauss(cc),gauss(bb),size->4,color->(1,1,1)*al);
 hot2=gauss((aa+bb)/2)+(0,2);
);

ty3(p):=(
 al=if(type!=3,.3,1);
 aa=complex(p);
 bb=complex(p+(-4,0));
 cc=bb-(bb-aa)*exp(45°*i)*sqrt(0.5);
 fillpolygon((gauss(aa),gauss(bb),gauss(cc)),color->(0.4,0.6,1)*al);
 draw(gauss(aa),gauss(bb),size->4,color->(1,1,1)*al);
 draw(gauss(aa),gauss(cc),size->4,color->(1,1,1)*al);
 draw(gauss(cc),gauss(bb),size->4,color->(1,1,1)*al);
 hot3=gauss((aa+bb)/2)+(0,2);
);






fi(d,a):=(
fill(
polygon(screenbounds())--polygon([
 [-24-d,-21-d],
 [19+d,-21-d],
 [19+d,20+d],
 [-24-d,20+d]
]
),
//COLOR
//color->(2/255,47/255,83/255),
color->(0,0,0),
alpha->a);
);

fi(0,0.2);
fi(0.1,0.2);
fi(0.2,0.2);
fi(0.3,0.2);
fi(0.4,0.2);
fi(0.5,0.2);
fi(0.6,0.2);
fi(0.7,1);

fillpolygon((
  (20,-100),
  (20,100),
  (120,100),
  (120,-100)
),
//COLOR
//color->(2/255,47/255,83/255)
color->(0,0,0)
);


ty1((30,2));
ty2((30,12));
ty3((30,7));


apply(1..4,ind=images_#;
  drawimage(ind_1,ind_2,scale->ind_3,alpha->if(sel==#,1,0.45))
);


;
