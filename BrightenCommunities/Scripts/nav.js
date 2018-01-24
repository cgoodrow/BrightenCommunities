$(document).ready(function () {

    console.log(isActive);
    var isActive = false;

    $('.js-menu').on('click', function () {
        console.log("click");
        if (isActive) {
            $(this).removeClass('active');
            $('body').removeClass('menu-open');
        } else {
            $(this).addClass('active');
            $('body').addClass('menu-open');
        }
        isActive = !isActive;
    });
});