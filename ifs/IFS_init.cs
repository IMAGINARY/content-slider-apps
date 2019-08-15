
K = 1.5;
use8bittextures();
//res = 1024;
res = 2*K*screenresolution();
waittime = 1;
explaintime = pi;
poss=(
 (1.2, .6),
 (1.2, .3),
 (1.2, 0),
 (1.2, -.3),
 (1.2, -.6)
);
idleanimation=true;
paused = false;

sel=1;
framecnt = 0;

L = (-K,-K,1);
R = (K,-K,1);
select(k) := (
  sel = k;
  if(sel==1,
    used = [A,B,C,D];
    A.xy = [-0.1438, -0.6005]/.8;
    B.xy = [-0.0982, -0.1297]/.8;
    C.xy = [-0.2615, 0.0841]/.8;
    D.xy = [0.0708, 0.1087]/.8;
    scene() := (
      fillcircle((0,0),10, color->[1/255,2/255,0/255]);
      draw(A,B, size->10, color->[1,.4,.3]);
    );
    gentrafos() := (
      Trafos = [map(B, A, D, B), map(B, A, C, B)];
    );
    snap() := (
      if(|D,B|>|B,A|,
        D.xy = B.xy+|B,A|/|D,B|*(D.xy-B.xy);
      );
      if(|C,B|>|B,A|,
        C.xy = B.xy+|B,A|/|C,B|*(C.xy-B.xy);
      );
    );
  );
  if(sel==2,
    /*
       D
    A-B   C
       E
    */
    used = [A,B,C,D,E];
    A.xy = [-0.6102, -0.6148];
    B.xy = [-0.5046, -0.4246];
    C.xy = [0.4446, 0.488];
    D.xy = [-0.5969, -0.0351];
    E.xy = [-0.1151, -0.4051];
    scene() := (
      fillcircle((0,0),10, color->[0,1,0]/255);
      fillcircle(E.xy,.3, color->[3,0,0]/255);
      fillcircle(D.xy,.3, color->[0,0,3]/255);
      fillcircle(C.xy,.3, color->[3,2,0]/255);
      draw(A,B, size->10, color->[.6,.6,.5]);
    );
    gentrafos() := (
      Trafos = [map(A, C, B, C), map(A, C, B, D), map(A, C, B, E)];
    );
    snap() := (
      if(|D,B|>|A,C|/2,
        D.xy = B.xy+|A,C|/2/|D,B|*(D.xy-B.xy);
      );
      if(|E,B|>|A,C|/2,
        E.xy = B.xy+|A,C|/2/|E,B|*(E.xy-B.xy);
      );

    );
  );
  if(sel==3,
    used = [A,B,C,D,E];
    A.xy = [-1.5,0]/2;
    B.xy = [-0.5,0]/2;
    C.xy = [0,sqrt(3)/2]/2;
    D.xy = [0.5,0]/2;
    E.xy = [1.5,0]/2;
    scene() := (
      draw(A,B, color->[.5,.2,.4], size->30);
      draw(B,C, color->[.5,.2,.4], size->30);
      draw(C,D, color->[.5,.2,.4], size->30);
      draw(D,E, color->[.5,.2,.4], size->30);
    );
    gentrafos() := (
      Trafos = [map(A, E, A, B), map(A, E, B, C), map(A, E, C, D), map(A, E, D, E)];
    );
    snap() := (
      M = (A.xy+E.xy)/2;
      if(|B,M|>|A,M|,
        B.xy = M.xy+|A,M|/|B,M|*(B.xy-M.xy);
      );
      if(|C,M|>|A,M|,
        C.xy = M.xy+|A,M|/|C,M|*(C.xy-M.xy);
      );
      if(|D,M|>|A,M|,
        D.xy = M.xy+|A,M|/|D,M|*(D.xy-M.xy);
      );
    );
  );
  if(sel==4,
    used = [A,B,C,D];
    A.xy = [-1.75,0]/2.5;
    B.xy = [-1,1]/2.5;
    C.xy = [1,-1]/2.5;
    D.xy = [1.75,0]/2.5;
    scene() := (
      fillcircle((0,0),10, color->[1/255,2/255,3/255]);
      fillcircle((0,0), .4, color->[3,2,0]/255);
    );
    gentrafos() := (
      Trafos = [map(A, D, A, B), map(A, D, B, C), map(A, D, C, D)];
    );
    snap() := (
      M = (A.xy+D.xy)/2;
      if(|B,M|>|A,M|,
        B.xy = M.xy+|A,M|/|B,M|*(B.xy-M.xy);
      );
      if(|C,M|>|A,M|,
        C.xy = M.xy+|A,M|/|C,M|*(C.xy-M.xy);
      );
    );
  );
  if(sel==5,
    used = [A,B,C,D,E];
    A.xy = [-0.0639, -0.119];
    B.xy = [-0.6992, -0.1289];
    C.xy = [0.3234, 0.3398];
    D.xy = [-0.404, 0.4922];
    E.xy = [-0.3182, 0.6276];
    scene() := (
      fillcircle((0,0),10, color->[2/255,1/255,0/255]);
      fillcircle(A.xy, .4, color->[0,0,3]/255);
      //draw(A,B, size->10, color->[.4,.4,.3]);
    );
    gentrafos() := (
      Trafos = [map(B, A, C, A), map(A, B, D, E)];
    );

    snap() := (
      if(|C,A|>.99*|B,A|,
        C.xy = A.xy+.99*|B,A|/|C,A|*(C.xy-A.xy);
      );

      if(|C,A|<.5*|B,A|,
        C.xy = A.xy+.5*|B,A|/|C,A|*(C.xy-A.xy);
      );

      if(|E,D|>.8*|B,A|,
        E.xy = D.xy+.8*|B,A|/|E,D|*(E.xy-D.xy);
      );
    );
  );
  forall(allpoints(),p, p.pinned = true; p.visible = false);
  forall(used,p, p.pinned = false; p.visible = true);
  forall(allpoints(),p,p:"xy0" = p.xy);
  init();
);

init() := (
  clearimage("ifs");
  clearimage("seed");
  resetclock();
  if(!paused,
    playanimation();
    framecnt = 0;
  );
  CF = 0.2;
);

createimage("ifs", res, res);
createimage("seed", res, res);
select(1);

applytrafo(T, p) := (
  h = T*[p_1,p_2,1];
  [h_1,h_2]/h_3;
);

pause():=(
  paused = true;
  pauseanimation();
);

resume():=(
  paused = false;
  select(sel);
  playanimation();
);

reset() := (
  framecnt = 0;
  select(randomint(length(poss)-1)+1);
  idleanimation = true;
);
