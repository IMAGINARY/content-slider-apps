if(waiting,
   if(seconds()-timestamp>.5,
      waiting=false;
     // upaction();
   )
);
if(movingfilm,

animating=true;

animpos=animation_startindex;

//drawstuff(move);

startindex=startindex+1;
if(startindex>length(animation),
   movingfilm=false;
   stopanimation();
   animating=false;
   active=active++[special];
   special=[];
   drawstuff(move);
   )
);
