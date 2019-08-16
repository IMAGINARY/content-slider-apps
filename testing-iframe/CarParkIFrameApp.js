import Application from '../common/js/application.js';

class CarParkIFrameApp extends Application {
    static defaultConfig = {
        appName: 'CarParkIFrameApp',
    };

    constructor(config = {}) {
        super(Object.assign(CarParkIFrameApp.defaultConfig, config));

        const iframe = document.createElement('iframe');
        this._readyPromise = new Promise(resolve => iframe.addEventListener('load', () => resolve(this)));

        iframe.src = 'http://science-to-touch.com/Mathematikon/dmweb/content/G4/Widget.html?';
        iframe.style.width = '100%';
        iframe.style.height = '100%';

        this._iframe = iframe;
    }

    get ready() {
        return this._readyPromise;
    }

    get domElement() {
        return this._iframe;
    }

    reset() {
        super.reset();
        this._iframe.src += 'a';
    }
}

export default CarParkIFrameApp;
