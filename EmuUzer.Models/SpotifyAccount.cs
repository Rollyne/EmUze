﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Data.Models
{
    public class SpotifyAccount
    {
        public string Id { get; set; }

        [Key, Column(Order = 0)]
        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public string Username { get; set; }

        [NotMapped]
        public string AccessToken { get; set; }

        public string ModelError { get; set; }
    }
}