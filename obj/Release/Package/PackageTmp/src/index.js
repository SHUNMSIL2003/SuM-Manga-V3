"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var ProgressBar = /** @class */ (function () {
    function ProgressBar(options) {
        // eslint-disable-next-line @typescript-eslint/no-explicit-any
        var assign = function (to, from) {
            Object.keys(from).forEach(function (key) {
                to[key] = from[key];
            });
        };
        var config = {
            size: 2,
            color: "#29e",
            className: "bar-of-progress",
            delay: 80,
        };
        if (options) {
            assign(config, options);
        }
        var initialStyle = {
            position: "fixed",
            top: 0,
            left: 0,
            margin: 0,
            padding: 0,
            border: "none",
            borderRadius: 0,
            backgroundColor: "currentColor",
            zIndex: 10000,
            height: typeof config.size === "number" ? config.size + "px" : config.size,
            color: config.color,
            opacity: 0,
            width: "0%",
        };
        var startedStyle = {
            opacity: 1,
            width: "99%",
            transition: "width 10s cubic-bezier(0.1, 0.05, 0, 1)",
        };
        var finishedStyle = {
            opacity: 0,
            width: "100%",
            transition: "width 0.1s ease-out, opacity 0.5s ease 0.2s",
        };
        var glowStyle = {
            opacity: 0.4,
            boxShadow: "3px 0 8px",
            height: "100%",
        };
        var timeout;
        var current;
        this.start = function () {
            if (current && current.parentNode) {
                current.parentNode.removeChild(current);
            }
            current = document.body.appendChild(document.createElement("div"));
            current.className = config.className + " stopped";
            assign(current.style, initialStyle);
            var glow = current.appendChild(document.createElement("div"));
            glow.className = "glow";
            assign(glow.style, glowStyle);
            if (timeout != null) {
                clearTimeout(timeout);
            }
            timeout = setTimeout(function () {
                timeout = null;
                current.className = config.className + " started";
                assign(current.style, startedStyle);
            }, config.delay);
            // Force a reflow, just to be sure that the initial style takes effect.
            current.scrollTop = 0;
        };
        this.finish = function () {
            if (timeout != null) {
                clearTimeout(timeout);
                timeout = null;
            }
            if (current) {
                current.className = config.className + " finished";
                assign(current.style, finishedStyle);
            }
        };
    }
    return ProgressBar;
}());
exports.default = ProgressBar;
//# sourceMappingURL=index.js.map