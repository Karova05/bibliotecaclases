

using modelos.ACME;
using dataaccess.ACME;

namespace services.ACME
{
    public class EmpresaServices
    {

        public bool Crear(empresaentidad empresaentidad)

        {

            empresaDA empresaDA = new empresaDA();

            try

            {

                empresaDA.insertar(empresaentidad);

                return true;
            
            }

            catch 
            {

                return false;
            }
        
        }

        public bool actualizar (empresaentidad empresaentidad)

        {

            empresaDA empresaDA = new empresaDA();

            try

            {

                empresaDA.modificar(empresaentidad);

                return true;

            }

            catch
            {

                return false;
            }

        }

        public empresaentidad? buscarxID(int idempresa)

        {

            empresaDA? empresaDA = new empresaDA();

            try

            {

                return empresaDA.buscarid(idempresa);
            
            
            }

            catch 
            
            { 
            
                return null;
            
            }
        
        
        }

        public List<empresaentidad>? Listar()

        {

            empresaDA? empresaDA = new empresaDA();

            try

            {

                return empresaDA.Listar();


            }

            catch

            {

                return null;

            }


        }


        public bool eliminar(empresaentidad empresaentidad)

        {

            empresaDA empresaDA = new empresaDA();

            try

            {

                empresaDA.anular(empresaentidad);

                return true;

            }

            catch
            {

                return false;
            }

        }

    }
}
