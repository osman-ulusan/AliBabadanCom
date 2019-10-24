using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Kategori : BaseKategori
    {
        public virtual List<AltKategori> AltKategori { get; set; }

        public virtual List<Ilan> Ilan { get; set; }
    }
}
