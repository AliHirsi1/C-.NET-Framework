using CarDealarship.Model.Tables;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealarship.UI.Models
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public Users User { get; set; }
        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required]
        [StringLength(50)]
        public string Email { get; set; }

        [Required]      
        [StringLength(10, ErrorMessage = "Password must be between 6 - 10 characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Required]
        [StringLength(10, ErrorMessage = "Password must be between 6 - 10 characters long", MinimumLength = 6)]
        [DataType(DataType.Password)]
        public string ConfirmPassword { get; set; }
        [Required]
        public string Role { get; set; }
        public List<SelectListItem> RoleItems { get; set; }

        public UserViewModel()
        {
            RoleItems = new List<SelectListItem>();
        }

        public void SetRoleItems()
        {
            RoleItems.Add(new SelectListItem
            {
                Value = "Admin",
                Text = "Admin",
            });
            RoleItems.Add(new SelectListItem
            {
                Value = "Sales",
                Text = "Sales"
            });
        }
    }
}