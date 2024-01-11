using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectBuricLuka.Model
{
    public class DeveloperDTO
    {
        
        public int ID { get; set; }
    
        public string Name { get; set; }

        public string Website {get;set;}

        public int YearFounded { get; set; }

        public CityProjectDTO? CityProjectDTO { get; set; }


    }
}
