upaction():=(
if(pressed,reset());
    pressed=false;
if(moving,

  diff=lastmouse-pos;
  goalpos=special+diff;



  hits=select(pegs,|goalpos,#.xy|<2);
  hits2=select(active,|goalpos,#.xy|<2);
  if(length(hits)==1 &length(hits2)==0 ,
    hit=hits_1;
    middle=select(active,|(goalpos+special)/2,#.xy|<2);
    if(abs(|special-hit|/unit-2)<0.1&length(middle)==1,
      active=active++hits;
      active=active--middle;
     // playtone(62,channel->9,velocity->.4);
    special=[];
    moving=false;

      ,
      moveback();
   //   active=active++[special];
    );
    ,
      moveback();
    //  active=active++[special];

  ) ;
 // special=[];
 // moving=false;
);


);

animating=false;

//KNOPF POSITION
rect=[[23,-4],[26,-4],[26,-1],[23,-1]];
pressed=false;
unit=4.54;
pegs=[[17.88,-11],[8.8,4.72],[-0.28,-11],[4.26,-3.14],[13.34,-3.14],[15.61,-7.07],[8.8,-3.14],[8.8,-11],[6.53,-7.07],[1.99,-7.07],[4.26,-11],[13.34,-11],[6.53,0.79],[11.07,0.79],[11.07,-7.07]] ;
moving=false;
  pos=(0,0);

active=pegs--[pegs_4];
special=[];
drawpeg(p):=(
 gsave();
 clip(circle(p+(0.2,-0.2),2.4));
 drawimage(A,B,"boardB");
 grestore();
);

drawspecial(pp):=(

  if(special!=[],
    gsave();
    diff=pp-pos;

    off=(0,-0.1);
    fill(circle(special+diff+off,1.75),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.7),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.65),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.6),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.55),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.5),color->(.5,0,0),alpha->.1);
    clip(circle(special+diff,2.4));
    drawimage(A+diff,B+diff,"boardAX");
    fill(circle(special+diff,1.5),color->(0,0,0),alpha->.1);
    grestore();
  );
);



drawstuff(mp):=(
//clrscr();

 drawimage(A,B,"boardC");
 apply(active,p,drawpeg(p));
 drawspecial(mp);
 if(special!=[],
  posmo= possiblemoves(special);
  apply(posmo,
    drawpos(#);
  );
 );
 if(!moving&!stillpossible(),
   drawtext((-4,4),"Ende:",color->(1,1,1),size->30);
   drawtext((-4,2.0),length(active)+" sind übrig",color->(1,1,1),size->30);
 );
);

drawpos(#):=(
    off=(.1,-.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->9*3,alpha->0.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->7*3,alpha->0.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->5*3,alpha->0.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->3*3,alpha->0.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->1*3,alpha->0.1);
);
movingfilm=false;
waiting=false;
moveback():=(
  diff=mouse().xy-pos;
  nn=round(|diff|/2);
  animation=apply(1..nn,q=#/nn;(q)*pos+(1-q)*mouse().xy);
  animation=animation++[animation_(-1)];
  startindex=1;
  movingfilm=true;
  playanimation();
//  drawstuff(pos);
);

movebackX():=(
   drawstuff(pos);
   active=active++[special];
   special=[];

);


possiblemoves(sp):=(
  ll=[];
  apply(pegs--active,p,
    if(  abs(|p-sp|/unit-2)<0.1,
      if(length(select(active,|#-(p+sp)/2|<0.1))==1,ll=ll++[p])
    )
  );
  ll;
);


stillpossible():=(
  erg=false;
  forall(active,try,
     if(possiblemoves(try)!=[],erg=true)
  );

  erg;
);

reset():=(

err("RESET");
   pegs=[[17.88,-11],[8.8,4.72],[-0.28,-11],[4.26,-3.14],[13.34,-3.14],[15.61,-7.07],[8.8,-3.14],[8.8,-11],[6.53,-7.07],[1.99,-7.07],[4.26,-11],[13.34,-11],[6.53,0.79],[11.07,0.79],[11.07,-7.07]] ;
   active=pegs--[pegs_(randomint(15)+1)];
   special=[];
)



;
