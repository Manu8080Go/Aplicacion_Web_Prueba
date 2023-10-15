using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Prueba.Negocio.Model
{
    public class ClienteModel
    {
        public int IdCliente { get; set; }

        [Required]
        [Display(Name = "Nombre: ")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno: ")]
        public string ApellidoPaterno { get; set; }

        [Required]
        [Display(Name = "Apellido Materno: ")]
        public string ApellidoMaterno { get; set; }

        [Required]
        [Display(Name = "Telefono: ")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Email: ")]
        public string Email { get; set; }
    }
}
