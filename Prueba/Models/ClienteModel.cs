using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueba.Models
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