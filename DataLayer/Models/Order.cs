using DataLayer.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models;

public partial class Order
{
    [Required(ErrorMessage = "Order Id is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Order Id should be positive!")]
    [Display(Name = "Order Id")]
    public int OrderId { get; set; }

    //public int? CustomerId { get; set; }

    [Required(ErrorMessage = "Account Id is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Account Id should be positive!")]
    [Display(Name = "Account Id")]
    public int? AccountId { get; set; }

    [Required(ErrorMessage = "Order Date is required!")]
    [Display(Name = "Order Date")]
    [DateValidation(ErrorMessage = "Year-Month-Day")]
    public DateTime? OrderDate { get; set; }

    [Required(ErrorMessage = "Deleted is required!")]
    [Display(Name = "Deleted")]
    public bool? Deleted { get; set; }

    [Required(ErrorMessage = "Note is required!")]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "The lenght of Note is from 3 to 255 charaters")]
    [Display(Name = "Note")]
    public string? Note { get; set; }

    [Required(ErrorMessage = "Status is required")]
    [Display(Name = "Status")]
    [Range(0, 3, ErrorMessage = "0:Delivered ,1:Received, 2:Cancel, 3:Return")]
    public int? Status { get; set; }


    //public virtual Customer? Customer { get; set; }

    public virtual Account? Account { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();
}
