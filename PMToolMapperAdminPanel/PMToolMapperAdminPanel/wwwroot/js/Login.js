$(document).ready(function () {

    $("form").submit(function (e) {
        e.preventDefault();
    });

    $("#submit").click(function () {
        var name = $('#userName').val();
        var password = $('#password').val();
        var token = ''
        $.ajax({
            type: 'POST',
            url: '/Login/CheckUser',
            data: { userName: name, Password: password },
            success: function (resultData) {

                if (resultData.isValid) {

                    var token = resultData.token;

                    sessionStorage.setItem("token", JSON.stringify(token));

                    window.location.href = "/Home";

                } else {

                    $('#errormsg').html(resultData.message);

                }


            }
        });
    });


 


});