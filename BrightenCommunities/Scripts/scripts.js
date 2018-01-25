$(document).ready(function () {
 
    if ($('.blog').height() > 300) {
        console.log("big");
        $('.blog').css("max-height", "300px");
        $('.blog').css("overflow-y", "scroll");
}
});

