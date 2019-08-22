t1=map(A,B,B,C);
t2=map(A,B,B,D);
col(x):=(0.6*x,(1-x)*.8,0);


tree(a,b,n):=(
  if(n>0&|a_[1,2]/a_3,b_[1,2]/b_3|>.15,
     draw(a,b,size->n*1*2,color->col(n/nn));
     tree(t1*a,t1*b,n-1);
     tree(t2*a,t2*b,n-1);
     );
  );
nn=12;
// drawimage((-15,-11),(15,-11),"back");

tree(A.homog,B.homog,nn);

pauseanimation(); //draw the tree only once
