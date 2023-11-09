using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kps_web_api.Entities;

[Table("UserRoles", Schema = "dbo")]
public partial class UserRole
{
    [Key]
    [Column("UserRoleID")]
    public int UserRoleId { get; set; }

    [StringLength(50)]
    public string RoleName { get; set; } = null!;

    [StringLength(50)]
    public string Token { get; set; } = null!;

    [InverseProperty("UserRole")]
    public virtual ICollection<UserAuthentication> UserAuthentications { get; } = new List<UserAuthentication>();
}
