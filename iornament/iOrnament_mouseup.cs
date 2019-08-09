
      //	stopWebGL();
if(dragging,
   strokelist=strokelist++[stroke];
);

dragging=false;

hits=select(1..ncols,y,
   |colpos_y,shiftedmouse().xy|<1
);
if(length(hits)==1,pencolor=hits_1;color=cols_pencolor;setdot());

hits=select(1..17,y,
   |grouppos_y,shiftedmouse().xy|<1
);
if(length(hits)==1,
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
