angular.module("postList").
  component("postList", {
      templateUrl: "app/post-list/post-list.html",
      controller: ["PostService", function PostListController(postService) {
          this.posts = postService.query();
      }]
  });