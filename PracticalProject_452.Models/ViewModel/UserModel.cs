using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PracticalProject_452.Models.ViewModel
{
    public class UserModel
    {
        public int UserId { get; set; }
        public string UserName { get; set; }
        [Required(ErrorMessage ="Please enter EmailId !")]
        public string Email { get; set; }
        [Required(ErrorMessage ="Please enter password !")]
        public string Password { get; set; }
        public string Token { get; set; }
    }
}
