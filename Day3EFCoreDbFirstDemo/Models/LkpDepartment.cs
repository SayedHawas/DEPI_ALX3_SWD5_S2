using System;
using System.Collections.Generic;

namespace Day3EFCoreDbFirstDemo.Models;

public partial class LkpDepartment
{
    public int DepartmentId { get; set; }

    public string Name { get; set; } = null!;

    public string? Description { get; set; }

    public bool IsDelete { get; set; }

    public string ManagerName { get; set; } = null!;

    public virtual ICollection<LkpEmployee> LkpEmployees { get; set; } = new List<LkpEmployee>();
}
