using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProjectBuricLuka.Model
{
    public class City
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        public virtual ICollection<Client> Clients { get; set; }
    }
}
