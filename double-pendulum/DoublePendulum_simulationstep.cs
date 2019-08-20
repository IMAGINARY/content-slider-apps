if(pressed2,
  if(simulationtime()>lastsimulationtime+.008,
    lastsimulationtime = simulationtime();
    if(l==[],
      l=[C.xy]++l;
    );
    
    if(l_1!=C.xy,
      l=[C.xy]++l;
    );

    if(length(l)>n,
      l=apply(1..(length(l)-1),l_#);
    );
  );
);
