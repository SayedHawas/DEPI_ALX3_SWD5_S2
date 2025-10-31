using System;
using System.Collections.Generic;

namespace Day3EFCoreDbFirstDemo.Models;

public partial class Vendor
{
    public int VendorId { get; set; }

    public string VendorName { get; set; } = null!;

    public string Mobile { get; set; } = null!;

    public string Email { get; set; } = null!;

    public decimal TotalBalance { get; set; }

    public decimal Creadit { get; set; }

    public bool? IsDelete { get; set; }

    public virtual ICollection<SupplyOrder> SupplyOrders { get; set; } = new List<SupplyOrder>();
}
