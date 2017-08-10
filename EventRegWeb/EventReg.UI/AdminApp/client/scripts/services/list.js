(function (app) {
    var list = function ($q, db) {

        var GetList = function (listID) {
            var deferred = $q.defer();
            db.List("list", false, "admin").then(function (data) {
                angular.forEach(data, function (item) {
                    if (item.ListID == listID) {
                        deferred.resolve(item.Items);
                    }
                });
            });
            return deferred.promise;
        };

        return {
            GetList: GetList
        };
    };
    list.$inject = ["$q", "db"];
    app.factory("list", list);
}(angular.module('app')));