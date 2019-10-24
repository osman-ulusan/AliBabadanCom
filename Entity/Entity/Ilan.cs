using Entity.Entity;
using Entity.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Ilan
    {
        [Key]
        public int Id { get; set; }

        [StringLength(200), Required(ErrorMessage = "Bu alan doldurulmalıdır"), DisplayName("İlan Başlığı")]
        public string Title { get; set; }

        [DataType(DataType.Html)]
        [DisplayName("Açıklama"),Required(ErrorMessage = "Bu alan doldurulmalıdır")]
        public string Description { get; set; }

        [DataType(DataType.DateTime),Required(ErrorMessage = "Bu alan doldurulmalıdır"), DisplayName("İlan Tarihi")]
        public DateTime CreateDate { get; set; } = DateTime.Now;

        [DisplayName("Görüntülenme Sayısı")]
        [Required]  
        public int GörüntülenmeSayisi { get; set; } = 0;

        [DefaultValue(false)]
        public bool IsConfirmed { get; set; } = false;

        [DefaultValue(false)]
        public bool IsSold { get; set; } = false;

        [DefaultValue(false)]
        public bool IsDeleted { get; set; } = false;

        [Required]
        public int ColorId { get; set; }
        [ForeignKey("ColorId")]
        public virtual Color Color { get; set; }

        [Required]
        [DisplayName("Teklif Sayısı")]
        public int TeklifSayisi { get; set; }

        [Required]
        public bool Garanti { get; set; }

        [Required]
        public int ImagesId { get; set; }
        [ForeignKey("ImagesId")]
        public virtual Images Images { get; set; }

        [Required]
        public string UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual ApplicationUser User { get; set; }

        [Required]
        public int KategoriId { get; set; }
        [ForeignKey("KategoriId")]
        public virtual Kategori Kategori { get; set; }

        [Required]
        public int AltKategoriId { get; set; }
        [ForeignKey("AltKategoriId")]
        public virtual AltKategori AltKategori { get; set; }

        [Required]
        public int MarkaId { get; set; }
        [ForeignKey("MarkaId")]
        public virtual Marka Marka { get; set; }

        [Required]
        public int ModelId { get; set; }
        [ForeignKey("ModelId")]
        public virtual Model Model { get; set; }
    }
}
