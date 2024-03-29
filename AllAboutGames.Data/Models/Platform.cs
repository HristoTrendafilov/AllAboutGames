﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
#nullable disable

namespace AllAboutGames.Data.Models
{
    public class Platform
    {
        [Key]
        public long PlatformID { get; set; }

        [Required(ErrorMessage = "Platform name is required.")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Image is required.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Info is required.")]
        public string Info { get; set; }

        public DateTime? ReleaseDate { get; set; }

        public bool IsDeleted { get; set; }

        public DateTime? DeletedOn { get; set; }

        [Required]
        [ForeignKey(nameof(Developer))]
        public long DeveloperID { get; set; }

        public Developer Developer { get; set; }

        public virtual List<GamePlatform> GamesPlatforms { get; set; } = new List<GamePlatform>();
    }
}
