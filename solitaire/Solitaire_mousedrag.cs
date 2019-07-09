timestamp=seconds();

mpo=mouse().xy;
if(mpo.x>rect_1_1 & mpo.x<rect_2_1 &
   mpo.y>rect_1_2 & mpo.y<rect_3_2&!moving,pressed=true,pressed=false);

  lastmouse=mouse().xy;

;
