
//the following is executed for every rendered frame
if (dragging,
    dx = 3 * (sx - mouse().x); dy = 3 * (sy - mouse().y);,
    dx = .01 * cos(seconds() * .3); dy = .01 * sin(seconds() * .3);
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
zoom = exp(2 * PC.y - .5);

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

//lines for the sliders
draw((.7, .4), (.7, -.4), color -> (1,1,1),size->2);
draw((.85, .4), (.85, -.4), color -> (1,1,1),size->2);
draw((1, .4), (1, -.4), color -> (1,1,1),size->2);

drawimage(poss_1+(-.10,-.10),poss_1+(.10,-.10),"im1",alpha->if(sel==1,1,.6));
drawimage(poss_2+(-.10,-.10),poss_2+(.10,-.10),"im2",alpha->if(sel==2,1,.6));
drawimage(poss_3+(-.10,-.10),poss_3+(.10,-.10),"im3",alpha->if(sel==3,1,.6));
drawimage(poss_4+(-.10,-.10),poss_4+(.10,-.10),"im4",alpha->if(sel==4,1,.6));
drawimage(poss_5+(-.10,-.10),poss_5+(.10,-.10),"im5",alpha->if(sel==5,1,.6));
drawimage(poss_6+(-.10,-.10),poss_6+(.10,-.10),"im6",alpha->if(sel==6,1,.6));
