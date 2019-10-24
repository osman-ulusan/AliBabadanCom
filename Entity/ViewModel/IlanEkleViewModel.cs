using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace Entity.ViewModel
{
    public class IlanEkleViewModel
    {
        [Required(ErrorMessage = "İlan Başlığını Girmeniz Gerekmektedir")]
        [Display(Name = "İlan Başlığı")]
        [StringLength(30)]
        public string Title { get; set; }

        [Required(ErrorMessage = "İlan Açıklamasını Girmeniz Gerekmektedir")]
        [Display(Name = "İlan Açıklaması")]
        public string Description { get; set; }

        public bool Garanti { get; set; }

        [Required(ErrorMessage = "Renk Girmeniz Gerekmektedir")]
        [Display(Name = "Renk")]
        public int ColorId { get; set; }

        [Required]
        public int KategoriId { get; set; }

        [Required]
        public int AltKategoriId { get; set; }

        [Required]
        public int MarkaId { get; set; }

        [Required]
        public int ModelId { get; set; }

        [Required]
        public string Image1 { get; set; }

        public string Image2 { get; set; }

        public string Image3 { get; set; }


        public List<HttpPostedFileBase> PictureUpload { get; set; }

    }
}
