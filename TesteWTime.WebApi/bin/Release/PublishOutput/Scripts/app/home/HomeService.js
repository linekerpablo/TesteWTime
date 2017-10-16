app.service("HomeService", function ($http) {
    this.getStats = function () {
        return $http.get("Urls/Stats")
    }
});