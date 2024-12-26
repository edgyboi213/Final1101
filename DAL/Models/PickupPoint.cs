using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class PickupPoint
{
    public int PickupPointId { get; set; }

    public string Address { get; set; } = null!;

    public int ZipCode { get; set; }

    public virtual ICollection<Order> Orders { get; set; } = new List<Order>();
}
