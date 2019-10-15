import Application from '../common/js/application.js';
import './2048-content-slider-v1.2.3/js/game2048.js';
import '../common/js/loadjs/3.6.1/loadjs.min.js';

const _cssUrl = new URL('2048-content-slider-v1.2.3/style/main.css', import.meta.url).href;
const _cssReady = loadjs(['css!' + _cssUrl], {returnPromise: true});

class Game2048App extends Application {
    constructor(config = {}) {
        super(Object.assign(Game2048App.defaultConfig, config));
        this._game2048 = new Game2048();
    }

    static get defaultConfig() {
        return {
            appName: '2048',
            appDescription: 'Tippe einen Spielstein an, um dessen Punktezahl zu sehen. Schiebe gleiche Steine ineinander, um daraus einen Neuen mit höherer Punktezahl zu erzeugen. Mit der Zeit wird das Spielfeld dadurch ganz schön voll. Schaffst du es einen 2048-Spielstein zu bilden? Wie viele Steine muss man dazu verschmelzen?',
        };
    }

    get ready() {
        return _cssReady;
    }

    get domElement() {
        return this._game2048.domElement;
    }

    pause() {
        super.pause();
        if (this._isReady) {
            this._game2048.pause();
        }
    }

    resume() {
        super.resume();
        if (this._isReady) {
            this._game2048.resume();
        }
    }

    reset() {
        super.reset();
        if (this._isReady) {
            this._game2048.reset();
        }
    }
}

export default Game2048App;
