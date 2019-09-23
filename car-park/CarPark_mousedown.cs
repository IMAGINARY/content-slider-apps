if(downpending,
  upaction();
);
if(|mouse().x-N.x|<2 & M.y - mouse().y < 0.5 & mouse().y - L.y < 0.5,
  moveto(N,mouse());
  processslider();
);
downpending=true;
downaction();
