const urlParams = new URLSearchParams(window.location.search);
const ID = urlParams.get('ID');
$(document).ready(async function () {
    GetCurrentDate();
    GetDropDownValue();
    if (ID != null) {
        GetStores(ID);
        GetUserName(ID);
    }
});

function GetCurrentDate() {
    // Get the current date
    var currentDate = new Date();

    // Get the elements that represent the textbox
    var textbox = document.getElementById("TranDate");

    // Format the date as a string
    var dateString = currentDate.toISOString().substr(0, 10);

    // Set the value of the textbox to the formatted date string
    textbox.value = dateString;

    //Set Read Only
    textbox.readOnly = true;
}

const GetDropDownValue = async () => {
    await new Promise(function () {
        $.ajax({
            type: "Get",
            url: "/StoreRights/GetDropDownValue",
            success: function (resp) {

                if (resp.IsSuccess) {
                    GetStores(resp.Data.GetStores);
                    GetUserName(resp.Data.GetUserName);
                }
                else {
                    Error("Error", resp.Msg);
                }

            }
        });
    })
}
const GetStores = async (data) => {
    await new Promise(function () {
        if (data != null) {
            var p = '<option value="0" selected="selected">(select a Store) </option>';
            for (var i = 0; i < data.length; i++) {
                p += '<option value="' + data[i].StoreID + '">' + data[i].StoreTitle + '</option>';
            }
            $("#fk_StoreID").html(p).trigger('change');
        }
        $("#fk_StoreID").val(ID);
        $("#fk_StoreID").trigger('change');
    });
}
const GetUserName = async (data) => {
    await new Promise(function () {
        if (data != null) {
            var p = '<option value="0" selected="selected">(select a UserName) </option>';
            for (var i = 0; i < data.length; i++) {
                p += '<option value="' + data[i].UserID + '">' + data[i].UserName + '</option>';
            }
            $("#fk_UserID").html(p).trigger('change');
        }
        $("#fk_UserID").val(ID);
        $("#fk_UserID").trigger('change');
    });
}

const btnSave = async () => {
    return await new Promise(function () {
        debugger
        if ($('#fk_UserID').val() == 0 || $('#fk_StoreID').val() == 0 ) {
            Error("", "Please Select User Or Store");
            return;
        }
        var IDN = ID == undefined ? 0 : ID;
        debugger
        StoreRights = {
            TranID: IDN,
            TranDate: $('#TranDate').val(),
            fk_StoreID: $('#fk_StoreID').val(),
            fk_UserID: $('#fk_UserID').val(),
        }
        debugger
        $.ajax({
            type: "POST",
            url: "/StoreRights/SaveRight",
            //data: {  },
            data: JSON.stringify({ modelStoreRights: StoreRights }),
            dataType: "json",
            contentType: 'application/json; charset=utf-8',

            success: function (resp) {
                if (resp.IsSuccess) {
                    window.location.href = "/StoreRights/Index";
                } else {
                    Error("Error", resp.Msg)
                }
            }
        });
    })
}

let myTable;

function btnclose() {
    window.location.href = "/StoreRights/Index";
}