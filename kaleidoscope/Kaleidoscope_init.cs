images=[
[(28,-4),"bild",.285],
[(28,-8),"bild2",.285],
[(28,-12),"bild3",.285],
[(28,-16),"bild4",.285]
];

resume():=(
   if(pendanimation,playanimation(),stopanimation());
);

reset():=(
  A.homog=(4, 0.63313657, -1.04065347);
  B.homog=(0.9043478, -4, 0.6749865);
  D.homog=(-3.2947, -4, 0.289674);
  E.homog=(4, -1.4651206, 0.23502179);
  G.homog=(4, -1.81823465, -0.2468792697);
  M.homog=(4, 0, 0.13995);
  L.homog=(4, -2.09576888, 0.181818);
  pendanimation=true;

  type=1;
  sel=randomint(4)+1;
);
reset();

playanimation();
