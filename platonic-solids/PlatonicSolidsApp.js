import CindyApp from "../common/js/CindyApp.js";

class PlatonicSolidsApp extends CindyApp {
  constructor() {
    super();
  }

  async _initCindyArgs() {
    const relativeUrl = filename => new URL(filename,
      import.meta.url).href;


    var translations = {};
    await IMAGINARY.i18n.init({
      translationsDirectory: relativeUrl('tr'),
    }).then(function(lang) {
      translations[lang] = IMAGINARY.i18n.getStrings();
    }).catch(function(err) {
      console.log("Error loading translation: " + err);
      throw err;
    });

    return {
      scripts: await CindyApp.loadScripts(relativeUrl('PlatonicSolids_'), ['init', 'draw', 'mousedown', 'mousedrag', 'mouseup', 'tick'], '.cs'),
      language: IMAGINARY.i18n.getLang(),
      translations: translations,
      ports: [{
        element: this.canvas,
        //width: 1920,
        //height: 1080,
        transform: [{
          //visibleRect: [-18, 10.5, 17, -12.5]
          visibleRect: [-20, 15, 20, -15] //4:3
        }],
        background: "rgb(0,0,0)"
      }],
      geometry: [{
          "name": "Q",
          "type": "Free",
          "pos": [
            -19.5, -1.2

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "visible": false,
          "labeled": true,
          "pinned": true
        },
        {
          "name": "R",
          "type": "Free",
          "pos": [
            -15, -1.2
          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "visible": false,
          "labeled": true,
          "pinned": true
        },
        {
          "name": "a",
          "type": "Segment",
          "pos": [
            0.0,
            3.225806451612903,
            4.0
          ],
          "color": [
            1.0,
            1.0,
            1.0
          ],
          "args": [
            "Q",
            "R"
          ],
          "size": 3
        },
        {
          "name": "S",
          "type": "PointOnLine",
          "pos": [
            4.0,
            0.3131313111544739,
            -0.25252525093102735
          ],
          "color": [
            1.0,
            1.0,
            1.0
          ],
          "args": [
            "a"
          ],
          "size": 4.0,
          "narrow": true
        },
        {
          "name": "C4",
          "type": "Free",
          "pos": [
            17, 8
          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "plane": 1,
          "pinned": true,
          "visible": false
        },
        {
          "name": "C6",
          "type": "Free",
          "pos": [
            17, 3.5

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "plane": 1,
          "pinned": true,
          "visible": false

        },
        {
          "name": "C8",
          "type": "Free",
          "pos": [
            17, -1

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "plane": 1,
          "pinned": true,
          "visible": false

        },
        {
          "name": "C12",
          "type": "Free",
          "pos": [
            17, -5.5

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "plane": 1,
          "pinned": true,
          "visible": false

        },
        {
          "name": "C20",
          "type": "Free",
          "pos": [
            17, -10

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "plane": 1,
          "pinned": true,
          "visible": false

        },
        {
          "name": "DelOut",
          "type": "Free",
          "pos": [
            -18, 8

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "pinned": true,
          "visible": false

        },
        {
          "name": "DelIn",
          "type": "Free",
          "pos": [
            -18, 3.2

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "pinned": true,
          "visible": false

        },
        {
          "name": "NoEdges",
          "type": "Free",
          "pos": [
            -18, -5.5

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "pinned": true,
          "visible": false

        },
        {
          "name": "YesEdges",
          "type": "Free",
          "pos": [
            -18, -10

          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "pinned": true,
          "visible": false

        },
        {
          "name": "Dummy",
          "type": "Free",
          "pos": [
            0.0,
            0.355889724310776,
            -0.2506265664160401
          ],
          "color": [
            1.0,
            0.0,
            0.0
          ],
          "pinned": false,
          "visible": false
        }
      ],
      images: {
        image11: relativeUrl("img/image-11.png"),
        image12: relativeUrl("img/image-12.png"),
        image13: relativeUrl("img/image-13.png"),
        image14: relativeUrl("img/image-14.png"),
        image15: relativeUrl("img/image-15.png"),
        image16: relativeUrl("img/image-16.png"),
        image17: relativeUrl("img/image-17.png"),
        //image18: relativeUrl("img/image-18.png"),
        image19: relativeUrl("img/image-19.png"),
        image20: relativeUrl("img/image-20.png")
      },
      use: ["QuickHull3D"]
    };
  }

  get name() {
    return 'Platonische Körper';
  }

  get description() {
    return 'TODO. Lorem ipsum dolor sit amet, consetetur sadipscing elitr, sed diam nonumy eirmod tempor invidunt ut labore et dolore magna aliquyam erat, sed diam voluptua. At vero eos et accusam et justo duo dolores et ea rebum.';
  }

  get credits() {
    return '';
  }
}

export default PlatonicSolidsApp;
