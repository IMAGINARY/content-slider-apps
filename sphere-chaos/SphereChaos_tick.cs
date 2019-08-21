if(idle==1,
   ttt=0.1;
      E.xy=gauss(complex(E-D)*exp(.03*i*ttt))+D;
 );
if(mousedown==0,
  colrot=colrot+0.25;
  if(colrot>=150,colrot=0);
);
