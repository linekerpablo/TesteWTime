app.controller('HomeController', function ($scope, HomeService) {
    $scope.init = function () {
        $scope.getStats();
    }

    $scope.getStats = function () {
        HomeService.getStats().then(function (response) {
            console.log(response);
            console.log(response.data[0].hits);

            $scope.stats = response.data[0];
        });
    };
})   