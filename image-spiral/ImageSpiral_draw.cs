if(pinall,apply(1..length(allpoints()), (allpoints()_#).xy=bck_# ));

restrict(p,mi,ma):=(
  xx=max(min(p.x,ma.x),mi.x);
  yy=max(min(p.y,ma.y),mi.y);
  p.xy=(xx,yy);
);
minpt=(-11,-14);
maxpt=(18,16);
//draw(minpt,maxpt);
//draw(minpt);
//draw(maxpt);
restrict(C,minpt,maxpt);
restrict(B,minpt,maxpt);


E.xy=(E-D)/|E-D|*3+D;

if(G.y<=F.y,G.xy=F.xy);
if(G.y>=A.y,G.xy=A.xy);

bb=complex(B);
cc=complex(C);
sc=|F,G|/|G,A+(0,1)|;

w=arctan2(E-D)-90°;
fac=cc/bb;
st=1;
erg=apply(1..1000,
e=st;
st=st*fac;
e;
);
erg=reverse(erg);


apply(erg,st,
if(|st|*sc<10,

drawimage(gauss(bb*st),images_sel_2,scale->|st|*sc/2.5,angle->arctan2(im(st*i),re(st*i))-w);
);
);



apply(1..6,ind=images_#;drawimage(ind_1,ind_2,scale->ind_3,alpha->if(sel==#,1,0.4)));



drawimage(D.xy,
images_sel_2,
scale->images_sel_3*.7,
angle->-w);



bck=apply(allpoints(),#.xy);

;
