sx = mouse().x;
sy = mouse().y;
dragging = sx < .5 & sx > -.5 ;
br = 0.1;
forall(1..9,k,
  if(|mouse().xy,poss_k|<0.1, select(k));
);

idleanimation = idleanimation & !dragging;
