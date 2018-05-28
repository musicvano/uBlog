import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

import { Post } from './post';
import { MessageService } from './message.service';

@Injectable({ providedIn: 'root' })
export class PostService {
    postsUrl = '../api/posts';

    constructor(private http: HttpClient, private messageService: MessageService) { }

    getPosts(): Observable<Post[]> {
        return this.http.get<Post[]>(this.postsUrl)
            .pipe(
                tap(heroes => this.log(`fetched posts`)),
                catchError(this.handleError('getPosts', []))
            );
    }

    getPost(id: number): Observable<Post> {
        const url = `${this.postsUrl}/${id}`;
        return this.http.get<Post>(url).pipe(
            tap(_ => this.log(`fetched post id=${id}`)),
            catchError(this.handleError<Post>(`getPost id=${id}`))
        );
    }

    private handleError<T>(operation = 'operation', result?: T) {
        return (error: any): Observable<T> => {
            console.error(error);
            this.log(`${operation} failed: ${error.message}`);
            return of(result as T);
        };
    }

    private log(message: string) {
        this.messageService.add('PostsService: ' + message);
    }
}