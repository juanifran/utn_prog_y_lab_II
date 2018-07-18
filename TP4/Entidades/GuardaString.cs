using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Entidades
{
    public static class GuardaString
    {
        #region Metodos
        /// <summary>
        /// Guarda string en archivo de texto
        /// </summary>
        /// <param name="texto"></param>
        /// <param name="archivo"></param>
        /// <returns></returns>
        public static bool Guardar(this string texto, string archivo)
        {
            string path = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);

            try
            {
                if (!File.Exists(Path.Combine(path, archivo)))
                {
                    StreamWriter s1 = new StreamWriter(Path.Combine(path, archivo), false,UTF8Encoding.UTF8);
                    s1.WriteLine(texto);
                    s1.Close();
                    return true;
                }
                else
                {
                    StreamWriter s1 = File.AppendText(Path.Combine(path, archivo)); ;
                    s1.WriteLine(texto);
                    s1.Close();
                    return true;
                }
                
            }
            catch (Exception)
            {
                return false;
            }
        }
        #endregion
    }
}
