angular.module('myApp', ['kendo.directives'])
    .controller('KendoStuffController', function ($scope) {

        $scope.testData = "Testing the Kendo Upload Component";

        $scope.fileAsyncOptions = {
            autoUpload: false,
            saveUrl: 'api/attachment/save',
        };

        $scope.validationOptions = {
            maxFileSize: 30000000
        };

        $scope.uploadFile = function (e) {
            e.data = {
                supportingInfo: JSON.stringify({
                    description: $('#fileDesc').val(),
                    isDefaultImage: true
                })
            };
        };

    });