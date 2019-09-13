mpo=mouse().xy;
if(mpo.x>rect_1_1 & mpo.x<rect_2_1 &
   mpo.y>rect_1_2 & mpo.y<rect_3_2,pressed=true);

found=select(active,|mouse().xy,#.xy|<2);

moving=false;
if(length(found)==1&!movingfilm,
//  playtone(60,channel->9);
  special=found_1;
  active=active--[special];
  pos=mouse().xy;
  moving=true;

  lastmouse=mouse().xy;
);
timestamp=seconds();
lastclickts=seconds();
waiting=true;
waiting=false;//TOTGELEGT

playanimation();
