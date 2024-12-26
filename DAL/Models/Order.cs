﻿using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public string Status { get; set; } = null!;

    public DateOnly DeliveryDate { get; set; }

    public int? UserId { get; set; }

    public int PickupPointId { get; set; }

    public DateOnly OrderDate { get; set; }

    public string Code { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();

    public virtual PickupPoint PickupPoint { get; set; } = null!;

    public virtual User? User { get; set; }
}
