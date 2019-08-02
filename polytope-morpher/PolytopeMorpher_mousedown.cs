damping=0.998;
startx=mouse().x;
starty=mouse().y;
dragging=
|mouse().xy,W|>.3
&|mouse().xy,O|>.3
&|mouse().xy,L|>.3
&|mouse().xy,P|>.3
&|mouse().xy,Rot|>.3&|mouse().xy,Span|>.3
&mouse().x<11;

presstime=seconds();

d=1.5;
prevchoice=choice;
if(|mouse().xy,C4|<2,choice=0;iterdepth=0);
if(|mouse().xy,C6|<2,choice=1;iterdepth=0);
if(|mouse().xy,C8|<2,choice=2;iterdepth=0);
if(|mouse().xy,C12|<2,choice=3;iterdepth=0);
if(|mouse().xy,C20|<2,choice=4;iterdepth=0);

if(|mouse().xy-Wand| < 1.2,magic());

if((prevchoice==6)&(choice!=6),
  P.xy=G.xy;
  L.xy=A.xy;
  O.xy=M.xy;
);
