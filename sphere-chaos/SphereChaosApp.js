import CindyApp from "../common/js/CindyApp.js";

class SphereChaosApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(SphereChaosApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'Lichtstrahl',
            appDescription: 'Wenn sich ein Lichtstrahl zwischen kreisförmigen Spiegeln reflektiert, entsteht <em>deterministisches Chaos</em>: eine kleine Änderung kann unvorhersehbare Auswirkungen haben. Was passiert, wenn der Lichtstrahl im Inneren eines Kreises startet?',
            pauseScript: '',
            resumeScript: '',
        };
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('SphereChaos_'), ['init', 'mousedown', 'mouseup', 'draw', 'tick'], '.cs'),
            defaultAppearance: {},
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",
                transform: [{visibleRect: [-16.291666666666668, 19.5, 26.375, -12.5]}]
            }],
            angleUnit: "°",
            geometry:
                [
                    {
                        name: "M1",
                        type: "Free",
                        pos: [1.4857142857142855, -4, 1.4081632653061225],
                        color: [1, 1, 1],
                        size: 9,
                    },
                    {
                        name: "C1",
                        type: "CircleByRadius",
                        pos: [1.4857142857142855, -4, 1.4081632653061225],
                        args: ["M1"],
                        radius: 5,
                        color: [1, 1, 1],
                        size: 5,
                    },
                    {
                        name: "M2",
                        type: "Free",
                        pos: [-1.2, 9, 1],
                        radius: 5,
                        color: [1, 1, 1],
                        size: 9,
                    },
                    {
                        name: "C2",
                        type: "CircleByRadius",
                        args: ["M2"],
                        radius: 5,
                        color: [1, 1, 1],
                        size: 5,
                    },
                    {
                        name: "M3",
                        type: "Free",
                        pos: [12.043333333333337, 6.035, 1],
                        color: [1, 1, 1],
                        size: 9,
                    },
                    {
                        name: "C3",
                        type: "CircleByRadius",
                        args: ["M3"],
                        radius: 7,
                        color: [1, 1, 1],
                        size: 5,
                    },
                    {
                        name: "RayBegin",
                        type: "Free",
                        pos: [3, 3, 1],
                        color: [1, 1, 1],
                        size: 9,
                        labeled: false,
                    },
                    {
                        name: "RayCircle",
                        type: "CircleByRadius",
                        color: [0.0, 0.0, 1.0],
                        radius: 3,
                        args: ["RayBegin"],
                        labeled: false,
                        visible: false,
                    },
                    {
                        name: "RayEnd",
                        type: "PointOnCircle",
                        pos: [5.5725, 1.4565], // should be angle: 329*(Math.PI/180), but it doesn't work
                        color: [1.0, 0.0, 0.0],
                        args: ["RayCircle"],
                        alpha: 0.0,
                        border: false,
                        labeled: false,
                    },
                    {
                        name: "Ray",
                        type: "Segment",
                        color: [1, 1, 1],
                        alpha: 0.2,
                        args: ["RayBegin", "RayEnd"],
                        size: 5,
                        arrowshape: "line", arrowsides: "==>", arrowsize: 1, arrowposition: 1.0,
                        labeled: false,
                        visible: true
                    }
                ]
        }
            ;
    }
}

export default SphereChaosApp;
