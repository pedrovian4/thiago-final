using upload_img.Model;

namespace upload_img.Business
{
    public class PostBusiness
    {
        private Context Context { get; }
        public PostBusiness(Context context)
        {
            Context = context;
        }

        public Post AdicionarPost(PostDTO postDto, string caminho)
        {
            Post post = new Post
            {
                UserId = postDto.UserId,
                ImgUrl = caminho,
                Title = postDto.Title,
                Description = postDto.Description
            };


            var entity = Context.Posts.Add(post);
            Context.SaveChanges();



            PostTag postTag = new PostTag
            {
                PostId = entity.CurrentValues.GetValue<int>("Id"),
                TagId = postDto.TagId
            };

            Context.PostTags.Add(postTag);
            Context.SaveChanges();


            return new Post
            {
                UserId = postDto.UserId,
                ImgUrl = caminho,
                Title = postDto.Title,
            };
        }
    }
}
