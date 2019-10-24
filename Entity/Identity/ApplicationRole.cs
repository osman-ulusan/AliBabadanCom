using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Identity
{
    public class ApplicationRole:IdentityRole
    {
        public bool IsActive { get; set; } = true;
    }
}
