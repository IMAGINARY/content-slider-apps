if(resetpossible & |mouse().y-SIZE/2+1|<2 & mouse().x<.5, reset(lastk));
if(mode == "select" & |mouse()-P2|>1,
forall(1..length(pos),k,
 if(|pos_k-mouse().xy|<.5,
    sel = k;
   );
);
);
