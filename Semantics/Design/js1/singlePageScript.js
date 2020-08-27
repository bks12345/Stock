 
        function HideMenu() { }

        $(document).ready(function () {
            $(document).delegate('.input-group-addon', 'click', function () {
                $('.fixed-header').css('z-index', '-1024');
            });
            $(document).delegate('.zIndex', 'click', function () {
                $('.fixed-header').css('z-index', '1024');
            });
        });
  
        function bindform() {
            Sys.Application.add_init(function () {
                var table = $('#rpt5').DataTable({
                    scrollY: "65vh",
                    scrollX: true,
                    scrollCollapse: true,
                    paging: false
                });

//                new $.fn.dataTable.FixedColumns(table, {
//                    leftColumns: 1,
//                    rightColumns: 1
//                });
                // for table scroll width
                (function ($) {
                    $.fn.hasScrollBar = function () {
                        return this.get(0).scrollHeight > this.innerHeight();
                    }
                })(jQuery);

                $(".dataTables_scrollBody").each(function () {
                    if ($(".dataTables_scrollBody").hasScrollBar()) {
                        $(".dataTables_scrollBody").addClass('dataTables_scrollBody1');
                    }
                    else {
                        $(".dataTables_scrollBody").removeClass('dataTables_scrollBody1');
                    }
                });
                // for table scroll width end
                $('#rpt5 tbody tr').click(function () {
                    $('#rpt5 tbody tr.select_table').removeClass('select_table');
                    $(this).addClass('select_table');
                });
            });
        }
        Sys.Application.add_init(function () {
            bindform();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt5_wrapper');
            if (aaa == null) {
                bindform();
            }
        });
   

        function bindform1() {
            Sys.Application.add_init(function () {
                var table = $('#rpt2').DataTable({
                    scrollY: "65vh",
                    scrollX: true,
                    scrollCollapse: true,
                    paging: false
                });

//                new $.fn.dataTable.FixedColumns(table, {
//                    leftColumns: 1,
//                    rightColumns: 1
//                });

                $('#rpt2 tbody tr').click(function () {
                    $('#rpt2 tbody tr.select_table').removeClass('select_table');
                    $(this).addClass('select_table');
                });
            });
        }
        Sys.Application.add_init(function () {
            bindform1();
        });

        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt2_wrapper');
            if (aaa == null) {
                bindform1();
            }
        });
       
 
   
        function HideMenu() { };
        function bindform2() {

            var table = $('#rpt3').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });
            // for table scroll width
            (function ($) {
                $.fn.hasScrollBar = function () {
                    return this.get(0).scrollHeight > this.innerHeight();
                }
            })(jQuery);

            $(".dataTables_scrollBody").each(function () {
                if ($(".dataTables_scrollBody").hasScrollBar()) {
                    $(".dataTables_scrollBody").addClass('dataTables_scrollBody1');
                }
                else {
                    $(".dataTables_scrollBody").removeClass('dataTables_scrollBody1');
                }
            });
            // for table scroll width end

            $('#rpt3 tbody tr').click(function () {
                $('#rpt3 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        $(document).ready(function () {
            bindform2();

        });


        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt3_wrapper');
            if (aaa == null) {
                bindform2();
            }
        });
       
 
   
        function bindform3() {

            var table = $('#rpt4').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt4 tbody tr').click(function () {
                $('#rpt4 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform4() {

            var table = $('#rpt6').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt6 tbody tr').click(function () {
                $('#rpt6 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform5() {

            var table = $('#rpt7').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt7 tbody tr').click(function () {
                $('#rpt7 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform6() {

            var table = $('#rpt8').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt8 tbody tr').click(function () {
                $('#rpt8 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform7() {

            var table = $('#rpt9').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt9 tbody tr').click(function () {
                $('#rpt9 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform8() {

            var table = $('#rpt10').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt10 tbody tr').click(function () {
                $('#rpt10 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform9() {

            var table = $('#rpt11').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt11 tbody tr').click(function () {
                $('#rpt11 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform10() {

            var table = $('#rpt12').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt12 tbody tr').click(function () {
                $('#rpt12 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform11() {

            var table = $('#rpt13').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt13 tbody tr').click(function () {
                $('#rpt13 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform12() {

            var table = $('#rpt14').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt14 tbody tr').click(function () {
                $('#rpt14 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform13() {

            var table = $('#rpt15').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt15 tbody tr').click(function () {
                $('#rpt15 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform14() {

            var table = $('#rpt16').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt16 tbody tr').click(function () {
                $('#rpt16 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform15() {

            var table = $('#rpt17').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt17 tbody tr').click(function () {
                $('#rpt17 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform16() {

            var table = $('#rpt18').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt18 tbody tr').click(function () {
                $('#rpt18 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform17() {

            var table = $('#rpt19').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt19 tbody tr').click(function () {
                $('#rpt19 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform18() {

            var table = $('#rpt20').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt20 tbody tr').click(function () {
                $('#rpt20 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform19() {

            var table = $('#rpt21').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt21 tbody tr').click(function () {
                $('#rpt21 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform20() {

            var table = $('#rpt22').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt22 tbody tr').click(function () {
                $('#rpt22 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform21() {

            var table = $('#rpt23').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt23 tbody tr').click(function () {
                $('#rpt23 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform22() {

            var table = $('#rpt24').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt24 tbody tr').click(function () {
                $('#rpt24 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform23() {

            var table = $('#rpt25').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt25 tbody tr').click(function () {
                $('#rpt25 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform24() {

            var table = $('#rpt26').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt26 tbody tr').click(function () {
                $('#rpt26 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform25() {

            var table = $('#rpt27').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt27 tbody tr').click(function () {
                $('#rpt27 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform26() {

            var table = $('#rpt28').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt28 tbody tr').click(function () {
                $('#rpt28 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform27() {

            var table = $('#rpt29').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt29 tbody tr').click(function () {
                $('#rpt29 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform28() {

            var table = $('#rpt30').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt30 tbody tr').click(function () {
                $('#rpt30 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform29() {

            var table = $('#rpt31').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt31 tbody tr').click(function () {
                $('#rpt31 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform30() {

            var table = $('#rpt32').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt32 tbody tr').click(function () {
                $('#rpt32 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform31() {

            var table = $('#rpt33').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt33 tbody tr').click(function () {
                $('#rpt33 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform32() {

            var table = $('#rpt34').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt34 tbody tr').click(function () {
                $('#rpt34 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform33() {

            var table = $('#rpt35').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt35 tbody tr').click(function () {
                $('#rpt35 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        function bindform34() {

            var table = $('#rpt36').DataTable({
                scrollY: "65vh",
                scrollX: true,
                scrollCollapse: true,
                paging: false
            });

//            new $.fn.dataTable.FixedColumns(table, {
//                leftColumns: 1,
//                rightColumns: 1
//            });

            $('#rpt36 tbody tr').click(function () {
                $('#rpt36 tbody tr.select_table').removeClass('select_table');
                $(this).addClass('select_table');
            });
        }
        $(document).ready(function () {
            bindform3();
            bindform4();
            bindform5();
            bindform6();
            bindform7();
            bindform8();
            bindform9();
            bindform10();
            bindform11();
            bindform12();
            bindform13();
            bindform14();
            bindform15();
            bindform16();
            bindform17();
            bindform18();
            bindform19();
            bindform20();
            bindform21();
            bindform22();
            bindform23();
            bindform24();
            bindform25();
            bindform26();
            bindform27();
            bindform28();
            bindform29();
            bindform30();
            bindform31();
            bindform32();
            bindform33();
            bindform34();
        });


        var prm = Sys.WebForms.PageRequestManager.getInstance();

        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt4_wrapper');
            if (aaa == null) {
                bindform3();
            }
        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt6_wrapper');
            if (aaa == null) {
                bindform4();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt7_wrapper');
            if (aaa == null) {
                bindform5();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt8_wrapper');
            if (aaa == null) {
                bindform6();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt9_wrapper');
            if (aaa == null) {
                bindform7();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt10_wrapper');
            if (aaa == null) {
                bindform8();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt11_wrapper');
            if (aaa == null) {
                bindform9();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt12_wrapper');
            if (aaa == null) {
                bindform10();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt13_wrapper');
            if (aaa == null) {
                bindform11();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt14_wrapper');
            if (aaa == null) {
                bindform12();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt15_wrapper');
            if (aaa == null) {
                bindform13();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt16_wrapper');
            if (aaa == null) {
                bindform14();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt17_wrapper');
            if (aaa == null) {
                bindform15();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt18_wrapper');
            if (aaa == null) {
                bindform16();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt19_wrapper');
            if (aaa == null) {
                bindform17();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt20_wrapper');
            if (aaa == null) {
                bindform18();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt21_wrapper');
            if (aaa == null) {
                bindform19();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt22_wrapper');
            if (aaa == null) {
                bindform20();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt23_wrapper');
            if (aaa == null) {
                bindform21();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt24_wrapper');
            if (aaa == null) {
                bindform22();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt25_wrapper');
            if (aaa == null) {
                bindform23();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt26_wrapper');
            if (aaa == null) {
                bindform24();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt27_wrapper');
            if (aaa == null) {
                bindform25();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt28_wrapper');
            if (aaa == null) {
                bindform26();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt29_wrapper');
            if (aaa == null) {
                bindform27();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt30_wrapper');
            if (aaa == null) {
                bindform28();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt31_wrapper');
            if (aaa == null) {
                bindform29();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt32_wrapper');
            if (aaa == null) {
                bindform30();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt33_wrapper');
            if (aaa == null) {
                bindform31();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt34_wrapper');
            if (aaa == null) {
                bindform32();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt35_wrapper');
            if (aaa == null) {
                bindform33();
            }

        });
        prm.add_endRequest(function () {
            var aaa = document.getElementById('rpt36_wrapper');
            if (aaa == null) {
                bindform34();
            }

        });

   