angular.module("post").
  component("postList", {
      templateUrl: "app/post/post-list.html",

      controller: ["PostService", function PostListController(postService) {
          this.posts = postService.query();
      }]
  });