upperleft=(screenbounds()_1).xy;
upperright=(screenbounds()_2).xy;
lowerright=(screenbounds()_3).xy;
lowerleft=(screenbounds()_4).xy;
offset = upperright-(18.2,11);
Z.size=9;
Zsat.size=9;
Zdark.size=9;
Zalpha.size=9;
Zblur.size=9;
D.xy=(0,0);

if(lastoffset!=offset,
forall([X,Y,Z,Xsat,Ysat,Zsat,Xdark,Ydark,Zdark,Xalpha,Yalpha,Zalpha,Xblur,Yblur,Zblur],el,
el.xy = el.xy + (offset-lastoffset);
);
);
lastoffset = offset;


if(|D-F|>7.8,F.xy=D+(F-D)/|F-D|*7.8);
if(|D-F|<2,F.xy=D+(F-D)/|F-D|*2);

//fillcircle((0,0),100);

Dummy.xy=(-10,-10);
if(Z.x<X.x,Z.xy=X.xy);
if(Z.x>Y.x,Z.xy=Y.xy);
if(Zsat.x<Xsat.x,Zsat.xy=Xsat.xy);
if(Zsat.x>Ysat.x,Zsat.xy=Ysat.xy);
if(Zdark.x<Xdark.x,Zdark.xy=Xdark.xy);
if(Zdark.x>Y.x,Zdark.xy=Ydark.xy);
if(Zalpha.x<Xalpha.x,Zalpha.xy=Xalpha.xy);
if(Zalpha.x>Y.x,Zalpha.xy=Yalpha.xy);
if(Zblur.x<Xblur.x,Zblur.xy=Xblur.xy);
if(Zblur.x>Yblur.x,Zblur.xy=Yblur.xy);
size=(|X,Z|/|X,Y|)^1.5*2+.03;
color=cols_pencolor;
setdot();

sat=|Xsat,Zsat|/|Xsat,Ysat|;
dark=|Xdark,Zdark|/|Xdark,Ydark|;
alpha=(|Xalpha,Zalpha|/|Xalpha,Yalpha|)^2*.95+.05;
blur=(|Xblur,Zblur|/|Xblur,Yblur|);
E.xy=D+gauss(complex(F-D)*i);

setcols(sat,dark);

quadrat=[D.xy,F.xy,E.xy];




cell=quadrat;
bas=inverse(transpose([cell_2-cell_1,cell_3-cell_1]));

wsi=11;
predrawing();
posa=F.xy;
posb=D.xy;
drawtile();



//javascript("callhandle()");



colorplot(
position = #;//TODO?
z = complex(position-posb)/complex(posa-posb)*2;
z = complex([re(z)/str_1, im(z)/str_2]);
//z = z*complex((1.0,-1.0))/2+i;
z = z/2;
annotcol= imagergba((0,0),(1,0),"annot", z, repeat->true);
piccol = imagergba((0,0),(1,0),"tile", z, repeat->true);
annotcol*annotcol_4+(1-annotcol_4)*piccol;
);


drawing();
