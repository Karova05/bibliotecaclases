using System.ComponentModel.DataAnnotations;

namespace modelos.ACME
{
    public class empresaentidad
    {

        [Range(0, int.MaxValue, ErrorMessage = "debe seleccionar una empresa.")]

        [Display (Name = "codigo")]
       public int idempresa { get; set; }

        [Required (ErrorMessage = "debe seleccionar un tipo de empresa.")]

        [Range(1, int.MaxValue, ErrorMessage = "debe seleccionar un tipo de empresa.")]

        [Display(Name = "tipo empresa")]
        public int? idtipoempresa { get; set; }

        [Required(ErrorMessage = "del nombre de la empresa es obligatorio.")]

        [Display(Name = "nombre empresa")]

        public string empresa { get; set; } = string.Empty;

        [Required(ErrorMessage = "la direccion de la empresa es obligatoria.")]

        [Display(Name = "direccion")]

        public string direccion { get; set; } = string.Empty;

        [Required(ErrorMessage = "el ruc de la empresa es obligatoria.")]

        [Display(Name = "ruc")]

        public string ruc { get; set; } = string.Empty;

        [Required(ErrorMessage = "debe ingresar la fecha de creacion.")]

        [Display(Name = "fecha de creacion")]

        public DateTime fechacreacion { get; set; } = DateTime.Now;

        [Required(ErrorMessage = "debe ingresar el presupuesto.")]

        [Display(Name = "presupuesto")]

        public decimal presupuesto { get; set; }

        public bool activo { get; set; } = true;

        // propiedad de navegacion a tipoempresa

        public tipoempresaentidad? tipoempresaentidad { get; set; }

    }
}
