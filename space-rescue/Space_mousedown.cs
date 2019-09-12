if(resetpossible & |mouse().y-1.25|<.75 & |mouse().x-(SIZE+1.75)|<.75, reset(lastk));
if(mode == "select" & |mouse()-P2|>1,
forall(1..length(pos),k,
 if(|pos_k-mouse().xy|<.5,
    sel = k;
   );
);
);
