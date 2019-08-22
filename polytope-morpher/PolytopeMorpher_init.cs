cache=zerovector(5000);
fcache=zerovector(100);



wx=0;
wy=0;
oldparamv=(0,0,0,0,0,0);
oldcolparams=(0,0);

choice=2;
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
renderPoint(p):=(
  pp=mat*p;
  draw((pp_1,pp_2),color->edgecol,border->false,size->3)
);

//Das Malt ein Segment aus homogenen Koordinaten
renderLine(p,q):=(
  pp=mat*p;
  qq=mat*q;
  draw((pp_1,pp_2),(qq_1,qq_2));
);




norm(p):=(p_1,p_2,p_3);




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
  connect(pp++[pp_1],color->(1,1,1)*.5,size->1*3);
//draw(center(pp),(nn_1,nn_2)*1+center(pp),color->(1,1,1));
);

renderPolygonB(pp,col):=(
//  pp=apply(pol,mat*#);

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

  fillpoly(pp,color->(rgb_1*col_1,rgb_2*col_2,rgb_3*col_3),alpha->alpha);
  connect(pp++[pp_1],color->(1,1,1)*.5,size->1*(.7)^iterdepth*2);
//draw(center(pp),(nn_1,nn_2)*1+center(pp),color->(1,1,1));
);

renderPolygonF(pp,col):=(
//  pp=apply(pol,mat*#);
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
  fillpoly(pp,color->(rgb_1*col_1,rgb_2*col_2,rgb_3*col_3),alpha->alpha);
  connect(pp++[pp_1],color->(1,1,1)*sum(col)*.5,size->2*(.7)^iterdepth*2);//TODO .5 wieder wegmachen
//draw(center(pp),(nn_1,nn_2)*1+center(pp),color->(1,1,1));
);




renderPolygonX(pol,col):=(
//  pp=apply(pol,mat*#);

pp=pol;
  pp=apply(pp,(#_1,#_2));
  drawpoly(pp,alpha->1);
);




init3d():=(
// renderlist=[];
// pr=[];
);

center(ll):=sum(ll)/length(ll);


poly3d(l):=(l);



draw3d(a,b):=();


pro(vert):=(vert_1,vert_2,1);

ori(pol):=(
  det(pro(pol_1),pro(pol_2),pro(pol_3))
);

render3d():=(
mati=transpose(mat);

  if(init==0,

  renderlist=
  apply(pr,ll,
    mll=apply(ll_1,mat*(#))/scal;
    [mll,center(mll)_3,ll_2]
  );

  init=1;
  ,
  ii=1;

  forall(pr,ll,
    mll=ll_1*mati/scal;

    (renderlist_ii)_1=mll;
    (renderlist_ii)_2=center(mll)_3;
    (renderlist_ii)_3=ll_2;
      ii=ii+1;
  );



);


//  rl=sort(renderlist,#_2);

  forall(renderlist,pol,
      if(ori(pol_1)~>=0,
       renderPolygonB(pol_1,pol_3*(pol_2+10)/10)
      );
  );


 forall(renderlist,pol,
      if(ori(pol_1)~<=0,
       renderPolygonF(pol_1,pol_3*(pol_2+10)/10)
      );
);


//err("B4 "+seconds());

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




iterdepth=0;

definebody(zell):=(
  body=zell_1;
  segs=zell_2;
  faces=zell_3;
if(choice!=6, initdirs=apply(body,#/|#|));
);

spanfactor=(0.24,.38,.38,0.78,0.78,0,0,0,0);
spanfac():=(
  sf=1;
  if(choice<6,sf=spanfactor_(choice+1));
  sfold=of;
  if(choice==6,sf=sfold);
  sf;1
);



colorf(obj,ff):=actcol;
colorf(obj,ff):=(

nn=linearsolve((obj_(ff_1),obj_(ff_2),obj_(ff_3)),(1,1,1));
nn=nn/|nn|;
dd=-sort(apply(initdirs,-#*nn))_1;
hue(colspan*spanfactor_(choice+1)*(dd-1)+(angle+colspan)/(2*pi));
);


colorfx(obj,ff):=(
nn=linearsolve((obj_(ff_1),obj_(ff_2),obj_(ff_3)),(1,1,1));

hue(4*1/|nn|);
);



 object(obj,faces):=(
      pr= apply(faces,fa,[apply(fa_1,obj_#),fa_2])
 );


ambient=(0.2,0.2,0.2);


choice=1;
tchoice=1;



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
cell12=(s1*set(flatten(apply(pm2(1+tau,tau,0),perm3ev(#_1,#_2,#_3)),levels->1))++cell6)*s1;
cell20=s1*set(flatten(apply(pm2(1,tau,0),perm3ev(#_1,#_2,#_3)),levels->1));




calcsegs(body):=(
  ch=convexhull3d(body);
  pts=ch_1;
  cfaces=ch_2;
  csegs=apply(cfaces,f,ff=f++[f_1];apply(1..length(f),set([ff_#,ff_(#+1)])));
  csegs=set(flatten(csegs,levels->1));
  (pts,csegs,cfaces);
);

definepoly(body):=(
  q=calcsegs(body);
  q
);

cell4=(definepoly(cell4));
cell8=(definepoly(cell8*1.3));
cell6=(definepoly(cell6*0.8));
cell12=(definepoly(cell12*1.5));
cell20=(definepoly(cell20*1.1));


magic():=(
if(length(objx)<1500,

  id=initdirs;
spanfactor_7=spanfactor_(choice+1);
  choice=6;
  P.xy=G.xy;
  L.xy=A.xy;
  O.xy=M.xy;
  special=definepoly(objx);
  initdirs=id;
iterdepth=iterdepth+1;
);
);

resetall():=(
   choice=1;
   tchoice=1;
   O.xy=M.xy;
  rr=random();
   P.xy=rr*G+(1-rr)*K;
   rr=random();

   L.xy=rr*A+(1-rr)*C;
   W.homog=(4, -2.474666, 0.2666666);
   Rot.homog=(4, -1.781974, 0.1784110);
   Span.homog=(4, -1.51954, 0.2129865);
   pendinganimation=true;
   damping=1;
   tt=0.4;
   wx=(random()-.5)*.3*tt;
   wy=(random()+.5)*.1*tt;
   choice=floor(random()*5);
   iterdepth=0;

    Rot.xy=gauss(complex(Rot-H)*exp(i*random()))+H;

    Span.xy=H+gauss(complex(diff)*exp(i*oldangle))*2.5




);

resume():=(
   if(pendinganimation,playanimation(),pauseanimation());
);

highlight(but):= connect(
    (
      off+but+(1,1)*w,
      off+but+(-1,1)*w,
      off+but+(-1,-1)*w,
      off+but+(1,-1)*w,
      off+but+(1,1)*w
  ),color->(1,1,1)*.7,size->2
);

dehighlight(but):= fillpoly(
    (
      off+but+(1,1)*w,
      off+but+(-1,1)*w,
      off+but+(-1,-1)*w,
      off+but+(1,-1)*w,
      off+but+(1,1)*w
  ),color->(1,1,1)*.0,size->2,alpha->0.6
);

damping=1;
 tt=0.4;
   wx=(random()-.5)*.3*tt;
   wy=(random()+.5)*.1*tt;
   choice=floor(random()*5);
   iterdepth=0;
   pendinganimation=true;
