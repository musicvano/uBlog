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
                Title = post.Title,
                Slug = post.Slug,
                Content = post.Content,
                DateCreated = post.DateCreated,
                Draft = post.Draft,
                Tags = Create(post.PostTags)
            };
        }

        public static TagModel Create(Tag tag)
        {
            return new TagModel
            {
                Name = tag.Name,
                Slug = tag.Slug
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

        public static List<TagModel> Create(List<PostTag> postTags)
        {
            return postTags.Select(p => Create(p.Tag)).ToList();
        }
    }
}