using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuricLuka.Model
{
    public class Publisher
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }
        [ForeignKey(nameof(Country))]
        public int? CountryID { get; set; }
        public Country? Country { get; set; }
        public virtual ICollection<VideoGame>? VideoGames { get; set; }


    }
}
