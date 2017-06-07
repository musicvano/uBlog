angular.module("post").
  component("postEdit", {
      templateUrl: "app/post/post-edit.html",

      controller: ["PostService", "$routeParams", "ngDialog", "ngFoobar",
          function PostEditController(PostService, $routeParams, ngDialog, ngFoobar) {
            this.postId = $routeParams.id;
            this.post = PostService.get({ id: this.postId });

            this.savePost = function () {
                console.log("submit");
                PostService.update({ id: this.postId }, this.post,
                    function Success() {
                        ngFoobar.show("success", "Post have been saved");
                    },
                    function Failed() {
                        ngFoobar.show("error", "Error occured");
                    });
            };

            this.showHelp = function ShowHelp() {
                ngDialog.open({
                    template: 'app/modal/md-help.html',
                    width: "80%",
                    className: 'ngdialog-theme-default'
                });
            };
        }
      ]
  });