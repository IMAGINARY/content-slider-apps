res = 1024;

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
//  [PA,(0.6,-.2), (1.10,-.2), "Parameter $\alpha$"],
//  [PB,(0.6,-.35), (1.10,-.35), "Transparenz"],
//  [PC,(0.6,-.5), (1.10,-.5), "Zoom"]
);

L = (-1,-1);
R = (1,-1);
MF = 1.5;

select(k) := (
  sel = k;
  if(sel==1,
    used = [A,B,C,D];
    A.xy = [-0.1438, -0.6005];
    B.xy = [-0.0982, -0.1297];
    C.xy = [-0.2615, 0.0841];
    D.xy = [0.0708, 0.1087];
    MF = 1.5;
    AF = .9;
    NC = 0;
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
    used = [A,B,C,D];
    A.xy = [-1.75,0]/3;
    B.xy = [-1,1]/3;
    C.xy = [1,-1]/3;
    D.xy = [1.75,0]/3;
    MF = 1.2;
    AF = .9;
    NC = 0;
    scene() := (
      fillcircle((0,0),10, color->[1/255,2/255,3/255]);
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
  if(sel==3,
    used = [A,B,C,D,E];
    A.xy = [-1.5,0]/3;
    B.xy = [-0.5,0]/3;
    C.xy = [0,sqrt(3)/2]/3;
    D.xy = [0.5,0]/3;
    E.xy = [1.5,0]/3;
    MF = 1.5;
    AF = .8;
    NC = 0.3;
    scene() := (
      draw(A,B, color->[.5,.2,.4], size->10);
      draw(B,C, color->[.5,.2,.4], size->10);
      draw(C,D, color->[.5,.2,.4], size->10);
      draw(D,E, color->[.5,.2,.4], size->10);
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
    MF = 1.2;
    AF = .9;
    NC = 0;
    scene() := (
      fillcircle((0,0),10, color->[1/255,2/255,1/255]);
      draw(A,B, size->10, color->[.4,.4,.3]);
    );
    gentrafos() := (
      Trafos = [map(B,C,A,C), map(B,D,A,C), map(B,E,A,C)];
    );
    snap() := (
      //TODO
    );

  );
  if(sel==5,
    used = [A,B,C,D,E];
    A.xy = [-0.0037, -0.0271];
    B.xy = [-0.4298, 0.0135];
    C.xy = [-0.2762, 0.2502];
    D.xy = [-0.3526, 0.3766];
    E.xy = [-0.472, 0.2791];
    MF = 1.2;
    AF = .9;
    NC = 0;
    scene() := (
      fillcircle((0,0),10, color->[3/255,2/255,1/255]);
      //draw(A,B, size->10, color->[.4,.4,.3]);
    );
    gentrafos() := (
      Trafos = [map(C,A,B,A), map(D,E,A,B)];
    );

    //{name: "Tr0", type: "TrSimilarity", color: [0.0, 0.0, 1.0], args: ["B", "C", "A", "A"], alpha: 0.8999999761581421, dock: {offset: [0.0, -0.0]}},
    //{name: "Tr1", type: "TrSimilarity", color: [0.0, 0.0, 1.0], args: ["A", "D", "B", "E"], alpha: 0.8999999761581421, dock: {offset: [0.0, -0.0]}},

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
