using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace UserProfile.Models
{
    public class SocialDetails
    {
        
        public int Id { get; set; }

        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email")]
        public string email { get; set; }

        [Display(Name = "Profile Image")]
        public string profileImgUrl { get; set; }

        [Display(Name = "Friend's Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string friendsEmail { get; set; }

        




    }
}
