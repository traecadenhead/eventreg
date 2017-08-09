(function (app) {
    var security = function ($q, db, $state) {

        var SignIn = function (login) {
            var deferred = $q.defer();
            db.Post("admin", "signin", login).then(function (data) {
                if (data != null) {
                    amplify.store("AdminUser", data);
                    deferred.resolve(true);
                }
                else {
                    deferred.resolve(false);
                }
            });
            return deferred.promise;
        };

        var IsLoggedIn = function () {
            if (amplify.store("AdminUser") != null) {
                return true;
            }
            else {
                return false;
            }
        };

        var CheckLogin = function () {
            var deferred = $q.defer();
            if (!IsLoggedIn()) {
                $state.go("SignIn");
                deferred.reject("not logged in");
            }
            else {
                deferred.resolve(true);
            }
            return deferred.promise;
        }

        return {
            SignIn: SignIn,
            IsLoggedIn: IsLoggedIn,
            CheckLogin: CheckLogin
        };
    };
    security.$inject = ["$q", "db", "$state"];
    app.factory("security", security);
}(angular.module('app')));