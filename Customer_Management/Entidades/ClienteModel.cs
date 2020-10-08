using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Entidades
{
        public class ClienteModel
        {
            // [Display(Name = "Código")]
            public int Id { get; set; }
            [Display(Name = "Tipo de Documento"),
             Required(ErrorMessage = "El tipo de documento es requerido"),
             StringLength(10, ErrorMessage = "Máximo Permitido 10")]
            public string Tipo_documento { get; set; }

            [Display(Name = "Nro. documento"),
             Required(ErrorMessage = "El nro de documento es requerido"),
             StringLength(20, ErrorMessage = "Máximo Permitido 20")]
            public string Nro_documento { get; set; }

            [Display(Name = "Nombre completo o Razón social"),
             Required(ErrorMessage = "El nombre es requerido"),
             StringLength(255, ErrorMessage = "Máximo Permitido 255")]
            public string Nombre { get; set; }

            [Display(Name = "Direccion del Cliente"),
             Required(ErrorMessage = "La Direccion es requerida"),
             StringLength(255, ErrorMessage = "Máximo Permitido 255")]
            public string Direccion { get; set; }

            [Display(Name = "Número de Teléfono"),
             Required(ErrorMessage = "El telefono es requerido"),
             StringLength(100, ErrorMessage = "Máximo Permitido 100")]
            public string Telefono { get; set; }

            [Display(Name = "Correo Electronico"),
             Required(ErrorMessage = "El correo es requerido"),
             StringLength(255, ErrorMessage = "Máximo Permitido 255")]
            public string Correo { get; set; }

            public string Estados { get; set; }
    }
}
