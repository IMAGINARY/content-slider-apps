import CindyApp from "../common/js/CindyApp.js";

class ImageSpiralApp extends CindyApp {
    constructor() {
        super();
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('ImageSpiral_'), ['init', 'mousedown', 'draw', 'tick'], '.cs'),
            defaultAppearance: {},
            images: {
                test1: relativeUrl('assets/test1.png'),
                test2: relativeUrl('assets/test2.png'),
                test3: relativeUrl('assets/test3.png'),
                test4: relativeUrl('assets/test4.png'),
                test5: relativeUrl('assets/test5.png'),
                test6: relativeUrl('assets/test6.png'),
            },
            ports: [{
                element: this.canvas,
                background: "rgba(0,255,0,0)",
                transform: [{visibleRect: [-12, 16, 30, -14]}]
            }],
            geometry: [
                {
                    name: "B",
                    type: "Free",
                    pos: [4, -0.3346613545816733, 0.39840637450199207],
                    size: 9,
                    color: [0, 1, 0]
                },
                {
                    name: "C",
                    type: "Free",
                    pos: [4, 1.2289387168822175, 0.4359319522866157],
                    size: 9,
                    color: [0, 1, 0]
                },
                {
                    name: "D",
                    type: "Free",
                    pos: [4, 1.9, 0.17953321364452424],
                    pinned: true,
                    size: 7,
                    color: [1, 1, 1],
                    labeled: true,
                    visible: false
                },
                {
                    name: "C0",
                    type: "CircleMr",
                    args: ["D"],
                    radius: 3,
                    pinned: true,
                    size: 3,
                    color: [1, 1, 1],
                    printname: "$C_{0}$"
                },
                {
                    name: "E",
                    type: "Free",
                    pos: [5, 3.1, 0.20859302441322417],
                    pinned: false,
                    size: 9,
                    color: [1, 1, 1]
                },
                {
                    name: "A",
                    type: "Free",
                    pos: [4, 2, 0.14880952380952378],
                    pinned: true,
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {
                    name: "F",
                    type: "Free",
                    pos: [4, 1.1, 0.14880952380952378],
                    pinned: true,
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {
                    name: "a",
                    type: "Segment",
                    args: ["A", "F"],
                    pos: [-0.1488095238095238, 0, 4],
                    size: 3,
                    color: [1, 1, 1],
                    labeled: true
                },
                {
                    name: "G",
                    type: "PointOnLine",
                    args: ["a"],
                    pos: [4, 1.8, 0.1488095238095238],
                    size: 9,
                    color: [1, 1, 1],
                    labeled: true
                }
            ]
        };
    }

    get name() {
        return 'Spirale';
    }

    get description() {
        return 'Ein Bild wird um ein Zentrum gedreht und gestaucht oder gestreckt, das nennt man eine <em>Drehstreckung</em>. Das so veränderte Bild wird wieder gedreht und um denselben Faktor gestaucht oder gestreckt und so weiter. Dadurch entstehen wie von selbst faszinierende Bilder.';
    }

    get credits() {
        return 'Author 2a<br/>Author 2b';
    }
}

export default ImageSpiralApp;
