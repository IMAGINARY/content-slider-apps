fieldtype = randomint(3); //every day another field

resetfield() := (
  if(fieldtype==0,
    //Triangular
    unit=4.54;
    pegs=[[17.88,-11],[8.8,4.72],[-0.28,-11],[4.26,-3.14],[13.34,-3.14],[15.61,-7.07],[8.8,-3.14],[8.8,-11],[6.53,-7.07],[1.99,-7.07],[4.26,-11],[13.34,-11],[6.53,0.79],[11.07,0.79],[11.07,-7.07]] ;
    active=pegs--[pegs_(randomint(15)+1)];
  );

  if(fieldtype==1,
    // English style
    unit = 3.5;
    pegs = (directproduct(-3..3,-1..1)++directproduct(-1..1,(-3..-2)++2..3));
    active = pegs -- [(0,0)];
    delta = (2.5,-.5);
    pegs = unit*apply(pegs, #+delta);
    active = unit*apply(active, #+delta);
  );
  if(fieldtype==2,
    // French (European) style, 37 holes, 17th century;
    unit = 3.5;
    pegs = (directproduct(-3..3,-1..1)++directproduct(-1..1,(-3..-2)++2..3)++directproduct([-2,2],[-2,2]));
    start = [1,0];
    if(random()>0.5, start=-start);
    if(random()>0.5, start=start_[2,1]);
    active = pegs -- [start];
    delta = (2.5,-.5);
    pegs = unit*apply(pegs, #+delta);
    active = unit*apply(active, #+delta);
  );
);


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
      resetclock(); middleanimation = true;
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
//rect=[[23,-4],[26,-4],[26,-1],[23,-1]];
rect=[[25,-16],[29,-16],[29,-12],[25,-12]];
pressed=false;

moving=false;
  pos=(0,0);

special=[];

getomega0(p) := (
  sin(p*[-22*pi*121,32])/4; //something small random based on the position;
);
drawpeg(p):=(
 /*gsave();
 clip(circle(p+(0.2,-0.2),2.4));
 drawimage(A,B,"boardB");
 grestore();*/
 //fillcircle(p,unit/2,color->[1,.3,0], alpha->.5);
 d1 = [-unit/2,-unit/2]; d2 = [unit/2,-unit/2];

 d1 = gauss(complex(d1*exp(i*getomega0(p))));
 d2 = gauss(complex(d2*exp(i*getomega0(p))));
 if(gameend,
    d1 = gauss(complex(d1*exp(i*seconds())));
    d2 = gauss(complex(d2*exp(i*seconds())));
 );
 drawimage(p+d1,p+d2, "peg");
);

drawemptypeg(p):=(
 d1 = [-unit/2,-unit/2]; d2 = [unit/2,-unit/2];
 drawit = true;
 if(middleanimation & seconds()<1, if(p==middle_1,
   drawit = false;
   drawimage(p+d1,p+d2, "emptypeg", alpha->seconds());
   d1 = gauss(complex(d1*exp(i*getomega0(p))));
   d2 = gauss(complex(d2*exp(i*getomega0(p))));
   omega = sin(p*[21,12]); //almost random but constant in time
   d1 = gauss(complex(d1*exp(omega*i*seconds())))*(.5+.5*cos(pi*seconds()));
   d2 = gauss(complex(d2*exp(omega*i*seconds())))*(.5+.5*cos(pi*seconds()));
   drawimage(p+d1,p+d2, "peg"); drawit = false;
 ), middleanimation = false;);

 if(drawit,
  drawimage(p+d1,p+d2, "emptypeg");
 );
);

drawspecial(pp):=(

  if(special!=[],
    //gsave();
    diff=pp-pos;

    off=(0,0);
    /*fill(circle(special+diff+off,1.75),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.7),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.65),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.6),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.55),color->(.5,0,0),alpha->.1);
    fill(circle(special+diff+off,1.5),color->(.5,0,0),alpha->.1);*/
  /*  clip(circle(special+diff,2.4));
    drawimage(A+diff,B+diff,"boardAX");
    fill(circle(special+diff,1.5),color->(0,0,0),alpha->.1);
    grestore();
*/
  //  fillcircle(pp,unit/2,color->[1,.3,.5], alpha->.5);

  //shadow
    forall(unit/10/2*(5..12),r,
      fillcircle(pp,r,color->(0,0,0),alpha->.02);
    );

    drawimage(pp+[-unit/2,-unit/2],pp+[unit/2,-unit/2], "peg");
  );
);



drawstuff(mp):=(
//clrscr();

 //drawimage(A,B,"boardC");
 apply(active,p,drawpeg(p));
 apply(pegs -- active,p,drawemptypeg(p));

 if(special!=[],
  posmo= possiblemoves(special);
  apply(posmo,
    drawpos(#);
  );
 );
 drawspecial(mp);
 gameend = !moving&!stillpossible();

 if(gameend,
    playanimation();
    if(length(active)==1,
      drawtext((-9,-14),"Gewonnen!",color->(1,1,1),size->50);
      ,
      drawtext((-9,-14),"Ende:" + newline + length(active)+" sind übrig",color->(1,1,1),size->50);
    );
 );
);


drawwaterring(pp, t) := (
  forall(1..9,k,
    drawcircle(pp,unit/2*t,size->3*k,color->(.5,.5,.6),alpha->.1*(.5-.5*cos(t*2*pi)));
  );
);
drawpos(pp):=(
    /*off=(.1,-.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->9*3,alpha->0.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->7*3,alpha->0.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->5*3,alpha->0.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->3*3,alpha->0.1);
    drawcircle(#+off,2,color->(0,0.5,0.2),size->1*3,alpha->0.1);*/
    drawwaterring(pp, mod(seconds()/2,1));
    drawwaterring(pp, mod(seconds()/2+1/2,1));

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
   gameend = false;
   middleanimation = false;
   //pegs=[[17.88,-11],[8.8,4.72],[-0.28,-11],[4.26,-3.14],[13.34,-3.14],[15.61,-7.07],[8.8,-3.14],[8.8,-11],[6.53,-7.07],[1.99,-7.07],[4.26,-11],[13.34,-11],[6.53,0.79],[11.07,0.79],[11.07,-7.07]] ;
   resetclock();
   resetfield();
   special=[];
   pauseanimation();
);

reset();
