//UI
forall(1..length(levels),k,
P = computeP(k);
draw(P + (-.1,0), P + (.1,0), color->[1,1,1]);
);


//snap
k = round(min(1,max(0,|P2,P0|/|P1,P0|))*(length(levels)-1))+1;
setk(k);


//reset text
if(resetpossible, drawtext((-.5,SIZE/2), size->140, "⟲", color->[1,1,1], alpha->resetalpha));

if(mode=="animation" & seconds()<T,
lambda = seconds()/T;
resetalpha = min(max(resetalpha, lambda),.8);
mpos = (1-lambda)*posA + lambda*posB;
,
mode = "select";
mpos = pos;
);



solved = (pos_1==TARGET);

connect([(1,1),(SIZE,1),(SIZE,SIZE),(1,SIZE),(1,1)], color->[1,1,1]);
drawcircle(TARGET,.55, size->4,color->[.6,.5,1], alpha->.7);
forall(mpos, p, if(p!=mpos_1, fillcircle(p,.5, color->[.9,.5,.1], alpha->.7)));
fillcircle(mpos_1, if(solved,1/(2+5*seconds()),.5), color->[.6,.5,1], alpha->.7);

if(sel>0,
fillcircle(mpos_sel,.3, color->[.8,0,0]);
forall([(-1,0),(1,0),(0,1),(0,-1)],d,
  if(gettargetsonray(d)!=[] & isfree(mpos_sel+d),
    draw(mpos_sel+.7*d,mpos_sel+1.2*d, color->[.8,0,0], size->6, arrow->true);
  );
 );
);

if(solved,
drawtext(TARGET, color->[1,1,1],"Level " + k +" gelöst!");
//fillcircle(TARGET,seconds(),color->[1,0,0], alpha->.3);
if(seconds()>2,
setk(mod(k, length(levels))+1)
);

);

//save ressources
if(mode!="animation" & !solved,
  pauseanimation();
);
