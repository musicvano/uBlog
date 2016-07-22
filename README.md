# uBlog
Simple blog engine based on ASP.NET Core 1.0.

uBlog is currently under **development**. Some news can be found on my website [mvano.com](http://mvano.com).

## Overview

Solution consists of separate parts:

- uBlog.Data - data access layer works with [SQLite](https://www.sqlite.org/) database
- uBlog.Core - all services provide core functionality for the blog
- uBlog.Web - ASP.NET Core app uses Razor view engine for GET requests and provides WebAPI for admin panel
- uBlog.Test - unit and integration tests for the blog
- uTool - command-line interface (CLI) for initial database configuration, migration, etc.

Project uses such libraries and frameworks:

- [Entity Framework Core](https://ef.readthedocs.io)
- [CommonMark.NET](https://github.com/Knagis/CommonMark.NET)
- [AngularJS](https://angularjs.org)
- [Skeleton CSS](http://getskeleton.com)
- [Font Awesome](http://fontawesome.io)
- [Prism](http://prismjs.com)

uBlog supports [Disqus](https://disqus.com/) service for commenting and [AddThis](https://www.addthis.com) for sharing across social networks.

## License
This project is licensed under the MIT License.