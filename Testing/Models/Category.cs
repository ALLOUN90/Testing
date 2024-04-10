using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace Testing.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(30)]
        [DisplayName("Category Name ")]
        public string Name { get; set; }
        [DisplayName("DesplayOrder")]
        [Range(1,100,ErrorMessage = "DesplayOrder must be between 1 and 100.")]
        public int DesplayOrder { get; set; }
    }
}
