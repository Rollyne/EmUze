using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class SpotifyAccount
    {
        [Key, ForeignKey("User")]
        public string UserId { get; set; }

        public string AccountId { get; set; }

        public string Username { get; set; }

        public string ModelError { get; set; }

        public ApplicationUser User { get; set; }
    }
}