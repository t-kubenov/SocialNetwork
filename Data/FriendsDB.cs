using Microsoft.EntityFrameworkCore;
using SocialNetwork.Areas.Identity.Data;
namespace SocialNetwork.Data
{
    public class FriendsDB
    {
        public int Id { get; set; } 
        public SocialNetworkUser? Requester { get; set; }
        public SocialNetworkUser? Addressee { get; set; } 
        public DateTime DateInitiated { get; set; } = DateTime.Now;
        public int StatusCode { get; set; } // 0 - sent, 1 - accepted, 2 - blocked
    }
}
