import CindyApp from "../common/js/CindyApp.js";

class DoublePendulumApp extends CindyApp {
    static defaultConfig = {
        appName: 'Doppelpendel',
        appDescription: 'An einem Pendel ist ein weiteres Pendel aufgehängt. Dadurch entsteht ein einfaches System, das <em>deterministisches Chaos</em> aufweist. Wie sich das System mit der Zeit verhält, hängt stark von der Startposition, den Längen und Massen der beiden Pendel ab.',
    };

    constructor(config = {}) {
        super(Object.assign(DoublePendulumApp.defaultConfig, config));
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('DoublePendulum_'), ['init', 'mousedown', 'draw', 'simulationstep'], '.cs'),
            defaultAppearance: {},
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",
                transform: [{visibleRect: [-11.125, 11.916666666666666, 31.541666666666668, -20.083333333333332]}]
            }],
            geometry:
                [
                    {
                        name: "A",
                        type: "Free",
                        pos: [4, -2.4074074074074074, 0.46296296296296297],
                        pinned: true,
                        color: [1, 1, 1],
                        alpha: 0.8999999761581421
                    },
                    {
                        name: "B",
                        type: "Free",
                        pos: [8, 4, 1],
                        narrow: 100,
                        tracedim: 0.46153846153846156,
                        size: 11,
                        textsize: 17,
                        color: [1, 0.5, 0.5],
                        alpha: 0.8999999761581421
                    },
                    {
                        name: "a",
                        type: "Segment",
                        args: ["A", "B"],
                        pos: [-0.400381942958006, 0.10398077170054389, 4],
                        lineborder: true,
                        size: 8,
                        color: [0.098039225, 0.61960787, 0.30588236],
                        alpha: 0.8999999761581421
                    },
                    {
                        name: "C",
                        type: "Free",
                        pos: [9, 7, 1],
                        narrow: 100,
                        tracelength: 163,
                        size: 11,
                        color: [0.5, 1, 0.5],
                        alpha: 0.8999999761581421
                    },
                    {
                        name: "b",
                        type: "Segment",
                        args: ["B", "C"],
                        pos: [-0.6558559754947599, -0.014400127426873377, 4],
                        lineborder: true,
                        size: 8,
                        color: [0.098039225, 0.61960787, 0.30588236],
                        alpha: 0.8999999761581421
                    },
                    {
                        name: "F",
                        type: "Free",
                        pos: [3.4, -4, -0.5],
                        narrow: 100,
                        size: 0,
                        color: [1, 0, 0],
                        alpha: 0.8999999761581421
                    },
                    {
                        name: "G",
                        type: "Free",
                        pos: [4, -2.1882352941176473, -0.5882352941176471],
                        narrow: 100,
                        size: 0,
                        color: [1, 0, 0],
                        alpha: 0.8999999761581421
                    },
                    {
                        name: "c",
                        type: "Segment",
                        args: ["F", "G"],
                        pos: [0.5882352941176472, 0, 4],
                        overlap: 4,
                        size: 3,
                        color: [1, 1, 1]
                    },
                    {
                        name: "Dummy",
                        type: "Free",
                        pos: [0, 0.355889724310776, -0.2506265664160401],
                        pinned: false,
                        color: [1, 0, 0],
                        visible: false
                    }
                ],
            behavior:
                [
                    {behavior: {type: "Environment", gravity: 0, deltat: 0.5, accuracy: 60}},
                    {name: "B", behavior: {type: "Mass", mass: 1, friction: 0}},
                    {name: "C", behavior: {type: "Mass", mass: 0.2, friction: 0}},
                    {name: "a", behavior: {type: "Spring", stype: 0, strength: 110}},
                    {name: "b", behavior: {type: "Spring", stype: 0, strength: 110}},
                    {name: "c", behavior: {type: "Gravity", strength: 0.01}}
                ]
        };
    }
}

export default DoublePendulumApp;
