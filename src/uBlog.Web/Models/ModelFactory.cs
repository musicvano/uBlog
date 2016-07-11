using System.Collections.Generic;
using System.Linq;
using uBlog.Data.Entities;

namespace uBlog.Web.Models
{
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
                Tags = post.PostTags.Select(pt => pt.Tag).ToList()
            };
        }

        public static TagModel Create(Tag tag)
        {
            return new TagModel
            {
                Id = tag.Id,
                Name = tag.Name,
                Slug = tag.Slug,
                Posts = tag.PostTags.Select(pt => pt.Post).ToList()
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