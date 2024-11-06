using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Test.Models
{
    public class Categories
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(100)]
        [DisplayName("Categories Name")]
        public string Name { get; set; }


        [DisplayName("Display Order")]
        [Range(1,100)]
        public int DisplayOrder { get; set; }

    }
}
