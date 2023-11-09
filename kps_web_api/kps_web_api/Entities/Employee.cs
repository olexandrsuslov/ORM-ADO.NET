using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace kps_web_api.Entities;

[Table("Employees", Schema = "dbo")]
[Index("RoleId", Name = "RoleID")]
public partial class Employee
{
    [Key]
    [Column("EmployeeID")]
    public int EmployeeId { get; set; }

    [StringLength(50)]
    public string? FirstName { get; set; }

    [StringLength(50)]
    public string? LastName { get; set; }

    [StringLength(100)]
    public string? Email { get; set; }

    [StringLength(20)]
    public string? Phone { get; set; }

    [Column("RoleID")]
    public int? RoleId { get; set; }

    [ForeignKey("RoleId")]
    [InverseProperty("Employees")]
    public virtual EmployeeRole? Role { get; set; }
}
