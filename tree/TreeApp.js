import CindyApp from "../common/js/CindyApp.js";

class TreeApp extends CindyApp {
    static defaultConfig = {
        appName: 'Ein Baum',
        pauseScript: '',
        resumeScript: '',
    };

    constructor(config = {}) {
        super(Object.assign(TreeApp.defaultConfig, config));
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;
        return {
            scripts: await CindyApp.loadScripts(relativeUrl('Tree_'), ['init', 'draw'], '.cs'),
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",
                transform: [{visibleRect: [-10, 10, 10, -10]}]
            }],
            geometry: [
                {name: "A", type: "Free", size: 6, pos: [0, -8], color: [1, 1, 1]},
                {name: "B", type: "Free", size: 6, pos: [0, -4.5], color: [1, 1, 1]},
                {name: "C", type: "Free", size: 6, pos: [1.5, -2], color: [1, 1, 1]},
                {name: "D", type: "Free", size: 6, pos: [-1.6, -2.5], color: [1, 1, 1]},
            ]
        };
    }
}

export default TreeApp;
