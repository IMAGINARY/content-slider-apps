import CindyApp from "../common/js/CindyApp.js";

class EventTesterApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(EventTesterApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'EVENT TESTER',
        };
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
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
                    element: this.canvas,
                    background: "rgba(255,255,255,1)", transform: [{visibleRect: [-12.38, 11.5, 20.02, -8.82]}]
                }],
            cinderella: {build: 1812, version: [2, 9, 1812]}
        };
    }
}

export default EventTesterApp;
