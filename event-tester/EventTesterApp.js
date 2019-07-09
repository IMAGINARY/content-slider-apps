import Application from '../common/js/application.js';

class EventTesterApp extends Application {
    constructor() {
        super();

        const canvas = document.createElement('canvas');
        canvas.width = 1560;
        canvas.height = 1170;

        const relativeUrl = filename => new URL(filename, import.meta.url);

        const initScriptPromise = $.get(relativeUrl('EventTester_init.cs'));
        const drawScriptPromise = $.get(relativeUrl('EventTester_draw.cs'));
        const mousedownScriptPromise = $.get(relativeUrl('EventTester_mousedown.cs'));
        const mouseupScriptPromise = $.get(relativeUrl('EventTester_mouseup.cs'));
        const mousedragScriptPromise = $.get(relativeUrl('EventTester_mousedrag.cs'));

        this._readyPromise = new Promise(async (resolve) => {
            this._cindy = createCindy.newInstance(
                {
                    scripts: {
                        init: await initScriptPromise,
                        mousedown: await mousedownScriptPromise,
                        mouseup: await mouseupScriptPromise,
                        mousedrag: await mousedragScriptPromise,
                        draw: await drawScriptPromise,
                    },
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
                }
            );
            if (canvas.parentElement === null) {
                // startup after insertion of the canvas into the DOM
                const observer = new MutationObserver(() => {
                    if (canvas.parentElement !== null) {
                        this._cindy.startup();
                        resolve(this);
                        observer.disconnect();
                    }
                });
                observer.observe(document, {childList: true, subtree: true});
            } else {
                // startup immediately
                this._cindy.startup();
                resolve(this);
            }
        });

        this._canvas = canvas;
    }

    get ready() {
        return this._readyPromise;
    }

    get domElement() {
        return this._canvas;
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

    pause() {
        console.log(`pause ${this.constructor.name}`);
        this.ready.then(instance => instance._cindy.evokeCS('pause();'));
    }

    resume() {
        console.log(`resume ${this.constructor.name}`);
        this.ready.then(instance => instance._cindy.evokeCS('reset();'));
    }

    restart(pauseAfterRestart) {
        console.log(`restart ${this.constructor.name}`);
        this.ready.then(instance => instance._cindy.evokeCS('reset();'));
    }
}

export default EventTesterApp;
