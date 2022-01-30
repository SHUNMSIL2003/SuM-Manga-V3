function ExpandControler10() {
    if (Top10RestElm.style.display == 'none') {
        Top10RestElm.style.display = 'block';
        Top10elm.style.height = (Top10elm.offsetHeight + Top10RestElm.offsetHeight) + 'px';
        if (Top10RestElm.classList.contains('fadeInDown') == false) {
            Top10RestElm.classList.remove('fadeOutUp');
            Top10RestElm.classList.add('fadeInDown');
        }
    }
    else {
        Top10RestElm.classList.remove('fadeInDown');
        Top10RestElm.classList.add('fadeOutUp');
        Top10elm.style.height = (Top10elm.offsetHeight - Top10RestElm.offsetHeight) + 'px';
        setTimeout(() => {
            Top10RestElm.style.display = 'none';
        }, 10100);
    }
};