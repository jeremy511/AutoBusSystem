using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using CapaEntidad;

namespace CapaDatos
{
    public class D_Bus
    {

        SqlConnection Sql = new SqlConnection(ConfigurationManager.ConnectionStrings["conectar"].ConnectionString);

        public List<E_Viaje> TripDataShow(string buscar)
        {
            SqlDataReader readData;

            SqlCommand cmd = new SqlCommand("SP_Consultar",Sql);
            cmd.CommandType = CommandType.StoredProcedure;
            Sql.Open();

            cmd.Parameters.Add("@buscar", buscar);

            readData = cmd.ExecuteReader();

            List<E_Viaje> list = new List<E_Viaje>();
            while (readData.Read())
            {
                list.Add (new E_Viaje
                {
                    Id = readData.GetInt32(0),
                    Nombre = readData.GetString(1),
                    Apellido = readData.GetString(2),
                    Cedula = readData.GetString(3),
                    Marca = readData.GetString(4),
                    Modelo = readData.GetString(5),
                    Placa = readData.GetString(6),
                    Ruta = readData.GetString(7),
                    IdBUS = readData.GetInt32(8),
                    IdRuta =  readData.GetInt32(9)

                });
            }

            Sql.Close();
            readData.Close();
            return list;
        }


        public SqlDataReader dataRead(string proc,string buscar) {

            SqlDataReader readData;

            SqlCommand cmd = new SqlCommand(proc, Sql);
            cmd.CommandType = CommandType.StoredProcedure;
            Sql.Open();

            cmd.Parameters.Add("@buscar", buscar);

            readData = cmd.ExecuteReader();

            return readData;
        
        }

        public List<E_Conductor> driverDataShow(string buscar)
        {
            SqlDataReader Data;
            Data = dataRead("SP_ConsultarEmp", buscar);
            List<E_Conductor> list = new List<E_Conductor>();
            while (Data.Read())
            {
                list.Add(new E_Conductor
                {
                    Id = Data.GetInt32(0),
                    Nombre = Data.GetString(1),
                    Apellido = Data.GetString(2),
                    Fecha = Data.GetDateTime(3),
                    Cedula = Data.GetString(4),
                    IdBus = Data.GetInt32(5),
                    IdRuta1 = Data.GetInt32(6),
                });
            }

            Sql.Close();
            Data.Close();
            return list;
        }
        public List<E_Bus> BusDataShow(string buscar)
        {
            SqlDataReader Data;
            Data = dataRead("SP_ConsultarBus", buscar);
            List<E_Bus> list = new List<E_Bus>();
            while (Data.Read())
            {
                list.Add(new E_Bus
                {
                    Id = Data.GetInt32(0),
                    Marca = Data.GetString(1),
                    Modelo = Data.GetString(2),
                    Placa = Data.GetString(3),
                    Color = Data.GetString(4),
                    Año = Data.GetString(5)
                });
            }

            Sql.Close();
            Data.Close();
            return list;
        }
        public List<E_Ruta> RouteDataShow(string buscar)
        {
            SqlDataReader Data;
            Data = dataRead("SP_ConsultarRuta", buscar);
            List<E_Ruta> list = new List<E_Ruta>();
            while (Data.Read())
            {
                list.Add(new E_Ruta
                {
                    Id = Data.GetInt32(0),
                    Ruta = Data.GetString(1)
                });
            }

            Sql.Close();
            Data.Close();
            return list;
        }

        public SqlCommand insert(string proc)
        {
            SqlCommand cmd = new SqlCommand(proc, Sql);
            cmd.CommandType = CommandType.StoredProcedure;
            return cmd;
        }

        public void insertDriver(E_Conductor e)
        {
            SqlCommand cmd;
            cmd = insert("SP_InsertarEmpleado");
            Sql.Open();

            cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", e.Apellido);
            cmd.Parameters.AddWithValue("@Fecha_nacimiento", e.Fecha);
            cmd.Parameters.AddWithValue("@Cedula", e.Cedula);
            cmd.Parameters.AddWithValue("@IdBus", e.IdBus);
            cmd.Parameters.AddWithValue("@IdRuta", e.IdRuta1);

            cmd.ExecuteNonQuery();
            Sql.Close();
        }
        public void insertBus(E_Bus e)
        {
            SqlCommand cmd;
            cmd = insert("SP_InsertarBus");
            Sql.Open();

            cmd.Parameters.AddWithValue("@Modelo", e.Modelo);
            cmd.Parameters.AddWithValue("@Marca", e.Marca);
            cmd.Parameters.AddWithValue("@Placa", e.Placa);
            cmd.Parameters.AddWithValue("@Color", e.Color);
            cmd.Parameters.AddWithValue("@Año", e.Año);
      

            cmd.ExecuteNonQuery();
            Sql.Close();
        }
        public void insertRoute(E_Ruta e)
        {
            SqlCommand cmd;
            cmd = insert("SP_InsertarRuta");
            Sql.Open();

            cmd.Parameters.AddWithValue("@Ruta", e.Ruta);

            cmd.ExecuteNonQuery();
            Sql.Close();
        }

        public DataTable comboAutobus()

        {
            SqlDataAdapter da = new SqlDataAdapter("sp_comboxAuto", Sql);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            da.Fill(data);
            return data;

        }
        public DataTable comboRuta()

        {
            SqlDataAdapter da = new SqlDataAdapter("sp_comboxRuta", Sql);
            da.SelectCommand.CommandType = CommandType.StoredProcedure;
            DataTable data = new DataTable();
            da.Fill(data);
            return data;

        }

        public void updateTrip(E_Conductor e) 
        {
            SqlCommand cmd = insert("SP_EditarTrip");
            Sql.Open();

            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.Parameters.AddWithValue("@IdBus", e.IdBus);
            cmd.Parameters.AddWithValue("@IdRuta", e.IdRuta1);

            cmd.ExecuteNonQuery();
            Sql.Close();
        }


        public void updateDriver(E_Conductor e)
        {
            SqlCommand cmd = insert("SP_EditarEmpleado");
            Sql.Open();

            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.Parameters.AddWithValue("@Nombre", e.Nombre);
            cmd.Parameters.AddWithValue("@Apellido", e.Apellido);
            cmd.Parameters.AddWithValue("@Fecha_nacimiento", e.Fecha);
            cmd.Parameters.AddWithValue("@Cedula", e.Cedula);

            cmd.ExecuteNonQuery();
            Sql.Close();

        }
        public void updateBus(E_Bus e)
        {
            SqlCommand cmd = insert("SP_EditarBus");
            Sql.Open();

            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.Parameters.AddWithValue("@Marca", e.Marca);
            cmd.Parameters.AddWithValue("@Modelo", e.Modelo);
            cmd.Parameters.AddWithValue("@Placa", e.Placa);
            cmd.Parameters.AddWithValue("@Color", e.Color);
            cmd.Parameters.AddWithValue("@Año", e.Año);

            cmd.ExecuteNonQuery();
            Sql.Close();

        }
        public void updateRoute(E_Ruta e)
        {
            SqlCommand cmd = insert("SP_EditarRuta");
            Sql.Open();

            cmd.Parameters.AddWithValue("@id", e.Id);
            cmd.Parameters.AddWithValue("@ruta", e.Ruta);

            cmd.ExecuteNonQuery();
            Sql.Close();

        }

        public void deleteDriver(E_Conductor e)
        {
            SqlCommand cmd = insert("SP_EliminarEmpleado");
            Sql.Open();

            cmd.Parameters.AddWithValue("@id",e.Id);
            cmd.ExecuteNonQuery();
            Sql.Close();

        }
        public void deleteBus(E_Bus e)
        {
            SqlCommand cmd = insert("SP_EliminarBus");
            Sql.Open();

            cmd.Parameters.AddWithValue("@id",e.Id);
            cmd.ExecuteNonQuery();
            Sql.Close();

        }
        public void deleteRoute(E_Ruta e)
        {
            SqlCommand cmd = insert("SP_EliminarRuta");
            Sql.Open();

            cmd.Parameters.AddWithValue("@id",e.Id);
            cmd.ExecuteNonQuery();
            Sql.Close();

        }
    }
}
