using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations.Schema;

//namespace SocialNetwork.Data

namespace SocialNetwork.Areas.Identity.Data
{
    public class UserDB: IdentityUser
    {
        //public int Id { get; set; }
        //public string Email { get; set; }
        //public string Password { get; set; } // i think this is definitely not how it should be done
        public DateTime DateCreated { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string FirstName { get; set; }

        [PersonalData]
        [Column(TypeName = "nvarchar(100)")]
        public string LastName { get; set; }

        [PersonalData]
        public DateTime DOB { get; set; }

        public string AvatarPath { get; set; }
    }
}
