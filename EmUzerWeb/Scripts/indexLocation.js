function getLocation() {
    if (navigator.geolocation) {
        navigator.geolocation.getCurrentPosition(suggest);
    } else {
        x.innerHTML = "Geolocation is not supported by this browser.";
    }
}

function suggest(position) {
    var emotion = $('#result-div h3').html();
    var weather = $('#weather h3').html();
    window.location.href = '/Suggestion?latitude=' + position.coords.latitude + '&longtitude=' + position.coords.longitude + '&emotion=' + emotion;
}