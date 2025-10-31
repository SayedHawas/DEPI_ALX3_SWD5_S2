using System;
using System.Collections.Generic;

namespace Day3EFCoreDbFirstDemo.Models;

public partial class OrderDetail
{
    public int OrderDetails { get; set; }

    public int OrderId { get; set; }

    public int ProductId { get; set; }

    public int Quatity { get; set; }

    public decimal UnitPrice { get; set; }

    public virtual Order Order { get; set; } = null!;

    public virtual Product Product { get; set; } = null!;
}
