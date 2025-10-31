using System;
using System.Collections.Generic;

namespace Day3EFCoreDbFirstDemo.Models;

public partial class LkpEmployee
{
    public int EmployeeId { get; set; }

    public string Name { get; set; } = null!;

    public string? Jobtitle { get; set; }

    public decimal Salary { get; set; }

    public string? Photo { get; set; }

    public string Email { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public int? DepartmentId { get; set; }

    public bool IsDelete { get; set; }

    public virtual LkpDepartment? Department { get; set; }

    public virtual ICollection<SupplyOrder> SupplyOrders { get; set; } = new List<SupplyOrder>();
}
