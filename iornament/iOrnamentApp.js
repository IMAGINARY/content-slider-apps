import CindyApp from "../common/js/CindyApp.js";

class iOrnament extends CindyApp {
  constructor() {
    super({pauseScript: '', resumeScript: ''});
  }

  async _initCindyArgs() {
    const relativeUrl = filename => new URL(filename,
      import.meta.url).href;

    let ypos = 4.8;
    let ydiff = 1.3;

    return {
      scripts: await CindyApp.loadScripts(relativeUrl('iOrnament_'), ['init', 'draw', 'mousedown', 'mousedrag', 'tick'], '.cs'),
      defaultAppearance: {},
      images: {
        "trash": relativeUrl("img/Trash.png"),
        "fund": relativeUrl("img/Fund.png"),
        "fundh": relativeUrl("img/FundHig.png"),
        "undo": relativeUrl("img/Undo.png"),
        "redo": relativeUrl("img/Redo.png"),
        "sat": relativeUrl("img/SSat.png"),
        "blur": relativeUrl("img/SBlur.png"),
        "alpha": relativeUrl("img/SAlpha.png"),
        "size": relativeUrl("img/SBlurX.png"),
        "dark": relativeUrl("img/SDark.png"),
        "dot": relativeUrl("img/qParticle.png"),
        "cm": relativeUrl("img/qcm.png"),
        "cmm": relativeUrl("img/qcmm.png"),
        "p1": relativeUrl("img/qp1.png"),
        "p2": relativeUrl("img/qp2.png"),
        "p3": relativeUrl("img/qp3.png"),
        "p3m1": relativeUrl("img/qp3m1.png"),
        "p4": relativeUrl("img/qp4.png"),
        "p4g": relativeUrl("img/qp4g.png"),
        "p4m": relativeUrl("img/qp4m.png"),
        "p6": relativeUrl("img/qp6.png"),
        "p6m": relativeUrl("img/qp6m.png"),
        "p31m": relativeUrl("img/qp31m.png"),
        "pg": relativeUrl("img/qpg.png"),
        "pgg": relativeUrl("img/qpgg.png"),
        "pm": relativeUrl("img/qpm.png"),
        "pmg": relativeUrl("img/qpmg.png"),
        "pmm": relativeUrl("img/qpmm.png"),
        "iO": relativeUrl("img/iO6.png"),
        "glow": relativeUrl("img/GlowPen1B.png"),
        "noglow": relativeUrl("img/GlowPen1.png"),
        "sym": relativeUrl("img/MathButtonB.png"),
        "nosym": relativeUrl("img/MathButton.png")
      },
      ports: [{
        element: this.canvas,
        background: "rgba(0,0,0,0)",
        transform: [{
          visibleRect: [-8.5, 11, 16, -11]
        }]
      }],
      geometry: [{
          "name": "A",
          "type": "Free",
          "pos": [-10, -10],
          "color": [1, 0, 0],
          "visible": false,
          "pinned": true
        },
        {
          "name": "B",
          "type": "Free",
          "pos": [10, -10],
          "color": [1, 0, 0],
          "pinned": true,
          "visible": false
        },
        {
          "name": "C",
          "type": "Free",
          "pos": [-10, 10],
          "color": [1, 0, 0],
          "pinned": true,
          "visible": false
        },
        {
          "name": "D",
          "type": "Free",
          "pos": [0, 0],
          "color": [.4, .4, .4],
          "pinned": true,
          "visible": true,
          "narrow": 100
        },
        {
          "name": "E",
          "type": "Free",
          "pos": [1, 0],
          "color": [.4, .4, .4],
          "pinned": true,
          "visible": false
        },
        {
          "name": "F",
          "type": "Free",
          "pos": [5.5, 1.5],
          "color": [1, 1, 1],
          "pinned": false,
          "visible": true,
          "narrow": 100
        },

        {
          "name": "X",
          "type": "Free",
          "pos": [12.5, ypos],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "Y",
          "type": "Free",
          "pos": [17.5, ypos],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "r",
          "type": "Segment",
          "args": ["X", "Y"],
          "color": [.6, .6, .6],
          "visible": true,
          size: 1.5
        },
        {
          "name": "Z",
          "type": "PointOnLine",
          "pos": [14, ypos],
          "args": ["r"],
          "color": [1, 1, 1],
          "visible": true,
          "narrow": 100,
          size: 9
        },
        {
          "name": "rx",
          "type": "Segment",
          "args": ["X", "Z"],
          "color": [1, 1, 1],
          "visible": true,
          size: 2.5
        },

        {
          "name": "Xsat",
          "type": "Free",
          "pos": [12.5, ypos - ydiff],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "Ysat",
          "type": "Free",
          "pos": [17.5, ypos - ydiff],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "rsat",
          "type": "Segment",
          "args": ["Xsat", "Ysat"],
          "color": [.6, .6, .6],
          "visible": true,
          size: 1.5
        },
        {
          "name": "Zsat",
          "type": "PointOnLine",
          "pos": [17, ypos - ydiff],
          "args": ["rsat"],
          "color": [1, 1, 1],
          "visible": true,
          "narrow": 100,
          size: 9
        },
        {
          "name": "rxsat",
          "type": "Segment",
          "args": ["Xsat", "Zsat"],
          "color": [1, 1, 1],
          "visible": true,
          size: 2.5
        },

        {
          "name": "Xdark",
          "type": "Free",
          "pos": [12.5, ypos - ydiff * 2],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "Ydark",
          "type": "Free",
          "pos": [17.5, ypos - ydiff * 2],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "rdark",
          "type": "Segment",
          "args": ["Xdark", "Ydark"],
          "color": [.6, .6, .6],
          "visible": true,
          size: 1.5
        },
        {
          "name": "Zdark",
          "type": "PointOnLine",
          "pos": [17.5, ypos - ydiff * 2],
          "args": ["rdark"],
          "color": [1, 1, 1],
          "visible": true,
          "narrow": 100,
          size: 9
        },
        {
          "name": "rxdark",
          "type": "Segment",
          "args": ["Xdark", "Zdark"],
          "color": [1, 1, 1],
          "visible": true,
          size: 2.5
        },

        {
          "name": "Xalpha",
          "type": "Free",
          "pos": [12.5, ypos - ydiff * 3],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "Yalpha",
          "type": "Free",
          "pos": [17.5, ypos - ydiff * 3],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "ralpha",
          "type": "Segment",
          "args": ["Xalpha", "Yalpha"],
          "color": [.6, .6, .6],
          "visible": true,
          size: 1.5
        },
        {
          "name": "Zalpha",
          "type": "PointOnLine",
          "pos": [17.5, ypos - ydiff * 3],
          "args": ["ralpha"],
          "color": [1, 1, 1],
          "visible": true,
          "narrow": 100,
          size: 9
        },
        {
          "name": "rxalpha",
          "type": "Segment",
          "args": ["Xalpha", "Zalpha"],
          "color": [1, 1, 1],
          "visible": true,
          size: 2.5
        },

        {
          "name": "Xblur",
          "type": "Free",
          "pos": [12.5, ypos - ydiff * 4],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "Yblur",
          "type": "Free",
          "pos": [17.5, ypos - ydiff * 4],
          "color": [1, 1, 1],
          "pinned": true,
          "visible": false
        },
        {
          "name": "rblur",
          "type": "Segment",
          "args": ["Xblur", "Yblur"],
          "color": [.6, .6, .6],
          "visible": true,
          size: 1.5
        },
        {
          "name": "Zblur",
          "type": "PointOnLine",
          "pos": [13, ypos - ydiff * 4],
          "args": ["rblur"],
          "color": [1, 1, 1],
          "visible": true,
          "narrow": 100,
          size: 9
        },
        {
          "name": "rxblur",
          "type": "Segment",
          "args": ["Xblur", "Zblur"],
          "color": [1, 1, 1],
          "visible": true,
          size: 2.5
        },
        {
          "name": "Dummy",
          "type": "Free",
          "pos": [0, 0],
          "color": [1, 0, 0],
          "visible": false,
          "pinned": false
        },
      ]
    };
  }

  get name() {
    return 'iOrnmanet';
  }

  get description() {
    return 'TODO';
  }

  get credits() {
    return 'TODO';
  }
}

export default iOrnament;
