// GLOBALS BEGIN
circles=[C1,C2,C3]; // add circles that should act as mirrors here
mousedown=0;

// will be re-set in reset()
colrot=0;
// GLOBALS END


restrictgeometry():=(
  regional(distance,minpt,maxpt);
  distance=1;
  minpt=(screenbounds()_4).xy+distance*[1,1];
  maxpt=(screenbounds()_2).xy-distance*[1,1];
  // draw(minpt,maxpt); draw(minpt); draw(maxpt);
  restrictpoint(M1,minpt,maxpt); restrictradius(C1,minpt,maxpt);
  restrictpoint(M2,minpt,maxpt); restrictradius(C2,minpt,maxpt);
  restrictpoint(M3,minpt,maxpt); restrictradius(C3,minpt,maxpt);
  restrictpoint(RayBegin,minpt,maxpt);
);

restrictpoint(p,mi,ma):=(
  regional(xx,yy);
  xx=max(min(p.x,ma.x),mi.x);
  yy=max(min(p.y,ma.y),mi.y);
  if(or(p.x != xx,p.y != yy),p.xy=[xx,yy]);
);

restrictradius(c,mi,ma):=(
  regional(maxr);
  maxr=|ma-mi|/2;
  if(c.radius>maxr,c.radius=maxr);
);

intersect(p,s,circle):=(
  regional(ll,q,scal,dist,a,b);

  q=p-circle.center;
  scal=s*q;
  dist=q*q-circle.radius^2;

  a=-scal+sqrt(scal^2-dist);
  b=-scal-sqrt(scal^2-dist);

  ll=[];
  if(|im(a)|<0.00000001 & re(a)>0.00000001,ll=ll++[[circle,re(a)]]);
  if(|im(b)|<0.00000001 & re(b)>0.00000001,ll=ll++[[circle,re(b)]]);
  ll;
);

reflect(p,s,circle,a):=(
  regional(pp,ss,sp);
  pp=p+a*s;
  ss=s;
  sp=pp-circle.center;
  sp=sp/|sp|;
  ss=s-2*(s*sp)*sp;
  [pp,ss];
);

drawrayreflections(segment,circles):=(
  regional(stop,count,n,alpha,dim,l,hit,erg,p,s,l);
  p=(segment_1).xy;
  s=segment_2-segment_1;
  s=s/|s|;

  stop=false;
  count=0;
  n=150;
  alpha=1;
  dim=0.985;
  while(count<n & !stop,
    count=count+1;
    l=[];
    forall(circles,l=l++intersect(p,s,#));
    l=sort(l,#_2);

    ahue=colrot+count;
    if(ahue>150,ahue=ahue-150);
    if(length(l)>0,(
      hit=l_1;
      erg=reflect(p,s,hit_1,hit_2);
      draw(p,erg_1,color->(hue((ahue*(1/n)))),alpha->alpha,size->4);
      p=re(erg_1);
      s=re(erg_2);
    ),(
      draw(p,p+100*s,color->(hue((ahue*(1/n)))),alpha->alpha,size->4);
      stop=true;
   ));
   alpha=alpha*dim;
  );
);

render():=(
  restrictgeometry();

  forall(circles,fillcircle(#.center,#.radius,color->(.1,.1,.1)));

  drawrayreflections([RayBegin,RayEnd],circles);
);

reset():=(
  idle=1;
  colrot=0;
);

reset();
