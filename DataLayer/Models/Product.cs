using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models;

public partial class Product
{
    [Required(ErrorMessage = "Product Id is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Product Id should be positive!")]
    [Display(Name = "Product Id")]
    public int ProductId { get; set; }

    [Required(ErrorMessage = "Product Name is required!")]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "The lenght of Product Name is from 3 to 255 charaters")]
    [Display(Name = "Product Name")]
    public string ProductName { get; set; } = null!;

    [Required(ErrorMessage = "Description is required!")]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "The lenght of Description is from 3 to 255 charaters")]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Category Id is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Category Id should be positive!")]
    [Display(Name = "Category Id")]
    public int? CatId { get; set; }

    [Required(ErrorMessage = "Price is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Price should be positive!")]
    [Display(Name = "Price")]
    public int? Price { get; set; }

    [Required(ErrorMessage = "Discount is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Discount should be positive!")]
    [Display(Name = "Discount")]
    public int? Discount { get; set; }

    [Required(ErrorMessage = "Image Link is required!")]
    [Display(Name = "Image Link")]
    [Url]
    public string? Thumb { get; set; }

    [Required(ErrorMessage = "Actived is required!")]
    [Display(Name = "Active")]
    public bool Active { get; set; }

    [Required(ErrorMessage = "Title is required!")]
    [StringLength(255, MinimumLength = 3, ErrorMessage = "The lenght of Title is from 3 to 255 charaters")]
    [Display(Name = "Title")]
    public string? Title { get; set; }

    [Required(ErrorMessage = "Units In Stock is required!")]
    [Range(1, int.MaxValue, ErrorMessage = "Units In Stock should be positive!")]
    [Display(Name = "Units In Stock")]
    public int? UnitsInStock { get; set; }

    public virtual Category? Cat { get; set; }

    public virtual ICollection<OrderDetail> OrderDetails { get; } = new List<OrderDetail>();
}
