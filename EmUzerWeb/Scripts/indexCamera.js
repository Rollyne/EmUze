// Grab elements, create settings, etc.
var video = document.getElementById('video');

// Get access to the camera!
if (navigator.mediaDevices && navigator.mediaDevices.getUserMedia) {
    // Not adding `{ audio: true }` since we only want video now
    navigator.mediaDevices.getUserMedia({ video: true }).then(function (stream) {
        video.src = window.URL.createObjectURL(stream);
        video.play();
    });
}
// Elements for taking the snapshot
var canvas = document.getElementById('canvas');
var context = canvas.getContext('2d');
var video = document.getElementById('video');

// Trigger photo take
$("#snap").on("click", function () {
    context.drawImage(video, 0, 0, 640, 480);
    canvas.toDataURL();
    savePic(canvas.toDataURL());
    $('#snapping-div').hide();
    $('#result-div').show();
});

function snapAgain() {
    $('#actions').hide();
    $('#result-div').hide();
    $('#result-div h3').html(' ');
    $('#snapping-div').show();
}

function savePic(dataUrl) {
    $.ajax({
        type: "POST",
        url: "/Emotion/Post",
        data: {
            imageString: dataUrl
        },
        success: function (emotion) {
            $('#result-div h3').html(emotion);
            $('#actions').show();
        },
        error:  function(data) {
            console.log(data);
        }
    });
}