using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Prueba.Models
{
    public class EmpleadoModel
    {
        public int IdEmpleado { get; set; }

        [Required]
        [Display(Name = "Nombre: ")]
        public string NombreEmpleado { get; set; }

        [Required]
        [Display(Name = "Apellido Paterno: ")]
        public string ApellidoPaternoEmpleado { get; set; }

        [Required]
        [Display(Name = "Apellido Materno: ")]
        public string ApellidoMaternoEmpleado { get; set; }

        [Required]
        [Display(Name = "Número Empleado: ")]
        public string NoEmpleado { get; set; }
    }
}