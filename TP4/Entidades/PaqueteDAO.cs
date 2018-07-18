using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Data.SqlClient;
using System.Data;

namespace Entidades
{
    public static class PaqueteDAO
    {
        #region Campos
        static SqlConnection _conexion;
        static SqlCommand _comando;
        #endregion

        #region Metodos
        static PaqueteDAO()
        {
            
        }
        /// <summary>
        /// Inserta un paquete en la tabla
        /// </summary>
        /// <param name="P"></param>
        /// <returns></returns>
        public static bool Insetar(Paquete P)
        {
            PaqueteDAO._conexion = new SqlConnection(Properties.Settings.Default.CadenaConexion);
            PaqueteDAO._comando = new SqlCommand();
            PaqueteDAO._comando.CommandType = System.Data.CommandType.Text;
            PaqueteDAO._comando.Connection = PaqueteDAO._conexion;

            bool todoOk = false; 
            string sql = "INSERT INTO Personas (direccionEntrega, trackingID, alumno) VALUES('" + P.TackingID + "','" + P.DireccionEntrega + "','Juan Ifran')";
            try
            {
                PaqueteDAO._comando.CommandText = sql;
                PaqueteDAO._conexion.Open();
                PaqueteDAO._comando.ExecuteNonQuery();
                todoOk = true;
            }
            catch (Exception)
            {
                
            }
            finally
            {
                if (todoOk)
                    PaqueteDAO._conexion.Close();
            }
            return todoOk;
        }
        #endregion
    }
}
