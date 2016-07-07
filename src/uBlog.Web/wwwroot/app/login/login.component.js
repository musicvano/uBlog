angular.module("uBlog").component("login", {
    controller: ['$scope', '$rootScope', '$location', 'AuthService',
    function ($scope, $rootScope, $location, AuthService) {
        // reset login status
        //this

        AuthService.ClearCredentials();

        $scope.login = function () {
            $scope.dataLoading = true;
            AuthService.Login($scope.username, $scope.password, function (response) {
                if (response.success) {
                    AuthService.SetCredentials($scope.username, $scope.password);
                    $location.path('/');
                } else {
                    $scope.username = '';
                    $scope.password = '';
                    $scope.error = response.message;
                    $scope.dataLoading = false;
                }
            });
        };
    }],
    templateUrl: "app/login/login.html"
});