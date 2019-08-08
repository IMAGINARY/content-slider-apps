//the following is executed for every rendered frame
if (dragging,
    dx = 3 * (sx - mouse().x); dy = 3 * (sy - mouse().y);,
    dx = .9*dx; dy = .9*dy;
);

if(|(dx,dy)|<.00001,
  dx=0; dy=0;
  pauseanimation();
);

sx = mouse().x;
sy = mouse().y;

//the rotation matrix: It is modified either if the user is dragging or time passes
mat = mat * (
    (1, 0, 0),
    (0, cos(dy), -sin(dy)),
    (0, sin(dy), cos(dy))
) * (
    (cos(dx), 0, -sin(dx)),
    (0, 1, 0),
    (sin(dx), 0, cos(dx))
);


//the 3 sliders at the left.
//snap
forall(sliders, s,
  (s_1).y = (s_2).y;
  if((s_1).x<(s_2).x, (s_1).x=(s_2).x);
  if((s_1).x>(s_3).x, (s_1).x=(s_3).x);
);

//read values
a = smootha(-.1+1.2*sliderval(sliders_1));
alpha = sliderval(sliders_2)*.5+.49;
zoom = exp(sliderval(sliders_3)-1);
/*
PA.x = 0.7;
if (PA.y > .4, PA.y = .4);
if (PA.y < -.4, PA.y = -.4);
a = smootha((.5 + PA.y/.7));

PB.x = 0.85;
if (PB.y > .4, PB.y = .4);
if (PB.y < -.4, PB.y = -.4);
alpha = ((.4 + PB.y) / .8) * .7 + .3;

PC.x = 1;
if (PC.y > .4, PC.y = .4);
if (PC.y < -.4, PC.y = -.4);
zoom = exp(2 * PC.y - .5);*/

//configuration for the lights in the scene. A light has a position, a gamma-parameter for its shininess and a color
lightdirs = [
    ray((.0, .0), -100), //enlights parts of the surface which normal points away from the camera
    ray((.0, .0), -100),
    ray((.0, .0), 100), //Has an effect, if the normal of the surface points to the camera
    ray((.0, .0), 100),
    (-10, 10, -2.),
    (-10, 10, -2.),
    (10, -8, 3.),
    (10, -8, 3.)
];

gamma = [2, 20, 2, 20, 1, 10, 1, 10];

colors = [
    (.3, .5, 1.),
    (1, 2, 2) / 2,
    (1., 0.2, 0.1),
    (2, 2, 1) / 2,
    .4 * (.7, .8, .3),
    .9 * (.7, .8, .3),
    .4 * (.6, .1, .6),
    .9 * (.6, .1, .6)
];

//render the scene. # is the pixel coordinate


if(prerender,
  colorplot((-.6,-.6),(.6,-.6),"canv",
    clipedScene(#)
  );

  drawimage((-.6,-.6), (.6,-.6), "canv")
  ,
  colorplot( //(-.6,-.6),(.6,-.6),"canv",
    clipedScene(#)
  );
);

// drawtext((-.65, -.45), "degree: $" + if(newN<100,newN,"\infty") +"$");


//images

ims = 0.07;
forall(1..9,k,
  drawimage(poss_k+(-ims,-ims),poss_k+(ims,-ims),"im"+k,alpha->if(sel==k,1,.6));
);

//highlight selected
connect(
    (
      poss_sel+0.08*(1,1),
      poss_sel+0.08*(-1,1),
      poss_sel+0.08*(-1,-1),
      poss_sel+0.08*(1,-1),
      poss_sel+0.08*(1,1)
  ),color->(1,1,1)*.7,size->2
);

//lines for the sliders
forall(sliders, s,
  drawtext(s_2+(0,.02), s_4, color->[1,1,1], size->20);
  draw(s_2, s_3, color->gray(.7), size->2);
);

drawtext(align->"mid", (0, .55), text_1, size->text_2, color->[1,1,1]);
