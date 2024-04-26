using System.Data;
using Microsoft.Data.SqlClient;
using modelos.ACME;

namespace dataaccess.ACME
{
    public class empresaDA
    {

        private conexion _conexion = new conexion();

        public void insertar(empresaentidad empresaentidad)
        {

            SqlConnection sqlConn = _conexion.conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try

            {

                sqlConn.Open();
                sqlcomm.Connection = sqlConn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "insertarempresa";
                sqlcomm.Parameters.Add(new SqlParameter("@idempresa", SqlDbType.Int)).Direction = ParameterDirection.Output;
                sqlcomm.Parameters.Add(new SqlParameter("@idtipoempresa", empresaentidad.idtipoempresa));
                sqlcomm.Parameters.Add(new SqlParameter("@direccion", empresaentidad.direccion));
                sqlcomm.Parameters.Add(new SqlParameter("@ruc", empresaentidad.ruc));
                sqlcomm.Parameters.Add(new SqlParameter("@fechacreacion", empresaentidad.fechacreacion));
                sqlcomm.Parameters.Add(new SqlParameter("@presupuesto", empresaentidad.presupuesto));
                sqlcomm.Parameters.Add(new SqlParameter("@activo", empresaentidad.activo));

                sqlcomm.ExecuteNonQuery();
                empresaentidad.idempresa = (int)sqlcomm.Parameters[sqlcomm.Parameters.IndexOf("@idempresa")].Value;

                sqlConn.Close();

            }

            catch (Exception ex)
            {

                throw new Exception("empresaDA.insertar: " + ex.Message);


            }

            finally

            {

                sqlConn.Dispose();



            }


        }


        public void modificar(empresaentidad empresaentidad)

        {

            SqlConnection sqlConn = _conexion.conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try

            {

                sqlConn.Open();
                sqlcomm.Connection = sqlConn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "modificarempresa";
                sqlcomm.Parameters.Add(new SqlParameter("@idempresa", empresaentidad.idempresa));
                sqlcomm.Parameters.Add(new SqlParameter("@idtipoempresa", empresaentidad.idtipoempresa));
                sqlcomm.Parameters.Add(new SqlParameter("@direccion", empresaentidad.direccion));
                sqlcomm.Parameters.Add(new SqlParameter("@ruc", empresaentidad.ruc));
                sqlcomm.Parameters.Add(new SqlParameter("@fechacreacion", empresaentidad.fechacreacion));
                sqlcomm.Parameters.Add(new SqlParameter("@presupuesto", empresaentidad.presupuesto));
                sqlcomm.Parameters.Add(new SqlParameter("@activo", empresaentidad.activo));

                if (sqlcomm.ExecuteNonQuery() != 1)
                {
                    throw new Exception("empresada.modificar: problema al actualizar.");
                }

                sqlConn.Close();

            }

            catch (Exception ex)
            {

                throw new Exception("empresaDA.modificar: " + ex.Message);


            }

            finally

            {

                sqlConn.Dispose();


            }


        }

        public void anular(empresaentidad empresaentidad)

        {

            SqlConnection sqlConn = _conexion.conectar();
            SqlCommand sqlcomm = new SqlCommand();

            try

            {

                sqlConn.Open();
                sqlcomm.Connection = sqlConn;
                sqlcomm.CommandType = CommandType.StoredProcedure;
                sqlcomm.CommandText = "anularempresa";
                sqlcomm.Parameters.Add(new SqlParameter("@idempresa", empresaentidad.idempresa));


                sqlcomm.ExecuteNonQuery();


                sqlConn.Close();

            }

            catch (Exception ex)
            {

                throw new Exception("empresaDA.anular: " + ex.Message);


            }

            finally

            {

                sqlConn.Dispose();


            }


        }


        public List<empresaentidad> Listar()

        {

            SqlConnection sqlConn = _conexion.conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlComm = new SqlCommand();

            List<empresaentidad>? listaempresas = new List<empresaentidad>();
            empresaentidad? empresaentidad;

            try

            {

                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "ListarEmpresa";

                sqlDataRead = sqlComm.ExecuteReader();

                while (sqlDataRead.Read())
                {

                    empresaentidad = new();
                    empresaentidad.idempresa = (int)sqlDataRead["idempresa"];
                    empresaentidad.idtipoempresa = (int)sqlDataRead["idtipoempresa"];
                    empresaentidad.empresa = sqlDataRead["empresa"].ToString() ?? string.Empty;
                    empresaentidad.direccion = sqlDataRead["direccion"].ToString() ?? string.Empty;
                    empresaentidad.ruc = sqlDataRead["ruc"].ToString() ?? string.Empty;
                    if (sqlDataRead["fechacreacion"] != DBNull.Value)
                    {

                        empresaentidad.fechacreacion = (DateTime)sqlDataRead["fechacreacion"];

                    }
                    if (sqlDataRead["fechacreacion"] != DBNull.Value)
                    {

                        empresaentidad.presupuesto = (decimal)sqlDataRead["presupuesto"];

                    }

                    empresaentidad.activo = (bool)sqlDataRead["activo"];

                    listaempresas.Add(empresaentidad);


                }


                sqlConn.Close();

                return listaempresas;

            }

            catch (Exception ex)
            {

                throw new Exception("empresaDA.Listar: " + ex.Message);


            }

            finally

            {

                sqlConn.Dispose();


            }


        }

        public empresaentidad buscarid(int idempresa)


        {

            SqlConnection sqlConn = _conexion.conectar();
            SqlDataReader sqlDataRead;
            SqlCommand sqlComm = new SqlCommand();


            empresaentidad? empresaentidad = null;

            try

            {

                sqlConn.Open();
                sqlComm.Connection = sqlConn;
                sqlComm.CommandType = CommandType.StoredProcedure;
                sqlComm.CommandText = "buscarEmpresa";

                sqlComm.Parameters.Add(new SqlParameter("@idempresa", idempresa));


                sqlDataRead = sqlComm.ExecuteReader();

                while (sqlDataRead.Read())
                {

                    empresaentidad = new();
                    empresaentidad.idempresa = (int)sqlDataRead["idempresa"];
                    empresaentidad.idtipoempresa = (int)sqlDataRead["idtipoempresa"];
                    empresaentidad.empresa = sqlDataRead["empresa"].ToString() ?? string.Empty;
                    empresaentidad.direccion = sqlDataRead["direccion"].ToString() ?? string.Empty;
                    empresaentidad.ruc = sqlDataRead["ruc"].ToString() ?? string.Empty;
                    if (sqlDataRead["fechacreacion"] != DBNull.Value)
                    {

                        empresaentidad.fechacreacion = (DateTime)sqlDataRead["fechacreacion"];

                    }
                    if (sqlDataRead["fechacreacion"] != DBNull.Value)
                    {

                        empresaentidad.presupuesto = (decimal)sqlDataRead["presupuesto"];

                    }

                    empresaentidad.activo = (bool)sqlDataRead["activo"];



                }


                sqlConn.Close();

                if (empresaentidad == null)

                {

                    throw new Exception("empresada.buscarid: el id de la empresa no existe.");

                }

                return empresaentidad;

            }

            catch (Exception ex)
            {

                throw new Exception("empresaDA.buscarid: " + ex.Message);


            }

            finally

            {

                sqlConn.Dispose();


            }


        }


    }

}
