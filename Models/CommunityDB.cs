using SocialNetwork.Areas.Identity.Data;

namespace SocialNetwork.Models
{
    public class CommunityDB
    {
        public int Id { get; set; }
        public SocialNetworkUser? Owner { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string? AvatarPath { get; set; }
    }
}
