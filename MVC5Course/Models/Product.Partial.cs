namespace MVC5Course.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(ProductMetaData))]
    public partial class Product : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Price>1000 && this.Stock > 100)
            {
                yield return new ValidationResult("本商品價格與庫存量不合理",
                    new string[] { "Price","Stock"});
            }

            if (this.ProductName.Contains("will"))
            {
                yield return new ValidationResult("本商品名稱己為註冊商標不可用",
               new string[] { "ProductName" });
            }
            yield break;
        }
    }

    public partial class ProductMetaData
    {
        [Required]
        public int ProductId { get; set; }
        
        [StringLength(80, ErrorMessage="欄位長度不得大於 80 個字元")]
        public string ProductName { get; set; }
        [Required]
        [Range(1,10)]
        public Nullable<decimal> Price { get; set; }
        [Required]
        public Nullable<bool> Active { get; set; }
        [Required]
        public Nullable<decimal> Stock { get; set; }
        [Required]
        public bool IsDeleted { get; set; }
    
        public virtual ICollection<OrderLine> OrderLine { get; set; }
    }
}
