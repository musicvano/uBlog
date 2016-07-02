angular.
  module("postDetail").
  component("postDetail", {
      template: 'TBD: Detail view for <span>{{$ctrl.phoneId}}</span>',
      controller: ['$routeParams',
        function PhoneDetailController($routeParams) {
            this.phoneId = $routeParams.phoneId;
        }
      ]
  });