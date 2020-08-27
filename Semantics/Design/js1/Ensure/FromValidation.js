function ValidationWithExpression(obj, sts, hasEvent) {
    var vfont = document.getElementById(obj.id).style.fontFamily;
    if (Validate(obj, false)) {
        //for date
        if (sts == "date") {
            if (isDate(obj, false)) {
                document.getElementById(obj.id).setAttribute("style", "border-color:none;font-family:" + vfont + ";");
                //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
                if (hasEvent)
                    __doPostBack(obj.id, '');
                return true;
            }
            else {
                alert('This is not valid date. Date format should be "01-Jan-2015"');
                document.getElementById(obj.id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
                //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
                $('#search-loading').hide(); $('#empty').hide();
                return false;
            }
        }

        //for email
        if (sts == "email") {
            if (validateEmail(obj, false)) {
                document.getElementById(obj.id).setAttribute("style", "border-color:none;font-family:" + vfont + ";");
                //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
                if (hasEvent)
                    __doPostBack(obj.id, '');
                return true;
            }
        }
    }
    return false;
}
/************************************************************************************************************************/
function Validate(obj, hasEvent) {
    var id = obj.id,
            value = obj.value;
    var vfont = document.getElementById(id).style.fontFamily;
    if (document.getElementById(id).type == "select-one") {
        if (document.getElementById(id).options[document.getElementById(id).selectedIndex].text == "None" || document.getElementById(id).options[document.getElementById(id).selectedIndex].text == "") {
            alert("required field");
            document.getElementById(id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
            //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
            //            if (hasEvent)
            //                __doPostBack(id, '');
            $('#search-loading').hide(); $('#empty').hide();
            return false;
        }
        else {
            document.getElementById(id).setAttribute("style", "border-color:none;font-family:" + vfont + ";");
            //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
            if (hasEvent)
                __doPostBack(id, '');
            return true;
        }
    }
    else {
        if (value == "") {
            alert("required field");
            document.getElementById(id).style.setProperty('border', '1px solid red', '');
            document.getElementById(id).style.setProperty('font-family', + vfont , '');
            //document.getElementById(id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
            $('#search-loading').hide(); $('#empty').hide();
            return false;
        }
        else {
            document.getElementById(id).style.setProperty('border', 'none', '');
            document.getElementById(id).style.setProperty('font-family', +vfont, '');
            //document.getElementById(id).setAttribute("style", "border-color:none;font-family:" + vfont + ";");
            if (hasEvent)
                __doPostBack(id, '');
            return true;
        }
    }
}
/************************************************************************************************************************/
function validateEmail(obj, hasEvent) {
    var vfont = document.getElementById(obj.id).style.fontFamily;
    var email = obj.value;
    if (email != "") {
        var re = /^([\w-]+(?:\.[\w-]+)*)@((?:[\w-]+\.)*\w[\w-]{0,66})\.([a-z]{2,6}(?:\.[a-z]{2})?)$/i;
        if (re.test(email)) {
            document.getElementById(obj.id).setAttribute("style", "border-color:none;font-family:" + vfont + ";");
            //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
            if (hasEvent)
                __doPostBack(obj.id, '');
            return true;
        }
        else {
            alert('This is not valid emailid');
            document.getElementById(obj.id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
            //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
            $('#search-loading').hide(); $('#empty').hide();
            return false;
        }
    }
    return true;
}
/************************************************************************************************************************/
function isDate(obj, hasEvent) {
    var vfont = document.getElementById(obj.id).style.fontFamily;
    var currVal = obj.value;
    //    if (currVal == '') {
    //        alert('This is not valid date. Date format should be "01-Jan-2015"');
    //        document.getElementById(obj.id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";"); 
    //        return false;
    //    }

    if (currVal != '') {
        //Declare Regex  
        var rxDatePattern = /^(\d{1,2})(\/|-)(?:(\d{1,2})|(jan)|(feb)|(mar)|(apr)|(may)|(jun)|(jul)|(aug)|(sep)|(oct)|(nov)|(dec))(\/|-)(\d{4})$/i;

        var dtArray = currVal.match(rxDatePattern);

        if (dtArray == null) {
            alert('This is not valid date. Date format should be "01-Jan-2015"'); document.getElementById(obj.id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
            $('#search-loading').hide(); $('#empty').hide(); return false;
        }

        var dtDay = parseInt(dtArray[1]);
        var dtMonth = parseInt(dtArray[3]);
        var dtYear = parseInt(dtArray[17]);

        if (isNaN(dtMonth)) {
            for (var i = 4; i <= 15; i++) {
                if ((dtArray[i])) {
                    dtMonth = i - 3;
                    break;
                }
            }
        }

        if (dtMonth < 1 || dtMonth > 12) {
            alert('This is not valid date. Date format should be "01-Jan-2015"'); document.getElementById(obj.id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
            $('#search-loading').hide(); $('#empty').hide(); return false;
        }
        else if (dtDay < 1 || dtDay > 31) {
            alert('This is not valid date. Date format should be "01-Jan-2015"'); document.getElementById(obj.id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
            $('#search-loading').hide(); $('#empty').hide(); return false;
        }
        else if ((dtMonth == 4 || dtMonth == 6 || dtMonth == 9 || dtMonth == 11) && dtDay == 31) {
            alert('This is not valid date. Date format should be "01-Jan-2015"'); document.getElementById(obj.id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
            $('#search-loading').hide(); $('#empty').hide(); return false;
        }
        else if (dtMonth == 2) {
            var isleap = (dtYear % 4 == 0 && (dtYear % 100 != 0 || dtYear % 400 == 0));
            if (dtDay > 29 || (dtDay == 29 && !isleap)) {
                alert('This is not valid date. Date format should be "01-Jan-2015"'); document.getElementById(obj.id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
                $('#search-loading').hide(); $('#empty').hide(); return false;
            }
        }

        document.getElementById(obj.id).setAttribute("style", "border-color:none;font-family:" + vfont + ";");
        if (hasEvent)
            __doPostBack(obj.id, '');
        return true;
    }
    return true;
}
/************************************************************************************************************************/
function ValidateFromForm(obj, hasEvent) {
    var id = obj.id,
            value = obj.value;

    var vfont = document.getElementById(id).style.fontFamily;
    if (value == "" || document.getElementById(id).options[document.getElementById(id).selectedIndex].text == "") {
        alert("req");
        document.getElementById(id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
        //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
        $('#search-loading').hide(); $('#empty').hide();
        return false;
    }
    else {
        document.getElementById(id).setAttribute("style", "border-color:none;font-family:" + vfont + ";");
        //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
        if (hasEvent)
            __doPostBack(id, '');
        return true;
    }
}

/************************************************************************************************************************/
function validateMobNo(obj, hasEvent) {
    /**/
    var id = obj.id,
            value = obj.value;

    var vfont = document.getElementById(id).style.fontFamily;
    if ((value.length > 0 && value.length < 10) || value.length > 10 || !/^\d+$/.test(value)) {
        alert("Please enter valid Mobile No.!");
        document.getElementById(id).setAttribute("style", "border:1px solid red; font-family:" + vfont + ";");
        //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
        $('#search-loading').hide(); $('#empty').hide();
        return false;
    }
    else {
        document.getElementById(id).setAttribute("style", "border-color:none;font-family:" + vfont + ";");
        //document.getElementById(id).setAttribute("style", "font-family:" + vfont + ";");
        if (hasEvent)
            __doPostBack(id, '');
        return true;
    }
}