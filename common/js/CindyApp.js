import Application from './application.js';

class CindyApp extends Application {
    constructor() {
        super();
        console.log("CindyApp called");
        this._cindy = null;
        this._cindyPromise = (async () => createCindy.newInstance(await this.cindyArgs))()
            .then(cindy => this._cindy = cindy);
        this._isReady = false;
        this._readyPromise = CindyApp.waitForDomInsertion(this.canvas, document)
            .then(() => this.cindyReady)
            .then(cindy => {
                cindy.startup();
                this._isReady = true;
                return this;
            });
    }

    static async loadScripts(prefix, infixes, suffix) {
        const scripts = {};
        const promises = [];
        // TODO: error handling for failed loads
        for (let infix of infixes)
            promises.push($.get(prefix + infix + suffix).then(scriptText => scripts[infix] = scriptText));
        Promise.all(promises);
        return scripts;
    }

    get canvas() {
        if (typeof this._canvas === 'undefined') {
            this._canvas = document.createElement('canvas');
            this._canvas.width = 1560;
            this._canvas.height = 1170;
        }
        return this._canvas;
    }

    get cindyReady() {
        return this._cindyPromise;
    }

    get cindy() {
        return this._cindy;
    }

    get cindyArgs() {
        if (typeof this._cindyArgs === 'undefined')
            this._cindyArgs = this._initCindyArgs();
        return this._cindyArgs;
    }

    async _initCindyArgs() {
        throw new Error(`Unimplemented. Must be implemented in subclass ${this.constructor.name}.`);
    }

    static async waitForDomInsertion(element, root) {
        return new Promise(resolve => {
            if (element.parentElement === null) {
                // resolve after insertion of the element into the given DOM subtree
                const observer = new MutationObserver(() => {
                    if (element.parentElement !== null) {
                        observer.disconnect();
                        resolve();
                    }
                });
                observer.observe(root, {childList: true, subtree: true});
            } else {
                // resolve immediately
                resolve();
            }
        });
    }

    get ready() {
        console.log(this._readyPromise);
        return this._readyPromise;
    }

    get domElement() {
        return this.canvas;
    }

    get name() {
        return 'CindyApp';
    }

    get description() {
        return 'Eine App, die mit CindyJS erstellt wurde.';
    }

    get credits() {
        return '';
    }

    pause() {
        console.log(`pause ${this.constructor.name}`);
        if (this._isReady)
            this.cindy.evokeCS('pause();');
    }

    resume() {
        console.log(`resume ${this.constructor.name}`);
        if (this._isReady)
            this.cindy.evokeCS('resume();');
    }

    restart(pauseAfterRestart) {
        console.log(`restart ${this.constructor.name}`);
        if (this._isReady)
            this.cindy.evokeCS('reset();');
    }
}

export default CindyApp;
