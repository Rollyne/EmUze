

//$(document).ready(function () {

//    function MakeCaptureBlocksSameHeight() {
//        let windowHeight = window.innerHeight;
//        if ($(".imageCapture").height() > windowHeight) {
//            $(".imageCapture").height(windowHeight);
//        }
        
//        console.log(windowHeight);
//    }

//    $(window).resize(MakeCaptureBlocksSameHeight).trigger("resize");
//});

//Background Shrink Properties
$(document).ready( function () {
    let $bg = $(".bg"),
        aspectRatio = $bg.innerWidth / $bg.innerHeight;
    
    function resizeBg() {
        if ((window.innerWidth / window.innerHeight) < aspectRatio) {
            $bg.removeClass()
                .addClass('bgheight');
        } else {
            $bg.removeClass()
                .addClass('bgwidth');
        }
    }

   /* $(window).resize(resizeBg).trigger("resize");*/
});


