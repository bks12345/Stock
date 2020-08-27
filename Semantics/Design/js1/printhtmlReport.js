function printDocument() {
    alert("Are You Sure You Want to Print This");
    var restorepage = document.body.innerHTML;
    var printcontent = document.getElementById('front').innerHTML;
    document.body.innerHTML = printcontent;
    window.print();
    document.body.innerHTML = restorepage;
}