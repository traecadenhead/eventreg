// Index
(function (app) {
    var CustomerIndex = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga) {

        var Load = function () {
            ga.TrackScreen("CustomerIndex");

        };

        Load();

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerIndex.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga"];
    app.controller("CustomerIndex", CustomerIndex);
}(angular.module("app")));