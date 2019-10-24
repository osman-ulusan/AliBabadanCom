using Entity.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public int Puan { get; set; }
        public bool IsActive { get; set; } = true;
        public virtual List<KullaniciAdresi> KullaniciAdresi { get;set; }
        public virtual List<Ilan> Ilan { get; set; }
    }
}
