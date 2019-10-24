using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Marka : BaseKategori
    {
        public int? AltKategoriId { get; set; }
        [ForeignKey("AltKategoriId")]
        public virtual AltKategori AltKategori { get; set; }

        public virtual List<Model> Model { get; set; }

        public virtual List<Ilan> Ilans { get; set; }
    }
}
