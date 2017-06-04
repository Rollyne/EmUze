using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Data.Models;

namespace EmuUzer.Models
{
    public class SpotifyAccount
    {
        [Key, Column(Order = 0)]
        public string Id { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string SpotifyId { get; set; }

        public string Username { get; set; }

        public string ModelError { get; set; }
    }
}