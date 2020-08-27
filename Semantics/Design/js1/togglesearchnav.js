$(document).ready(function () {
    $('#tblcontents').on('click', function () {
        var $searchSection = $('.search-section'),
            $searchOutput = $('.search-output');
        if ($searchSection.is(":visible")) {
            $searchSection.animate({ left: '-33.33%' }, {
                duration: 500,
                progress: function () {
                    $searchOutput.css({
                        left: $searchSection.offset().left - $searchSection.outerWidth(true) + 'px'
                    });
                },
                complete: function () {
                    $searchSection.hide();
                    $searchOutput.removeAttr('style');
                    $searchOutput.removeClass('col-sm-8 col-md-8').addClass('col-sm-12 col-md-12');
                }
            });
        }
        else {
            $searchSection.show();
            $searchOutput.removeClass('col-sm-12 col-md-12').addClass('col-sm-8 col-md-8');
            $searchSection.animate({ left: 0 }, {
                duration: 500,
                progress: function () {
                    $searchOutput.css({
                        left: $searchSection.position().left + 'px'
                    });
                },
                complete: function () {
                    $searchOutput.removeAttr('style');
                }
            });
        }
    });

    $('#tblcontents1').on('click', function () {
        var $searchSection1 = $('.search-section1'),
            $searchOutput1 = $('.search-output1');
        if ($searchSection1.is(":visible")) {
            $searchSection1.animate({ left: '-33.33%' }, {
                duration: 500,
                progress: function () {
                    $searchOutput1.css({
                        left: $searchSection1.offset().left - $searchSection1.outerWidth(true) + 'px'
                    });
                },
                complete: function () {
                    $searchSection1.hide();
                    $searchOutput1.removeAttr('style');
                   // $searchOutput1.removeClass('col-sm-7 col-md-8').addClass('col-sm-12 col-md-12');
                    $searchOutput1.removeClass('col-sm-8').addClass('col-sm-12 col-md-8');
                }
            });
        }
        else {
            $searchSection1.show();
           //$searchOutput1.removeClass('col-sm-12 col-md-12').addClass('col-sm-7 col-md-8');
            $searchOutput1.removeClass('col-sm-12').addClass('col-sm-8 col-md-8');
            $searchSection1.animate({ left: 0 }, {
                duration: 500,
                progress: function () {
                    $searchOutput1.css({
                        left: $searchSection1.position().left + 'px'
                    });
                },
                complete: function () {
                    $searchOutput1.removeAttr('style');
                }
            });
        }
    });
});