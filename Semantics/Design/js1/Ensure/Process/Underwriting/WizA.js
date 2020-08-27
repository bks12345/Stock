function HideMenu() { }
var constModule;
function confirmReport() {
    var _DOCID = document.getElementById("<%=hdn_DocumentID.ClientID %>").value;
    var _repName = "";
    var _OpenFrom = "UW_TEMPLATES";
    if (confirm("Do you want to Print the report?")) {
        window.location.replace('UwTest.aspx');
        window.open('../../Reports/RptTemplates.aspx?PrmReportName=' + _repName + '&&PrmOpenFrom=' + _OpenFrom + '&&PrmDocumentID=' + _DOCID, 'Graph');
        return true;
    } else {
        window.location.replace('UwTest.aspx');
        return false;
    }
}
document.getElementById('IframeEdit').style.height = (window.outerHeight * 0.67) + "px";
//document.getElementById('IframeEdit').style.Width = (window.outerWidth * 0.8) + "px";

function ChangeSrc(task, module) {
    constModule = module;
    if (module == 'Policy') {
        if (task == 'Open') {
            document.getElementById("<%= lblType.ClientID %>").innerHTML = "Enter Policy No. / Debit Advice No.";
            document.getElementById("<%= hdnTask.ClientID %>").value = task;
            document.getElementById("<%= lblNote.ClientID %>").innerHTML = "Note: Endorsement No. are not allowed";
        }
        else if (task == 'Edit') {
            document.getElementById("<%= lblType.ClientID %>").innerHTML = "Enter Policy No. / Debit Advice No.";
            document.getElementById("<%= hdnTask.ClientID %>").value = task;
            document.getElementById("<%= lblNote.ClientID %>").innerHTML = "Note: Only Latest Policy can be edited";
        }
        else if (task == 'endorse' || task == 'renew') {
            document.getElementById("<%= lblType.ClientID %>").innerHTML = "Enter Policy No.";
            document.getElementById("<%= hdnTask.ClientID %>").value = task;
            document.getElementById("<%= lblNote.ClientID %>").innerHTML = "";
        }
    }
    else if (task == 'Multiple') {
        $find('modalpopupMultiple').show();
    }
    else if (task == 'co') {
        $find('modalpopupCo').show();
    }
    else if (module == "PrintingMatters") {
        if (task == "Open") {
            var frame = $get('IframeEdit');
            document.getElementById("<%=lblTitle.ClientID %>").innerHTML = "Printing Matters";
            document.getElementById('IframeEdit').style.Width = (window.outerWidth * 0.8) + "px";
            frame.src = "../../Setup/Underwriting/UW/printing_matters.aspx";
            frame.src = frame.src + "?OPENAS=POPUP";
        }
    }
    else {
        var frame = $get('IframeEdit');
        frame.src = "";
        if (module == 'Bank') {
            document.getElementById('kyc-modal').style.width = (window.outerWidth * 0.4) + "px";
            frame.src = "../../Setup/Underwriting/SpecialClient/BankForm.aspx";
            if (task == 'Add') {
                document.getElementById("<%=lblTitle.ClientID %>").innerHTML = "Add Bank Information";
                frame.src = frame.src + "?Task=" + task + "&&Module=" + module;
            }
            else if (task == 'Edit') {
                document.getElementById("<%=lblTitle.ClientID %>").innerHTML = "Edit Bank Information";
                if (document.getElementById("<%= hdnBankId.ClientID %>").value > 0) {
                    frame.src = frame.src + "?Task=" + task + "&&Module=" + module + "&&BankCode=" + document.getElementById("<%=hdnBankId.ClientID %>").value;
                }
            }
            frame.src = frame.src + "&&OPENAS=POPUP";
        }
        else if (module == 'Branch') {
            document.getElementById('kyc-modal').style.width = (window.outerWidth * 0.4) + "px";
            frame.src = "../../Setup/Underwriting/SpecialClient/BankForm.aspx";

            if (task == 'Add') {
                document.getElementById("<%=lblTitle.ClientID %>").innerHTML = "Add Branch Information";
                frame.src = frame.src + "?Task=" + task + "&&Module=" + module + "&&BankCode=" + document.getElementById("<%= hdnBankId.ClientID %>").value;
            }
            else if (task == 'Edit') {
                document.getElementById("<%=lblTitle.ClientID %>").innerHTML = "Edit Branch Information";
                frame.src = frame.src + "?Task=" + task + "&&Module=" + module + "&&BankCode=" + document.getElementById("<%= hdnBankId.ClientID %>").value + "&&BranchCode=" + document.getElementById("<%=hdnBranchId.ClientID %>").value;
            }
            frame.src = frame.src + "&&OPENAS=POPUP";
        }
        else if (module == 'Kyc') {
            document.getElementById('kyc-modal').style.width = (window.outerWidth * 0.8) + "px";
            frame.src = "../../Setup/Underwriting/UW/AddCustomer.aspx";

            if (task == 'Add') {
                document.getElementById("<%=lblTitle.ClientID %>").innerHTML = "Add Account Information";
                frame.src = frame.src + "?Task=" + task;
            }
            else if (task == 'Edit') {
                document.getElementById("<%=lblTitle.ClientID %>").innerHTML = "Edit Account Information";
                if (document.getElementById("<%= hdnKycId.ClientID %>").value > 0)
                    frame.src = frame.src + "?Task=" + task + "&&Id=" + document.getElementById("<%=hdnKycId.ClientID %>").value;
            }
            frame.src = frame.src + "&&OPENAS=POPUP";
        }
    }
}

function ClosePopup() {
    if (constModule == 'Bank') {
        document.getElementById("<%=btnRefreshBank.ClientID %>").click();
    }
    else if (constModule == 'Branch') {
        document.getElementById("<%=btnRefreshBranch.ClientID %>").click();
    }
    else if (constModule == 'Kyc') {
        document.getElementById("<%=btnRefreshAccount.ClientID %>").click();
    }
    else if (constModule == 'PrintingMatters') {
        document.getElementById("<%=btnRefreshPrintMatters.ClientID %>").click();
    }
}
function Confirm(msg, frm) {
    var confirm_value = document.createElement("INPUT");
    confirm_value.type = "hidden";
    confirm_value.name = "confirm_value";

    var called_for = document.createElement("INPUT");
    called_for.type = "hidden";
    called_for.name = "called_for";
    called_for.value = frm;

    if (confirm(msg)) {
        confirm_value.value = "Yes";
    } else {
        confirm_value.value = "No";
    }
    document.forms[0].appendChild(confirm_value);
    document.forms[0].appendChild(called_for);
    document.getElementById("<%= btnConfirm.ClientID %>").click();
}
$('#myModal').on('shown.bs.modal', function () {
    $('#myInput').focus()
});