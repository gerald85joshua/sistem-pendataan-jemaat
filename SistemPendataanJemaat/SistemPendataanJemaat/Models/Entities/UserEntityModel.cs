using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace SistemPendataanJemaat.Models.Entities
{
    [Table("tbl_user")]
    public class UserEntityModel
    {
        public Guid User_ID { get; set; }

        [Display(Name = "Username")]
        [Required(ErrorMessage = "Username is required")]
        [StringLength(100, ErrorMessage = "Username can't be longer than 50 characters")]
        public string User_Name { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "Email is required")]
        [StringLength(100, ErrorMessage = "Email can't be longer than 50 characters")]
        public string User_Email { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "Password is required")]
        public string User_Password { get; set; }

        [NotMapped] // Does not effect with database
        [Display(Name = "Confirm Password")]
        [Compare("User_Password", ErrorMessage = "Password doesn't match")]
        public string Confirm_Password { get; set; }

        [Display(Name = "Role")]
        public string User_Role { get; set; }

        public string Is_Login { get; set; }

        public DateTime Last_Login { get; set; }

    }
}
