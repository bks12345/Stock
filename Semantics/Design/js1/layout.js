$(document).ready(function () {
    // Global variables within this jQuery ready function
    var $pageWrapper = $('.page-wrapper');
   // var defaultWidth = $('.right-sidebar').outerWidth();
    var defaultWidth = $('.sidebar').outerWidth();
    // var $rsb = $('.right-sidebar'),
    var $rsb = $('.sidebar'),
       // rsbr = Number($rsb.css('right').replace('px', '')); 
        rsbr = Number($rsb.css('left').replace('px', ''));

    var pwml = Number($pageWrapper.css('margin-left').replace('px', '')),
        pwmr = Number($pageWrapper.css('margin-right').replace('px', ''));

    var cobj = {
        //width: $('.page-container').width() - $('.sidebar').outerWidth(true) - defaultWidth - pwml - pwmr - rsbr //page Wrapper width
        width: $('.page-container').width() - $('.right-sidebar').outerWidth(true) - defaultWidth - pwml - pwmr - rsbr //page Wrapper width
    };
    $pageWrapper.css(cobj);


    //right-sidebar collapsable
    $('#right-navigator').on('click', function () {
       // alert("called");
        $(this).toggleClass('lft-arrow');
        var btnWidth = 0, pwWidth = 0;
        if ($rsb.is(".collapsable")) {
          //  btnWidth = $(this).outerWidth(true);
            pwWidth = $pageWrapper.width() + defaultWidth - btnWidth;
            $rsb.removeClass('collapsable');

        }
        else {
            btnWidth = defaultWidth;
            //pwWidth = $('.page-container').width() - $('.sidebar').outerWidth(true) - defaultWidth - pwml - pwmr - rsbr;
            pwWidth = $('.page-container').width() - $('.right-sidebar').outerWidth(true) - defaultWidth - pwml - pwmr - rsbr;
            $rsb.addClass('collapsable');
        }
        //$pageWrapper.css({ width: pwWidth });
        //$rsb.css({ width: btnWidth + 'px' });
        $pageWrapper.animate({ width: pwWidth }, 0);
        $rsb.animate({ width: btnWidth + 'px' }, 0);
    });

 


    // for add page-wrapper1 class in sidebar collapsable
        $("#right-navigator").click(function () {
            if ($("#pageContainer").hasClass('page-wrapper')) {
                $("#pageContainer").removeClass('page-wrapper').addClass('page-wrapper1');
            } else {
                $("#pageContainer").removeClass('page-wrapper1').addClass('page-wrapper');
            }
        });


        // for toggle hide and show sidebar collapsable
//        $("#right-navigator").click(function () {
//            $(".sidebar").fadetoggle();
//        });




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
       // alert("done");
    });
});