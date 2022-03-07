$(document).ready(function(){
    $("body").fadeTo(1000,1);
    
    $("video").on("ended", function () {
        this.currentTime = 15;
        this.play();
    });
    $(".bg-video-wrap").hover(function () {
        $(this).children("video")[0].play();
    }, function () {
        var el = $(this).children("video")[0];
        el.pause();
    });
});