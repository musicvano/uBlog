angular.module("uBlog").
  config(["$locationProvider", "$routeProvider",
    function config($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix('!');

        $routeProvider.
            when("/posts", {
                template: "<post-list />"
            }).
            when("/posts/new", {
                template: "<post-new />"
            }).
            when("/posts/:id/edit", {
                template: "<post-edit />"
            }).
            when("/search", {
                template: "<search />"
            }).
            when("/settings", {
                template: "<settings />"
            }).
            otherwise("/posts");
    }
  ]).run(['$rootScope', '$location', '$cookieStore', '$http',
    function ($rootScope, $location, $cookieStore, $http) {
        // keep user logged in after page refresh
        $rootScope.globals = $cookieStore.get('globals') || {};
        if ($rootScope.globals.currentUser) {
            $http.defaults.headers.common['Authorization'] = 'Basic ' + $rootScope.globals.currentUser.authdata;
        }

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to login page if not logged in
            if ($location.path() !== '/login' && !$rootScope.globals.currentUser) {
                $location.path('/login');
            }
        });
    }]);