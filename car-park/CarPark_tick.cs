move=animation_startindex;
if(move_2=="Push",push(move_1));
if(move_2=="Pull",pull(move_1));
startindex=startindex+1;
if(startindex>length(animation),
//TODO WHY DOES STOPANIM NOT WORK
pauseanimation();
setsliderindex(mod(getsliderindex()+1,length(levels)));
);
