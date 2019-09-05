levels = getshuffledlevels();

gettargetsonray(d) := (
  targetsonray = select(pos, p,
                        delta = p-pos_sel;
                        if(d.x == 0,
                           delta.x == 0 & delta.y*d.y>0,
                           delta.y == 0 & delta.x*d.x>0
                          );
                       );
);

reset(k) := (

    SIZE = 7;
    TARGET = (4,4);
    pos = levels_k;
    posA = pos;
    posB = pos;

    sel = 0;
    resetpossible = false;
    resetalpha = 0;
    target = (0,0);

    mode = "select";
    T = 0;
    resetclock();playanimation();
);

computeP(k) := (
  lambda = (k-1)/(length(levels)-1);
  (1-lambda)*P0.xy+lambda*P1.xy
);

setk(k) := (
  P2.xy = computeP(k);
  if(k!=lastk,
    lastk = k;
    reset(k);
  );
);

isfree(f) := (
  regional(free);
  free = true;
  forall(pos, p, if(p==f, free=false));
  free
);
lastk = 0;
setk(1);

reset() := (
  setk(1);
);
