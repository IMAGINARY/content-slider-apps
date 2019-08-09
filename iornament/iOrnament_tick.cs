
      if(strokecount>length(strokelist),pauseanimation(),
        canvas(A,B,C,"tile",
            strox=strokelist_strokecount;
     size=strox_1_1;
     alpha=strox_1_2;
     color=strox_1_3;
      blur=strox_1_5;
      glowing=strox_1_4;
     setglow(strox_1_4);
     setdot();
     if(linecount==1,backup());
     apply(linecount..min((length(strox_2)-1),linecount+10),

       draggingActionInLoop(strox_2_#,strox_2_(#+1));
       linecount=#;
     );

      if(linecount> length(strox_2)-1,
        strokecount=strokecount+1;linecount=1,
        linecount=linecount+1;
      );
    );
);
