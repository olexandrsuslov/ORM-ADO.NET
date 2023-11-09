using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kps_web_api.Entities;

[Table("EmployeeRoles", Schema = "dbo")]
public partial class EmployeeRole
{
    [Key]
    [Column("RoleID")]
    public int RoleId { get; set; }

    [StringLength(50)]
    public string? RoleName { get; set; }

    [InverseProperty("Role")]
    public virtual ICollection<Employee> Employees { get; } = new List<Employee>();
}
