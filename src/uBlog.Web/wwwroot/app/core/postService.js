var core = angular.module("core");

core.service("PostService", ["$resource", function ($resource) {
    return $resource("api/posts");
}]);