import CindyApp from "../common/js/CindyApp.js";

class LunarApp extends CindyApp {
  static defaultConfig = {
    appName: 'Lunar Lockout',
    appDescription: 'Bewege den orangen Kreis in die Mitte des Feldes.',
    appCredits: 'Level & Implemtierung: Aaron Montag. Spielidee inspiriert von Hiroshi Yamamoto.',
  };

  constructor(config = {}) {
    super(Object.assign(LunarApp.defaultConfig, config));
  }

  async _initCindyArgs() {
    const relativeUrl = filename => new URL(filename,
      import.meta.url).href;
    let SIZE = 7;

    let levels = await CindyApp.request({
      url: relativeUrl("Lunar_levels.txt")
    });

    function wrap(v) { //converts js-lists of lists of real numbers to CS-object.
      if (typeof v === "number") {
        return {
          "ctype": "number",
          "value": {
            'real': v,
            'imag': 0
          }
        };
      } else if (typeof v === "object" && v.length !== undefined) {
        return {
          "ctype": "list",
          "value": v.map(wrap)
        }
      }
    };

    CindyJS.registerPlugin(1, "loadlevels", function(api) {
      // Define a CindyScript function called "verdoppeln"
      // that takes a single argument
      api.defineFunction("loadlevels", 0, function(args, modifs) {
        let j = 0;
        let res = [],
          cur = [];
        let robot = [1, 1];

        levels.split('\n').filter(line => (line.length == SIZE)).forEach(function(line) {
          for (let i = 0; i < SIZE; i++) {
            if (line[i] == 'o')
              cur.push([i + 1, SIZE - j]);
            else if (line[i] == 'S')
              robot = [i + 1, SIZE - j];
          }
          j++;
          if (j == SIZE) {
            j = 0;
            res.push([robot].concat(cur));
            cur = [];
          }
        });
        return wrap(res);
      });
    });

    this.canvas.style.backgroundImage = `url('${relativeUrl("background.jpg")}')`;

    return {
      scripts: await CindyApp.loadScripts(relativeUrl('Lunar_'), ['init', 'draw', 'mousedown', 'mouseup'], '.cs'),
      geometry: [{
          name: "P0",
          type: "Free",
          pos: [SIZE + 2, 1],
          pinned: true,
          color: [1, 0, 0],
          visible: false
        },
        {
          name: "P1",
          type: "Free",
          pos: [SIZE + 2, SIZE],
          pinned: true,
          color: [1, 0, 0],
          visible: false
        },
        {
          name: "seg",
          type: "Segment",
          args: ["P0", "P1"],
          pos: [1, 0, 0],
          size: 3,
          color: [1, 1, 1]
        },
        {
          name: "P2",
          type: "PointOnLine",
          args: ["seg"],
          pos: [SIZE + 2, 1.2],
          narrow: 100,
          size: 11,
          color: [1, 1, 1]
        },
      ],
      ports: [{
        element: this.canvas,
        virtualheight: 750,
        virtualwidth: 1000,
        transform: [{
          visibleRect: [0.2, SIZE+1, SIZE + 2.2, 0]
        }]
      }],
      autoplay: true,
      behavior: [],
      use: ["loadlevels"]
    };
  }
}

export default LunarApp;
