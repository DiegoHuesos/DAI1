using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace SistemaAlumnos
{
    class Alumno
    {
        public Int16 ClaveUnica { get; set; }
        public String nombre { get; set; }
        public String sexo { get; set; }
        public String correo { get; set; }
        public Int16 semestre { get; set; }
        public int programa { get; set; }

        public Alumno()
        {
        }

        public Alumno(short claveUnica, string nombre, string sexo, string correo, short semestre, int programa)
        {
            ClaveUnica = claveUnica;
            this.nombre = nombre;
            this.sexo = sexo;
            this.correo = correo;
            this.semestre = semestre;
            this.programa = programa;
        }

        public Alumno(short claveUnica, string correo)
        {
            ClaveUnica = claveUnica;
            this.correo = correo;
        }

        // función de agregar un alumno a la Tabla alumno y regresa un entero positivo si lo pudo agregar
        // o un negativo si no lo agregó

        public int agregar(Alumno a)
        {
            int res = 0;
            //abrir la conexión
                SqlConnection con;
                con = Conexión.conectar();
            //comand para ejecutar el query (insert)
            SqlCommand cmd = new SqlCommand(String.Format("insert into alumno (claveUnica, nombre, sexo, correo, semestre, idPrograma) values ({0}, '{1}', '{2}', '{3}', {4}, {5})", a.ClaveUnica, a.nombre, a.sexo, a.correo, a.semestre, a.programa), con);
            res = cmd.ExecuteNonQuery(); //# de columnas o registros afectados
            //cerrar la conexión
            con.Close();
            return res;
        }

        public int eliminar(Int16 CU)
        {
            int res=0;
            //abrir la conexión
            SqlConnection con;
            con = Conexión.conectar();
            //comand para ejecutar el query (delete)
            SqlCommand cmd = new SqlCommand(String.Format("delete from alumno where claveUnica=={0}",  CU), con);
            res = cmd.ExecuteNonQuery(); //# de columnas o registros afectados
            //cerrar la conexión
            con.Close();
            return res;
        }

        public int modificar(Alumno a)
        {
            int res = 0;
            //abrir la conexión
            SqlConnection con;
            con = Conexión.conectar();
            //comand para ejecutar el query (update)
            SqlCommand cmd = new SqlCommand(String.Format("update alumno set correo=='{0}' where claveUnica=={1}", a.correo, a.ClaveUnica), con);
            res = cmd.ExecuteNonQuery(); //# de columnas o registros afectados
            //cerrar la conexión
            con.Close();
            return res;
        }

        public List<Alumno> buscar(String nombre)
        {
            List<Alumno> lis = new List<Alumno>();
            Alumno a;
            SqlDataReader rd;
            //abrir la conexión
            SqlConnection con;
            con = Conexión.conectar();
            //comand para ejecutar el query
            SqlCommand cmd = new SqlCommand(String.Format("select * from alumno where nombre like '%{0}%'", nombre), con);
            rd = cmd.ExecuteReader();
            while (rd.Read())
            {
                a = new Alumno();
                a.ClaveUnica = rd.GetInt16(0);
                a.nombre = rd.GetString(1);
                a.sexo = rd.GetString(2);
                a.correo = rd.GetString(3);
                a.semestre = rd.GetInt16(4);
                a.programa = rd.GetInt16(5);
                lis.Add(a);
            }
            //cerrar la conexión
            con.Close();
            return lis;
        }
    }
}
