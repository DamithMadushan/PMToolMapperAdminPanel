$(document).ready(function () {

    $("#successmsg").hide();

    $("#addtool").click(function () {

        $("#successmsg").hide();

        var toolName = $('#toolname').val();
        var token = sessionStorage.getItem("token");


        $.ajax({
            type: 'POST',
            url: '/PMTool/addTool',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            data: { toolname: toolName },
            success: function (resultData) {

                if (resultData.isValid) {

                    $("#successmsg").show();

                } else {

                    $("#successmsg").hide();
                }


            }
        });
    });





});