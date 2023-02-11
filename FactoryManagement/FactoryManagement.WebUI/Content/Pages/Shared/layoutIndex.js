$(document).ready(async function () {

});

function Error(heading,error) {
    swal(heading, error, {
        icon: 'error',
        buttons: false,
        //timer: 5000,
    });
}
function Success(heading, Msg) {
    swal(heading, Msg, 'success');
}

function SetDateOnTextbox(date) {
    var retrunDate;
    var valueDate = date == null ? null : new Date(parseInt(date.substring(6)));
    if (valueDate != null) {
        retrunDate = `${valueDate.getFullYear()}-${(valueDate.getMonth() + 1).toString().padStart(2, 0)}-${valueDate.getDate().toString().padStart(2, 0)}`;
    }
    else {
        retrunDate = " ";
    }
    return retrunDate;
}
function Datefilter(date) {
    var retrunDate;
    var valueDate = date == null ? null : new Date(parseInt(date.substring(6)));
    if (valueDate != null) {
        retrunDate = `${valueDate.getFullYear()}-${(valueDate.getMonth() + 1).toString().padStart(2, 0)}-${valueDate.getDate().toString().padStart(2, 0)}`;
    }
    else {
        retrunDate = " ";
    }
    return retrunDate;
}

function Monthfilter(date) {
    var retrunDate;
    var valueDate = date == null ? null : new Date(parseInt(date.substring(6)));
    if (valueDate != null) {
        retrunDate = `${valueDate.getFullYear()}-${(valueDate.getMonth() + 1).toString().padStart(2, 0)}`;
    }
    else {
        retrunDate = " ";
    }
    return retrunDate;
}
function DateTimefilter(date) {

    var retrunDate;
    var valueDate = date == null ? null : new Date(parseInt(date.substring(6)));
    if (valueDate != null) {
        retrunDate = `${valueDate.getFullYear()}-${(valueDate.getMonth() + 1).toString().padStart(2, 0)}-${valueDate.getDate().toString().padStart(2, 0)} ${valueDate.getHours() % 12 || 12}:${valueDate.getMinutes()}:${valueDate.getSeconds()}`;
    }
    else {
        retrunDate = " ";
    }

    return retrunDate;
}
function MonthfilterWithAlpha(date) {
    const month = ["January", "February", "March", "April", "May", "June", "July", "August", "September", "October", "November", "December"];
    var retrunDate;
    var valueDate = date == null ? null : new Date(parseInt(date.substring(6)));
    if (valueDate != null) {
        retrunDate = `${(month[valueDate.getMonth()]).toString().padStart(2, 0)},${valueDate.getFullYear()}`;
    }
    else {
        retrunDate = " ";
    }
    return retrunDate;
}

const Logout = async () => {
    await new Promise(function () {
        $.get("/Login/Logout");
    })
}