using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Mesaj
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Not { get; set; }

        [Required]
        public int SaticiId { get; set; }

        [Required]
        public int AliciId { get; set; }

        [Required]
        public int UrunId { get; set; }

        [DataType(DataType.DateTime), Required]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        public int IlanId { get; set; }

    }
}
