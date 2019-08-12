res = 1024;

use8bittextures();

poss=(
 (1.2, .6),
 (1.2, .3),
 (1.2, 0),
 (1.2, -.3),
 (1.2, -.6)
);

sel=1;

K = 1.5;
L = (-K,-K);
R = (K,-K);
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
      Trafos = [map(D,B,B,A), map(C,B,B,A)];
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
      Trafos = [map(B,C,A,C), map(B,D,A,C), map(B,E,A,C)];
    );
    snap() := (
      //TODO
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
      Trafos = [map(A,B,A,E), map(B,C,A,E), map(C,D,A,E), map(D,E,A,E)];
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
      Trafos = [map(A,B,A,D), map(B,C,A,D), map(C,D,A,D)];
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
    A.xy = [-0.0529, -0.2179];
    B.xy = [-0.4421, 0.0997];
    C.xy = [-0.3008, 0.1794];
    D.xy = [-0.4018, 0.3581];
    E.xy = [-0.5028, 0.4606];
    scene() := (
      fillcircle((0,0),10, color->[2/255,1/255,0/255]);
      fillcircle(A.xy, .4, color->[0,0,3]/255);
      //draw(A,B, size->10, color->[.4,.4,.3]);
    );
    gentrafos() := (
      Trafos = [map(C,A,B,A), map(D,E,A,B)];
    );

    snap() := (
      //TODO
    );
  );
  forall(allpoints(),p, p.pinned = true; p.visible = false);
  forall(used,p, p.pinned = false; p.visible = true);
  init();
);

init() := (
  clearimage("ifs");
  clearimage("seed");
  resetclock();
  CF = 0.5;
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
