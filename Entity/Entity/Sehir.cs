using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Sehir
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

       
        public virtual List<Ilce> Ilce { get; set; }
    }
}
