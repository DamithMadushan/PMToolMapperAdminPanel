$(document).ready(function () {

    $("#successmsg").hide();

    var token = sessionStorage.getItem("token");

    getPMTools();
    getPMToolsFeatureCategory();
    getPMToolsFeatures();
    getFeaturesTable();

    clear()

    function getPMTools() {

        $.ajax({
            type: 'POST',
            url: '/SetFeatures/getTools',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            success: function (resultData) {

                $("#toolname").html("");

                var bodyhtml = "";

                bodyhtml += "<option value='' disabled='disabled'>--Select--</option>";

                var toolnames = resultData.tools;

                $.each(toolnames, function (k, v) {
                    bodyhtml += "<option value=" + v.toolId + ">" + v.toolName + "</option>";
                });


                $("#toolname").html(bodyhtml);

            }
        });

    }



    function getPMToolsFeatureCategory() {

        $.ajax({
            type: 'POST',
            url: '/SetFeatures/getToolFeatureCategory',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            success: function (resultData) {

                $("#featureCategory").html("");

                var bodyhtml = "";

                bodyhtml += "<option value='' disabled='disabled'>--Select--</option>";

                var FeatureCategoryNames = resultData.categories;

                $.each(FeatureCategoryNames, function (k, v) {
                    bodyhtml += "<option value=" + v.featureCategoryId + ">" + v.featureCategoryName + "</option>";
                });


                $("#featureCategory").html(bodyhtml);

            }
        });

    }



    function getPMToolsFeatures() {

        $.ajax({
            type: 'POST',
            url: '/SetFeatures/getToolFeatures',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            success: function (resultData) {

                $("#featurename").html("");

                var bodyhtml = "";

                bodyhtml += "<option value='' disabled='disabled'>--Select--</option>";

                var FeatureNames = resultData.features;

                $.each(FeatureNames, function (k, v) {
                    bodyhtml += "<option value=" + v.featureId + ">" + v.featureName + "</option>";
                });


                $("#featurename").html(bodyhtml);

            }
        });

    }

    function clear() {

        $("#toolname").val("");
        $('#featurename').val("");
        $('#featureCategory').val("");
        $('#featureapiurl').val("");
        $('#toolstatus').val("");

    }

    $("#save").click(function () {


        var _toolId = $('#toolname').val();
        var _featureId = $('#featurename').val();
        var _featureCategoryId = $('#featureCategory').val();
        var _featureapiurl = $('#featureapiurl').val();
        var _toolstatus = $('#toolstatus').val();


        $.ajax({
            type: 'POST',
            url: '/SetFeatures/addToolFeatures',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            data: {
                FeatureId: _featureId,
                FeatureCategoryId: _featureCategoryId,
                ToolId: _toolId,
                FeatureUrl: _featureapiurl,
                FeatureStatus: _toolstatus
            },
            success: function (resultData) {

                if (resultData.isValid) {

                    $("#successmsg").show();

                    clear();

                    getFeaturesTable();

                    setTimeout(function () {
                        $("#successmsg").hide();
                    }, 2000);


                } else {

                    $("#successmsg").hide();
                }


            }
        });
    });




    function getFeaturesTable() {

        $.ajax({
            type: 'POST',
            url: '/SetFeatures/getToolFeatureDetails',
            headers: { "Authorization": 'Bearer ' + JSON.parse(token) },
            success: function (resultData) {

                $("#pmtoolFeaturesboby").html("");

                var body;
                var toolnames = resultData.features;

                $.each(toolnames, function (k, v) {
                    body += "<tr><td>" + v.id + "</td>";
                    body += "<td>" + v.toolName + "</td>";
                    body += "<td>" + v.featureName + "</td>";
                    body += "<td>" + v.featureCategoryName + "</td>";
                    body += "<td>" + v.featureUrl + "</td>";
                    body += "<td>" + v.featureStatus + "</td></tr>";
                });


                $("#pmtoolFeaturesboby").html(body);

            }
        });

    }
});