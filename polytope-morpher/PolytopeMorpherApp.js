import CindyApp from "../common/js/CindyApp.js";

class PolytopeMorpherApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(PolytopeMorpherApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'Polyeder basteln',
            appDescription: 'Ausgehend von einem platonischen Körper kann man durch das Anwenden von drei Operationen neue symmetrische Körper erzeugen. Ein Druck auf den Zauberstab übernimmt das aktuelle Objekt als neuen Ausgangspunkt für die Verformungen.',
            resetScript: 'resetAll();',
        };
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('PolytopeMorpher_'), ['draw', 'init', 'mousedown', 'mousedrag', 'mouseupX', 'tick'], '.cs'),
            defaultAppearance: {},
            images: {
                image1: relativeUrl("assets/image-1.png"),
                image2: relativeUrl("assets/image-2.png"),
                image3: relativeUrl("assets/image-3.png"),
                image4: relativeUrl("assets/image-4.png"),
                image5: relativeUrl("assets/image-5.png"),
                image6: relativeUrl("assets/image-6.png"),
                image7: relativeUrl("assets/image-7.png"),
                image8: relativeUrl("assets/image-8.png")
            },
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",
                transform: [{visibleRect: [-8.966666666666667, 11.466666666666667, 25.166666666666668, -14.133333333333333]}]
            }],
            geometry: [
                {
                    name: "U",
                    type: "Free",
                    pos: [4, -3.2, 0.26666666666666666],
                    pinned: true,
                    size: 2,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "V",
                    type: "Free",
                    pos: [4, -1.8666666666666667, 0.26666666666666666],
                    pinned: true,
                    size: 2,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "g",
                    type: "Segment",
                    args: ["U", "V"],
                    pos: [-0.26666666666666666, 0, 4],
                    size: 3,
                    color: [0.5019608, 0.5019608, 0.5019608]
                },
                {
                    name: "W",
                    type: "PointOnLine",
                    args: ["g"],
                    pos: [4, -2.474666666666667, 0.2666666666666667],
                    size: 9,
                    color: [1, 1, 1],
                    narrow: 100,
                },
                {
                    name: "H",
                    type: "Free",
                    pos: [4, -1.9074446680080486, 0.2012072434607646],
                    pinned: true,
                    color: [1, 1, 1]
                },
                {
                    name: "C1",
                    type: "CircleMr",
                    args: ["H"],
                    radius: 4,
                    size: 1,
                    color: [1, 1, 1],
                    printname: "$C_{1}$",
                    visible: false
                },
                {
                    name: "Rot",
                    type: "Free",
                    narrow: 100,
                    pos: [4, -1.7819742732112895, 0.17841102347588844],
                    plane: 3,
                    color: [1, 1, 1],
                    size: 8
                },
                {
                    name: "Span",
                    type: "Free",
                    narrow: 100,
                    pos: [4, -1.519543949003716, 0.21298655916459697],
                    plane: 3,
                    size: 6,
                    color: [1, 1, 1]
                },
                {
                    name: "A",
                    type: "Free",
                    pos: [4, -1.4285714285714286, 0.2857142857142857],
                    pinned: true,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "C",
                    type: "Free",
                    pos: [4, -0.8333333333333334, 0.16666666666666666],
                    pinned: true,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "a",
                    type: "Segment",
                    args: ["A", "C"],
                    pos: [0, 0.8, 4],
                    size: 3,
                    color: [0.5019608, 0.5019608, 0.5019608]
                },
                {
                    name: "G",
                    type: "Free",
                    pos: [4, -0.8571428571428571, 0.2857142857142857],
                    pinned: true,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "K",
                    type: "Free",
                    pos: [4, -0.5, 0.16666666666666666],
                    pinned: true,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "c",
                    type: "Segment",
                    args: ["G", "K"],
                    pos: [0, 1.3333333333333333, 4],
                    size: 3,
                    color: [0.5019608, 0.5019608, 0.5019608]
                },
                {
                    name: "L",
                    type: "PointOnLine",
                    args: ["a"],
                    pos: [4, -1.4285714285714277, 0.2857142857142856],
                    narrow: 100,
                    size: 9,
                    color: [1, 1, 1]
                },
                {
                    name: "M",
                    type: "Free",
                    pos: [4, -0.2857142857142857, 0.2857142857142857],
                    pinned: true,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "N",
                    type: "Free",
                    pos: [4, -0.16666666666666666, 0.16666666666666666],
                    pinned: true,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "d",
                    type: "Segment",
                    args: ["M", "N"],
                    pos: [0, -4, -4],
                    size: 3,
                    color: [0.5019608, 0.5019608, 0.5019608]
                },
                {
                    name: "O",
                    type: "PointOnLine",
                    args: ["d"],
                    pos: [4, -0.28571428571428575, 0.28571428571428575],
                    narrow: 100,
                    size: 9,
                    color: [1, 1, 1]
                },
                {
                    name: "P",
                    type: "PointOnLine",
                    args: ["c"],
                    pos: [4, -0.7590984016221631, 0.2530328005407211],
                    narrow: 100,
                    size: 9,
                    color: [1, 1, 1]
                },
                {name: "Wand", type: "Free", pos: [23, 4], pinned: true, color: [1, 1, 1], visible: false},
                {name: "C4", type: "Free", pos: [15, 8], pinned: true, color: [1, 1, 1], visible: false},
                {name: "C6", type: "Free", pos: [19, 8], pinned: true, color: [1, 1, 1], visible: false},
                {name: "C12", type: "Free", pos: [15, 4], pinned: true, color: [1, 1, 1], visible: false},
                {name: "C20", type: "Free", pos: [19, 4], pinned: true, color: [1, 1, 1], visible: false},
                {
                    name: "B8",
                    type: "Free",
                    pos: [4, -1.8993963782696177, 0.2012072434607646],
                    pinned: true,
                    color: [1, 1, 1]
                },
                {name: "C8", type: "Free", pos: [23, 8], pinned: true, color: [1, 1, 1], visible: false},
                {name: "Dummy", type: "Free", pos: [0, 0, 1], pinned: false, color: [1, 1, 1], visible: false}
            ]
        };
    }
}

export default PolytopeMorpherApp;
