$(document).ready(function () {
 
    if ($('.blog, .volunteers').height() > 300) {
        console.log("big");
        $('.blog, .volunteers').css("max-height", "300px");
        $('.blog, .volunteers').css("overflow-y", "scroll");
}
});

