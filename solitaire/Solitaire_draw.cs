if(!animating,
    drawstuff(mouse().xy),
    drawstuff(animpos)
    );

  diff=mouse().xy-pos;
  goalpos=special+diff;

//fillpoly(rect,color->gray(if(pressed,.3,.5)), alpha->.5);
//drawpoly(rect,color->gray(.8),size->1, alpha->.5);

drawimage(rect_1+(.5,.5),rect_2+(-.5,.5),if(!pressed,"replay","replaypressed"),alpha->if(!pressed,1,.7));

;
