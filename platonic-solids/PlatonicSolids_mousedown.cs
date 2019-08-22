dragging=false;
if(|mouse().x|<13,
 startx=mouse().x;
 starty=mouse().y;
 //dragging=|mouse().xy,S|>.3
 dragging = true;
//&|mouse().xy,X|>.3
//&|mouse().xy,C|>.3
;
);
presstime=seconds();
presspos=mouse().xy;

if(|mouse().xy-NoEdges|<3,edges=false);
if(|mouse().xy-YesEdges|<3,edges=true);


addseq(i):=if(i!=sequenz_(-1)&length(sequenz)<maxdepth+1,sequenz=sequenz++[i]);

if(|mouse().xy-C4|<3,addseq(1));
if(|mouse().xy-C6|<3,addseq(2));
if(|mouse().xy-C8|<3,addseq(3));
if(|mouse().xy-C12|<3,addseq(4));
if(|mouse().xy-C20|<3,addseq(5));


if((|mouse().xy-DelOut|<3)&(length(sequenz)>1),sequenz=apply(2..length(sequenz),sequenz_#));
if((|mouse().xy-DelIn|<3)&(length(sequenz)>1),sequenz=apply(1..length(sequenz)-1,sequenz_#));
