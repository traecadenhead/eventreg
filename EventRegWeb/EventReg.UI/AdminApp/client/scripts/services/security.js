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

        var CheckLogin = function (type) {
            var deferred = $q.defer();
            var user = GetUser();
            if (user == null || !HasType(type)) {
                $state.go("SignIn");
                deferred.reject("not logged in");
            }
            else {
                deferred.resolve(user);
            }
            return deferred.promise;
        };

        var HasType = function(type){
            if(type == undefined || type == null || type == ''){
                return true;
            }
            else{
                var user = GetUser();
                if (type == "Admin" && user.Type == 'Admin') {
                    return true;
                }
                else if (type == "Customer" && (user.Type == 'Admin' || user.Type == 'Customer')) {
                    return true;
                }
                else {
                    return false;
                }
            }
        };

        var GetUser = function () {
            return amplify.store("AdminUser");
        };

        return {
            SignIn: SignIn,
            IsLoggedIn: IsLoggedIn,
            CheckLogin: CheckLogin,
            GetUser: GetUser
        };
    };
    security.$inject = ["$q", "db", "$state"];
    app.factory("security", security);
}(angular.module('app')));