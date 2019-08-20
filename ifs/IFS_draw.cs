exalpha = sqrt(clamp(1-(seconds()-waittime)/explaintime)*clamp(seconds()/waittime));

if(idleanimation,
  forall(allpoints(),p,
    omega = sin((p:"xy0")_1*1000)/2;//some "random-deterministic" value for each point;
    radius = .05*smoothclamp((seconds()-waittime-explaintime)/5);
    p.xy = p:"xy0" + radius*(cos(omega*seconds()),sin(omega*seconds()));
  );
  framecnt = 0;
);


static = framecnt>200 & exalpha<.001;

if(static,
  pauseanimation();
  errc("paused IFS because it is likely to be satic.");
);
framecnt = framecnt+1;

snap();
gentrafos();
N = length(Trafos);


clearimage("seed");
canvas(L,R,"seed",
   scene();
);


mp = min(Trafos, T, 1/(|det(T)|))*1.5;
nsamples = 20;
samplescale = .6/sqrt(nsamples);
colorplot((0,0),(1,0),"CF",
  //cavg = sum(1..3, j, imagergb((0,0),(1,0),"ifs",pts_j+(0.52,0.55)))/3;
  cavg = [0,0,0];
  repeat(nsamples, j,
    phi = j*137.507764°;
    cavg = cavg + imagergb((-1,-1),(1,-1),"ifs", samplescale*re(sqrt(j))*(cos(phi), sin(phi))); //some random sample points
  );
  cavg = cavg/nsamples;
  CF = imagergb((-1,-1),(1,-1),"CF",.00001*#).r;
  (.9*CF+.1*|cavg|/mp)
);


colorplot(L,R,"ifs",
          color = imagergb(L,R,"seed",#);
          CF = imagergb((-1,-1),(1,-1),"CF",.00001*#).r;
          forall(1..N, k,
                 other = imagergb(Trafos_k*L, Trafos_k*R, "ifs", #);
                 color = color + ((1-CF)*1.1+CF/N)*other;
                );
          color*(1-((#*#)/(K*K))^2); //fade out
         );
drawimage(L,R,"ifs");



if(exalpha>0.01,
  //t = mod(seconds(),2)/2;
  t = -cos(max(0,seconds()-waittime))/2+.5;
  iTrafos = t*apply(Trafos, T, T/T_3_3)+(1-t)*apply(Trafos,[[1,0,0],[0,1,0],[0,0,1]]); //mix with identity
  colorplot(L,R,"anim",
    color = [0,0,0];
    CF = imagergb((-1,-1),(1,-1),"CF",.00001*#).r;
    forall(1..N, k,
     other = imagergb(iTrafos_k*L, iTrafos_k*R, "ifs", #);
     color = color + ((1-t)/N+t*1)*((1-CF)*1.1+CF/N)*other;
    );
    exalpha*[color_1, color_2, color_3, 1];//fade background
  );
  drawimage(L,R,"anim");

);



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
