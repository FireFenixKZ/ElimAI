using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Domain.Entity
{
    public class Category
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        public string Slug { get; set; } = string.Empty;
        public string Icon { get; set; } = string.Empty;
        public int? ParentId { get; set; }
        public int Position { get; set; } = 0;
        public DateTime? Created { get; set; }
        public DateTime? Updated { get; set; }
        public bool HomeStatus { get; set; } = false;
        public int Priority { get; set; } = 0;
        [ForeignKey("CategoryId")]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
