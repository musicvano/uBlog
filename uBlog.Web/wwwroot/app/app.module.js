angular.module("uBlog", [
    "ngRoute",
    "ngCookies",
    "ngResource",
    "core",
    "mainMenu",
    "post",
    "search",
    "settings",
    "angular-loading-bar",
    "ngDialog",
    "ngFoobar"
]).config(["cfpLoadingBarProvider", function (cfpLoadingBarProvider) {
    cfpLoadingBarProvider.includeSpinner = false;
}]);