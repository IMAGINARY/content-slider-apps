if(pressed1,
  B.pinned=true;
  C.pinned=true,
  B.pinned=false;
  C.pinned=false
);
restrict(p,mi,ma):=(
  if(!pressed1,
    xx=max(min(p.x,ma.x),mi.x);
    yy=max(min(p.y,ma.y),mi.y);
    p.xy=(xx,yy);
  );
);
minpt=(-11,-20);
maxpt=(31,11.5);
//draw(minpt,maxpt);
//draw(minpt);
//draw(maxpt);
restrict(B,minpt,maxpt);
restrict(C,minpt,maxpt);
restrict(F,minpt,maxpt);
restrict(G,minpt,maxpt);

 Dummy.xy=0;
 fillpoly(button1,color->gray(if(pressed1,.3,.5)));
drawpoly(button1,color->gray(.8),size->4);
fillpoly(button2,color->gray(if(pressed2,.3,.5)));
drawpoly(button2,color->gray(.8),size->4);
drawtext(button1_1+(2,.5),if(pressed1,"Stop","Start"),color->(1,1,1),size->34);
drawtext(button2_1+(2,.5),"Spur",color->(1,1,1),size->34);
draw(F,G, arrow->true,size->7,color->(1,1,1));

if(pressed2,
  forall(reverse(1..length(l)),
    r=exp(-#*.01)*0.4;
    fillcircle(l_#,r,alpha->(1-#/n)/1.5,color->(1,1,0));
    drawcircle(l_#,r,alpha->(1-#/n)/1.5,color->(0,0,0));
  ),
  l=[];
);

oldb=B.xy;
oldc=C.xy;
//errc(pressed2);
