import CindyApp from "../common/js/CindyApp.js";

class SolitaireApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(SolitaireApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'Solitaire-Spiel',
            appDescription: 'In jedem Spielzug überspringt man mit einer Kugel eine andere, die dann weggenommen wird. Nach 13 Zügen soll nur noch eine Kugel übrig bleiben. Das Ganze ist gar nicht so einfach. Profis schaffen es, den letzten Spielstein dort zu positionieren, wo zu Beginn das Loch war.',
            pauseScript: '',
            resumeScript: '',
        };
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;

        this.canvas.style.backgroundImage = `url('${relativeUrl("assets/background.png")}')`;

        return {
            scripts: await CindyApp.loadScripts(relativeUrl('Solitaire_'), ['draw', 'init', 'mousedown', 'mousedrag', 'mouseup', 'tick'], '.cs'),
            defaultAppearance: {},
            images: {
                replay: relativeUrl("assets/Replay.png"),
                peg: relativeUrl("assets/peg.png"),
                emptypeg: relativeUrl("assets/emptypeg.png"),
            },
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",
                transform: [{visibleRect: [-10.635445120621503, 13.61908146108596, 30.41961350747239, -17.17221250998446]}]
            }],
            geometry: [
                {
                    name: "A",
                    type: "Free",
                    pos: [-1.75, -4, 0.25],
                    pinned: true,
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {
                    name: "B",
                    type: "Free",
                    pos: [4, -2.6666666666666665, 0.16666666666666666],
                    pinned: true,
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {
                    name: "C",
                    type: "Free",
                    pos: [4, -2.6181818181818177, 0.45454545454545453],
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                },
                {
                    name: "D",
                    type: "Free",
                    pos: [4, -2.460850111856823, 0.2237136465324385],
                    color: [1, 0, 0],
                    labeled: true,
                    visible: false
                }
            ]
        };
    }
}

export default SolitaireApp;
