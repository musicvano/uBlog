# uBlog
Simple blog engine based on ASP.NET Core 2.0.

uBlog is currently under **development**. Some news can be found on my website [mvano.com](http://mvano.com).

## Overview

Solution consists of separate parts:

- uBlog.Data - data access layer works with [SQLite](https://www.sqlite.org/) database
- uBlog.Core - all services provide core functionality for the blog
- uBlog.Web - ASP.NET Core app uses Razor view engine for GET requests and provides WebAPI for admin panel
- uBlog.Test - unit and integration tests for the blog

Project uses such libraries and frameworks:

- [Entity Framework Core](https://ef.readthedocs.io)
- [CommonMark.NET](https://github.com/Knagis/CommonMark.NET)
- [Angular 6](https://angular.io)
- [Bulma CSS](http://bulma.io)
- [Material Design Icons](https://materialdesignicons.com)
- [highlight.js](https://highlightjs.org)

uBlog supports [Disqus](https://disqus.com/) service for commenting and [AddThis](https://www.addthis.com) for sharing across social networks.

## License
This project is licensed under the MIT License.