angular.module("post").
    factory("PostService", ["$resource",
      function ($resource) {
          return $resource("http://localhost:5890/api/posts/:id", null,
              {
                  'update': { method: 'PUT' }
              });
      }]);