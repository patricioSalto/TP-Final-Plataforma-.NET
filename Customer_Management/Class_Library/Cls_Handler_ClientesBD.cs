using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace Class_Library
{
    public class Cls_Handler_ClientesBD
    {
        private SqlConnection _objConexion;
        private SqlCommand _objCommand;
        private SqlDataAdapter _objAdater;
        private DataSet _objDataSet;

        private void getConnection()
        {
            string connString = ConfigurationManager.ConnectionStrings["ClienteConnDev"].ToString();
            _objConexion = new SqlConnection(connString);
        }

        public List<Entidades.ClienteModel> Obtener_Clientes()
        {
            List<Entidades.ClienteModel> retornoList = new List<Entidades.ClienteModel>();

            getConnection();

            _objCommand = new SqlCommand("SP_LISTAR_CLIENTES", _objConexion);
            _objCommand.CommandType = CommandType.StoredProcedure;

            _objConexion.Open();
            _objAdater = new SqlDataAdapter(_objCommand);
            _objDataSet = new DataSet();
            _objAdater.Fill(_objDataSet);
            _objConexion.Close();

            if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in _objDataSet.Tables[0].Rows)
                {
                    retornoList.Add(new Entidades.ClienteModel
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Tipo_documento = Convert.ToString(row["Tipo_documento"]),
                        Nro_documento = Convert.ToString(row["Nro_documento"]),
                        Nombre = Convert.ToString(row["Nombre"]),
                        Direccion = Convert.ToString(row["Direccion"]),
                        Telefono = Convert.ToString(row["Telefono"]),
                        Correo = Convert.ToString(row["Correo"]),
                        Estados = Convert.ToString(row["Estatus"])
                    });
                }
            }

            return retornoList;

        }

        public List<Entidades.ClienteModel> Obtener_Clientes(String filtro)
        {
            List<Entidades.ClienteModel> retornoList = new List<Entidades.ClienteModel>();

            getConnection();

            _objCommand = new SqlCommand("SP_LISTAR_CLIENTES_POR_BUSQUEDA", _objConexion);
            _objCommand.CommandType = CommandType.StoredProcedure;

            _objCommand.Parameters.Add("@filtro", SqlDbType.VarChar).Value = filtro+"%";

            _objConexion.Open();
            _objAdater = new SqlDataAdapter(_objCommand);
            _objDataSet = new DataSet();
            _objAdater.Fill(_objDataSet);
            _objConexion.Close();

            if (_objDataSet.Tables[0].Rows.Count > 0)
            {
                foreach (DataRow row in _objDataSet.Tables[0].Rows)
                {
                    retornoList.Add(new Entidades.ClienteModel
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        Tipo_documento = Convert.ToString(row["Tipo_documento"]),
                        Nro_documento = Convert.ToString(row["Nro_documento"]),
                        Nombre = Convert.ToString(row["Nombre"]),
                        Direccion = Convert.ToString(row["Direccion"]),
                        Telefono = Convert.ToString(row["Telefono"]),
                        Correo = Convert.ToString(row["Correo"]),
                        Estados = Convert.ToString(row["Estatus"])
                    });
                }
            }

            return retornoList;

        }

        public bool mtd_Insertar_Cliente(Entidades.ClienteModel datosInsertar)
        {
            bool resultado = true;

            getConnection();

            _objCommand = new SqlCommand("SP_INSERTAR_CLIENTE", _objConexion);
            _objCommand.CommandType = CommandType.StoredProcedure;

            _objCommand.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = datosInsertar.Tipo_documento;
            _objCommand.Parameters.Add("@nro_documento", SqlDbType.VarChar).Value = datosInsertar.Nro_documento;
            _objCommand.Parameters.Add("@nombre_cliente", SqlDbType.VarChar).Value = datosInsertar.Nombre;
            _objCommand.Parameters.Add("@direccion", SqlDbType.VarChar).Value = datosInsertar.Direccion;
            _objCommand.Parameters.Add("@telefono", SqlDbType.VarChar).Value = datosInsertar.Telefono;
            _objCommand.Parameters.Add("@correo", SqlDbType.VarChar).Value = datosInsertar.Correo;
            _objCommand.Parameters.Add("@estatus", SqlDbType.VarChar).Value = datosInsertar.Estados;

            _objConexion.Open();
            _objCommand.ExecuteNonQuery();
            _objConexion.Close();

            return resultado;
        }

        public bool mtd_Update_Cliente(Entidades.ClienteModel datosActualizar)
        {
            bool resultado = true;

            getConnection();

            _objCommand = new SqlCommand("SP_UPDATE_CLIENTE", _objConexion);
            _objCommand.CommandType = CommandType.StoredProcedure;

            _objCommand.Parameters.Add("@id", SqlDbType.Int).Value = datosActualizar.Id;
            _objCommand.Parameters.Add("@tipo_documento", SqlDbType.VarChar).Value = datosActualizar.Tipo_documento;
            _objCommand.Parameters.Add("@nro_documento", SqlDbType.VarChar).Value = datosActualizar.Nro_documento;
            _objCommand.Parameters.Add("@nombre_cliente", SqlDbType.VarChar).Value = datosActualizar.Nombre;
            _objCommand.Parameters.Add("@direccion", SqlDbType.VarChar).Value = datosActualizar.Direccion;
            _objCommand.Parameters.Add("@telefono", SqlDbType.VarChar).Value = datosActualizar.Telefono;
            _objCommand.Parameters.Add("@correo", SqlDbType.VarChar).Value = datosActualizar.Correo;
            _objCommand.Parameters.Add("@estatus", SqlDbType.VarChar).Value = datosActualizar.Estados;

            _objConexion.Open();
            _objCommand.ExecuteNonQuery();
            _objConexion.Close();

            return resultado;
        }

        public bool mtd_Eliminar_Cliente(int id)
        {
            bool resultado = true;

            getConnection();

            _objCommand = new SqlCommand("SP_ELIMINAR_CLIENTE", _objConexion);
            _objCommand.CommandType = CommandType.StoredProcedure;

            _objCommand.Parameters.Add("@id", SqlDbType.Int).Value = id;
            _objConexion.Open();
            _objCommand.ExecuteNonQuery();
            _objConexion.Close();

            return resultado;
        }


    }
}
