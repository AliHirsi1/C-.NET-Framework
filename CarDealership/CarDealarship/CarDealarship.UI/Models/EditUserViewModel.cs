using CarDealarship.Model.Tables;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CarDealarship.UI.Models
{
    public class EditUserViewModel
    {
        public Users User { get; set; }
        public string FristName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public bool IsDisabled { get; set; }

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

        public EditUserViewModel()
        {
            RoleItems = new List<SelectListItem>();
        }

        public void SetRoleItems()
        {


            RoleItems.Add(new SelectListItem()
            {
                Value = "Admin",
                Text = "Admin"
            });

            RoleItems.Add(new SelectListItem()
            {
                Value = "Sales",
                Text = "Sales"
            });

            RoleItems.Add(new SelectListItem()
            {
                Value = "IsDisabled",
                Text = "IsDisabled"
            });


        }

    }
}