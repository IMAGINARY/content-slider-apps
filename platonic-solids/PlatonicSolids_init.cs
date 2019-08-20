
maxdepth=7;


col=(0.1,0.65,1);
ptf(t,col,depth):=t*(1,1,1)*|col|+(1-t)*col;
ptf(t,col,depth):=(t*(1,1,1)*depth^0.3+(1-t)*col)*depth;
ptl=[0,.05,.1,.15,.2,.25,.3,.35]*.5;
ptr=[1,.9,.8,.7,.6,.45,.3,.2]*.47;
ptc=[0,0.1,0.2,0.3,0.4,0.5,0.7,0.9];
ptd=(-1,1.4);
//drawcircle((0,0),1);

drawpoint(p,r,col,depth):=(
 fillcircle(p+ptd*ptl_1*r,ptr_1*r*1.1,color->(0,0,0),alpha->1,size->0.6);
 repeat(8,#,t=#;
  fillcircle(p+ptd*ptl_t*r,ptr_t*r,color->ptf(ptc_t,col,depth),alpha->1);
 );
);
init=0;

resetclock();


wx = cos(seconds())/200; wy = sin(seconds())/200;

choice=3;
multicol=1;
next():=(choice=choice+1;if(choice==5,choice=1));
anim=false;

scal=0.15;

init=0;


mat=[
  [1,0,0],
  [0,1,0],
  [0,0,1]
];

mat0=[
  [1,0,0],
  [0,1,0],
  [0,0,1]
];



mmmx=mat0;
mmmy=mat0;





edgecol=(0.76,0.78,0.54);
edgecol=(.9,.9,.9);
edgecol=(0.4,0.3,0.3);

//Das Malt einen Punkt aus homogenen Koordinaten
renderPointX(p):=(
  pp=mat*p;
  draw((pp_1,pp_2),color->edgecol,border->false,size->3)
);

//Das Malt ein Segment aus homogenen Koordinaten
renderLineX(p,q):=(
  pp=mat*p;
  qq=mat*q;
  draw((pp_1,pp_2),(qq_1,qq_2));
);




norm(p):=(p_1,p_2,p_3);


ll=.9;
mm=.1;

clip=3.6;

clipfkt(p):=true;


ptsize(p):=|points_p|*.4;


renderLine(po,depth,col,siz):=(
 size1=ptsize(po_1);
 size2=ptsize(po_2);
 pol=(rotpoints_(po_1),rotpoints_(po_2));

 ptest=(pol_1+pol_2)/2;
//rr=|ptest|^2;
//zz=ptest_3;
//if(rr/dist>zz,col=(1,1,1));
 po1=pol_1;
 po2=pol_2;
 ll=|po1,po2|;
 if(ll>0,
  dd1=1/ll*1.4*size1;
  dd2=1/ll*1.4*size2;

  pb1=(dd2*po1+(1-dd2)*po2);
  pb2=(dd1*po2+(1-dd1)*po1);

  bb=(depth+30)/30;
 // dis1=(dist/(dist-pb1_3*2));
 // dis2=(dist/(dist-pb2_3*2));

  dis1=0.5*(dist/(dist-pb1_3));
  dis2=0.5*(dist/(dist-pb2_3));

  sipre=(dis1+dis2)/2*siz*3*1.6;


  if(|dis1|<600&|dis2|<600&dis1>0&dis2>0,
  if(col_2<col_3&false,

   draw((pb1_1,pb1_2)*dis1,(pb2_1,pb2_2)*dis2,color->(0,0,0),size->8*sipre,alpha->1);
//   draw((pb1_1,pb1_2)*dis1,(pb2_1,pb2_2)*dis2,color->col*bb*.3,size->7*sipre,alpha->1,dashing->5);
//   draw((pb1_1,pb1_2)*dis1,(pb2_1,pb2_2)*dis2,color->col*bb*.8,size->6*sipre,alpha->1,dashing->5);
   draw((pb1_1,pb1_2)*dis1,(pb2_1,pb2_2)*dis2,color->col*bb,size->4*sipre,alpha->1,dashing->5);
   ,
   draw((pb1_1,pb1_2)*dis1,(pb2_1,pb2_2)*dis2,color->(0,0,0),size->8*sipre,alpha->1);
   draw((pb1_1,pb1_2)*dis1,(pb2_1,pb2_2)*dis2,color->col*bb*.5,size->7*sipre,alpha->1);
   draw((pb1_1,pb1_2)*dis1,(pb2_1,pb2_2)*dis2,color->col*bb*.8,size->6*sipre,alpha->1);
   draw((pb1_1,pb1_2)*dis1,(pb2_1,pb2_2)*dis2,color->col*bb,size->4*sipre,alpha->1);


   );
  );
 );
);


//dist=7;

renderPoint(po,depth,col,psiz):=(
psiz=ptsize(po_1);
pol=rotpoints_(po_1);
//rr=|pol|^2;
//zz=pol_3;
if(clipfkt(points_(po_1)),
 bb1=pol_3;
 bb2=(bb1+30)/30;
 pol=(pol_1,pol_2)*.5*(dist/(dist-bb1));
 //draw(pol,color->col*bb1,size->5,border->true);
// drawpoint(pol,.4,col*bb2);

//if(rr/dist<zz,col=(1,0,0));

 drawpoint(pol,psiz*(dist/(dist-bb1)),col,bb2);


);
);


renderPolygon(pol,col):=(
//  pp=apply(pol,mat*#);

pp=pol;
  aa=pp_1;bb=pp_2,cc=pp_3;
  nn=cross(bb-aa,bb-cc);
  nn=nn/abs(nn);
  rgb=ambient;

  forall(lights,(
      shade=-sin(nn*#_1);
      if(nn*#_1>0,shade=0);
      rgb=rgb+#_2*shade;
    )
  );
  pp=apply(pp,(#_1,#_2));
  aa=pol_1;bb=pol_2,cc=pol_3;

  fillpoly(pp,color->(rgb_1*col_1,rgb_2*col_2,rgb_3*col_3),alpha->.8);
  connect(pp++[pp_1],color->(1,1,1)*sum(col)*.5,size->1);
//draw(center(pp),(nn_1,nn_2)*1+center(pp),color->(1,1,1));
);



renderPolygonX(pol,col):=(
//  pp=apply(pol,mat*#);

pp=pol;
  pp=apply(pp,(#_1,#_2));
  fillpoly(pp,alpha->1);
);




init3d():=(
// renderlist=[];
// pr=[];
);

center(ll):=sum(ll,rotpoints_#)/length(ll);

center2(ll):=sum(ll)/length(ll);


poly3d(l):=(l);


pro(vert):=(vert_1,vert_2)*.5*(dist/(dist-vert_3))++[1];

ori(pol):=(
  det(pro(pol_1),pro(pol_2),pro(pol_3))
);

facecol=(1,.7,.5);
//facecol=(1,.7,1);



draw3d(a,b):=();
depthfun(ob):=ob_2;

backfrpt(p):=if((|p|^2/dist)<p_3,1,-1);

backfr(ob):=if(length(ob_1)==1,
   backfrpt(rotpoints_(ob_1_1)),
   backfrpt((rotpoints_(ob_1_1)+rotpoints_(ob_1_2))/2));



depthfun(ob):=(ob_2+1000*ob_4*backfr(ob));

render3d():=(
 mati=transpose(mat);
 rotpoints=points*mati/scal;
//err(hull);

//err(hull);

//err(length(objects));
// drawbackhull();

 if(init==0,

   renderlist=
   apply(objects,ll,
     [ll_1,center(ll_1)_3,ll_2,ll_3]
   );
   init=1;
  ,
   ii=1;
   forall(objects,ll,
     (renderlist_ii)_2=center(renderlist_ii_1)_3;
     ii=ii+1;
   );
  );
  rl=sort(renderlist,depthfun(#));

  forall(rl,pol,
      if(edges&length(pol_1)==2,
       renderLine(pol_1,pol_2,pol_3,pol_4)
      );
      if(length(pol_1)==1,
       renderPoint(pol_1,pol_2,pol_3,pol_4)
      );
  );
// drawfronthull();

);


//berechnet innkugel und umkugelradius

minmax(obj):= (
 if(length(obj)>3,
  ch=convexhull3d(obj);
  obj=ch_1;
  maxval=1/(-sort(apply(ch_1,-|#|))_1);
  ff=ch_2;
  dual=apply(ff,f,
    linearsolve((obj_(f_1),obj_(f_2),obj_(f_3)),(1,1,1));
  );
  ch=convexhull3d(dual);
  minval=-sort(apply(ch_1,-|#|))_1;
  (minval,maxval);
  ,
  (|obj_1|,|obj_1|);
 );
);


perm(a,b,c):=(
  (a,b,c),
  (a,c,b),
  (b,a,c),
  (b,c,a),
  (c,a,b),
  (c,b,a)
);


perm1(a,b,c):=(
  (a,b,c),
  (b,c,a),
  (c,a,b)
);




matrz(w):=(
(cos(w),sin(w),0),
(-sin(w),cos(w),0),
(0,0,1)
);

matrx(w):=(
(1,0,0),
(0,cos(w),sin(w)),
(0,-sin(w),cos(w))
);

matry(w):=(
(cos(w),0,-sin(w)),
(0,1,0),
(sin(w),0,cos(w))
);




nn(v):=v/|v|;






definebody(zell):=(

init=0;
  points=zell_1;
  sizes=zell_2;
  objects=zell_3;
);





colorf(obj,ff):=actcol;
colorf(obj,ff):=(
nn=linearsolve((obj_(ff_1),obj_(ff_2),obj_(ff_3)),(1,1,1));

nn=nn/|nn|;
//err(nn*initdirs_1);
//err(ff);
dd=-sort(apply(initdirs,-#*nn))_1;
//err(dd);
hue(colspan*spanfactor_(choice+1)_tchoice*(1-dd)+angle/(2*pi));
);


colorfx(obj,ff):=(
nn=linearsolve((obj_(ff_1),obj_(ff_2),obj_(ff_3)),(1,1,1));

hue(4*1/|nn|);
);



 object(obj,faces):=(
      pr= apply(faces,fa,[apply(fa_1,obj_#),fa_2])
 );



reset():=(
E.angle=0;
F.angle=0;
M.angle=0;
N.angle=0;
O.angle=0;
P.angle=0;
);




boo(t):=if(t.pressed,0,1);



highlight(but):= connect(
    (
      off+but+(1,1)*w,
      off+but+(-1,1)*w,
      off+but+(-1,-1)*w,
      off+but+(1,-1)*w,
      off+but+(1,1)*w
  ),color->(1,1,1),size->2
);


;
ambient=(0.2,0.2,0.2);

edges=true;



choice=2;
tchoice=1;
dragging = false;



reset():=(
 points=[];
 sizes=[];
 list=[];
 objects=[];
 count=1;
 celllist=[];
 wx = cos(seconds())/200; wy = sin(seconds())/200;
);





perm3(b,c,d):=(
 (b,c,d),
 (b,d,c),
 (c,b,d),
 (c,d,b),
 (d,b,c),
 (d,c,b)
);


perm3ev(b,c,d):=(
 (b,c,d),
 (c,d,b),
 (d,b,c)
);



pm1(b,c,d):=(
   (b,c,d),
   (-b,c,d));

pm2(b,c,d):=
pm1(b,c,d)++pm1(b,-c,d);
pm3(b,c,d):=
pm2(b,c,d)++pm2(b,c,-d);

tau=(sqrt(5)-1)/2;

s1=0.5;

cell4=s1*[(1,1,1),(1,-1,-1),(-1,1,-1),(-1,-1,1)];
cell8=s1*set(flatten(apply(pm1(1,0,0),perm3(#_1,#_2,#_3)),levels->1));
cell6=s1*set(pm3(1,1,1));
cell12=(set(flatten(apply(pm2(1+tau,tau,0),perm3ev(#_1,#_2,#_3))/2,levels->1))++cell6)*s1;
cell20=s1*set(flatten(apply(pm2(tau,1,0),perm3ev(#_1,#_2,#_3)),levels->1));



calcsegs(body):=(
  ch=convexhull3d(body);
  pts=ch_1;
  faces=ch_2;
  segs=apply(faces,f,ff=f++[f_1];apply(1..length(f),set([ff_#,ff_(#+1)])));
  segs=set(flatten(segs,levels->1));
  (pts,segs);
);

definepoly(body):=(
  q=calcsegs(body);
  q
);

cell4=(definepoly(cell4),(1,.5,0),3.7);
cell6=(definepoly(cell6),(0.3,.7,0.4),3.2);
cell8=(definepoly(cell8),(0.3,.5,1),5.4);
cell12=(definepoly(cell12),(1,1,0),5.5);
cell20=(definepoly(cell20),(.8,0,0),4.7);





//erzeugt listen:
//ptoints ==> Liste aller beteiligten Atome
//sizes ==> Liste der Atomgrößen
//pr ==> Liste zu rendernden Kanten und Punkte

reset();
addcell(cell,si,count):=(
  col=cell_2*.7;
  cell=cell_1;
  nn=length(points);
  points=points++cell_1*si;
  segs=cell_2;

  sizes=sizes++apply(1..length(cell_1),depth);
  newobjects=apply(1..length(cell_1),[[#+nn],(1,1,1)*.4,sizes_(#+nn),count]);
  newobjects=newobjects++apply(segs,[[#_1+nn,#_2+nn],col,depth,count]);
  objects=objects++newobjects;

  celllist=celllist++[[newobjects]];


//objects=objects++apply(segs,[[#_1,#_2],(1,0,0)*.7,0.5]);

);




collinear(a,b,c):=(
//err(a);
//err(b);
//err("SUM "+format(|a,c|+|b,c|,14));
//err("ORI "+format(|a,b|,14));
  |a,c|+|b,c|~=|a,b|;
);

createsplit(i,j):=(
  pointsi=cells_i_1_1;
  segsi=cells_i_1_2;
  pointsj=cells_j_1_1*trans_i_j;
  segstmp=[];
  nn=length(pointsi);
  ptstmp=pointsi;
  apply(segsi,s,
     pp=select(pointsj,collinear(pointsi_(s_1),pointsi_(s_2),#));
     if(pp==[],
       segstmp=segstmp++[s]
     ,
       ptstmp=ptstmp++pp;
       nn=nn+1;
       segstmp=segstmp++[[s_1,nn],[s_2,nn]]
     );
  );

  [[ptstmp,segstmp],cells_i_2,cells_i_3];
);


trans=[
[1,         1/3,     1,          2/3,        tau],
[1,         1,       1,          (1+tau^3),  1],
[1/3,       1/3,     1,          2/3,        tau],
[1/2,       1/2,     (tau+1)/2,  1,          3/5],
[(1+tau)/3,(1+tau)/3,1,      ((sqrt(3)/(1+tau))),          1]
];


cells=(cell4,cell6,cell8,cell12,cell20);
cell3split=createsplit(3,5);
cell1split=createsplit(1,3);
cell4split=createsplit(4,3);
cell5split=createsplit(5,3);

cells=cells++[cell1split,cell6,cell3split,cell4split,cell5split];

addcell(next,count):=(
 if(cur!=0,
  siz=trans_(if(cur>5,cur-5,cur))_(if(next>5,next-5,next))*siz,
  siz=cells_next_3;
 );
 addcell(cells_next,siz,count);
 cur=next;
 depth=depth*.8;
);




//sequenz=[5,4,1,3,5,3,4,2];
sequenz=[2];

processseq(sequenz):=(
 reset();
 siz=3.5;
 depth=1;
 cur=0;
 forall(1..length(sequenz)-1,
   next=sequenz_#;
   if(next==1& sequenz_(#+1)==3,next=next+5);
   if(next==3& sequenz_(#+1)==5,next=next+5);
   if(next==4& sequenz_(#+1)==3,next=next+5);
   if(next==5& sequenz_(#+1)==3,next=next+5);
   sequenz_#=next;
 );
 count=1;
 forall(sequenz,
   addcell(#,count);
   count=count+1;
 );
init=0;
);

processseq(sequenz);
oldsequenz=sequenz;

resetall():=(
   sequenz=[2];
   edges=true;
   S.homog=(4, 0.3131313, -0.2525252);
);
pause():=(
   pauseanimation();
);


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
  ),color->(1,1,1.5)*.2,alpha->0.7

);


resume() := (
  playanimation();
  wx = cos(seconds())/200; wy = sin(seconds())/200;
);
