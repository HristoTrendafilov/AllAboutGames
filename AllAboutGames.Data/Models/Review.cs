﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Review
    {
        [Key]
        public long ReviewID { get; set; }

        [Required(ErrorMessage = "Review text is required.")]
        public string Text { get; set; }

        public DateTime CreatedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Game))]
        public long GameID { get; set; }
        public virtual Game Game { get; set; }

        [Required]
        [ForeignKey(nameof(ReviewedBy))]
        public long UserID { get; set; }
        public virtual ApplicationUser ReviewedBy { get; set; }

        [Required]
        [ForeignKey(nameof(Rating))]
        public long RatingID { get; set; }
        public virtual Rating Rating { get; set; }
    }
}
