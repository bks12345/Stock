
var prm = Sys.WebForms.PageRequestManager.getInstance();
prm.add_endRequest(function () {

    $('.table-design1 table tbody tr').click(function () {
        $('.table-design1 table tbody tr.select_table').removeClass('select_table');
        $(this).addClass('select_table');
    });

    $('.table-design1 table tbody').on('contextmenu', 'tr', function () {
        $('.table-design1 table tbody tr.select_table').removeClass('select_table');
        $(this).addClass('select_table');
        return true;
    });

    //for fixed table
    $('.pane-hScroll').scroll(function () {
        $('.pane-vScroll').width($('.pane-hScroll').width() + $('.pane-hScroll').scrollLeft());
    });

    $(window).resize(function () {
        $('.pane-vScroll').width($('.pane-hScroll').width() + $('.pane-hScroll').scrollLeft());
    })

    //for toggle with search engine design
      $('#tblcontents').click(function () {     
         $('.pane-vScroll').width($('.pane-hScroll').width() + $('.pane-hScroll').scrollLeft() + $('#serchdesign_left').width());     
     });
});


//for fixed table new
      
$('.table-design1 table tbody tr').click(function () {
    $('.table-design1 table tbody tr.select_table').removeClass('select_table');
    $(this).addClass('select_table');
});


$('.pane-hScroll').scroll(function () {
    $('.pane-vScroll').width($('.pane-hScroll').width() + $('.pane-hScroll').scrollLeft());
});

$(window).resize(function () {
    $('.pane-vScroll').width($('.pane-hScroll').width() + $('.pane-hScroll').scrollLeft());
})
//for fixed table ends
     
