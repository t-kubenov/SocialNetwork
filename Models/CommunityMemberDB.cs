using Microsoft.EntityFrameworkCore;
using SocialNetwork.Areas.Identity.Data;

namespace SocialNetwork.Models
{
    public class CommunityMemberDB
    {
        public int Id { get; set; }
        public CommunityDB? Community { get; set; }
        public SocialNetworkUser? User { get; set; }
    }
}
