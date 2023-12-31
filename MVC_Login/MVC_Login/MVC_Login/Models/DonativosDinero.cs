//------------------------------------------------------------------------------
// <auto-generated>
//     Este código se generó a partir de una plantilla.
//
//     Los cambios manuales en este archivo pueden causar un comportamiento inesperado de la aplicación.
//     Los cambios manuales en este archivo se sobrescribirán si se regenera el código.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MVC_Login.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    public partial class DonativosDinero
    {
        public int ID { get; set; }
        [Required(ErrorMessage = "El campo 'Donativos' es obligatorio.")]
        [Range(1, 1000,
        ErrorMessage = "Value for {0}$ para la donacion solamente puede estar entre {1}$ and {2}$.")]
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]

        public decimal Donativo { get; set; }
        [Required(ErrorMessage = "El campo 'Correo' es obligatorio.")]
        [EmailAddress(ErrorMessage = "Por favor, ingresa una dirección de correo electrónico válida.")]
        public string correocomo_fk { get; set; }
        public System.DateTime fecha_donativo { get; set; }
    
        public virtual Usuario Usuario { get; set; }
    }
}
