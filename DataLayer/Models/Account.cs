using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.Models;

public partial class Account
{

    public int AccountId { get; set; }

    [Required(ErrorMessage = "Phone Number is required!")]
    [Display(Name = "Phone Number")]
    //[Phone(ErrorMessage = "It's not the validate Phone Number")]
    //[DataType(DataType.PhoneNumber)]
    //[StringLength(10,ErrorMessage = "It's not the validate Phone Number")]
    public string? Phone { get; set; }

    [Required(ErrorMessage = " Email Address is required!")]
    [EmailAddress]
    [Display(Name = "Email Address")]
    public string? Email { get; set; }

    //[StringLength(20, MinimumLength = 6, ErrorMessage = "The lenght of Password is from 6 to 20 charaters")]
    //[Display(Name = "Password")]
    public string? Password { get; set; }

    public bool Active { get; set; }

    [Required(ErrorMessage = "FullName is required!")]
    [StringLength(50, MinimumLength = 3, ErrorMessage = "The lenght of FullName is from 3 to 50 charaters")]
    [Display(Name = "FullName")]
    public string? FullName { get; set; }

    public int? RoleId { get; set; }

    public virtual ICollection<Order> Orders { get; } = new List<Order>();
}
