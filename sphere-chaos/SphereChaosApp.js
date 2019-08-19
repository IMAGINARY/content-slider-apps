import CindyApp from "../common/js/CindyApp.js";

class SphereChaosApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(SphereChaosApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'Lichtstrahl',
            appDescription: 'Wenn sich ein Lichtstrahl zwischen kreisförmigen Spiegeln reflektiert, entsteht <em>deterministisches Chaos</em>: eine kleine Änderung kann unvorhersehbare Auswirkungen haben.  Was passiert, wenn der Lichtstrahl im Inneren eines Kreises startet?',
        };
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('SphereChaos_'), ['init', 'mousedown', 'draw', 'tick'], '.cs'),
            defaultAppearance: {},
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",

                transform: [{visibleRect: [-16.291666666666668, 19.5, 26.375, -12.5]}]
            }],
            geometry: [
                {
                    name: "A",
                    type: "Free",
                    pos: [1.4857142857142855, -4, 1.4081632653061225],
                    color: [1, 0, 0],
                    alpha: 0.8999999761581421,
                    pointborder: false,
                    size: 9,
                    narrow: 100
                },
                {
                    name: "B",
                    type: "Free",
                    pos: [-1.2, 9, 1],
                    color: [1, 0, 0],
                    alpha: 0.8999999761581421,
                    pointborder: false,
                    size: 9,
                    narrow: 100
                },
                {
                    name: "C",
                    type: "Free",
                    pos: [12.043333333333337, 6.035, 1],
                    color: [1, 0, 0],
                    alpha: 0.8999999761581421,
                    pointborder: false,
                    size: 9,
                    narrow: 100
                },
                {
                    name: "D",
                    type: "Free",
                    pos: [3, 3, 1],
                    color: [1, 0.7, 0],
                    alpha: 0.8999999761581421,
                    pointborder: false,
                    size: 9,
                    narrow: 100
                },
                {name: "C3", type: "CircleMr", args: ["D"], radius: 1, size: 3, color: [0, 0, 1], alpha: 0},
                {name: "E", type: "Free", pos: [13, -3, 1], pinned: false, size: 4, color: [1, 1, 1], narrow: 100},
                {name: "Dummy", type: "Free", pos: [100, 100], pinned: false, size: 0, color: [1, 1, 1]}
            ]
        };
    }
}

export default SphereChaosApp;
