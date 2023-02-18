
$(document).ready(async function () {
    await GetDropDownValue();
});



const GetDropDownValue = async () => {
    await new Promise(function () {
        $.ajax({
            type: "Get",
            url: "/GoodReceived/GetDropDownValue",
/*            data: { UserName: username, Password: password },*/
            success: function (resp) {
                debugger

            }
        });
    })
}