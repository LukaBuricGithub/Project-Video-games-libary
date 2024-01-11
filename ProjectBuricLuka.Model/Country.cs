using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBuricLuka.Model
{
    public class Country
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Publisher>? Publishers { get; set; }
        public virtual ICollection<City>? Cities { get; set; }
    }
}
