prerender = false; //render on canvas before displaying; otherwise render in screen resolution

idleanimation = true;
resetclock();

if(prerender,
  resolution = 512;
  createimage("canv",resolution, resolution);
);



poss=(
 (0.65, .5),
 (0.85, .5),
 (1.05, .5),
 (0.65, .3),
 (0.85, .3),
 (1.05, .3),
 (0.65, .1),
 (0.85, .1),
 (1.05, .1)
);
 sel=4;

sliders = (
  [PA,(0.6,-.2), (1.10,-.2), "Parameter $\alpha$"],
  [PB,(0.6,-.35), (1.10,-.35), "Transparenz"],
  [PC,(0.6,-.5), (1.10,-.5), "Zoom"]
);

text = ["",20];

T8(x):=128*x^8-256*x^6+160*x^4-32*x^2+1;

select(k) := (
  sel = k;
  if(sel==1,
     setzoom(0.7);
     seta(1);
     fun(x,y,z) := (x^2+y^2+a*z^2-1);
     text = ["$x^2+y^2+\alpha z^2 = 1$",30];
  );
  if(sel==2,
     setzoom(.6);
     seta(1);
     fun(x,y,z) := (x^2+a*y^2-1);
     text = ["$x^2+\alpha y^2 = 1$",30];
  );
  if(sel==3,
     setzoom(.9);
     seta(0);
     fun(x,y,z) := (x^2+z^2-1/3*(1+y)^3*(1-y)^3-a);
     text = ["$x^2+z^2-\tfrac{1}{3} (1+y)^3(1-y)^3 = \alpha$",30];
  );
  if(sel==4,
     setzoom(0.7);
     seta(1);
     fun(x,y,z) := ((x^2+y^2+z^2-(0.5+a)^2)^2-(3*((0.5+a)^2)-1)/(3-((0.5+a)^2))*(1-z-sqrt(2)*x)*(1-z+sqrt(2)*x)*(1+z+sqrt(2)*y)*(1+z-sqrt(2)*y));
     //text = ["Kummer Quadrik" + newline + "$\left(x^2+y^2+z^2-(0.5+\alpha)^2\right)^2-\frac{3 (0.5+\alpha)^2-1}{3-(0.5+\alpha)^2} (1-z-\sqrt{2} x) (1-z+\sqrt{2} x) (1+z+\sqrt{2} y) (1+z-\sqrt{2} y)=0$", 20];
     text = ["Kummer Quadrik", 30];
  );
  if(sel==5,
     setzoom(.6);
     seta(1);
     fun(x,y,z) := (4*((a*(1+sqrt(5))/2)^2*x^2-y^2)*((a*(1+sqrt(5))/2)^2*y^2-z^2)*((a*(1+sqrt(5))/2)^2*z^2-x^2)-1*(1+2*(a*(1+sqrt(5))/2))*(x^2+y^2+z^2-a^2)^2);
     text = ["Barth Sextik",30];
  );
  if(sel==6,
     setzoom(.6);
     seta(1);
     fun(x,y,z) := T8(x)+T8(y)+T8(z)+2*a-1;
     text = ["Chmutov Octik", 30];
  );
  if(sel==7,
     seta(1);
     setzoom(0.3);
     fun(x,y,z) := (a*(1/4*(sqrt(2)-1)*(x^2+y^2)^2+(x^2+y^2)*((1-1/sqrt(2))*z^2+1/8*(2-7*sqrt(2)))-z^4+(0.5+sqrt(2))*z^2-1/16*(1-12*sqrt(2)))^2-(cos(0*pi/4)*x+sin(0*pi/4)*y-1)*(cos(pi/4)*x+sin(pi/4)*y-1)*(cos(2*pi/4)*x+sin(2*pi/4)*y-1)*(cos(3*pi/4)*x+sin(3*pi/4)*y-1)*(cos(4*pi/4)*x+sin(4*pi/4)*y-1)*(cos(5*pi/4)*x+sin(5*pi/4)*y-1)*(cos(6*pi/4)*x+sin(6*pi/4)*y-1)*(cos(7*pi/4)*x+sin(7*pi/4)*y-1));
     text = ["Endraß Octik",30];
  );
  if(sel==8,
     setzoom(0.5);
     seta(0);
     fun(x,y,z) := (a+x^3+x^2*z^2-y^2);
     text = ["$\alpha+x^3+x^2\cdot z^2-y^2=0$",30];
  );
  if(sel==9,
     setzoom(.1);
     seta(.5);
     seta(0);
     fun(x,y,z) := (a+x^5-1*1*10*x^3*y^2+5*x*y^4-1*1*3*z^5-1*1*5*x^4-1*1*10*x^2*y^2-1*1*5*y^4+10*z^3+20*x^2+20*y^2-1*1*15*z-1*1*24);
     text = ["Cusps", 30];
  );
  init();
);

speciala = .5;
smootha(x) := if(x<speciala,
 (-1/(speciala+.01))*(x-speciala)^2+speciala,
 (1/(1.01-speciala))*(x-speciala)^2+speciala
);

sliderval(s) := (
  |s_2,s_1|/|s_2,s_3|
);

setesliderval(k, v) := (
  (sliders_k_1).xy = (1-v)*sliders_k_2+v*sliders_k_3;
);

seta(na) := (
 a = na+.0001;
 speciala = na;
 //PA.y = (a-.5)*.7;
 setesliderval(1, (na+.1)/1.2);
);

setzoom(zoom) := (
 //PC.y = (zoom);
 setesliderval(3, zoom);
);

//initialize some variables
mat = [
   [0.3513, -0.4908, -0.7973],
   [-0.8171, -0.5765, -0.0051],
   [-0.4571, 0.6533, -0.6036]
];
sx = mouse().x;
sy = mouse().y;
dragging = false;
N = 5;
zoom = 2.2;
a = 0.3;
alpha = .7;
eps = .001;

//we stand at position mat*(0, 0, -2.2/zoom) and watch to (0,0,0).
//ray(pixel, t) is the point in R^3 that lies at position t the ray behind the pixel at location pixel(vec2)
//t=0 is corresponds to points within the interesting area near (0,0,0)
ray(pixel, t) := mat * ((t+2.2/zoom) * (pixel.x, pixel.y, 1) + (0, 0, -2.2/zoom));

//sphere with radius 1/zoom for clipping
S(r) := (r * r - 1/(zoom*zoom));

//fun is the user defined trivariate polynomial
fun(x, y, z) := (x ^ 2 + y ^ 2 + z ^ 2 - (0.5 + a) ^ 2) ^ 2 - (3.0 * ((0.5 + a) ^ 2) - 1.0) / (3.0 - ((0.5 + a) ^ 2)) * (1 - z - sqrt(2) * x) * (1 - z + sqrt(2) * x) * (1 + z + sqrt(2) * y) * (1 + z - sqrt(2) * y);


     //F takes vec3 instead of 3 variables
     F(p) := (p=p/zoom;fun(p.x, p.y, p.z));

     //casteljau algorithm to evaluate and subdivide polynomials in Bernstein form.
     //poly is a vector containing the coefficients, i.e. p(x) = sum(0..N, i, poly_(i+1) * b_(i,N)(x)) where b_(i,N)(x) = choose(N, i)*x^i*(1-x)^(N-1)
     casteljau(poly, x) := (
       regional(alpha, beta);
       alpha = 1-x;
       beta = x;
       forall(0..N, k,
         repeat(N-k,
           poly_# = alpha*poly_# + beta*poly_(#+1);
         );
       );
       poly //the bernstein-coefficients of the polynomial in the interval [x,1]
     );

     //evaluates a polynomial, represented as vector of coefficients in bernstein-form
     eval(poly, x) := casteljau(poly, x)_1;

     //this function has to be called whenever fun changes
     init() := (
       dx = .05; dy =.02;
       diff(fun(x,y,z), x, dxF(x,y,z) := #);
       diff(fun(x,y,z), y, dyF(x,y,z) := #);
       diff(fun(x,y,z), z, dzF(x,y,z) := #);

         newN = degree(fun(x,y,z), x, y, z);
         if(newN==-1, newN=1000);
         if(newN!=N,
           N = newN;
           //The following line is DIRTY, but it makes the application run smooth for high degrees. :-)
           //Nethertheless, it might cause render errors for high degree surfaces. In fact, only a subset of the surface is rendered.
           //Adapt limit according to hardware.
           //values of kind 4*n-1 are good values, as it means to use vectors of length 4*n.
           N = min(N,7);

           //N+1 Chebyshev nodes for interval (0-eps, 1+eps) for eps = (1-cos(pi/(2*(N+1))))/cos(pi/(2*(N+1)))
           li = reverse(apply(1..(N+1), k, (cos((2 * k - 1) / (2 * (N+1)) * pi)/cos(pi/(2*(N+1)))+1)/2)); //li contains 0 and 1

           //A is the matrix of the linear map that evaluates a polynomial in bernstein-form at the Chebyshev nodes
           A = apply(li, node,
             //the i-th column contains the values of the (i,N) bernstein polynomial evaluated at the Chebyshev nodes
             apply(0..N, i, eval(
               apply(0..N, if(#==i,1,0)), // e_i = [0,0,0,1,0,0]
               node //evaluate  b_(i,N)(node)
             ))
           );

           B = (inverse(A)); //B interpolates polynomials (in Bernstein basis), given the values [p(li_1), p(li_2), ...]
         )

     );

     select(4);

     //B3 is a matrix that interpolates quadratic polynomials (in monomial basis), given the values [p(-2), p(0), p(2)]
     B3 = inverse(apply([-2, 0, 2], c, apply(0 .. 2, i, c ^ i)));

     //use symbolic differentation function
     dF(p) := (p=p/zoom; (
         dxF(p.x,p.y,p.z),
         dyF(p.x,p.y,p.z),
         dzF(p.x,p.y,p.z)
     ));

     //update the color color for the pixel at position pixel assuming that the surface has been intersected at ray(pixel, dst)
     //because of the alpha-transparency updatecolor should be called for the intersections with large dst first
     updatecolor(pixel, dst, color) := (
       regional(x, normal);
       x = ray(pixel, dst); //the intersection point in R^3
       color = (1 - alpha) * color;

       normal = dF(x);
       normal = normal / |normal|;

       forall(1..length(lightdirs),
         //illuminate if the normal and lightdir point in the same direction
         illumination = max(0, (lightdirs_# / abs(lightdirs_#)) * normal);
         color = color + alpha * (illumination ^ gamma_#) * colors_#;
       );
       color
     );


     nsign(pixel, a, b) := ( //Descartes rule of sign for the interval (a,b)
       //obtain the coefficients in bernstein basis of F along the ray in interval (a,b) by interpolation within this interval
       poly = B * apply(li,
         F(ray(pixel, a+#*(b-a))) //evaluate F(ray(pixel, ·)) along Chebyshev nodes for (a,b)
       );
       //count the number of sign changes
       ans = 0;
       //last = poly_1;
       forall(2..(N+1), k,
         //if(last == 0, last = poly_k;); this (almost) never happens
         if(min(poly_(k-1), poly_k) <= 0 & 0 <= max(poly_(k-1), poly_k), //sign switch; avoid products due numerics
           ans = ans + 1;
         );
       );
       ans //return value
     );


     //bisect F(ray(pixel, ·)) in [x0, x1] assuming that F(ray(pixel, x0)) and F(ray(pixel, x1)) have opposite signs
     bisectf(pixel, x0, x1) := (
         regional(v0, v1, m, vm);
         v0 = F(ray(pixel, x0));
         v1 = F(ray(pixel, x1));
         repeat(11,
             m = (x0 + x1) / 2; vm = F(ray(pixel, m));
             if (min(v0,vm) <= 0 & 0 <= max(v0, vm), //sgn(v0)!=sgn(vm); avoid products due numerics
                 (x1 = m; v1 = vm;),
                 (x0 = m; v0 = vm;)
             );
         );
         m //return value
     );

     //id encodes a node in a binary tree using heap-indices
     //1 is root node and node v has children 2*v and 2*v+1
     //computes s=2^depth of a node id: Compute floor(log_2(id));
     //purpose: id corresponds interval [id-s,id+1-s]/s
     gets(id) := (
       s = 1;
       repeat(15,
         if(2*s<=id,
           s = 2*s;
         )
       );
       s //return value
     );

     //determines the next node in the binary tree that would be visited by a regular in DFS
     //if the children of id are not supposed to be visited
     //In interval logic: finds the biggest unvisited interval directly right of the interval of id.
     next(id) := (
       id = id+1;
       //now: remove zeros from right (in binary representation) while(id&1) id=id>>1;
       repeat(15,
         if(mod(id,2)==0,
           id = floor(id/2);
         )
       );
       if(id==1, 0, id) //return value - id 0 means we stop our DFS
     );


 //what color should be given to pixel with pixel-coordinate pixel (vec2)
 computeColor(pixel, l, u, color) := (
     regional(a, b);
     //traverse binary tree (DFS) using heap-indices
     //1 is root node and node v has children 2*v and 2*v+1
     id = 1;
     //maximum number of steps
     repeat(min(newN*20,128),
       //id=0 means we are done; do only a DFS-step if we are not finished yet
       if(id>0,
         s = gets(id); //s = floor(log_2(id))

         //the intervals [a,b] are chossen such that (id in binary notation)
         //id = 1   => [a,b]=[l,u]
         //id = 10  => [a,b]=[l,(u+l)/2]
         //id = 101 => [a,b]=[l,(u+3*l)/4]
         //id = 11  => [a,b]=[(u+l)/2,u]
         //...
         a = u - (u-l)*((id+1)/s-1);
         b = u - (u-l)*((id+0)/s-1);

         //how many sign changes has F(ray(pixel, ·)) in (a,b)?
         cnt = nsign(pixel, a, b);
         if(cnt == 1 % (b-a)<1e-4, //in this case we found a root (or it is likely to have a multiple root)
           //=>colorize and break DFS
           color = updatecolor(pixel, bisectf(pixel, a, b), color);
           id = next(id),
         if(cnt == 0, //there is no root
           id = next(id), //break DFS

           //otherwise cnt>=2: there are cnt - 2*k roots.
           id = 2*id;  //visit first child within DFS
         )
     );
     ));
     color
   );

//render clipped scene
clipedScene(pixel) := (
  spolyvalues = apply([-2, 0, 2], v, S(ray(pixel, v))); //evaluate S along ray
  spoly = B3 * spolyvalues;                         //interpolate to monomial basis
  D = (spoly_2 * spoly_2) - 4. * spoly_3 * spoly_1; //discriminant of spoly

  color = gray(0); //the color, which will be returned
  if (D >= 0, //ray intersects ball
    color = computeColor(
      pixel,
      (-spoly_2 - re(sqrt(D))) / (2 * spoly_3), //intersection entering the ball
      (-spoly_2 + re(sqrt(D))) / (2 * spoly_3), //intersection leaving the ball
      color
    );
  );
  color //return value
);

paused = false;
pause():=(
  pauseanimation();
  paused = true;
);

resume():=(
  paused = false;
  playanimation();
  idleanimation = true;
);

reset() := (
  select(randomint(length(poss)-1)+1);
  idleanimation = true;
);
