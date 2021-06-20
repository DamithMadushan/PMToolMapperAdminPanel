$(document).ready(function () {


    $("#logout").click(function () {

        $.ajax({
            type: 'GET',
            url: '/Login/LogOut',
            success: function (resultData) {

                if (resultData.status) {

                    sessionStorage.setItem("token", "");

                    window.location.href = "/";

                } 


            }
        });
    });
});