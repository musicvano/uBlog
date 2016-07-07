using System;
using System.Collections.Generic;
using uBlog.Data.Entities;

namespace uBlog.Data
{
    public class DbInitializer
    {
        public static void Seed()
        {
            using (var contex = new BlogContext())
            {
                contex.Database.EnsureDeleted();
                contex.Database.EnsureCreated();
                var settings = new Settings
                {
                    Author = "Ivan Muzyka",
                    About = "I am teacher, blogger and  C/C++/C# developer. I like to create small, nice and fast desktop and web apps. I am excited to present my personal blog where I am going to write my thoughts about programming and IT news. Feel free to contact me if you have any questions. I am open for cooperation.",
                    Photo = "me.png",
                    Email = "musicvano@gmail.com",
                    Url = "http://mvano.com",
                    Github = "https://github.com/musicvano",
                    Facebook = "https://www.facebook.com/musvano",
                    Twitter = "https://twitter.com/musvano",
                    Skype = "musicvano",
                    Location = "Ukraine",
                    PageSize = 10,
                };
                contex.Settings.Add(settings);

                var tags = new List<Tag>
                {
                    new Tag
                    {
                        Name = "News",
                        Slug = "news"
                    },
                    new Tag
                    {
                        Name = "uBlog",
                        Slug = "ublog"
                    },
                    new Tag
                    {
                        Name = "ASP.NET Core",
                        Slug = "asp-net-core"
                    }
                };
                contex.Tags.AddRange(tags);

                var posts = new List<Post>
                {
                    new Post
                    {
                        Title = "О моем блоге",
                        Slug = "о-моем-блоге",
                        Content = article1,
                        DateCreated = new DateTime(2016, 06, 22),
                        Draft = false
                    }/*,
                    new Post
                    {
                        Title = "My first post",
                        Slug = "my-first-post",
                        Content = article2,
                        DateCreated = DateTime.Now,
                        Draft = false
                    }*/
                };
                contex.Posts.AddRange(posts);

                var postTags = new List<PostTag>
                {
                    new PostTag
                    {
                        Post = posts[0],
                        Tag = tags[0]
                    },
                    new PostTag
                    {
                        Post = posts[0],
                        Tag = tags[1]
                    },
                    new PostTag
                    {
                        Post = posts[0],
                        Tag = tags[2]
                    }/*,
                    new PostTag
                    {
                        Post = posts[1],
                        Tag = tags[1]
                    },
                    new PostTag
                    {
                        Post = posts[1],
                        Tag = tags[2]
                    }*/
                };
                contex.PostTags.AddRange(postTags);
                contex.SaveChanges();
            }
        }

        const string article1 =
@"Всех приветствую!

Решил наконец-то создать свой личный блог. И не просто создать, используя готовый движок типа [WordPress](https://wordpress.com), [Ghost](https://ghost.org), [Е2 Эгея](http://blogengine.ru), а написать с нуля блоговый движок на C# на базе [ASP.NET Core 1.0](http://www.asp.net).

![Мой блоговый движок](http://performancemanagementcompanyblog.files.wordpress.com/2012/11/sws-bicycle.gif ""Мой блоговый движок"")

Знаю, знаю, что мой велосипед будет с квадратными колесами, но решив создать блоговый движок, я задался такими основными целями:

- изучить новый кросплатформенный фреймворк [ASP.NET Core 1.0](http://www.asp.net);
- проверить, насколько готова эта технология для применения ее в продакшене, например, на VPS сервере Debian 8.5;
- реализовать админку блога на фреймворке типа [AngularJS](https://angularjs.org);
- разработать архитектуру приложения на базе трехуровневой модели, использовав принцип Dependency Injection;
- проделать много другой рутинной работы c HTML, CSS, SASS, Gulp, Entity Framework, Markdown и т.д.;
- и конечно все это хорошенько покритиковать :-)

Как можно заметить, большинство современных технологий для веба (ASP.NET Core, Java, Node.js, Ruby on Rails) работают на виртуальных машинах и виртуальных серверах (VPS), а не на разделяемом хостинге (shared hosting), как это было раньше, как это успешно до нашего времени делает PHP. Наверное, один из факторов живучести PHP как раз и является низкая стоимость хостинга, что немало важно для личных сайтов, для сайтов мелкого бизнеса. Сегодня на рынке IT есть недорогой и доступный VPS хостинг, например:

- [BuyVM](http://buyvm.net/kvm-vps) - 2 Cores / RAM 256 MB / SSD 30 GB / $5.00 per month;
- [DigitalOcean](https://www.digitalocean.com) - 1 Core / RAM 512 MB / SSD 20 GB / $5.00 per month;
- [VPSDime](https://vpsdime.com) - 4 Cores / RAM 6 GB / SSD 30 GB / $7.00 per month.

Однако объем оперативной памяти 512 МБ не так уж и велик для VPS, на котором работают: серверная операционная система, система управления базой данных, сайт с различными сервисами и, конечно же, виртуальная машина (CLR, JVM). В условиях ограниченного бюджета на хостинг компилируемые языки (С/С++, Objective-C, D, Go) могут быть достаточно выгодными. К сожалению, их редко используют для создания сайтов. Но это уже другая история, о которой мы тоже поговорим.

Итак, в дальнейшем я хочу написать цикл статей о создании блогового движка на ASP.NET Core, детально остановить на тех вопросах, которые забрали у меня много времени, особенно в архитектурном плане. Эти статьи не перетендуют на исчерпывающее руководство по разработке сайта на C#, но могут быть полезными новичкам.

В этом блоге я планирую писать о программировании на Assembler, C, C++, C#, JavaScript, веб-разработке, различных технологиях, новостях в мире IT и многом другом. Язык изложения будет как русским, так и английским.

К сожалению, блог на данным момент очень примитивный и находится в стадии разработки, многих полезных фич ему не хватает по сравнению со зрелыми продуктами. Но будем развиваться! Все, кому интересно, пишите коментарии, давайте дельные советы :-)";

        const string article2 =
@"Lol";
    }
}