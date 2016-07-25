using System.Collections.Generic;
using System.Linq;
using uBlog.Data.Entities;

namespace uBlog.Web.Models
{
    /// <summary>
    /// Mapper between entities and view models
    /// </summary>
    public class ModelFactory
    {
        public static PostModel Create(Post post)
        {
            return new PostModel
            {
                Id = post.Id,
                Title = post.Title,
                Slug = post.Slug,
                Content = post.Content,
                DateCreated = post.DateCreated,
                Draft = post.Draft,
                Tags = post.PostTags.Select(pt => new TagModel
                {
                    Id = pt.Tag.Id,
                    Name = pt.Tag.Name,
                    Slug = pt.Tag.Slug,
                    Posts = null
                }).ToList()
            };
        }

        public static Post Create(PostModel post)
        {
            return new Post
            {
                Id = post.Id,
                Title = post.Title,
                Slug = post.Slug,
                Content = post.Content,
                DateCreated = post.DateCreated,
                Draft = post.Draft,
                PostTags = post.Tags.Select(t => new PostTag
                {
                    PostId = post.Id,
                    TagId = t.Id
                }).ToList()
            };
        }

        public static TagModel Create(Tag tag)
        {
            return new TagModel
            {
                Id = tag.Id,
                Name = tag.Name,
                Slug = tag.Slug,
                Posts = tag.PostTags.Select(pt => new PostModel
                {
                    Id = pt.Post.Id,
                    Title = pt.Post.Title,
                    Slug = pt.Post.Slug,
                    Content = pt.Post.Content,
                    DateCreated = pt.Post.DateCreated,
                    Draft = pt.Post.Draft,
                    Tags = null
                }).ToList()
            };
        }

        public static UserModel Create(User user)
        {
            return new UserModel
            {
                Id = user.Id,
                Username = user.Username,
                Email = user.Email,
                About = user.About,
                Photo = user.Photo,
                Url = user.Url,
                Github = user.Github,
                Facebook = user.Facebook,
                Twitter = user.Twitter,
                Skype = user.Skype,
                Location = user.Location
            };
        }

        public static List<PostModel> Create(List<Post> posts)
        {
            return posts.Select(p => Create(p)).ToList();
        }

        public static List<TagModel> Create(List<Tag> tags)
        {
            return tags.Select(t => Create(t)).ToList();
        }
    }
}