using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace upload_img.Model
{
    [Table("post_tags")]
    public class PostTag
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("post_id")]
        public int PostId { get; set; }

        [Column("tag_id")]
        public int TagId { get; set; }

        public virtual Post Posts { get; set; }
        public virtual Tag Tags { get; set; }

    }
}
