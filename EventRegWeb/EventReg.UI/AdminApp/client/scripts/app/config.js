// initialize app with angular plugins
var app = angular.module('app', ['ui.router', 'angular-loading-bar', 'ngAnimate', 'ngSanitize', 'relativePathsInPartial', 'ui.bootstrap', 'angulartics', 'angulartics.google.analytics', 'ng.deviceDetector']);

// configuration for angular app
var configFunction = function ($stateProvider, $httpProvider, $locationProvider, cfpLoadingBarProvider, $urlRouterProvider, $urlMatcherFactory, $compileProvider, relativePathsInterceptorProvider) {
    // url settings
    $urlMatcherFactory.caseInsensitive(true);
    $urlMatcherFactory.strictMode(false);
    // ignore '/Application' in URL paths
    relativePathsInterceptorProvider.setInteceptionPrefix('/AdminApp');
    // whitelist protocols for URLs
    $compileProvider.aHrefSanitizationWhitelist(/^\s*(http|https|itms-services|mailto):/);

    // loading bar settings
    cfpLoadingBarProvider.includeSpinner = false;

    // enable HTML5 mode for clean URLs
    $locationProvider.html5Mode({
        enabled: true,
        requireBase: false
    }).hashPrefix('!');
    
}
configFunction.$inject = ['$stateProvider', '$httpProvider', '$locationProvider', 'cfpLoadingBarProvider', '$urlRouterProvider', '$urlMatcherFactoryProvider', '$compileProvider', 'relativePathsInterceptorProvider'];

// apply configuration to app
app.config(configFunction);