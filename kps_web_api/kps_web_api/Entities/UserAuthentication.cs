using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kps_web_api.Entities;

[Table("UserAuthentication", Schema = "dbo")]
[Index("UserName", Name = "UserName", IsUnique = true)]
[Index("UserRoleId", Name = "UserRoleID")]
public partial class UserAuthentication
{
    [Key]
    [Column("UserID")]
    public int UserId { get; set; }

    [StringLength(50)]
    public string UserName { get; set; } = null!;

    [StringLength(255)]
    public string PasswordHash { get; set; } = null!;

    [Column("UserRoleID")]
    public int? UserRoleId { get; set; }

    [ForeignKey("UserRoleId")]
    [InverseProperty("UserAuthentications")]
    public virtual UserRole? UserRole { get; set; }
}
