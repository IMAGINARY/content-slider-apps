import Application from '../common/js/application.js';

class PaintApp extends Application {
    static defaultConfig = {
        appName: 'PaintApp',
    };

    constructor(config = {}) {
        super(Object.assign(PaintApp.defaultConfig, config));

        const div = document.createElement('div');
        div.style.width = '100%';
        div.style.height = '100%';

        const canvas = document.createElement("canvas");
        div.appendChild(canvas);

        const c = canvas.getContext('2d');

        const paintColors = {};
        const mouseId = 'mouse';

        let mouseDown = false;

        function addMouseListeners() {
            div.addEventListener('mousemove', function (e) {
                if (mouseDown) {
                    c.fillStyle = paintColors[mouseId];
                    const x = e.clientX - div.getBoundingClientRect().left;
                    const y = e.clientY - div.getBoundingClientRect().top;
                    drawCircle(x, y);
                }
            });

            div.addEventListener('mousedown', function (e) {
                mouseDown = true;
                setRandomPaintColor(mouseId);
            });

            div.addEventListener('mouseup', function (e) {
                mouseDown = false;
            });

            div.addEventListener('dblclick', function (e) {
                c.fillStyle = 'black';
                c.fillRect(0, 0, canvas.width, canvas.height);
            });
        }

        function setRandomPaintColor(id) {
            function rand255() {
                return Math.floor(Math.random() * 255);
            }

            paintColors[id] = 'rgb(' + rand255() + ',' + rand255() + ',' + rand255() + ')';
        }

        function drawCircle(x, y) {
            if (canvas.width !== div.getBoundingClientRect().width)
                canvas.width = div.getBoundingClientRect().width;
            if (canvas.height !== div.getBoundingClientRect().height)
                canvas.height = div.getBoundingClientRect().height;

            c.beginPath();
            c.arc(x, y, 20, 0, 2 * Math.PI);
            c.fill();
        }

        function addMultiTouchListeners() {
            div.addEventListener('touchmove', e => {
                setRandomPaintColor();
                for (let touch of e.changedTouches) {
                    c.fillStyle = paintColors[touch.identifier];
                    const x = touch.clientX - div.getBoundingClientRect().left;
                    const y = touch.clientY - div.getBoundingClientRect().top;
                    drawCircle(x, y);
                }
            });

            div.addEventListener('touchstart', e => {
                for (let touch of e.changedTouches)
                    setRandomPaintColor(touch.identifier);
            });

            div.addEventListener('touchend', e => {
                for (let touch of e.changedTouches)
                    delete paintColors[touch.identifier];
            });
        }

        addMouseListeners();
        addMultiTouchListeners();

        this._div = div;
        this._canvas = canvas;
        this._context = c;
    }

    get ready() {
        return Promise.resolve(this);
    }

    get domElement() {
        return this._div;
    }

    reset() {
        if (this.isReady)
            this._context.clearRect(0, 0, this._canvas.width, this._canvas.height);
    }
}

export default PaintApp;
