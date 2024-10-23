using WebApi2024.Models;
using System.Data.SqlClient;
using Microsoft.Data.SqlClient;
using System.Data;
namespace WebApi2024.Data
{
    public class DataCliente
    {
        public static List<CarreraModel> ListadoCarrera()
        {
            string consulta = "select * from carrera";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta,ClassGeneral.cadena);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            List<CarreraModel> listaCarr = new List<CarreraModel>();

            foreach(DataRow fila in tabla.Rows)
            {
                //Forma1
                //CarreraModel aux = new CarreraModel();
                //aux.idCarrera = fila[0].ToString();
                //aux.nombre_carrera = fila[1].ToString();
                //aux.estado_carrera = Convert.ToBoolean(fila[2]);
                //Forma2
                listaCarr.Add(new CarreraModel
                {
                    idCarrera = fila[0].ToString(),
                    nombre_carrera = fila[1].ToString(),
                    estado_carrera = Convert.ToBoolean(fila[2])
                });

            }   

            return listaCarr;
        }
        public static int NuevaCarrera(CarreraModel nuevaCarrera)
        {

            string consulta = "insert into carrera values (@idcar,@nomcar,@estado);";
            SqlConnection conection = new SqlConnection(ClassGeneral.cadena);
            SqlCommand comando = new SqlCommand(consulta, conection);
            comando.Parameters.AddWithValue("@idcar", nuevaCarrera.idCarrera);
            comando.Parameters.AddWithValue("@nomcar", nuevaCarrera.nombre_carrera);
            comando.Parameters.AddWithValue("@estado", nuevaCarrera.estado_carrera);

            try
            {
                conection.Close();
                conection.Open();
                comando.ExecuteNonQuery();
                conection.Close();

                return 1;
            }
            catch
            {
                return 0;

            }

        }

        public static int EliminarCarrera(string idCarrera)
        {
            string consulta = "DELETE FROM carrera WHERE idCarrera = @idcar;";
            SqlConnection conection = new SqlConnection(ClassGeneral.cadena);
            SqlCommand comando = new SqlCommand(consulta, conection);
            comando.Parameters.AddWithValue("@idcar", idCarrera);

            try
            {
                conection.Close(); // Asegurarse de cerrar la conexión antes de abrirla
                conection.Open();
                int filasAfectadas = comando.ExecuteNonQuery();
                conection.Close();

                return filasAfectadas; // Devuelve la cantidad de filas afectadas
            }
            catch
            {
                return 0; // Retorna 0 si hubo un error
            }
        }

        public static List<GradoModel> ListadoGrados()
        {
            string consulta = "select * from grado";
            SqlDataAdapter adapter = new SqlDataAdapter(consulta, ClassGeneral.cadena);
            DataTable tabla = new DataTable();
            adapter.Fill(tabla);
            List<GradoModel> listaGrado = new List<GradoModel>();

            foreach (DataRow fila in tabla.Rows)
            {
                //Forma1
                //CarreraModel aux = new CarreraModel();
                //aux.idCarrera = fila[0].ToString();
                //aux.nombre_carrera = fila[1].ToString();
                //aux.estado_carrera = Convert.ToBoolean(fila[2]);
                //Forma2
                listaGrado.Add(new GradoModel
                {
                    ID_Grado = Convert.ToInt16(fila[0].ToString()),
                    Nom_grado = fila[1].ToString(),
                    estado_grado = Convert.ToBoolean(fila[2])
                });

            }

            return listaGrado;
        }
        public static int NuevoGrado(GradoModel nuevoGrado)
        {
            string consulta = "insert into grado values (@nomGrado,@estado);";
            SqlConnection conection = new SqlConnection(ClassGeneral.cadena);
            SqlCommand comando = new SqlCommand(consulta, conection);
            comando.Parameters.AddWithValue("@nomGrado", nuevoGrado.Nom_grado);
            comando.Parameters.AddWithValue("@estado", nuevoGrado.estado_grado);

            try
            {
                conection.Close();
                conection.Open();
                comando.ExecuteNonQuery();
                conection.Close();

                return 1;
            }
            catch
            {
                return 0;

            }

        }


    }
}
