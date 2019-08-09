en=mouse().xy;
en=bas*(en-cell_1);

if(dragging,
 stroke_2=stroke_2++[en];
);

draggingAction(st,en);

if(mover()==F,
  dis=|F,D|;
  if(dis<1,F.xy=D+(F-D)/dis*1);
);

if(mover()==D,
    F.xy=D+olddist;
);

olddist=F-D;



st=en;
