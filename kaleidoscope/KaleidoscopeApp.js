import CindyApp from '../common/js/CindyApp.js';

class KaleidoscopeApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(KaleidoscopeApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'Kaleidoskop',
            appDescription: 'Bei diesem Kaleidoskop mit drei Spiegeln ergeben sich Muster, die sich ins Unendliche fortsetzen. Am großen Schiebeschalter kann man einstellen, wie oft gespiegelt werden soll. An den Punkten läßt sich die Position von Bild und Kaleidoskop verändern.',
            pauseScript: '',
            image1: 'assets/default/bild.jpg',
            image2: 'assets/default/bild2.jpg',
            image3: 'assets/default/bild3.jpg',
            image4: 'assets/default/bild4.jpg',
        };
    }

    static async retrieveConfigOverrides() {
        return this.retrieveConfigOverridesJsonByClass(import.meta.url);
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('Kaleidoscope_'), ['init', 'mousedown', 'mouseUpX', 'draw', 'tick'], '.cs'),
            defaultAppearance: {},
            images: {
                bild: relativeUrl(this.config.image1),
                bild2: relativeUrl(this.config.image2),
                bild3: relativeUrl(this.config.image3),
                bild4: relativeUrl(this.config.image4),
            },
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",
                transform: [{visibleRect: [-24.77777777777778, 20.944444444444443, 32.111111111111114, -21.72222222222222]}]
            }],
            geometry: [
                {name: "D", type: "Free", pos: [-3.294761077446647, -4, 0.28967492528689526], color: [0, 1, 0]},
                {name: "E", type: "Free", pos: [4, -1.4651206020708303, 0.23502179355544858], color: [0, 1, 0]},
                {name: "G", type: "Free", pos: [4, -1.8182346561184846, -0.2468792697603344], color: [0, 1, 0]},
                {name: "A", type: "Free", pos: [4, 0.6331361369740157, -1.0406676910965347], color: [1, 1, 1]},
                {name: "B", type: "Free", pos: [0.9043478260869564, -4, 0.6749865807836822], color: [1, 1, 1]},
                {
                    name: "H",
                    type: "Free",
                    pos: [4, 3.1491832864888676, 0.18181818181818182],
                    pinned: true,
                    size: 2,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "K",
                    type: "Free",
                    pos: [4, -3.1491832864888676, 0.18181818181818182],
                    pinned: true,
                    size: 2,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "e",
                    type: "Segment",
                    args: ["H", "K"],
                    pos: [-0.1818181818181818, 0, 4],
                    size: 3,
                    color: [1, 1, 1]
                },
                {
                    name: "L",
                    type: "PointOnLine",
                    args: ["e"],
                    pos: [4, -2.095768880425196, 0.18181818181818185],
                    narrow: 100,
                    size: 7,
                    color: [1, 1, 1]
                },
                {
                    name: "C",
                    type: "Free",
                    pos: [4, 0, 0.16],
                    pinned: true,
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {
                    name: "F",
                    type: "Free",
                    pos: [4, 0, 0.12903225806451613],
                    pinned: true,
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {name: "a", type: "Segment", args: ["C", "F"], pos: [0, -4, 0], size: 3, color: [1, 1, 1]},
                {
                    name: "M",
                    type: "PointOnLine",
                    args: ["a"],
                    pos: [4, 0, 0.13995342517954137],
                    narrow: 100,
                    size: 0,
                    color: [1, 1, 1],
                    pinned: true
                }
            ]
        };
    }
}

export default KaleidoscopeApp;
