angular.module("post").
  component("postDetail", {
      templateUrl: "app/post/post-list.html",

      controller: ['$routeParams',
        function PhoneDetailController($routeParams) {
            this.phoneId = $routeParams.phoneId;
        }
      ]
  });