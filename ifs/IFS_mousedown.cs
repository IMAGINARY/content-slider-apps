forall(1..9,k,
  if(|mouse().xy,poss_k|<0.1, select(k));
);


//forall(allpoints(), p, errc(p.name + ".xy = " + p.xy + ";"));
