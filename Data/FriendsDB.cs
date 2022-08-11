using Microsoft.EntityFrameworkCore;
namespace SocialNetwork.Data
{
    public class FriendsDB
    {
        public int Id { get; set; } 
        public virtual UserDB Requester { get; set; }
        public virtual UserDB Addressee { get; set; } 
        public DateTime DateInitiated { get; set; }
        public int StatusCode { get; set; } // 0 - sent, 1 - accepted, 2 - blocked
    }
}
