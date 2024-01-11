using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuricLuka.Model
{
    public  class VideoGame
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter video game name")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Enter the rating")]
        [Range(1.0,10.0,ErrorMessage = "Enter the rating (from 1 to 10)")]
        public double Rating { get; set; }
        [Required(ErrorMessage = "Enter website")]
        public string Website { get; set; }
        [Required(ErrorMessage = "Enter the genre of video game")]
        public string Genre { get; set; }

        public DateTime? ReleaseDate { get; set; }

        [ForeignKey(nameof(Publisher))]
        public int? PublisherID { get; set; }
        public Publisher? Publisher { get; set; }

        [ForeignKey(nameof(Developer))]
        public int? DeveloperID { get; set; }
        public Developer? Developer { get; set; }

    }
}
