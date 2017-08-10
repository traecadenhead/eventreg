// Index
(function (app) {
    var CustomerIndex = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security) {

        $scope.customers = [];

        var Load = function () {
            security.CheckLogin("Admin").then(function () {
                ga.TrackScreen("CustomerIndex");
                db.List("customer", true).then(function (data) {
                    $scope.customers = data;
                });
            });
        };

        Load();

        $scope.Edit = function (customerID) {
            $state.go("CustomerEdit", { 'customerID': customerID });
        };

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerIndex.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security"];
    app.controller("CustomerIndex", CustomerIndex);
}(angular.module("app")));

// Edit
(function (app) {
    var CustomerEdit = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security, $stateParams) {

        $scope.entity = null;

        var Load = function () {
            security.CheckLogin("Admin").then(function () {
                ga.TrackScreen("CustomerEdit");
                if (oh.HasValue($stateParams.customerID)) {
                    db.Get("customer", $stateParams.customerID, true).then(function (data) {
                        $scope.entity = data;
                    });
                }
                else {
                    $scope.entity = { CustomerID: 0 };
                }
            });
        };

        Load();

        $scope.Submit = function () {
            db.Save("customer", $scope.entity).then(function (result) {
                if (result > 0) {
                    deviceSvc.Alert("The customer information was saved.").then(function () {
                        if (result != $scope.entity.CustomerID) {
                            // reload the screen now that customer has an ID
                            $state.go("CustomerEdit", { "customerID": result });
                        }
                    });
                }
                else {
                    deviceSvc.Alert("A problem occurred while saving the customer.");
                }
            });
        };

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerEdit.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security", "$stateParams"];
    app.controller("CustomerEdit", CustomerEdit);
}(angular.module("app")));