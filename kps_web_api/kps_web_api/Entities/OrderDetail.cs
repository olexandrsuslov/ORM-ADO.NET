using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kps_web_api.Entities;

[Table("OrderDetails", Schema = "dbo")]
[Index("OrderId", Name = "OrderID")]
[Index("ProductId", Name = "ProductID")]
public partial class OrderDetail
{
    [Key]
    [Column("OrderDetailID")]
    public int OrderDetailId { get; set; }

    [Column("OrderID")]
    public int? OrderId { get; set; }

    [Column("ProductID")]
    public int? ProductId { get; set; }

    [Precision(10)]
    public decimal? TotalPrice { get; set; }

    [ForeignKey("OrderId")]
    [InverseProperty("OrderDetails")]
    public virtual Order? Order { get; set; }

    [InverseProperty("OrderDetail")]
    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
