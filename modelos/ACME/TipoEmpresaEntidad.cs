

namespace modelos.ACME
{
    public class tipoempresaentidad
    {

        public int idtipoempresa { get; set; }

        public string tipoempresa { get; set; } = string.Empty;

        public string descripcion { get; set; } = string.Empty;

        public string sigla { get; set; } = string.Empty;

        public bool activo { get; set; } = true;
    }
}
