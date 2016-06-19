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

        public static TagDetailModel Create(Tag tag, int postCount)
        {
            return new TagDetailModel
            {
                Name = tag.Name,
                Slug = tag.Slug,
                PostCount = postCount
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

        public static List<TagDetailModel> Create(List<Tag> tags, int[] postCounts)
        {
            int count = tags.Count;
            var res = new TagDetailModel[count];
            for (int i = 0; i < tags.Count; i++)
            {
                res[i] = Create(tags[i], postCounts[i]);
            }
            return res.ToList();
        }

        public static List<TagModel> Create(List<PostTag> postTags)
        {
            return postTags.Select(p => Create(p.Tag)).ToList();
        }
    }
}