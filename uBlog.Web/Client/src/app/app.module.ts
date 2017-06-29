import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { RouterModule, Routes } from '@angular/router';

import { AppComponent } from './app.component';
import { PostComponent } from './post/post.component';
import { PostsComponent } from './posts/posts.component';
import { TagsComponent } from './tags/tags.component';
import { SettingsComponent } from './settings/settings.component';
import { LoginComponent } from './login/login.component';

const routes: Routes = [
    { path: '', redirectTo: 'new', pathMatch: 'full' },
    { path: 'new', component: PostComponent },
    { path: 'posts', component: PostsComponent },
    { path: 'posts/:id', component: PostComponent },
    { path: 'tags', component: TagsComponent },
    { path: 'settings', component: SettingsComponent }
];

@NgModule({
    declarations: [
        AppComponent,
        PostComponent,
        PostsComponent,
        TagsComponent,
        SettingsComponent,
        LoginComponent
    ],
    imports: [
        BrowserModule,
        FormsModule,
        HttpModule,
        RouterModule.forRoot(routes)
    ],
    providers: [],
    bootstrap: [AppComponent]
})
export class AppModule { }