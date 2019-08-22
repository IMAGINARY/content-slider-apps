import CindyApp from "../common/js/CindyApp.js";

class PlatonicSolidsApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(PlatonicSolidsApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'Platonische Körper',
            appDescription: 'Hier können platonische Körper ineinander geschachtelt werden. Man achte auf die Vielfalt an Querbeziehungen, die sich durch die Art des Schachtelns ergeben.',
            resetScript: 'resetAll();',
            resumeScript: '',
            pauseScript: '',

        };
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('PlatonicSolids_'), ['draw', 'init', 'mousedown', 'mousedrag', 'mouseup', 'tick'], '.cs'),
            defaultAppearance: {},
            autoplay: true,
            images: {
                image11: relativeUrl("assets/image-11.png"),
                image12: relativeUrl("assets/image-12.png"),
                image13: relativeUrl("assets/image-13.png"),
                image14: relativeUrl("assets/image-14.png"),
                image15: relativeUrl("assets/image-15.png"),
                image16: relativeUrl("assets/image-16.png"),
                image17: relativeUrl("assets/image-17.png"),
                image19: relativeUrl("assets/image-19.png"),
                image20: relativeUrl("assets/image-20.png")
            },
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",
                transform: [{visibleRect: [-19.615384615384617, 13.923076923076923, 19.76923076923077, -15.615384615384615]}]
            }],
            geometry: [
                {
                    name: "Q",
                    type: "Free",
                    pos: [4, 0.28149829738933024, -0.22701475595913728],
                    pinned: true,
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {
                    name: "R",
                    type: "Free",
                    pos: [4, 0.33926128590971266, -0.2735978112175102],
                    pinned: true,
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {
                    name: "a",
                    type: "Segment",
                    args: ["Q", "R"],
                    pos: [0, 3.225806451612903, 4],
                    size: 3,
                    color: [1, 1, 1]
                },
                {
                    name: "S",
                    type: "PointOnLine",
                    args: ["a"],
                    pos: [4, 0.3131313111544739, -0.25252525093102735],
                    narrow: 50,
                    size: 4,
                    color: [1, 1, 1]
                },
                {
                    name: "C4",
                    type: "Free",
                    pos: [4, 1.9749373433583963, 0.25062656641604014],
                    pinned: true,
                    plane: 1,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "C6",
                    type: "Free",
                    pos: [4, 0.875, 0.25],
                    pinned: true,
                    plane: 1,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "C8",
                    type: "Free",
                    pos: [4, -0.25, 0.25],
                    pinned: true,
                    plane: 1,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "C12",
                    type: "Free",
                    pos: [4, -1.375, 0.25],
                    pinned: true,
                    plane: 1,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "C20",
                    type: "Free",
                    pos: [4, -2.5, 0.25],
                    pinned: true,
                    plane: 1,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "DelOut",
                    type: "Free",
                    pos: [4, -1.9354838709677415, -0.24813895781637713],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "DelIn",
                    type: "Free",
                    pos: [4, -0.7642679900744414, -0.24813895781637707],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "NoEdges",
                    type: "Free",
                    pos: [4, 1.25, -0.25],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "YesEdges",
                    type: "Free",
                    pos: [4, 2.355889724310776, -0.2506265664160401],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "Dummy",
                    type: "Free",
                    pos: [0, 0.355889724310776, -0.2506265664160401],
                    pinned: false,
                    color: [1, 0, 0],
                    visible: false
                }
            ]
        };
    }
}

export default PlatonicSolidsApp;
