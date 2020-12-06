using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserProfile.Models
{
    public class AuthorModel
    {
        public int Id { get; set; }
        public String GivenName { get; set; }
        public string SurName { get; set; }

        public string Email { get; set; }

        public ICollection<BlogModel> Blogs { get; set; }
    }
}
