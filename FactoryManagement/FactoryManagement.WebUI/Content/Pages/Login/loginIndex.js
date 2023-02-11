
$(document).ready(async function () {

});


const validate = async () => {
    await new Promise(function () {
        debugger
        var username = $('#username').val();
        var password = $('#password').val();
        if ($.trim(username) == "") {
            Error("", "Please Enter Your Username")
            return
        }
        if ($.trim(password) == "") {
            Error("", "Please Enter Your Password")
            return
        }

        $.ajax({
            type: "Get",
            url: "/Login/Validate",
            data: { UserName: username, Password: password },
            success: function (resp) {
                debugger
                if (resp.IsSuccess) {
                    if (resp.Data.isActive) {
                        window.location.href = "/Home/Index";
                    }
                    else {
                        Error("Error", "Invalid User..!!");
                    }
                }
                else {
                    Error("Error",resp.Msg);
                }

            }
        });
    })
}