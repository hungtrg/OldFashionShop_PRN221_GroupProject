using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Product
{
    public int ProductId { get; set; }

    public string ProductName { get; set; } = null!;

    public string? Description { get; set; }

    public int? CatId { get; set; }

    public int? Price { get; set; }

    public int? Discount { get; set; }

    public string? Thumb { get; set; }

    public bool Active { get; set; }

    public string? Title { get; set; }

    public int? UnitsInStock { get; set; }

    public virtual ICollection<AttributesPrice> AttributesPrices { get; } = new List<AttributesPrice>();

    public virtual Category? Cat { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
