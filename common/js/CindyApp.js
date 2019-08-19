import Application from './application.js';

class CindyApp extends Application {
    constructor(config = {}) {
        super(Object.assign(CindyApp.defaultConfig, config));
        console.log("CindyApp called");
        this._cindy = null;
        this._cindyPromise = (async () => createCindy.newInstance(await this.cindyArgs))()
            .then(cindy => this._cindy = cindy);
        this._cindyAppReadyPromise = super.ready
            .then(() => CindyApp.waitForDomInsertion(this.canvas, document))
            .then(() => this.cindyReady)
            .then(cindy => {
                cindy.startup();
                return this;
            });
    }

    static get defaultConfig() {
        return {
            appName: 'CindyJS app',
            pauseScript: 'pause();',
            resumeScript: 'resume();',
            resetScript: 'reset();',
        };
    }

    static async request(obj) {
        return new Promise((resolve, reject) => {
            let xhr = new XMLHttpRequest();
            xhr.open(obj.method || "GET", obj.url);
            if (obj.headers) {
                Object.keys(obj.headers).forEach(key => {
                    xhr.setRequestHeader(key, obj.headers[key]);
                });
            }
            xhr.onload = () => {
                if (xhr.status >= 200 && xhr.status < 300) {
                    resolve(xhr.response);
                } else {
                    reject(xhr);
                }
            };
            xhr.onerror = () => reject(xhr);
            xhr.send(obj.body);
        });
    }

    static async loadScripts(prefix, infixes, suffix) {
        const scripts = {};
        const promises = [];
        // TODO: error handling for failed loads
        for (let infix of infixes)
            promises.push(CindyApp.request({url: prefix + infix + suffix}).then(scriptText => scripts[infix] = scriptText));
        await Promise.all(promises);
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
        return this._cindyAppReadyPromise;
    }

    get domElement() {
        return this.canvas;
    }

    pause() {
        super.pause();
        if (this._isReady) {
            this.cindy.evokeCS(this.config.pauseScript);
            this.cindy.stop();
        }
    }

    resume() {
        super.resume();
        if (this._isReady) {
            this.cindy.evokeCS(this.config.resumeScript);
            this.cindy.play();
        }
    }

    reset() {
        super.reset();
        if (this._isReady) {
            this.cindy.evokeCS(this.config.resetScript);
        }
    }
}

export default CindyApp;
