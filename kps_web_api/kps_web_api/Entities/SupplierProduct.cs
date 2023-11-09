using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kps_web_api.Entities;

[Table("SupplierProducts", Schema = "dbo")]
[Index("ProductId", Name = "ProductID")]
[Index("SupplierId", Name = "SupplierID")]
public partial class SupplierProduct
{
    [Key]
    [Column("SupplierProductID")]
    public int SupplierProductId { get; set; }

    [Column("SupplierID")]
    public int? SupplierId { get; set; }

    [Column("ProductID")]
    public int? ProductId { get; set; }

    [Precision(10)]
    public decimal? SupplierPrice { get; set; }

    [ForeignKey("ProductId")]
    [InverseProperty("SupplierProducts")]
    public virtual Product? Product { get; set; }

    [ForeignKey("SupplierId")]
    [InverseProperty("SupplierProducts")]
    public virtual Supplier? Supplier { get; set; }
}
