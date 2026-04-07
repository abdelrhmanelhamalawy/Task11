using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Task11.Models;

[Table("Employee_Log")]
public partial class EmployeeLog
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Column("employee_id")]
    public int EmployeeId { get; set; }

    [Column("action")]
    [StringLength(50)]
    [Unicode(false)]
    public string Action { get; set; } = null!;

    [Column("action_date", TypeName = "datetime")]
    public DateTime? ActionDate { get; set; }
}
