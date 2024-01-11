using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuricLuka.Model
{
    public class Developer
    {
        [Key]
        public int ID { get; set; }
        [Required(ErrorMessage = "Enter the name of developer studio")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Enter the website")]
        public string Website {get;set;}

        [Required(ErrorMessage = "Enter the year of foundation")]
        public int YearFounded { get; set; }


        [ForeignKey(nameof(CityProject))]
        public int? CityProjectID { get; set; }
        public CityProject? CityProject { get; set; }


        public virtual ICollection<VideoGame>? VideoGames { get; set; }


    }
}
