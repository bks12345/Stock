$(window).on('load', function () {
    var $pw = $(window.parent);
    var pwnbh = $(window.parent.document).find('.navbar-fixed-top').height();
    console.log($pw.get(0), $pw.height(), pwnbh);
    // Get the height of the fixed header
    var phh = $(".fixed-header").outerHeight(true);
    var pfh = $(".fixed-footer").outerHeight(true);
       
    $('.fixed-container').css({
        top: phh,
        height: $pw.height() - pwnbh - phh - pfh
    });
});
// search-loading for search policy
$(document).ready(function () {
    $('.search-output').on('load', function () {
        $('#search-loading').hide();
        $('#empty').hide();
    });
});