function loadMainAnimate(idOrClass) {
    TweenMax.to(idOrClass, 2, { opacity: 1 });
}
function fadeIn(_idOrClass) {
    console.log('fadeInCall with id or class ->' + _idOrClass);
    TweenMax.to(_idOrClass, 2, { opacity: 1 });
}
function fadeOut(_idOrClass) {
    console.log('fadeOutCall with id or class ->' + _idOrClass);
    TweenMax.to(_idOrClass, 2, { opacity: 0 });
}
function fadeInOut(name, time, opacityTo) {
    console.log('fadeInOut name ->' + name + ' time ->' + time.toString() + ' opacityTo ->' + opacityTo.toString());
    TweenMax.to(name, time, { opacity: opacityTo });
}