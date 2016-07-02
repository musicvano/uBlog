angular.module("core").factory("PostService", ["$resource", function ($resource) {
    return $resource("api/posts");
}]);