/* Modified dragscroll.js by Undust4able */

(function (root, factory) {
    if (typeof define === 'function' && define.amd) {
        define(['exports'], factory);
    } else if (typeof exports !== 'undefined') {
        factory(exports);
    } else {
        factory((root.dragscroll = {}));
    }
}(this, function (exports) {
    var _window = window;
    var _document = document;

    var mousemove = 'mousemove';
    var mouseup = 'mouseup';
    var mousedown = 'mousedown';

    var touchmove = 'touchmove';
    var touchup = 'touchend';
    var touchdown = 'touchstart';

    var EventListener = 'EventListener';
    var addEventListener = 'add' + EventListener;
    var removeEventListener = 'remove' + EventListener;

    var dragged = [];
    var reset = function (i, el) {
        for (i = 0; i < dragged.length;) {
            el = dragged[i++];
            el = el.container || el;
            el[removeEventListener](mousedown, el.md, 0);
            _window[removeEventListener](mouseup, el.mu, 0);
            _window[removeEventListener](mousemove, el.mm, 0);

            el[removeEventListener](touchdown, el.td, 0);
            _window[removeEventListener](touchup, el.tu, 0);
            _window[removeEventListener](touchmove, el.tm, 0);
        }

        // cloning into array since HTMLCollection is updated dynamically
        dragged = [].slice.call(_document.getElementsByClassName('dragscroll'));
        for (i = 0; i < dragged.length;) {
            (function (el, lastClientX, lastClientY, pushed, scroller, cont) {
                (cont = el.container || el)[addEventListener](
                    mousedown,
                    cont.md = function (e) {
                        if (!el.hasAttribute('nochilddrag') ||
                            _document.elementFromPoint(
                                e.pageX, e.pageY
                            ) == cont
                        ) {
                            pushed = 1;
                            lastClientX = e.clientX;
                            lastClientY = e.clientY;

                            e.preventDefault();
                        }
                    }, 0
                );
                (cont = el.container || el)[addEventListener](
                    touchdown,
                    cont.td = function (e) {
                        if (!el.hasAttribute('nochilddrag') ||
                            _document.elementFromPoint(
                                e.pageX, e.pageY
                            ) == cont
                        ) {
                            pushed = 1;
                            e.preventDefault();

                            e = e.targetTouches[0];
                            lastClientX = e.clientX;
                            lastClientY = e.clientY;

                        }
                    }, 0
                );
                _window[addEventListener](
                    mouseup, cont.mu = function () { pushed = 0; }, 0
                );
                _window[addEventListener](
                    touchup, cont.tu = function () { pushed = 0; }, 0
                );
                _window[addEventListener](
                    mousemove,
                    cont.mm = function (e) {
                        if (pushed) {
                            (scroller = el.scroller || el).scrollLeft -=
                                (- lastClientX + (lastClientX = e.clientX));
                            scroller.scrollTop -=
                                (- lastClientY + (lastClientY = e.clientY));
                        }
                    }, 0
                );
                _window[addEventListener](
                    touchmove,
                    cont.tm = function (e) {
                        if (pushed) {
                            e = e.targetTouches[0];
                            (scroller = el.scroller || el).scrollLeft -=
                                (- lastClientX + (lastClientX = e.clientX));
                            scroller.scrollTop -=
                                (- lastClientY + (lastClientY = e.clientY));
                        }

                    }, 0
                );
            })(dragged[i++]);
        }
    }


    if (_document.readyState == 'complete') {
        reset();
    } else {
        _window[addEventListener]('load', reset, 0);
    }

    exports.reset = reset;
}));