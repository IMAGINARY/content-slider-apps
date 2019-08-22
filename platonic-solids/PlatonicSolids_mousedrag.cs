if(|mouse().x|<13,

if(dragging,
errc("drag");
xx=mouse().x;
yy=mouse().y;

fact = .98;
wy=fact*wy+(1-fact)*(startx-xx)*.4;
wx=fact*wx-(1-fact)*(starty-yy)*.4;

startx=xx;
starty=yy;

if(|(wx,wy)|>0.0001,playanimation(), pauseanimation());

);
);
