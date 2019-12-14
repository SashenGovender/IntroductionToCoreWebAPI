using System.ComponentModel.DataAnnotations;

// Package Manager Console to update DB
//  add-migration "Intial Migration"
//  update-database

namespace BlackjackData.Models
{
    public class PlayerSessionData
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string SessionId { get; set; }

        [Required]
        public int PlayerId  { get; set; }

        [Required]
        [Range(0,30)]
        public int Score { get; set; }

        [Required]
        public string PlayerCards { get; set; }


    }
}
 