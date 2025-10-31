using System;
using System.Collections.Generic;

namespace Day3EFCoreDbFirstDemo.Models;

public partial class SupplyOrderDetail
{
    public int SupplyOrderDetailsId { get; set; }

    public int SupplyOrderId { get; set; }

    public int ProductId { get; set; }

    public int Quantity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Product Product { get; set; } = null!;

    public virtual SupplyOrder SupplyOrder { get; set; } = null!;
}
