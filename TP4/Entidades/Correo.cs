using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Correo : IMostrar<List<Paquete>>
    {
        #region Campos
        List<Thread> mockPaquetes;
        List<Paquete> paquetes;
        #endregion

        #region Propiedades
        /// <summary>
        /// get y set de lista de paquetes
        /// </summary>
        public List<Paquete> Paquetes
        {
            get { return this.paquetes; }
            set { this.paquetes = value; }
        }
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializa las dos listas de la clase correo
        /// </summary>
        public Correo()
        {
            this.mockPaquetes = new List<Thread>();
            this.paquetes = new List<Paquete>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Publica información completa de todos los paquetes
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<List<Paquete>> elemento)
        {
            StringBuilder S = new StringBuilder();

            foreach (Paquete item in (List<Paquete>)((Correo)elemento).paquetes)
            {
                S.Append(string.Format("{0} ({1})\n",item.MostrarDatos(item),item.Estado));
            }

            return S.ToString();
        }
        /// <summary>
        /// Agrega un paquete solo si este no se encuentra, e inicia su ciclo de vida
        /// </summary>
        /// <param name="c"></param>
        /// <param name="p"></param>
        /// <returns></returns>
        public static Correo operator +(Correo c, Paquete p)
        {
            foreach (Paquete item in c.paquetes)
            {
                if (item == p)
                    throw new TrackingIdRepetidoException("paquete repetido interna");
            }
            c.paquetes.Add(p);
            Thread T1 = new Thread(p.MockCicloDeVida);
            c.mockPaquetes.Add(T1);
            T1.Start();

            return c;
        }
        /// <summary>
        /// Finaliza todos los hilos activos de la lista
        /// </summary>
        public void FinEntregas()
        {
            foreach (Thread item in this.mockPaquetes)
            {
                item.Interrupt();
            }
        }
        #endregion
    }
}
