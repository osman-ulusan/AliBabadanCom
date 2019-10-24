using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Model : BaseKategori
    {
        public int? MarkaId { get; set; }
        [ForeignKey("MarkaId")]
        public virtual Marka Marka { get; set; }

        public virtual List<Ilan> Ilan { get; set; }

    }
}
