import Application from '../common/js/application.js';

class CounterApp extends Application {
    static defaultConfig = {
        appName: 'CounterApp',
    };

    constructor(config = {}) {
        super(Object.assign(CounterApp.defaultConfig, config));

        const div = document.createElement("div");
        div.style.fontSize = '64px';
        div.style.color = '#' + Math.floor(Math.random() * 16777215).toString(16);

        this._domElement = div;

        this._number = 0;
        this._timeout = 0;
    }

    _animate() {
        this._render();
        this._number++;
        this._requestAnimation();
    }

    _render() {
        this.domElement.innerHTML = this._number;
    }

    _requestAnimation() {
        clearTimeout(this._timeout);
        this._timeout = window.setTimeout(this._animate.bind(this), 1000);
    }

    get ready() {
        return Promise.resolve(this);
    }

    get domElement() {
        return this._domElement;
    }

    pause() {
        super.pause();
        if (this.isReady) {
            window.clearTimeout(this._timeout);
            this._timeout = 0;
        }
    }

    resume() {
        super.resume();
        if (this.isReady) {
            if (this._timeout === 0)
                this._requestAnimation();
        }
    }

    reset() {
        super.reset();
        if (this.isReady) {
            this._number = 0;
        }
    }
}

export default CounterApp;
