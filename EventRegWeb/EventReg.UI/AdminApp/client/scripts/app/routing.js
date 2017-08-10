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
    .state('CustomerKeys', {
        url: '/admin/customer/keys',
        views: {
            "mainContainer": {
                templateUrl: function ($stateParams) {
                    return '/AdminApp/client/views/customer/keys.html';
                }
            }
        }
    })
    .state('CustomerEdit', {
        url: '/admin/customer/edit/{customerID}',
        views: {
            "mainContainer": {
                templateUrl: function ($stateParams) {
                    return '/AdminApp/client/views/customer/edit.html';
                }
            }
        }
    })
    .state('CustomerEdit.Basic', {
        url: '/basic',
        views: {
            "secondaryContainer": {
                templateUrl: '/AdminApp/client/views/customer/basic.html'
            }
        }
    })
    .state('CustomerEdit.Prefs', {
        url: '/prefs',
        views: {
            "secondaryContainer": {
                templateUrl: '/AdminApp/client/views/customer/prefs.html'
            }
        }
    })
    .state('CustomerEdit.Admins', {
        url: '/admins',
        views: {
            "secondaryContainer": {
                templateUrl: '/AdminApp/client/views/customer/admins.html'
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