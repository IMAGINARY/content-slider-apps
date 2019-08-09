

if(dragging,
   strokelist=strokelist++[stroke];
);

dragging=false;

hits=select(1..ncols,y,
   |colpos_y,shiftedmouse().xy|<2
);
hits=sort(hits,|colpos_#,shiftedmouse().xy|);
if(length(hits)>=1,pencolor=hits_1;color=cols_pencolor;setdot());

hits=select(1..17,y,
   |grouppos_y,shiftedmouse().xy|<1
);
hits=sort(hits,|grouppos_#,shiftedmouse().xy|);

resetdr=false;
if(length(hits)>=1,
  resetdr=true;
  group=hits_1;
  setgr(groups_group);
  resetdraw();
);


hits=select(1..6,y,
   |buttonpos_y,shiftedmouse().xy|<.7
);
if(length(hits)==1,
  hit=hits_1;
  if(buttons_hit=="trash",
    strokelist=[];
    reset();
  );
  if(buttons_hit=="undo",
    undo();
  );
  if(buttons_hit=="redo",
    redo();
  );
  if(buttons_hit=="fund",
    fundsel=!fundsel;
  );
  if(buttons_hit=="glow",
    glowing=!glowing;
    if(glowing,glow(),noglow());
  );
  if(buttons_hit=="sym",
    symannot=!symannot;
   // if(symannot,glow(),noglow());
  );
);


if(!resetdr,

st=mouse().xy;
  st=bas*(st-cell_1);

dragging=(mouse().x<10+offset.x );

if(|mouse().xy,F.xy|<1&fundsel,dragging=false);
if(|mouse().xy,D.xy|<1&fundsel,dragging=false);
if(dragging,
  clearredo();
  backup();
);
stroke=[[size,alpha,cols_pencolor,glowing,blur],[st]];
);
//draggingAction(st,st);
