using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models;

public partial class OrderDetail
{
    [Required(ErrorMessage = "Order Detail Id is required!")]
    [Range(1,int.MaxValue,ErrorMessage = "Order Detail Id should be positive!")]
    [Display(Name = "Order Detail Id")]
    public int OrderDetailId { get; set; }

    [Required(ErrorMessage = "Order Id is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Order Id should be positive!")]
    [Display(Name = "Order Id")]
    public int? OrderId { get; set; }

    [Required(ErrorMessage = "Product Id is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Product Id should be positive!")]
    [Display(Name = "Product Id")]
    public int? ProductId { get; set; }
    public string? ProductName { get; set; }

    [Required(ErrorMessage = "Order Number is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Order Number should be positive!")]
    [Display(Name = "Order Number")]
    public int? OrderNumber { get; set; }

    [Required(ErrorMessage = "Quantity is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Quantity should be positive!")]
    [Display(Name = "Quantity")]
    public int? Quantity { get; set; }

    [Required(ErrorMessage = "Discount is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Discount should be positive!")]
    [Display(Name = "Discount")]
    public int? Discount { get; set; }

    [Required(ErrorMessage = "Total is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Total should be positive!")]
    [Display(Name = "Total")]
    public int? Total { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
