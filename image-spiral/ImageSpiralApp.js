import CindyApp from "../common/js/CindyApp.js";

class ImageSpiralApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(ImageSpiralApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'Spirale',
            appDescription: 'Ein Bild wird um ein Zentrum gedreht und gestaucht oder gestreckt, das nennt man eine <em>Drehstreckung</em>. Das so veränderte Bild wird wieder gedreht und um denselben Faktor gestaucht oder gestreckt und so weiter. Dadurch entstehen wie von selbst faszinierende Bilder.',
            pauseScript: '',
            image1: 'assets/test1.png',
            image2: 'assets/test2.png',
            image3: 'assets/test3.png',
            image4: 'assets/test4.png',
            image5: 'assets/test5.png',
            image6: 'assets/test6.png',
        };
    }

    static async retrieveConfigOverrides() {
        return this.retrieveConfigOverridesJsonByClass(import.meta.url);
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('ImageSpiral_'), ['init', 'mousedown', 'draw', 'tick'], '.cs'),
            defaultAppearance: {},
            images: {
                test1: relativeUrl(this.config.image1),
                test2: relativeUrl(this.config.image2),
                test3: relativeUrl(this.config.image3),
                test4: relativeUrl(this.config.image4),
                test5: relativeUrl(this.config.image5),
                test6: relativeUrl(this.config.image6),
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
}

export default ImageSpiralApp;
