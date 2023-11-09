using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kps_web_api.Entities;

[Table("Products", Schema = "dbo")]
[Index("CategoryId", Name = "CategoryID")]
[Index("CouponId", Name = "CouponID")]
[Index("OrderDetailId", Name = "OrderDetailID")]
public partial class Product
{
    [Key]
    [Column("ProductID")]
    public int ProductId { get; set; }

    [StringLength(100)]
    public string? ProductName { get; set; }

    [StringLength(255)]
    public string? Description { get; set; }

    [Precision(10)]
    public decimal? Price { get; set; }

    [Column("CategoryID")]
    public int? CategoryId { get; set; }

    [Column("CouponID")]
    public int? CouponId { get; set; }

    [Column("OrderDetailID")]
    public int? OrderDetailId { get; set; }

    [ForeignKey("CategoryId")]
    [InverseProperty("Products")]
    public virtual ProductCategory? Category { get; set; }

    [ForeignKey("CouponId")]
    [InverseProperty("Products")]
    public virtual SalesCoupon? Coupon { get; set; }

    [ForeignKey("OrderDetailId")]
    [InverseProperty("Products")]
    public virtual OrderDetail? OrderDetail { get; set; }

    [InverseProperty("Product")]
    public virtual ICollection<SupplierProduct> SupplierProducts { get; } = new List<SupplierProduct>();
}
