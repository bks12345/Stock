

// for add page-wrapper1 class in sidebar collapsable
$("#right-navigator").click(function () {
    if ($("#pageContainer").hasClass('page-wrapper')) {
        $("#pageContainer").removeClass('page-wrapper').addClass('page-wrapper1');
    } else {
        $("#pageContainer").removeClass('page-wrapper1').addClass('page-wrapper');
    }
});





//$('#right-navigator').css('display', 'none');


$('.mp-ref').on('click', function (e) {
    //        e.preventDefault();
    var ltxt = $(this).text();
    var $mpContainer = $(this).next('.mp-level');
    $mpContainer.children('.icons-display').text(ltxt);
    $mpContainer.show();
    console.log($(this).attr('target'));
    if ('target' == $(this).attr('target')) {
        $('#empty').show();
        $('#target-loading').show();
    }
    //        return false;
});


//for active and back
$('.mp-back').on('click', function (e) {
    //        e.preventDefault();
    $(this).closest('.mp-level').find('li.active').removeClass('active');
    $(this).closest('.mp-level').hide();
    //        return false;
});


// for loading empty div
$('#pageContainer').on('load', function () {
    $('#target-loading').hide();
    $('#empty').hide();
});


// for active on menu
$('#mp-menu li').click(function () {
    $(this).closest('ul').children('li.active').removeClass('active');
    $(this).addClass('active');

});
// for active on menu ends


// for hide back and menu title
$("#right-navigator").click(function () {
    $(".mp-back").toggleClass("coll-heading");
});

$("#right-navigator").click(function () {
    $(".default").toggleClass("coll-heading");
});

// for hide back and menu title ends


// for hover effect on menu 
$("#mp-menu .mp-ref").hover(
                  function () {
                      $(this).addClass("hvr-push");
                  }, function () {
                      $(this).removeClass("hvr-push");
                  }
                );
// for hover effect on menu ends

// for inside icon on menu
$("#mp-menu li:has(ul)").each(function () {
    $(this).addClass("inside-icon")
}
                );
// for inside icon on menu ends


// for margin in nav-sidbar inside
$("#mp-menu li:has(div)").each(function () {
    $(this).addClass("inside-nav")
}
                );
// for margin in nav-sidbar inside ends



