using System;
using System.ComponentModel.DataAnnotations;

namespace CTShopSolution.ViewModels.System.Users
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        [Display(Name = "UserName")]
        public string UserName { get; set; }
        [Display(Name = "FirstName")]
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Display(Name = "PhoneNumber")]
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime Dob { get; set; }
    }
}
