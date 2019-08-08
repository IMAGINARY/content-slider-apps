import CindyApp from "../common/js/CindyApp.js";

class SurferApp extends CindyApp {
  constructor() {
    super();
  }

  async _initCindyArgs() {
    const relativeUrl = filename => new URL(filename,
      import.meta.url).href;


    return {
      scripts: await CindyApp.loadScripts(relativeUrl('Surfer_'), ['init', 'draw', 'mousedown', 'mousedrag', 'mouseup'], '.cs'),
      defaultAppearance: {},
      images: {
        im1: relativeUrl("img/01_Sphere.png"),
        im2: relativeUrl("img/02_Tube.png"),
        im3: relativeUrl("img/03_Citric.png"),
        im4: relativeUrl("img/04_Kummer.png"),
        im5: relativeUrl("img/05_Barth.png"),
        im6: relativeUrl("img/06_Octic.png"),
        im7: relativeUrl("img/07_Endras.png"),
        im8: relativeUrl("img/08_Humming.png"),
        im9: relativeUrl("img/09_Cusps.png")
      },
      ports: [{
        element: this.canvas,
        background: "rgba(0,0,0,0)",
        transform: [{
          visibleRect: [-.55, -.6, 1.05, .6]
        }]
      }],
      animation: {
        autoplay: true
      },
      use: ["CindyGL", "symbolic"],
      geometry: [{
          name: "PA",
          kind: "P",
          type: "Free",
          pos: [1, .37, 1],
          narrow: 80,
          color: [1, 1, 1],
          size: 8
        },
        {
          name: "PB",
          kind: "P",
          type: "Free",
          pos: [1, 2, 1],
          narrow: 80,
          color: [1, 1, 1],
          size: 8
        },
        {
          name: "PC",
          kind: "P",
          type: "Free",
          pos: [.5, .1, 1],
          narrow: 80,
          color: [1, 1, 1],
          size: 8
        }
      ]
    };
  }

  get name() {
    return 'Algebraic surfaces';
  }

  get description() {
    return 'TODO';
  }

  get credits() {
    return 'TODO';
  }
}

export default SurferApp;
