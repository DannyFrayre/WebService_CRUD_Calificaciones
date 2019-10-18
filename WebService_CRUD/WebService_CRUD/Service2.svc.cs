using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Data.SqlClient;

namespace WebService_CRUD
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "Service2" en el código, en svc y en el archivo de configuración a la vez.
    public class Service2 : IService2
    {
        public void crear(int nc, string nom, int c1, int c2, int c3, int c4, int c5)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source= DESKTOP-882OB3B; Initial Catalog=CRUD;Integrated Security=false;user=danny;password=sanchez");
            con.Open();
            cadena = "insert into CRUD2 values('" + nc + "','" + nom + "','" + c1 + "','" + c2 + "','" + c3 + "','" + c4 + "','" + c5 + "')";
            cmd = new SqlCommand(cadena, con);
            cmd.ExecuteNonQuery();
            con.Close();
        }

        public bool modificar(int nc, string nom, int c1, int c2, int c3, int c4, int c5)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source= DESKTOP-882OB3B; Initial Catalog=CRUD;Integrated Security=false;user=danny;password=sanchez");
            con.Open();
            cadena = "UPDATE CRUD2 SET No_de_control = ('" + nc + "'),Nombre = ('" + nom + "'), Calculo = ('" + c1 + "'), Calidad = ('" + c2 + "'), Ingles = ('" + c3 + "'), Admon = ('" + c4 + "'), Topicos = ('" + c5 + "')where No_de_control =('" + nc + "')";
            cmd = new SqlCommand (cadena, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }

        public bool eliminar(int nc)
        {
            SqlConnection con;
            SqlCommand cmd;
            string cadena = "";
            con = new SqlConnection("Data Source= DESKTOP-882OB3B; Initial Catalog=CRUD;Integrated Security=false;user=danny;password=sanchez");
            con.Open();
            cadena = "delete from CRUD2 where No_de_control = " + nc;
            cmd = new SqlCommand(cadena, con);
            if (cmd.ExecuteNonQuery() > 0)
            {
                return true;
            }
            else
            {
                return false;
            }
            con.Close();
        }

        public List <string> leer ()
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dato;
            string cadena = "";
            var datos = new string[7];
            var consulta = new List<string>();
            con = new SqlConnection("Data Source= DESKTOP-882OB3B; Initial Catalog=CRUD;Integrated Security=false;user=danny;password=sanchez");
            con.Open();
            cadena = "select * from CRUD2";
            cmd = new SqlCommand(cadena, con);
            dato = cmd.ExecuteReader();
            int i = 0;
            while (dato.Read())
            {
                datos[0] = dato.GetInt32(0).ToString();
                datos[1] = dato.GetString(1);
                datos[2] = dato.GetInt32(2).ToString();
                datos[3] = dato.GetInt32(3).ToString();
                datos[4] = dato.GetInt32(4).ToString();
                datos[5] = dato.GetInt32(5).ToString();
                datos[6] = dato.GetInt32(6).ToString();
                consulta.InsertRange(i, datos);
                i = i + 7;
            }
            con.Close();
            return consulta;
        }

        public string[] buscar(int nc)
        {
            SqlConnection con;
            SqlCommand cmd;
            SqlDataReader dato;
            string cadena = "";
            string[] datos = new string[7];
            con = new SqlConnection("Data Source= DESKTOP-882OB3B; Initial Catalog=CRUD;Integrated Security=false;user=danny;password=sanchez");
            con.Open();
            cadena = "select * from CRUD2 where No_de_control='" + nc + "'";
            cmd = new SqlCommand(cadena, con);
            dato = cmd.ExecuteReader();
            if (dato.Read())
            {
                datos[0] = dato.GetInt32(0).ToString();
                datos[1] = dato.GetString(1);
                datos[2] = dato.GetInt32(2).ToString();
                datos[3] = dato.GetInt32(3).ToString();
                datos[4] = dato.GetInt32(4).ToString();
                datos[5] = dato.GetInt32(5).ToString();
                datos[6] = dato.GetInt32(6).ToString();
            }
            con.Close();
            return datos;
        }
    }
}
