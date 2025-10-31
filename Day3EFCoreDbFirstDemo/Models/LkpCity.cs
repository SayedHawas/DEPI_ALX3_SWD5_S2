using System;
using System.Collections.Generic;

namespace Day3EFCoreDbFirstDemo.Models;

public partial class LkpCity
{
    public int CityId { get; set; }

    public string CityName { get; set; } = null!;

    public bool IsDelete { get; set; }
}
