angular.module("post").
  component("postNew", {
      templateUrl: "app/post/post-new.html",

      controller: ["PostService", function PostListController(postService) {
          this.posts = postService.query();
      }]
  });