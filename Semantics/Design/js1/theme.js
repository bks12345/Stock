
//default theme
var defaultTheme = "layout.css";
var currentTheme = $.cookie("currentTheme") == null ? defaultTheme : $.cookie("currentTheme");

$("#pageContainer").load(function(){
    changeTheme(currentTheme);
});


function changeDetected(){
    //alert($('#themes').find(":selected").val());
    currentTheme = $('#themes').find(":selected").val();
    $.cookie('currentTheme',currentTheme);
    changeTheme(currentTheme);
}

function changeTheme(themeName) {

    var path = "";

    if(themeName == "layout.css"){
        path = "Design/css1/" + themeName;   
    }
    else{
        path = "../../../../../Design/css1/themes/" + themeName;   
    }

    // var inner = document.getElementbyId("themeStyle");
    // var outer = document.getElementbyId("pageContainer").contentWindow.document.getElementbyId("themeStyle");

    // inner.href = path;
    // outher.href = path;

    $("#themeStyle").attr("href",path);
    var head = $("#pageContainer").contents().find("head");
    head.find("#themeStyle").attr("href",path);

}
