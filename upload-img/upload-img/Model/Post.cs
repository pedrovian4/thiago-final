using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;

namespace upload_img.Model
{
    [Table("Posts")]
    public class Post
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("user_id")]
        public int UserId { get; set; }

        [Column("img_url")]
        public string ImgUrl { get; set; }

        [Column("title")]
        public string Title { get; set; }

        [Column("description")]
        public string Description { get; set; }
    }
}
