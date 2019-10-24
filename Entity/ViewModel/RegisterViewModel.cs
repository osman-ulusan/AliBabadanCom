using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.ViewModel
{
    public class RegisterViewModel
    {
        [Required(ErrorMessage = "Kullanıcı adınızı giriniz.")]
        [StringLength(50)]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Email adresinizi giriniz")]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required(ErrorMessage = "Parolanızı giriniz")]
        [StringLength(50)]
        public string Password { get; set; }
    }
}
