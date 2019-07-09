drag=drag+1;
if(l!=[],
  if(l_(-1)_1=="DRAG:",
    l_(-1)_2=l_(-1)_2+1,
    l=l++[["DRAG:",1]]
  )
);

sta=sta++[mouse().xy];



if(|mouse().xy,A|<5,l=[];st=[]);
;
