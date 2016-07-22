angular.module("mainMenu").
  component("mainMenu", {
      templateUrl: "app/main-menu/main-menu.html",

      controller: 
        function MenuController() {
            this.hello = "Opps :)";
        }
      
  });