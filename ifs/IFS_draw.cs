snap();
gentrafos();
N = length(Trafos);

clamp(v) := min(max(0,v),1);

clearimage("seed");
canvas(L,R,"seed",
   scene();
);

colorplot(L,R,"ifs",
          color = imagergb(L,R,"seed",#);
          forall(1..N, k,
                 other = imagergb(Trafos_k*L, Trafos_k*R, "ifs", #);
                 color = color + ((1-CF)*1.3+CF/N)*other;
                );
          color*(1-((#*#)/(K*K))^2); //fade out
         );
drawimage(L,R,"ifs");

pts = directproduct(-1..1,-1..1)/3;

cavg = sum(pts, p, imagergb(L,R,"ifs",p+(0.02,0.05)))/length(pts);
CF = clamp(.9*CF+.1*|cavg|);


ims = 0.14;
forall(1..length(poss),k,
  drawimage(poss_k+(-ims,-ims),poss_k+(ims,-ims),"im"+k,alpha->if(sel==k,1,.6));
);

//highlight selected
connect(
    (
      poss_sel+0.15*(1,1),
      poss_sel+0.15*(-1,1),
      poss_sel+0.15*(-1,-1),
      poss_sel+0.15*(1,-1),
      poss_sel+0.15*(1,1)
  ),color->(1,1,1)*.7,size->2
);
