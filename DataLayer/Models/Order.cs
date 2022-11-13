using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Order
{
    public int OrderId { get; set; }

    //public int? CustomerId { get; set; }

    public int? AccountId { get; set; }

    public DateTime? OrderDate { get; set; }

    public bool? Deleted { get; set; }

    public string? Note { get; set; }

    public int? Status { get; set; }

    //public virtual Customer? Customer { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
