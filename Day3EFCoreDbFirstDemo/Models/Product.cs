using System;
using System.Collections.Generic;

namespace Day3EFCoreDbFirstDemo.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public decimal Price { get; set; }

    public string? Photo { get; set; }

    public string? Description { get; set; }

    public bool IsDelete { get; set; }

    public int CategoryId { get; set; }

    public virtual Category Category { get; set; } = null!;

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

    public virtual ICollection<SupplyOrderDetail> SupplyOrderDetails { get; set; } = new List<SupplyOrderDetail>();
}
