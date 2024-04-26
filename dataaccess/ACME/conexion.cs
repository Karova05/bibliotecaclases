using Microsoft.Data.SqlClient;

namespace dataaccess.ACME
{
    public class conexion
    {

        private readonly string? _cadenaconexion;

        public conexion()

        { 
        
            string? _cadenaconexion;

            _cadenaconexion = Environment.GetEnvironmentVariable("SQLServerXE");

            _cadenaconexion = _cadenaconexion;
        
        }

        public SqlConnection conectar () 
        
        {

            SqlConnection sqlConn;

            sqlConn = new SqlConnection(_cadenaconexion);

            return sqlConn;

        
        }


    }
}
