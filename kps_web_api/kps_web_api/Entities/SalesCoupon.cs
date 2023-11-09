using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kps_web_api.Entities;

[Table("SalesCoupons", Schema = "dbo")]
[Index("CouponCode", Name = "CouponCode", IsUnique = true)]
public partial class SalesCoupon
{
    [Key]
    [Column("CouponID")]
    public int CouponId { get; set; }

    [StringLength(20)]
    public string? CouponCode { get; set; }

    [Precision(5)]
    public decimal? DiscountPercentage { get; set; }

    [Column(TypeName = "date")]
    public DateTime? ExpirationDate { get; set; }

    [InverseProperty("Coupon")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
