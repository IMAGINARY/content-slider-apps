if(idle==1,RayEnd.xy=gauss(complex(RayEnd-RayBegin)*exp(.03*i*0.1))+RayBegin);
if(mousedown==0,colrot=mod(colrot+0.25,150));
