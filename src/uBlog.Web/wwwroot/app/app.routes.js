angular.
  module("uBlog").
  config(["$locationProvider", "$routeProvider",
    function config($locationProvider, $routeProvider) {
        $locationProvider.hashPrefix('!');

        $routeProvider.
          when("/posts", {
              template: "<post-list></post-list>"
          }).
          when("/posts/:id", {
              template: "<post-detail></post-detail>"
          }).
          otherwise("/posts");
    }
  ]);