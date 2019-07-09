if(moving,

  move=(mouse().xy-pos)/2;
  rmove=round(move);
  dir=special_2-special_1;
  if((dir_1~=0) & (|rmove.y,move.y|<0.2),move=rmove);
  if((dir_2~=0) & (|rmove.x,move.x|<0.2),move=rmove);
  if(special_1_1==special_2_1,move_1=0;move_2=restrict(interval,move_2));
  if(special_1_2==special_2_2,move_2=0;move_1=restrict(interval,move_1));

  special_1=oldcar_1+move;
  special_2=oldcar_2+move;

);
if(special!=[],



  if(!solved&special_3=="my"&special_1_1>4&special_1_1<6,
     solved=true;
     solvedsequence();
     moving=false;

  )
);

;
