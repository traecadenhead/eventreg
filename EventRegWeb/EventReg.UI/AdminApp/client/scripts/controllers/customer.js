// Index
(function (app) {
    var CustomerIndex = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security) {

        var Load = function () {
            security.CheckLogin().then(function () {
                ga.TrackScreen("CustomerIndex");
            });
        };

        Load();

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerIndex.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security"];
    app.controller("CustomerIndex", CustomerIndex);
}(angular.module("app")));