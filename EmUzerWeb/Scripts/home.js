var mq = window.matchMedia("(max-width: 860px)");

if (mq.matches) {
    console.log('yas');
    $('#video').width = "720px";
}