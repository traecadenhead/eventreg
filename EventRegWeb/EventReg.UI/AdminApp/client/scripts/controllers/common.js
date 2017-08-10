// Header
(function (app) {
    var CommonHeader = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $transitions, security) {
        $scope.current = "Home";
        $scope.showNav = false;
        $scope.user = null;

        var Load = function () {
            $scope.user = security.GetUser();
        };

        Load();

        $scope.ToggleNav = function () {
            if ($scope.showNav == true) {
                $scope.showNav = false;
            }
            else {
                $scope.showNav = true;
            }
        };

        $scope.LoadState = function (state) {
            $scope.showNav = false;
            $state.go(state);
        };

        $transitions.onSuccess({ to: "*" }, function (trans) {
            var to = trans.to().name;
            if (to.indexOf("Customer") >= 0) {
                to = "Customer";
            }
            $scope.current = to;
            $scope.user = security.GetUser();
        });
    };

    CommonHeader.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$transitions", "security"];
    app.controller("CommonHeader", CommonHeader);
}(angular.module("app")));