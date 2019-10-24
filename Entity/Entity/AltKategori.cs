using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class AltKategori : BaseKategori
    {
        public int? KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }

        public virtual List<Marka> Marka { get; set; }

        public virtual List<Ilan> Ilans { get; set; }
    }
}
