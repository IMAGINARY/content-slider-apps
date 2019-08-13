forall(1..length(poss),k,
  if(|mouse().xy,poss_k|<0.1, select(k));
);

idleanimation = false;
//forall(allpoints(), p, errc(p.name + ".xy = " + p.xy + ";"));
