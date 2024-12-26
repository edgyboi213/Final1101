using System;
using System.Collections.Generic;

namespace DAL.Models;

public partial class Product
{
    public string ProductArticleNumber { get; set; } = null!;

    public string Name { get; set; } = null!;

    public string Description { get; set; } = null!;

    public string Category { get; set; } = null!;

    public byte[]? Photo { get; set; }

    public string Manufacturer { get; set; } = null!;

    public decimal Cost { get; set; }

    public byte? DiscountAmount { get; set; }

    public int QuantityInStock { get; set; }

    public string Status { get; set; } = null!;

    public virtual ICollection<OrderProduct> OrderProducts { get; set; } = new List<OrderProduct>();
}
