// GLOBALS BEGIN

// will be set in reset()
levels=[];
carpermutations=[];
truckpermutations=[];

cars=[];
trucks=[];
my=[];

downpending=false;
moving=false;
solved=false;

sliderindexold=-1; // invalid old slider index, such that comparing it with any new index will always be false
startindex=1;
alldata=[];
special=[];
oldcar=[];
interval=[0,0];
move=["",""];
// GLOBALS END

upaction():=(
if(moving,
//  move=(mouse().xy-pos)/2;
  special_1=round(special_1);
  special_2=round(special_2);
  alldata=alldata++[special];
  moving=false;
  if(round(move)!=(0,0),
   if(special_3!="my",
    // playtone(60,channel->9),
     if(special_1==(5,4),
     //  playtone(67,channel->9),
     //  playtone(62,channel->9);
     )
    )
  );

  special=[];

);
downpending=false;

);

downaction():=(
regional(hotlist,rest);
hotlist=select(1..length(alldata),ishot(mouse().xy,alldata_#));
moving=false;
if(length(hotlist)==1,
  special=alldata_(hotlist_1);
  rest=1..length(alldata)--[hotlist_1];
  alldata=apply(rest,alldata_#);
  moving=true;
  pos=mouse().xy;
  oldcar=special;
  interval=getinterval(special);

);


);

pl(a,b):=(
   regional(d);
   regional(dd);
   d=.84;
   dd=.9;
   fillpolygon(
     [[a+dd,b+dd],[a-dd,b-dd],[a-dd,b+dd]],color->(1,1,1)*.7);
   fillpolygon(
     [[a+dd,b+dd],[a+dd,b-dd],[a-dd,b-dd]],color->(1,1,1)*.3);
   fillpolygon(
     [[a+d,b+d],[a+d,b-d],[a-d,b-d],[a-d,b+d]],color->(1,1,1)*.6);
);

drawcar(B,A,name):=(
  regional(diff,p1,p2);
  diff=B-A;
  p1=diff/|diff|;
  p2=perp(p1);
  p2=p2*1.1;
  p1=p1*1;
  drawimage(A-p1+p2,B+p1+p2,A-p1-p2,name);
  drawimage(A-p1+p2,B+p1+p2,A-p1-p2,"a6",alpha->0.3);
);


drawtruck(A,B,name):=(
  regional(diff,p1,p2);
  diff=B-A;
  p1=diff/|diff|;
  p2=perp(p1);
  p2=p2*1.2;
  p1=p1*1;
  drawimage(A-p1+p2,B+p1+p2,A-p1-p2,name);
  drawimage(A-p1+p2,B+p1+p2,A-p1-p2,"t7",alpha->0.3);
);

drawmy(A,B,name):=(
  regional(diff,p1,p2);
  diff=B-A;
  p1=diff/|diff|;
  p2=perp(p1);
  p2=p2*1.1;
  p1=p1*1;
  drawimage(A-p1+p2,B+p1+p2,A-p1-p2,name);
);

drawobj(obj,al):=(
  drawobj(obj_1*2+(1,1),obj_2*2+(1,1),obj_3,al)
);
drawobj(a,b,name,al):=(
  alpha(al);
  if(name_1=="a",drawcar(a,b,name));
  if(name_1=="t",drawtruck(a,b,name));
  if(name_1=="m",drawmy(a,b,name));
  alpha(1);
);

shuffle(list):=(
  regional(l);
  l=apply(1..length(list),random());
  sort(list,l_#);
);

car(i):="a"+carsl_i;
truck(i):="t"+trucksl_i;

devlevel(lev):=(
  cars=apply(1..length(lev_1),[lev_1_#_1,lev_1_#_2,car(#)]);
  trucks=apply(1..length(lev_2),[lev_2_#_1,lev_2_#_2,truck(#)]);
  my=apply(1..length(lev_3),[lev_3_#_1,lev_3_#_2,"my"]);
  alldata=cars++trucks++my;
  solved=false;
);

startlevel(levelnum):=(
  carsl = carpermutations_levelnum;
  trucksl = truckpermutations_levelnum;
  devlevel(levels_levelnum);
  special=[];
);

ishot(p,car):=(
  regional(a,b,diff,st,en,lot);
  a=car_1*2+(1,1);
  b=car_2*2+(1,1);
  diff=(b-a);
  diff=diff/|diff|;
  st=a-diff;
  en=b+diff;
//  draw(st,en);
  lot=meet(join(st,en),perp(join(st,en),p)).xy;
  |st,en|>|lot,en| & |st,en|>|lot,st| & |lot,p|<1;
);

restrict(int,a):=(
  min(max(int_1,a),int_2)
);

accident(a1,a2,b1,b2):=(
  regional(la,lb,cr);
  la=[a1,(a1+a2)/2,a2];
  lb=[b1,(b1+b2)/2,b2];
  cr=false;
  apply(la,a,apply(lb,b,cr=or(cr,|a,b|<0.1)));
  cr;
);

crash(p1,p2):=(
  regional(cr);
  cr=false;
  forall(alldata,
    cr=or(cr,accident(p1,p2,#_1,#_2));
  );
  cr=or(cr,contains(p1++p2,0));
  cr=or(cr,contains(p1++p2,7));
  cr;
);

vert(car):=(
  regional(min,max);
  min=0;
  while(!crash(car_1-(min+1,0),car_2-(min+1,0)),min=min+1);
  max=0;
  while(!crash(car_1+(max+1,0),car_2+(max+1,0)),max=max+1);
  [-min,max]
);


hor(car):=(
  regional(min,max);
  min=0;
  while(!crash(car_1-(0,min+1),car_2-(0,min+1)),min=min+1);
  max=0;
  while(!crash(car_1+(0,max+1),car_2+(0,max+1)),max=max+1);
  [-min,max]
);

getinterval(car):=(
  regional(erg);
  if(car_1_1==car_2_1,erg=hor(car));
  if(car_1_2==car_2_2,erg=vert(car));
  erg;
);

snapslider():=(
  // move N on the line to the position that belongs to its index
  moveto(N,M+(getsliderindex()/(length(levels)-1))*(L-M));
);

setsliderindex(index):=(
  regional(boundedindex);
  boundedindex=max(0,min(index,length(levels)-1));
  moveto(N,M+(boundedindex/(length(levels)-1))*(L-M));
);

getsliderindex():=(
  regional(vecML);
  regional(vecMN);
  regional(t);

  // compute the projection parameter of N onto ML
  vecML=(L-M).xy;
  vecMN=(N-M).xy;
  t=(vecMN*vecML)/(vecML*vecML);

  // this is the index
  round(t*(length(levels)-1));
);

processslider():=(
  regional(sliderindex);
  snapslider();
  sliderindex=getsliderindex();
  if(sliderindex!=sliderindexold,
    startlevel(sliderindex+1);
    sliderindexold=sliderindex;
  );
);

allthedrawing():=(
regional(h);
processslider();
clrscr();
drawtext(M+(.5,0),"leicht",color->(1,1,1),size->26);
drawtext(L+(.5,0),"schwer",color->(1,1,1),size->26);
//  drawtext(M+(-0.2,-1),"Schwierigkeitsgrad",color->(1,1,1),size->26);

fillpolygon(apply([A,B,C,D,E,F],#+(.03,-.03)),color->(1,1,1)*.0);

connect(apply([A,B,C,D,E,F],#+(.03,-.03)),size->17,color->(1,1,1)*.7);
connect(apply([A,B,C,D,E,F],#-(.03,-.03)),size->17,color->(1,1,1)*.3);
connect([A,B,C,D,E,F],size->13,color->(1,1,1)*.6);

repeat(6,i,
  repeat(6,j,
    pl(2*i+1,2*j+1);
  )
);

apply(1..length(levels),#,
  h=L.y+(#-1)*(M.y-L.y)/(length(levels)-1);
  draw((M.x-.2,h),(M.x+.2,h),color->(1,1,1));
);


apply(alldata,c,drawobj(c,1));

if(special!=[],
 drawobj(special,.9);
);
);

antiprismc(a,b,c):=(
  regional(xx,yy);
  xx=|a-b|^2;
  yy=|a-c|^2;
  if(yy==0,b,((a*b*xx)-(b*c*xx)-(a*c*yy)+(b*c*yy))/(a*xx-c*xx-a*yy+b*yy));
);

tractrix(a,b,c):=(
  regional(rb,rd);
  rb=a+(b-a)*2;
  rd=antiprismc(a,rb,c);
  (c+rd)/2;
);


push(p):=(
  regional(pa,pb,pc,pd);
  pa=special_1;
  pb=special_2;
  pc=pb+p;
  pd=gauss(tractrix(complex(pb),complex(pa),complex(pc)));
  special=[pd,pc,special_3]
);

pull(p):=(
  regional(pa,pb,pc,pd);
  pa=special_2;
  pb=special_1;
  pc=pb+p;
  pd=gauss(tractrix(complex(pb),complex(pa),complex(pc)));
  special=[pc,pd,special_3]
);

solvedsequence():=(

    if(solved,
    animation=apply(1..round((8-special_1_1)/0.2),((0.2,0),"Push"))
    ++apply(1..15,((0,0.2),"Pull"))
    ++apply(1..23,((0,-0.2),"Push"))
    ++apply(1..10,w=#*90°/10,((0,-0.2),"Push"))
    ++apply(1..40,((-.3,0),"Push"));
    startindex=1;
    playanimation()
  );
//  solved=false;
//  special=[];
);

reset():=(
    // select new set of randomly chosen levels and select the one that matches the current difficulty
    levels = getshuffledlevels();
    sliderindexold=-1;

    // shuffle car and truck colors
    carpermutations = apply(1..length(levels),shuffle(1..12));
    truckpermutations = apply(1..length(levels),shuffle(1..7));

    // redraw everything
    allthedrawing();
    pauseanimation();
);

reset();
