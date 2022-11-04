using System.ComponentModel.DataAnnotations.Schema;

namespace upload_img.Model
{
    [Table("Tags")]
    public class Tag
    {
        [Column("id")]
        public int Id { get; set; }

        [Column("tag_name")]
        public string TagName { get; set; }

        public virtual PostTag PostTag { get; set; }
    }
}
