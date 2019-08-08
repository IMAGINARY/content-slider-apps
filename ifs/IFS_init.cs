res = 512;

use8bittextures();

poss=(
 (0.65, .5),
 (0.85, .5),
 (1.05, .5),
 (0.65, .3),
 (0.85, .3),
 (1.05, .3),
 (0.65, .1),
 (0.85, .1),
 (1.05, .1)
);

sel=1;

sliders = (
  [PA,(0.6,-.2), (1.10,-.2), "Parameter $\alpha$"],
  [PB,(0.6,-.35), (1.10,-.35), "Transparenz"],
  [PC,(0.6,-.5), (1.10,-.5), "Zoom"]
);

L = (-1,-1);
R = (1,-1);


select(k) := (
  sel = k;
  if(sel==1,
    A.xy = [-0.1438, -0.6005];
    B.xy = [-0.0982, -0.1297];
    C.xy = [-0.2615, 0.0841];
    D.xy = [0.0708, 0.1087];
    scene() := (
      fillcircle((0,0),10, color->[1/255,2/255,0]);
      draw(A,B, size->10, color->[1,.4,.3]);
    );
    gentrafos() := (
      Trafos = [map(D,B,B,A), map(C,B,B,A)];
    );
  );
  if(sel==2,
    A.xy = [-1.75,0]/4;
    B.xy = [-1,1]/4;
    C.xy = [1,-1]/4;
    D.xy = [1.75,0]/4;
    scene() := (
      fillcircle((0,0),10, color->[1/255,2/255,3/255]);
    );
    gentrafos() := (
      Trafos = [map(A,B,A,D), map(B,C,A,D), map(C,D,A,D)];
    );
  );
  init();
);

init() := (
  clearimage("ifs");
  clearimage("seed");
);

createimage("ifs", res, res);
createimage("seed", res, res);
select(1);

applytrafo(T, p) := (
  h = T*[p_1,p_2,1];
  [h_1,h_2]/h_3;
);

pause():=(
  pauseanimation();
);

resume():=(
  playanimation();
);

restart() := (
  select(1);
);
