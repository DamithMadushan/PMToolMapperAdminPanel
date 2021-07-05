$(document).ready(function () {

    var token = sessionStorage.getItem("token");

    $("#successmsg").hide();

    getFeatures();


    $("#addFeature").click(function () {

        $("#successmsg").hide();

        var featureName = $('#featurename').val();


        $.ajax({
            type: 'POST',
            url: '/ToolFeatures/addFeature',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            data: { featurename: featureName },
            success: function (resultData) {

                if (resultData.isValid) {

                    $("#successmsg").show();


                    getFeatures();

                    $("#featurename").val("");

                    setTimeout(function () {
                        $("#successmsg").hide();
                    }, 2000);


                } else {

                    $("#successmsg").hide();
                }


            }
        });
    });




    function getFeatures() {

        $.ajax({
            type: 'POST',
            url: '/ToolFeatures/getFeatures',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            success: function (resultData) {

                $("#Featureboby").html("");

                var body;
                var featurenames = resultData.features;

                $.each(featurenames, function (k, v) {
                    body += "<tr><td>" + v.featureName + "</tr></td>";
                });


                $("#Featureboby").html(body);




            }
        });

    }



});