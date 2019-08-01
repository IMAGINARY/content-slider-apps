import CindyApp from "../common/js/CindyApp.js";

class SwarmApp extends CindyApp {
    constructor() {
        super();
    }

    async _initCindyArgs() {
        const relativeUrl = filename => new URL(filename, import.meta.url).href;

        var nn = 30;
        var b = 10;
        var gslp = [
            {name: "B", type: "Free", pos: [-b, b], color: [0, 0, 0], size: 3, pinned: true},
            {name: "C", type: "Free", pos: [-b, -b], color: [0, 0, 0], size: 3, pinned: true},
            {name: "D", type: "Free", pos: [b, -b], color: [0, 0, 0], size: 3, pinned: true},
            {name: "E", type: "Free", pos: [b, b], color: [0, 0, 0], size: 3, pinned: true},
            {name: "K", type: "Free", pos: [-6, -2], color: [.7, .7, 1], size: 13, narrow: 100},
            {name: "J", type: "Free", pos: [4, 3], color: [.7, .7, 1], size: 13, narrow: 100},
            {name: "L", type: "Free", pos: [-2, 7], color: [.7, .7, 1], size: 13, narrow: 100},


            {name: "S1", type: "Free", pos: [10.5, 6], color: [0, 0, 0], pinned: true, size: 2},
            {name: "S2", type: "Free", pos: [16, 6], color: [0, 0, 0], pinned: true, size: 2},
            {name: "S", type: "Free", pos: [12.5, 6], color: [1, 0.5, 0.5], pinned: false, size: 9, narrow: 100},
            {name: "l", type: "Segment", args: ["S1", "S2"], color: [1, 1, 1], pinned: false, size: 4},
            {name: "R1", type: "Free", pos: [10.5, 4], color: [0, 0, 0], pinned: true, size: 2},
            {name: "R2", type: "Free", pos: [16, 4], color: [0, 0, 0], pinned: true, size: 2},
            {name: "R", type: "Free", pos: [11.5, 4], color: [1, 1, 1], pinned: false, size: 9, narrow: 100},
            {name: "m", type: "Segment", args: ["R1", "R2"], color: [1, 1, 1], pinned: false, size: 4},
            {name: "T1", type: "Free", pos: [10.5, 0], color: [0, 0, 0], pinned: true, size: 2},
            {name: "T2", type: "Free", pos: [16, 0], color: [0, 0, 0], pinned: true, size: 2},
            {name: "T", type: "Free", pos: [13, 0], color: [0.5, 0.5, 1], pinned: false, size: 9, narrow: 100},
            {name: "o", type: "Segment", args: ["T1", "T2"], color: [1, 1, 1], pinned: false, size: 4},

            {name: "U1", type: "Free", pos: [10.5, -2], color: [0, 0, 0], pinned: true, size: 2},
            {name: "U2", type: "Free", pos: [16, -2], color: [0, 0, 0], pinned: true, size: 2},
            {name: "U", type: "Free", pos: [12, -2], color: [0.5, 0.5, 1], pinned: false, size: 9, narrow: 100},
            {name: "r", type: "Segment", args: ["U1", "U2"], color: [1, 1, 1], pinned: false, size: 4},

            {name: "a", type: "Segment", args: ["B", "C"], color: [1, 1, 1], size: 1},
            {name: "b", type: "Segment", args: ["C", "D"], color: [1, 1, 1], size: 1},
            {name: "c", type: "Segment", args: ["D", "E"], color: [1, 1, 1], size: 1},
            {name: "d", type: "Segment", args: ["E", "B"], color: [1, 1, 1], size: 1}


        ];

        for (var i = 0; i < nn; i++) {
            gslp.push(
                {
                    name: "A" + i, type: "Free",
                    pos: [(Math.random() - .5) * 14, (Math.random() - .5) * 14],
                    color: [1, .5, .5], size: .1
                }
            )

        }
        ;
        var physics = [
            {
                behavior: {
                    type: "Environment", gravity: 0,
                    accuracy: 10, deltat: 0.2,
                    balls: false, charges: true, friction: 0
                }
            },

            {name: "a", behavior: {type: "Bouncer"}},
            {name: "b", behavior: {type: "Bouncer"}},
            {name: "c", behavior: {type: "Bouncer"}},
            {name: "d", behavior: {type: "Bouncer"}},
            {name: "K", behavior: {type: "Mass", charge: 1, fixed: true}},
            {name: "L", behavior: {type: "Mass", charge: 1, fixed: true}},
            {name: "J", behavior: {type: "Mass", charge: 1, fixed: true}},
        ];


        for (var i = 0; i < nn; i++) {
            physics.push(
                {
                    name: "A" + i, behavior: {
                        type: "Mass",
                        vx: Math.random() - .5,
                        vy: Math.random() - .5,
                        charge: 1.2
                    },
                }
            )
        }

        return {
            scripts: await CindyApp.loadScripts(relativeUrl('Swarm_'), ['init', 'mousedown', 'mouseup', 'move'], '.cs'),
            geometry: gslp,
            behavior: physics,
            images: {
                fishr: relativeUrl("assets/fishr.png"),
                fishb: relativeUrl("assets/fishb.png")
            },
            ports: [{
                element: this.canvas,
                background: "rgba(0,0,0,1)",
                transform: [{visibleRect: [-10, 10, 16.7, -10]}]
            }]

        };
    }

    get name() {
        return 'Schwarmsimulator';
    }

    get description() {
        return 'Das Schwarmverhalten entsteht dadurch, dass jeder Fisch einfachen Regeln folgt: anderen Fischen und Hindernissen ausweichen, zu den Nachbarfischen und mit ihnen schwimmen, oder einfach weiter schwimmen. Über die Schieberegel kann man die Parameter dieser Regeln anpassen.';
    }

    get credits() {
        return '';
    }
}

export default SwarmApp;
