$(document).ready(function () {

    var token = sessionStorage.getItem("token");

    $("#successmsg").hide();

    getPMTools();


    $("#addtool").click(function () {

        $("#successmsg").hide();

        var toolName = $('#toolname').val();


        $.ajax({
            type: 'POST',
            url: '/PMTool/addTool',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            data: { toolname: toolName },
            success: function (resultData) {

                if (resultData.isValid) {

                    $("#successmsg").show();


                    getPMTools();

                    setTimeout(function () {
                        $("#successmsg").hide();
                        $("#toolname").val("");
                    }, 2000);

                } else {

                    $("#successmsg").hide();
                }


            }
        });
    });




    function getPMTools() {

        $.ajax({
            type: 'POST',
            url: '/PMTool/getTools',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            success: function (resultData) {

                $("#pmtoolsboby").html("");

                var body;
                var toolnames = resultData.tools;

                $.each(toolnames, function (k, v) {
                    body += "<tr><td>" + v.toolName + "</tr></td>";
                });


                $("#pmtoolsboby").html(body);

            }
        });

    }



});