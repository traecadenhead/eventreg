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

// Keys
(function (app) {
    var CustomerKeys = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security, list) {

        $scope.keys = [];
        $scope.types = [];

        var Load = function () {
            security.CheckLogin("Admin").then(function () {
                ga.TrackScreen("CustomerKeys");
                db.List("customer", true, "keys").then(function (data) {
                    $scope.keys = data;
                });
                list.GetList("PreferenceKeyTypes").then(function (data) {
                    $scope.types = data;
                });
            });
        };

        Load();

        $scope.Submit = function () {
            var i = 1;
            angular.forEach($scope.keys, function (item) {
                item.Ordinal = i;
                i++;
            });
            db.Save("customer", $scope.keys, "keys").then(function (result) {
                if (result) {
                    deviceSvc.Alert("The preference keys have been saved.");
                }
            });
        };

        $scope.Remove = function (item) {
            deviceSvc.Confirm("Are you sure you want to remove this key?").then(function (answer) {
                if (answer) {
                    db.Delete("customer", item.CustomerPrefKeyID, "key").then(function (result) {
                        if (result) {
                            var keys = $scope.keys
                            angular.forEach($scope.keys, function (key) {
                                if (key.CustomerPrefKeyID != item.CustomerPrefKeyID) {
                                    keys.push(key);
                                }
                            });
                            $scope.keys = keys;
                        }
                    });
                }
            });
        };

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerKeys.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security", "list"];
    app.controller("CustomerKeys", CustomerKeys);
}(angular.module("app")));

// Key Add
(function (app) {
    var CustomerKeyAdd = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security, list) {

        $scope.entity = null;

        var Load = function () {
            security.CheckLogin("Admin").then(function () {
                ga.TrackScreen("CustomerKeyAdd");
                list.GetList("PreferenceKeyTypes").then(function (data) {
                    $scope.types = data;
                });
            });
        };

        Load();

        $scope.Submit = function () {
            db.Save("customer", $scope.entity, "key").then(function (result) {
                if (result > 0) {
                    deviceSvc.Alert("The preference key has been saved.").then(function (data) {
                        $state.go("CustomerKeys");
                    });
                }
            });
        };

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerKeyAdd.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security", "list"];
    app.controller("CustomerKeyAdd", CustomerKeyAdd);
}(angular.module("app")));

// Edit
(function (app) {
    var CustomerEdit = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security, $stateParams) {

        $scope.customer = null;

        var Load = function () {
            security.CheckLogin("Admin").then(function () {
                ga.TrackScreen("CustomerEdit");
                if (oh.HasValue($stateParams.customerID)) {
                    db.Get("customer", $stateParams.customerID).then(function (data) {
                        $scope.customer = data;
                    });
                }
                else {
                    $scope.customer = { CustomerID: 0 };
                    $scope.Open("Basic");
                }
            });
        };

        Load();

        $scope.Open = function (view) {
            $state.go("CustomerEdit." + view, { "customerID": $scope.customer.CustomerID });
        };

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerEdit.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security", "$stateParams"];
    app.controller("CustomerEdit", CustomerEdit);
}(angular.module("app")));

// Edit Basic
(function (app) {
    var CustomerEditBasic = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security, $stateParams) {

        $scope.entity = null;

        var Load = function () {
            ga.TrackScreen("CustomerEdit.Basic");
            if (oh.HasValue($stateParams.customerID)) {
                db.Get("customer", $stateParams.customerID).then(function (data) {
                    $scope.entity = data;
                });
            }
            else {
                $scope.entity = { CustomerID: 0 };
            }
        };

        Load();

        $scope.Submit = function () {
            db.Save("customer", $scope.entity).then(function (result) {
                if (result > 0) {
                    db.Get("customer", $stateParams.customerID, true).then(function () {
                        deviceSvc.Alert("The customer information was saved.").then(function () {
                            if (result != $scope.entity.CustomerID) {
                                // reload the screen now that customer has an ID
                                $state.go("CustomerEdit.Basic", { "customerID": result });
                            }
                        });
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

    CustomerEditBasic.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security", "$stateParams"];
    app.controller("CustomerEditBasic", CustomerEditBasic);
}(angular.module("app")));

// Edit Prefs
(function (app) {
    var CustomerEditPrefs = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security, $stateParams) {

        $scope.prefs = [];

        var Load = function () {
            ga.TrackScreen("CustomerEdit.Prefs");
            if (oh.HasValue($stateParams.customerID)) {
                db.Get("customer", $stateParams.customerID, true, "prefs").then(function (data) {
                    $scope.prefs = data;
                });
            }
            else {
                $stage.go("Customers");
            }
        };

        Load();

        $scope.submit = function () {
            db.Save("customer", $scope.prefs, "prefs").then(function (result) {
                if (result) {
                    deviceSvc.Alert("The prefs have beens saved.");
                }
            });
        };

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerEditPrefs.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security", "$stateParams"];
    app.controller("CustomerEditPrefs", CustomerEditPrefs);
}(angular.module("app")));

// Edit Admins
(function (app) {
    var CustomerEditAdmins = function ($scope, db, oh, $state, root, deviceSvc, $sce, $timeout, $rootScope, $window, ga, security, $stateParams) {

        $scope.entity = null;

        var Load = function () {
            ga.TrackScreen("CustomerEdit.Admins");
            if (oh.HasValue($stateParams.customerID)) {
                db.Get("customer", $stateParams.customerID).then(function (data) {
                    $scope.entity = data;
                });
            }
            else {
                $scope.entity = { CustomerID: 0 };
            }
        };

        Load();

        // move to top of screen when view is loaded
        $timeout(function () {
            $window.scrollTo(0, 0);
        });
    };

    CustomerEditAdmins.$inject = ["$scope", "db", "oh", "$state", "root", "deviceSvc", "$sce", "$timeout", "$rootScope", "$window", "ga", "security", "$stateParams"];
    app.controller("CustomerEditAdmins", CustomerEditAdmins);
}(angular.module("app")));