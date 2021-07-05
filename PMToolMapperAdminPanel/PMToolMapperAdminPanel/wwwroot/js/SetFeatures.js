$(document).ready(function () {

    var token = sessionStorage.getItem("token");

    getPMTools();
    getPMToolsFeatureCategory();
    getPMToolsFeatures();

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
                    bodyhtml += "<option value=" + v.ToolId + ">" + v.toolName + "</option>";
                });


                $("#pmtoolsboby").html(bodyhtml);

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

                var FeatureCategoryNames = resultData.Categories;

                $.each(FeatureCategoryNames, function (k, v) {
                    bodyhtml += "<option value=" + v.FeatureCategoryId + ">" + v.FeatureCategoryName + "</option>";
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
                    bodyhtml += "<option value=" + v.FeatureId + ">" + v.FeatureName + "</option>";
                });


                $("#featurename").html(bodyhtml);

            }
        });

    }


});