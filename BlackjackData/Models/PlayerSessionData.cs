using BlackjackLib;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

// Package Manager Console to update DB
//  add-migration "Intial Migration"
//  pdate-migrations

namespace BlackjackData
{
    public class PlayerSessionData
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public int SessionId { get; set; }

        [Required]
        public int PlayerId  { get; set; }

        [Required]
        [Range(0,30)]
        public int Score { get; set; }

        [Required]
        public string PlayerCards { get; set; }


    }
}
 