using System;
using System.Collections.Generic;

namespace DataLayer.Models;

public partial class Order
{
    public int OrderId { get; set; }

    public int? CustomerId { get; set; }

    public DateTime? OrderDate { get; set; }

    public int? TransacStatusId { get; set; }

    public bool? Deleted { get; set; }

    public string? Note { get; set; }

    public virtual Customer? Customer { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();

    public virtual TransactStatus? TransacStatus { get; set; }
}
