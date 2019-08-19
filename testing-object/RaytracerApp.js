import Application from '../common/js/application.js';

class RaytracerApp extends Application {
    constructor(config = {}) {
        super(Object.assign(RaytracerApp.defaultConfig, config));

        const object = document.createElement('object');
        object.type = 'text/html';
        object.data = 'http://science-to-touch.com/CJS/test/science/cindygl-demo/06_raytracer_bisection.html?';
        object.style.width = '100%';
        object.style.height = '100%';

        this._object = object;
    }

    static get defaultConfig() {
        return {
            appName: 'RaytracerApp',
        };
    }

    get ready() {
        return Promise.resolve(this);
    }

    get domElement() {
        return this._object;
    }

    reset() {
        super.reset();
        if (this.isReady)
            this._object.src += 'a';
    }
}

export default RaytracerApp;

