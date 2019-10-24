using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Entity
{
    public class Images
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string Image1 { get; set; }

        [Required]
        [StringLength(30)]
        public string Image2 { get; set; }

        [Required]
        [StringLength(30)]
        public string Image3 { get; set; }



        //[Required]
        //public int IlanId { get; set; }
        //[ForeignKey("IlanId")]
        //public virtual Ilan Ilan { get; set; }

    }
}
