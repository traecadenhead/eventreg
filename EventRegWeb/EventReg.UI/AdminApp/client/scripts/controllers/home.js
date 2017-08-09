// Sign In
(function (app) {
    var HomeSignIn = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security) {

        $scope.login = {};

        var Load = function () {
            ga.TrackScreen("HomeSignIn");
        };

        Load();

        $scope.Submit = function () {
            security.SignIn($scope.login).then(function (result) {
                if (result) {
                    $state.go("Home");
                }
                else {
                    // TO DO: Rewrite the alert service so alert and confirm are 2 different calls
                    deviceSvc.Alert("alert", "Sorry, we couldn't sign you in with the information you entered.");
                }
            });
        };

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    HomeSignIn.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security"];
    app.controller("HomeSignIn", HomeSignIn);
}(angular.module("app")));

// Index
(function (app) {
    var HomeIndex = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security) {

        var Load = function () {
            security.CheckLogin().then(function () {
                ga.TrackScreen("HomeIndex");
            });            
        };

        Load();

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    HomeIndex.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security"];
    app.controller("HomeIndex", HomeIndex);
}(angular.module("app")));

