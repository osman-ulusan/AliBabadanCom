using Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class KullaniciAdresi
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SehirId { get; set; }

        [Required]
        public int IlceId { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public string Adres { get; set; }

        [Required]
        [StringLength(50)]
        public string Title { get; set; }

        public bool ısActive { get; set; } = true;
    }
}
