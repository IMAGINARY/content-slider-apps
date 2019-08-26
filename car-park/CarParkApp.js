import CindyApp from "../common/js/CindyApp.js";

class CarParkApp extends CindyApp {
    constructor(config = {}) {
        super(Object.assign(CarParkApp.defaultConfig, config));
    }

    static get defaultConfig() {
        return {
            appName: 'Ausparken',
            appDescription: 'Wer schafft es, das rote Rennauto auszuparken? Leider stehen einige Autos im Weg, denen wiederum andere Autos im Weg stehen. Dieses Knobelspiel wurde 1970 von Nobuyuki Yoshigahara erfunden.',
            pauseScript: '',
            resumeScript: 'pauseanimation();',
            numLevels: 7,
        };
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename,
            import.meta.url).href;

        const levelFiles = await Promise.all(["beginner", "easy", "medium", "hard", "extreme"].map(l => CindyApp.request({
            url: relativeUrl(`levels/${l}.txt`)
        })));

        // filter out invalid lines and parse level files
        const whitespaceRegExp = /\s+/g;
        const levelRegExp = /^[oxA-Z]{36}$/;
        const reduceWhiteSpace = s => s.replace(whitespaceRegExp, ' ').trim();
        const processLevelFile = f => f.split('\n')
            .map(reduceWhiteSpace)
            .map(l => l.split(" "))
            .filter(l => l.length === 3)
            .filter(l => levelRegExp.test(l[1]));
        const levelSets = levelFiles.map(processLevelFile);

        function wrap(v) { //converts js-lists of lists of real numbers to CS-object.
            if (typeof v === "number") {
                return {
                    "ctype": "number",
                    "value": {
                        'real': v,
                        'imag': 0
                    }
                };
            } else if (typeof v === "object" && v.length !== undefined) {
                return {
                    "ctype": "list",
                    "value": v.map(wrap)
                }
            }
        }

        function convertLevelFormat(levelstr) {
            const bins = {};
            for (let i = 0; i < 36; i++) {
                const c = levelstr[i];
                if (c !== 'o') {
                    if (!bins[c]) bins[c] = [];
                    bins[c].push([1 + i % 6, 6 - (i / 6 | 0)]); //convert to Cindy-coordinates
                }
            }
            const cindyformat = [[], [], []];
            Object.keys(bins).forEach(c => {
                if (c === 'A') {
                    cindyformat[2].push(bins[c].sort());
                } else if (bins[c].length === 2) {
                    cindyformat[0].push(bins[c].sort());
                } else if (bins[c].length === 3) {
                    cindyformat[1].push([bins[c][0], bins[c][2]].sort());
                }
            });
            return cindyformat;
        }

        function shuffledLevels(numLevels) {
            // keep start index for each set to to avoid selecting the same level twice
            const setLengths = levelSets.map(set => set.length);
            const levels = new Array(numLevels).fill(0).map((v, k) => {
                const setIndex = Math.floor((k * (levelSets.length - 1)) / (numLevels - 1));
                const set = levelSets[setIndex];
                if (setLengths[setIndex] > 0) {
                    // select a random level and move it to the end of the set to avoid returning duplicate levels
                    const levelIndex = Math.floor(Math.random() * setLengths[setIndex]);
                    const level = set[levelIndex];
                    set[levelIndex] = set[setLengths[setIndex] - 1];
                    set[setLengths[setIndex] - 1] = level;
                    setLengths[setIndex]--;
                    return level;
                } else {
                    // can not select levels without having duplicates, so just choose a random one
                    if (levelSets.length === 0) {
                        throw new Error("Car park level set is empty");
                    } else {
                        return set[Math.floor(Math.random() * set.length)];
                    }
                }
            });
            return levels;
        }

        CindyJS.registerPlugin(1, "carparklevels", (api) => {
            api.defineFunction("getshuffledlevels", 1, (args) => {
                const numLevels = api.evaluate(args[0]).value.real | 0;
                const levels = shuffledLevels(numLevels);
                return wrap(levels.map(level => convertLevelFormat(level[1])));
            });
            api.defineFunction("getshuffledlevels", 0, (args) => {
                const levels = shuffledLevels(this.config.numLevels);
                return wrap(levels.map(level => convertLevelFormat(level[1])));
            });
        });

        return {
            scripts: await CindyApp.loadScripts(relativeUrl('CarPark_'), ['draw', 'init', 'mousedown', 'mousedrag', 'mouseup', 'tick'], '.cs'),
            defaultAppearance: {},
            use: ["carparklevels"],
            images: {
                a1: relativeUrl("assets/a1.png"),
                a10: relativeUrl("assets/a10.png"),
                a11: relativeUrl("assets/a11.png"),
                a12: relativeUrl("assets/a12.png"),
                a2: relativeUrl("assets/a2.png"),
                a3: relativeUrl("assets/a3.png"),
                a4: relativeUrl("assets/a4.png"),
                a5: relativeUrl("assets/a5.png"),
                a6: relativeUrl("assets/a6.png"),
                a7: relativeUrl("assets/a7.png"),
                a8: relativeUrl("assets/a8.png"),
                a9: relativeUrl("assets/a9.png"),
                my: relativeUrl("assets/my.png"),
                t1: relativeUrl("assets/t1.png"),
                t2: relativeUrl("assets/t2.png"),
                t3: relativeUrl("assets/t3.png"),
                t4: relativeUrl("assets/t4.png"),
                t5: relativeUrl("assets/t5.png"),
                t6: relativeUrl("assets/t6.png"),
                t7: relativeUrl("assets/t7.png")
            },
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,0)",
                transform: [{
                    visibleRect: [-0.7280283924068959, 15.687837617026014, 23.320393343872503, -2.3484786851835353]
                }]
            }],
            geometry: [{
                    name: "A",
                    type: "Free",
                    pos: [4, 2.896551724137931, 0.27586206896551724],
                    pinned: true,
                    color: [0.011764707, 0.654902, 0.7372549],
                    visible: false
                },
                {
                    name: "B",
                    type: "Free",
                    pos: [4, 4, 0.27586206896551724],
                    pinned: true,
                    color: [0.011764707, 0.654902, 0.7372549],
                    visible: false
                },
                {
                    name: "C",
                    type: "Free",
                    pos: [-0.41379310344827586, -4, -0.27586206896551724],
                    pinned: true,
                    color: [0.011764707, 0.654902, 0.7372549],
                    visible: false
                },
                {
                    name: "D",
                    type: "Free",
                    pos: [4, 4, 2.6666666666666665],
                    pinned: true,
                    color: [0.011764707, 0.654902, 0.7372549],
                    visible: false
                },
                {
                    name: "E",
                    type: "Free",
                    pos: [4, 0.41379310344827586, 0.27586206896551724],
                    pinned: true,
                    color: [0.011764707, 0.654902, 0.7372549],
                    visible: false
                },
                {
                    name: "F",
                    type: "Free",
                    pos: [4, 2.0689655172413794, 0.27586206896551724],
                    pinned: true,
                    color: [0.011764707, 0.654902, 0.7372549],
                    visible: false
                },
                {
                    name: "G",
                    type: "Free",
                    pos: [4, 2.4539413505743948, 0.27378461313468927],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "H",
                    type: "Free",
                    pos: [4, 2.153071813333942, 0.24021679789814773],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "a",
                    type: "Segment",
                    args: ["G", "H"],
                    pos: [3.6900479683254696e-16, -0.4462773538912901, 4],
                    overlap: 1,
                    size: 1,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "K",
                    type: "PointOnLine",
                    args: ["a"],
                    pos: [4, 2.2181043779580167, 0.2474724381124468],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "b",
                    type: "Segment",
                    args: ["G", "K"],
                    pos: [9.41517364566149e-16, -0.4462773538912905, 4],
                    size: 4,
                    color: [1, 1, 1],
                    visible: false
                },
                {
                    name: "L",
                    type: "Free",
                    pos: [4, 2.883018915215197, 0.2017656373068423],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "M",
                    type: "Free",
                    pos: [4, 0.28610216985784337, 0.2017656373068423],
                    pinned: true,
                    color: [1, 0, 0],
                    visible: false
                },
                {
                    name: "c",
                    type: "Segment",
                    args: ["L", "M"],
                    pos: [-0.2017656373068423, 0, 4],
                    size: 3,
                    color: [1, 1, 1]
                },
                {
                    name: "N",
                    type: "PointOnSegment",
                    args: ["c"],
                    pos: [4, 0.2861021698578434, 0.2017656373068423],
                    narrow: 200,
                    size: 11,
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
            ]
        };
    }
}

export default CarParkApp;
