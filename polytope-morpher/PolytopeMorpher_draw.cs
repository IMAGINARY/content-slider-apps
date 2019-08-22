Dummy.xy=(0,0);
if(O.x<=M.x,O.xy=M.xy);
if(O.x>=N.x,O.xy=N.xy);
if(P.x<=G.x,P.xy=G.xy);
if(P.x>=K.x,P.xy=K.xy);
if(L.x<=A.x,L.xy=A.xy);
if(L.x>=C.x,L.xy=C.xy);

if(W.y<=U.y,W.xy=U.xy);
if(W.y>=V.y,W.xy=V.xy);



//layer(0);
clrscr();
//errf(c):=errc(c);
errf(c):=();
//err("A1 "+seconds());
//err(choice);
//err(tchoice);

if(choice==0,definebody(cell4));
if(choice==1,definebody(cell6));
if(choice==2,definebody(cell8));
if(choice==3,definebody(cell12));
if(choice==4,definebody(cell20));

if(choice==6,definebody(special));

Rot.xy=(Rot-H)/|Rot-H|*2.5+H;
Span.xy=(Span-H)/|Span-H|*2.5+H;
diff=(Rot-H);
diff=diff/|diff|;
rotangle=arctan2(diff);

if(mover()==Rot,
  Span.xy=H+gauss(complex(diff)*exp(i*oldangle))*2.5
);

diff=(Span-H);
diff=diff/|diff|;
spanangle=arctan2(diff);


oldangle=spanangle-rotangle;


colspan=if(spanangle<rotangle,oldangle+2*pi,oldangle);
angle=rotangle;


//angle=0;
//colspan=1.5;
colparams=(colspan,angle);

alpha=|U,W|/|U,V|;


col1=[0,0,1];
col2=[.1,1,0]*0;
col3=[1,0,1]*0;
actcol=(1,1,1);


col1=[.9,.9,1]*.5;
col2=[1,.9,.9]*.5;
col3=[1,1,1]*0;
actcol=(.5,.8,1);


amb=0.2;

lights=[
   [[-cos(30°),-sin(30°),-.5],col1],
   [[-cos(150°),-sin(150°),-.5],col2],
   [[-cos(270°),-sin(270°),-.5],col3]
];
ambient=(1,1,1)*amb;







param1=|G,P|/|G,K|;
param2=|A,L|/|A,C|;
param3=|M,O|/|M,N|;

if(mover()==P & |param1+param3-1|<0.02,param1=1-param3;P.xy=param1*K+(1-param1)*G);
if(mover()==O & |param1+param3-1|<0.02,param3=1-param1;O.xy=param3*N+(1-param3)*M);




paramv=(choice,param1,param2,param3,colspan,angle);

expandfactor=(3,2,1.5,1+tau^2,1+tau^4,0,1.5);
deformface(body,f):=(

  center=sum(f,body_#)/length(f);
  firstdeform=apply(f,(1-param1)*body_#+param1*center);
  firstdeform=firstdeform++[firstdeform_1];
  seconddeform=apply(1..length(f),mid=(firstdeform_#+firstdeform_(#+1))/2;
    [
      (1-param2)*firstdeform_#+param2*mid
,
      (1-param2)*firstdeform_(#+1)+param2*mid
    ]
  );
  seconddeform=flatten(seconddeform,levels->1);
  apply(1..2*length(f),seconddeform_#)++[(1-param3)*center+expandfactor_(choice+1)*param3*center];
);

deform(body,faces):=(
                     flatten(apply(faces,f,
                                   center=sum(f,body_#)/length(f);
                                   fcache=apply(f,(1-param1)*body_#+param1*center);
                                   apply(cycle(fcache),
                                         mid=((#_1)+(#_2))/2;
                                         [(1-param2)*(#_1)+param2*mid,
                                          (1-param2)*(#_2)+param2*mid]
                                         ) :> [(1-param3)*center+expandfactor_(choice+1)*param3*center]
                                   ), levels->2)
                     );

deformX(body,faces):=(

  count=0;
  forall(faces,f,
     center=sum(f,body_#)/length(f);
     nf=0;
     forall(f,nf=nf+1;fcache_nf=(1-param1)*body_#+param1*center;);
     fcache_(nf+1)=fcache_1;
     repeat(nf,
        mid=((fcache_#)+(fcache_(#+1)))/2;
        count=count+1;
        cache_count=(1-param2)*fcache_#+param2*mid;
        count=count+1;
        cache_count=(1-param2)*fcache_(#+1)+param2*mid;
     );
     count=count+1;
     cache_count=(1-param3)*center+expandfactor_(choice+1)*param3*center;
   );
   cache_(1..count);
);



if(|paramv,oldparamv|>0.0001,
errf("A1 "+seconds());
objx=deform(body,faces);
errf("A2 "+seconds());


init=0;
if(length(objx)>3,



 ch=convexhull3d(objx);
errf("A3 "+seconds());

 obj=ch_1*2;


//err(length(obj));

 ff=ch_2;
//if(ff!=ffold,err(ff));
ffold=ff;

 actcol=(.5,.8,1);

 ff=apply(ff,reverse(#));




 faces=apply(ff,[#,colorf(obj,#)]);
// faces=apply(ff,[#,(0,1,1)]);

 oldparamv=paramv;

 );
  object(obj,faces);
);//End recalc
errf("A4 "+seconds());

//err("A3 "+seconds());

gsave();
translate((1.3,-1.5));
 render3d();

grestore();

errf("A5 "+seconds());


//err("A4 "+seconds());









//drawpoly(((15,-4),(100,-4),(100,20),(15,20)),color->(0.3,0.4,0.5));

colchoice(i):=if(i==choice,(1,1,1),(1,1,1)*.5);

//drawtext((15,8),"Tetraeder",size->14,color->colchoice(0));
//drawtext((15,6.5),"Würfel",size->14,color->colchoice(1));
//drawtext((15,5),"Oktaeder",size->14,color->colchoice(2));
//drawtext((15,3.5),"Dodekaeder",size->14,color->colchoice(3));
//drawtext((15,2),"Ikosaeder",size->14,color->colchoice(4));





repeat(round(colspan/3°)-1,i,
  draw(
   H+(0,0.05)+|Rot-H|*(cos(i*3°+angle),sin(i*3°+angle)),
   H+(0,0.05)+|Rot-H|*(cos(i*3°+angle-3°),sin(i*3°+angle-3°)),
   color->(1,1,1),size->6);
);




//drawtext((14,9.5),"Starter:",color->(1,1,1),size->33);
drawtext((14,-2.5),"Flächen schrumpfen",color->(1,1,1),size->20);
drawtext((14,-4.5),"Punkte auf Kante verschieben",color->(1,1,1),size->20);
drawtext((14,-0.5),"Flächenmitten herausziehen",color->(1,1,1),size->20);
off=(-.05,0);
w=1.8;

//layer(4);


if(choice==0,highlight(C4));
if(choice==1,highlight(C6));
if(choice==2,highlight(C8));
if(choice==3,highlight(C12));
if(choice==4,highlight(C20));
if(choice==6,highlight(Wand));


//drawtext((1.5,-12.5),"Körper durch Anfassen bewegen",color->(1,1,1),align->"center",size->20,family->"Arial");



ss=1.5;
drawimage(Wand,"image1",scale->ss);
drawimage(C4,"image2",scale->ss);
drawimage(C6,"image3",scale->ss);
drawimage(C8,"image4",scale->ss);
drawimage(C12,"image5",scale->ss);
drawimage(C20,"image6",scale->ss);
drawimage(H,"image8",scale->1.1*ss);

if(length(objx)>1500,dehighlight(Wand));



pendinganimation=true;
