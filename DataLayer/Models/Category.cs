using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models;

public partial class Category
{
    //[Required(ErrorMessage = "Category Id is required!")]
    //[Range(1, int.MaxValue, ErrorMessage = "Category Id should be positive!")]
    //[Display(Name = "Category Id")]
    public int CatId { get; set; }

    [Required(ErrorMessage = "Category Name is required!")]
    [StringLength(250, MinimumLength = 3, ErrorMessage = "The lenght of Category Name is from 3 to 250 charaters")]
    [Display(Name = "Category Name")]
    public string? CatName { get; set; }

    //[Required(ErrorMessage = "Description is required!")]
    [StringLength(250, MinimumLength = 3, ErrorMessage = "The lenght of Description is from 3 to 250 charaters")]
    [Display(Name = "Description")]
    public string? Description { get; set; }

    [Required(ErrorMessage = "Seasons is required!")]
    [Display(Name = "Seasons")]
    [Range(1, 4, ErrorMessage = "1:Spring, 2:Summner, 3:Fall, 4:Winter")]
    public int? ParentId { get; set; }

    //[Required(ErrorMessage = "Levels of Fabric is required1")]
    [Display(Name = "Levels of Fabric")]
    [Range(1, 3, ErrorMessage = "1:Thick, 2:Medium, 3:Thin")]
    public int? Levels { get; set; }

    //[Required(ErrorMessage = "Stock Ordering is required!")]
    [Display(Name = "Stock Ordering")]
    [Range(1, 100, ErrorMessage = "Stock Ordering should below 100!")]
    public int? Ordering { get; set; }

    //[Required(ErrorMessage = "Published is required!")]
    //[Display(Name = "Published")]
    public bool Published { get; set; }

    [Required(ErrorMessage = "Title is required!")]
    [StringLength(250, MinimumLength = 3, ErrorMessage = "The lenght of Title is from 3 to 250 charaters")]
    [Display(Name = "Title")]
    public string? Title { get; set; }

    public virtual ICollection<Product> Products { get; } = new List<Product>();
}
