using Microsoft.EntityFrameworkCore;
namespace SocialNetwork.Areas.Identity.Data
{
    [Keyless]
    public class CommunityMemberDB
    {
        public int Id { get; set; }
        public virtual CommunityDB Community { get; set; }
        public virtual UserDB  User { get; set; }
    }
}
