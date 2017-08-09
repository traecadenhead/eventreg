var routingFunction = function ($stateProvider, $httpProvider, $locationProvider, $urlRouterProvider, $urlMatcherFactory) {
    $stateProvider
    //.state('ReviewIdentify', {
    //    url: '/app/review/identify/{placeID}',
    //    views: {
    //        "mainContainer": {
    //            templateUrl: function ($stateParams) {
    //                return '/Application/client/views/review/identify.html';
    //            }
    //        }
    //    }
    //})
    .state('SignIn', {
        url: '/admin/signin',
        views: {
            "mainContainer": {
                templateUrl: function ($stateParams) {
                    return '/AdminApp/client/views/home/signin.html';
                }
            }
        }
    })
    .state('Customers', {
        url: '/admin/customers',
        views: {
            "mainContainer": {
                templateUrl: function ($stateParams) {
                    return '/AdminApp/client/views/customer/index.html';
                }
            }
        }
    })
    .state('Home', {
        url: '/admin',
        views: {
            "mainContainer": {
                templateUrl: function ($stateParams) {
                    return '/AdminApp/client/views/home/index.html';
                }
            }
        }
    });
};

routingFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider'];

app.config(routingFunction);