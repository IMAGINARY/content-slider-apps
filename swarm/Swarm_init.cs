//  playanimation();
feed=false;

pts=allmasses()--[K,L,J];
pts=select(pts,(#.size)<9);
apply(pts,#:"vold"=#.v);

sizes=2*apply(pts,random()*.9+.8);
colors=apply(pts,random());

pause():=(
  pauseanimation();
);
resume():=(
  playanimation();
);
