using System;
using System.Collections.Generic;

namespace Day3EFCoreDbFirstDemo.Models;

public partial class SupplyOrder
{
    public int SupplyOrderId { get; set; }

    public DateTime SupplyDate { get; set; }

    public int VendorId { get; set; }

    public int EmployeeId { get; set; }

    public decimal Total { get; set; }

    public virtual LkpEmployee Employee { get; set; } = null!;

    public virtual ICollection<SupplyOrderDetail> SupplyOrderDetails { get; set; } = new List<SupplyOrderDetail>();

    public virtual Vendor Vendor { get; set; } = null!;
}
