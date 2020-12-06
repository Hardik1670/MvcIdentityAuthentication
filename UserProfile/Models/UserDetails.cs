using Newtonsoft.Json;
using System.Text.Json.Serialization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

using System.Threading.Tasks;

namespace UserProfile.Models
{
    public class UserDetails
    {
        public int Id { get; set; }
        [Display(Name = "Real Name")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string userName { get; set; }

        [Display(Name = "Alias")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string alias { get; set; }

        [Display(Name = "Website")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string website { get; set; }


        [Display(Name = "Social Url")]
        [StringLength(60, MinimumLength = 3)]
        [Required]
        public string socialUrl { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "The email address is required")]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        public string email { get; set; }

        [Display(Name = "Date Of Birth")]
        [DataType(DataType.Date)]
        public DateTime dob { get; set; }



       
       [Newtonsoft.Json.JsonIgnore]
        
        public ICollection<SocialDetails>userToSocialFK { get; set; }
       

    }
}
