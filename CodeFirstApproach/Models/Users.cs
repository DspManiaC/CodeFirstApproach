using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace CodeFirstApproach.Models
{
    public class Users
    {
        [Key]
        public int UserId { get; set; }
        [Required]
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [Display(Name = "First Name")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        public string LastName { get; set; }
        //[Required(ErrorMessage ="Email is requierd")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
      [MaxLength(10)]
        public string Mobile { get; set; }
    }
}