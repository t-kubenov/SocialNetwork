using Microsoft.EntityFrameworkCore;
namespace SocialNetwork.Data
{
    public class CommunityMemberDB
    {
        public int Id { get; set; }
        public virtual CommunityDB Community { get; set; }
        public virtual UserDB User { get; set; }
    }
}
