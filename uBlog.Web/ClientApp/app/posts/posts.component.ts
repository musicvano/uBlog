import { Component, OnInit } from '@angular/core';

import { Post } from '../post';
import { PostService } from '../post.service';

@Component({
    selector: 'app-posts',
    templateUrl: './posts.component.html'
})
export class PostsComponent implements OnInit {
    posts: Post[];

    constructor(private postService: PostService) { }

    ngOnInit() {
        this.getPosts();
    }

    getPosts(): void {
        this.postService.getPosts()
            .subscribe(posts => this.posts = posts);
    }
} 