using DvdModels.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DvdModels.Models
{
    public class Dvd
    {
        public int DvdId { get; set; }

        [Required]
        [Title(ErrorMessage = "Title cannot exceed 100 characters")]
        public string Title { get; set; }

        [Required]
        [Director(ErrorMessage = "Director cannot exceed 50 characters")]
        public string Director { get; set; }

        [Required]
        [ReleaseYear(ErrorMessage = "Release must be between 1800 - 9999")]
        public int ReleaseYear { get; set; }

        [Required]
        [Rating(ErrorMessage = "Rating cannot exceed 10 characters")]
        public string Rating { get; set; }

        [Notes(ErrorMessage = "Notes cannot exceed 180 characters")]
        public string Notes { get; set; }
    }
}
