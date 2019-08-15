x=S.x;
if(x<S1.x,x=S1.x);
if(x>S2.x,x=S2.x);
S.xy=(x,S1.y);

x=R.x;
if(x<R1.x,x=R1.x);
if(x>R2.x,x=R2.x);
R.xy=(x,R1.y);

x=T.x;
if(x<T1.x,x=T1.x);
if(x>T2.x,x=T2.x);
T.xy=(x,T1.y);

x=U.x;
if(x<U1.x,x=U1.x);
if(x>U2.x,x=U2.x);
U.xy=(x,U1.y);

others=|S,S1|/|S1,S2|;
dirothers=|R,R1|/|R1,R2|;
anz=round(|T,T1|/|T1,T2|*14)+1;

mspeed=|U,U1|/|U1,U2|+.1;

pts=allmasses();
pts=select(pts,(#.size)<9);

n=10;
nn=anz;
s1=others*1;
s2=dirothers*1;
s=sum(pts,#.xy);
forall(pts,m,
   vold=m.v;
   sorted=sort(pts,abs(m.xy-#.xy));

   near=sorted_(2..(nn));
   numb=length(near);
  // if(Text0.pressed,
  //   apply(near,draw(#,m,color->(1,1,0)));
  // );
   if(numb!=0,
     mid=sum(near,#.xy)/(numb);
     speed=sum(near,#.v)/(numb),
     mid=m.xy;
     speed=(0,0);
   );

  // if((isreal(speed_1)&isreal(speed_2)),
   if(true,
     m.v=m.v+s1*(mid-m.xy);
     m.v=m.v+s2*speed;
     middir=(B+C+D+E)/4-m.xy;
     m.v=m.v+middir*0.02;
     if(feed,
       m.v=m.v+(mouse().xy-m.xy);

     );
     m.color=hue(|m.v|);
     m.v=m.v/|m.v|*mspeed*3;
  );
//vold=m:"vold";

//   if(true,
//    vold=vold/|vold|;
//    errc(vold);
//    vnew=m.v;
//    l=((vnew*vold+1)/2)^2;
//    l=max(l,.3);
//    vv= l*vnew+(1-l)*vold;
//    m.v=vv/|vv|;
//   );
//m:"vold"=m.v;
);



nn=length(pts);
forall(1..nn,p=pts_#;
ang=arctan2(p.vx,-p.vy);
drawimage(p,"fishr",angle->ang,scale->sizes_#*.3*2,alpha->colors_#);
drawimage(p,"fishb",angle->ang,scale->sizes_#*.3*2,alpha->1-colors_#);
//draw(p,p-p.v,color->(0,0,0));
//fillcircle(p,.3,color->hue(|p.v|*.2));
//drawcircle(p,.3,color->(0,0,0));
);
//X.xy=[4,3];
//Y.xy=[-5,4];
//Z.xy=[5,-4];
K.v=(0,0);
J.v=(0,0);
L.v=(0,0);

drawtext(S1+(.0,-.5),"Schwimm zu den Nachbarn",size->22,color->(1,1,1));
//drawtext(S+(0,.7),format(others,2),size->24,color->(1,1,1));

drawtext(R1+(.0,-.5),"Schwimm mit den Nachbarn",size->22,color->(1,1,1));
//drawtext(R+(0,.7),format(dirothers,2),size->24,color->(1,1,1));

drawtext(T1+(.0,-.5),"Anzahl der Nachbarn",size->22,color->(1,1,1));
drawtext(T+(0,.4),format(anz-1,0),size->24,color->(1,1,1));

drawtext(U1+(.0,-.5),"Geschwindigkeit",size->22,color->(1,1,1));
