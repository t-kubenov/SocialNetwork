namespace SocialNetwork.Data
{
    public class UserDB
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; } // i think this is definitely how it shouldn't be done
        public DateTime DateCreated { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AvatarPath { get; set; }
    }
}
