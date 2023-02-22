using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Catalog.Domain.Entity
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; } = string.Empty;
        public string? Description { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        //public List<Image> Images { get; set; } = new List<Image>();
        [ForeignKey("CategoryId")]
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool Featured { get; set; } = false;
        public List<ProductVariant> Variants { get; set; } = new List<ProductVariant>();
        public bool Visible { get; set; } = true;
        public bool Deleted { get; set; } = false;
        [NotMapped]
        public bool Editing { get; set; } = false;
        [NotMapped]
        public bool IsNew { get; set; } = false;
        public int ShopId { get; set; }
        //public Shop Shop { get; set; }
        public string? Slug { get; set; }
        public bool RefundAble { get; set; }
        public string? ThumbNail { get; set; }
        public string? Attributes { get; set; }
        public bool Published { get; set; }
        public string? Tax { get; set; }
        public string? TaxType { get; set; }
        public string? Discount { get; set; }
        public string? DiscountType { get; set; }
        public DateTime CreatedTime { get; set; } = DateTime.Now;
        public DateTime UpdatedTime { get; set; } = DateTime.Now;
        public string? MetaTitle { get; set; }
        public string? MetaDesc { get; set; }
        public string? MetaImage { get; set; }
        public bool RequestStatus { get; set; }
        public string? DeniedNote { get; set; }
        public decimal ShippingCost { get; set; }

        public List<Review> Reviews { get; set; }
    }
}
