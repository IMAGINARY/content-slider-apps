import CindyApp from '../common/js/CindyApp.js';

class KaleidoscopeApp extends CindyApp {
    static defaultConfig = {
        appName: 'Kaleidoskop',
        appDescription: 'Bei diesem Kaleidoskop mit 3 Spiegeln ergeben sich Muster, die sich ins Unendliche fortsetzen. Am großen Schiebeschalter kann man einstellen, wie oft gespiegelt werden soll. An den Punkten läßt sich die Position von Bild und Kaleidoskop verändern.',
        pauseScript: '',
        resumeScript: '',
    };

    constructor(config = {}) {
        super(Object.assign(KaleidoscopeApp.defaultConfig, config));
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('Kaleidoscope_'), ['init', 'mousedown', 'mouseUpX', 'draw', 'tick'], '.cs'),
            defaultAppearance: {},
            images: {
                bild: relativeUrl("assets/bild.png"),
                bild2: relativeUrl("assets/bild2.png"),
                bild3: relativeUrl("assets/bild3.png"),
                bild4: relativeUrl("assets/bild4.png"),
                bild4X: relativeUrl("assets/bild4X.png"),
                bildX: relativeUrl("assets/bildX.png"),
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
