mpo=mouse().xy;
if(mpo.x>button1_1_1 & mpo.x<button1_2_1 & mpo.y>button1_1_2 & mpo.y<button1_3_2,
  pressed1=!pressed1;
  triggerinternalanimation();
);
if(mpo.x>button2_1_1 & mpo.x<button2_2_1 & mpo.y>button2_1_2 & mpo.y<button2_3_2,pressed2=!pressed2);

;
