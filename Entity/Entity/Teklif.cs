using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Teklif
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SaticiId { get; set; }

        [Required]
        public int AliciId { get; set; }

        [Required]
        public int UrunId { get; set; }

        [DataType(DataType.DateTime), Required, DisplayName("İlan Tarihi")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [Required]
        public decimal TeklifTutari { get; set; }

        [Required]
        public string Not { get; set; }
    }
}
