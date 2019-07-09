import CindyApp from "../common/js/CindyApp.js";

class EventTesterApp extends CindyApp {
    constructor() {
        super();
    }

    async cindyArgs(canvas) {
        const relativeUrl = filename => new URL(filename, import.meta.url);
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('EventTester_'), ['init', 'mousedown', 'mouseup', 'mousedrag', 'draw'], '.cs'),
            defaultAppearance: {fontFamily: "sans-serif", lineSize: 1, pointSize: 5.0},
            angleUnit: "°",
            geometry: [
                {
                    name: "A",
                    type: "Free",
                    pos: [4.0, -3.9365079365079367, -0.5291005291005291],
                    color: [1.0, 0.0, 0.0],
                    pinned: true,
                    labeled: true
                }],
            ports: [
                {
                    element: canvas,
                    background: "rgba(255,255,255,1)", transform: [{visibleRect: [-12.38, 11.5, 20.02, -8.82]}]
                }],
            cinderella: {build: 1812, version: [2, 9, 1812]}
        };
    }

    get name() {
        return 'EVENT TESTER';
    }

    get description() {
        return '';
    }

    get credits() {
        return '';
    }
}

export default EventTesterApp;
