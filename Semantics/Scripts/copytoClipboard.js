function copyToClipboard(element) {

    //element means id 
    //requires jquery
    var $temp = $("<input>");
    $("body").append($temp);
    $temp.val($(element).text()).select();
    document.execCommand("copy");
    $temp.remove();
}

function FxClipboard(prmdata) {

    // Create a dummy input to copy the string array inside it
    var dummy = document.createElement("input");
    // Add it to the document
    document.body.appendChild(dummy);
    // Set its ID
    dummy.setAttribute("id", "dummy_id");
    // Output the array into it  
    document.getElementById("dummy_id").value = prmdata;
    // Select it
    dummy.select();
    // Copy its contents
    document.execCommand("copy");
    // Remove it as its not needed anymore
    document.body.removeChild(dummy);
}



