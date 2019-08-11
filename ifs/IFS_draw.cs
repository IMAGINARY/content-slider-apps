snap();
gentrafos();
N = length(Trafos);
forall(1..N,k,
     Trafos_k = Trafos_k/(Trafos_k_3_3);
);
//factors = apply(Trafos, T, min(1.1,-.2+.1*sin(seconds())+sqrt(|det(T)|)));

//factors = .99*factors/sum(factors);

//clearimage("seed");

factors = AF*apply(Trafos, T, min(MF,sqrt(|det(T)|)));

//v = 0.3+.1*sin(seconds());
//v = 1;
factors = (1-NC)*factors+NC*factors/sum(factors);

clamp(v) := min(max(0,v),1);

clearimage("seed");
canvas(L,R,"seed",
   scene();
);
colorplot(L,R,"ifs",
          color = imagergba(L,R,"seed",#);
          p = [#_1,#_2,1];
          forall(1..N, k,
                 other = imagergba(L,R,"ifs",Trafos_k*[#_1,#_2,1]);
                 color = color + factors_k*other;
                );
          color*(1-((#*#)/(K*K))^2); //fade out

         );
drawimage(L,R,"ifs");
//drawtext((0,0), factors, color->[1,0,1]);



ims = 0.14;
forall(1..5,k,
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
