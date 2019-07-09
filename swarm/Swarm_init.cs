//  playanimation();
feed=false;

pts=allmasses()-[K,L,J];
pts=select(pts,(#.size)<9);
apply(pts,#:"vold"=#.v);
apply(pts,#.pinned=true);

sizes=apply(pts,random()*.6+.5);
colors=apply(pts,random());


pause():=(
  pauseanimation();
);
resume():=(
  playanimation();
);
