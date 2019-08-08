import CindyApp from "../common/js/CindyApp.js";

class IFSApp extends CindyApp {
  constructor() {
    super();
  }

  async _initCindyArgs() {
    const relativeUrl = filename => new URL(filename,
      import.meta.url).href;


    return {
      scripts: await CindyApp.loadScripts(relativeUrl('IFS_'), ['init', 'draw', 'mousedown'], '.cs'),
      defaultAppearance: {},
      images: {
        im1: relativeUrl("img/01_Tree.png"),
        im2: relativeUrl("img/01_Tree.png"),
        im3: relativeUrl("img/01_Tree.png"),
        im4: relativeUrl("img/01_Tree.png"),
        im5: relativeUrl("img/01_Tree.png"),
        im6: relativeUrl("img/01_Tree.png"),
        im7: relativeUrl("img/01_Tree.png"),
        im8: relativeUrl("img/01_Tree.png"),
        im9: relativeUrl("img/01_Tree.png")
      },
      ports: [{
        element: this.canvas,
        background: "rgba(0,0,0,0)",
        transform: [{
          visibleRect: [-.72, -.72, 1.20, .72]
        }]
      }],
      animation: {
        autoplay: true
      },
      use: ["CindyGL"],
      geometry: [
        {labeled: false, color:[1,1,1], size: 10, name: "A", type: "Free", pos: [0.5461344433141647, 1, -0.8694388507131142]},
        {labeled: false, color:[1,1,1], size: 10, name: "B", type: "Free", pos: [-0.5832007080270749, 0.17864187533740292, 1]},
        {labeled: false, color:[1,1,1], size: 10, name: "C", type: "Free", pos: [0.042069733399776155, 0.8344744471823282, 1]},
        {labeled: false, color:[1,1,1], size: 10, name: "D", type: "Free", pos: [1, -0.3674308286190039, -0.7770817202787361]}
      ]
    };
  }

  get name() {
    return 'Iterierte Funktionensysteme';
  }

  get description() {
    return 'TODO';
  }

  get credits() {
    return 'Aaron Montag';
  }
}

export default IFSApp;
