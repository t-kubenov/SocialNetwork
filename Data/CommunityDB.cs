namespace SocialNetwork.Areas.Identity.Data
{
    public class CommunityDB
    {
        public int Id { get; set; }
        public UserDB Owner { get; set; }
        public DateTime DateCreated { get; set; }
        public string Name { get; set; }
        public string AvatarPath { get; set; }
    }
}
