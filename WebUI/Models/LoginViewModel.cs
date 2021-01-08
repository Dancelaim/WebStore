using System;
using System.ComponentModel.DataAnnotations;

namespace WebUI.Models
{
    public class LoginViewModel
    {
        public Guid UserId { get; set; }
        [Required]
        public string UserName { get; set; }

        [Required]
        public string Password { get; set; }
    }
}