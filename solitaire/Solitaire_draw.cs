if(!animating,
    drawstuff(mouse().xy),
    drawstuff(animpos)
    );

  diff=mouse().xy-pos;
  goalpos=special+diff;

fillpoly(rect,color->gray(if(pressed,.3,.5)));
drawpoly(rect,color->gray(.8),size->4);

drawimage(rect_1+(.5,.5),rect_2+(-.5,.5),"replay",alpha->.7);

;
