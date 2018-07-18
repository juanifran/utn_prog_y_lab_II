using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace Entidades
{
    public class Paquete : IMostrar<Paquete>
    {
        #region Campos
        string direccionEntrega;
        EEstado estado;
        string trackinID;
        public delegate void DelegadoEstado(object sender, EventArgs e);
        public event DelegadoEstado InformaEstado;
        #endregion

        #region Propiedades
        /// <summary>
        /// Get Set de campo direccionEntrega
        /// </summary>
        public string DireccionEntrega
        {
            get { return this.direccionEntrega; }
            set { this.direccionEntrega = value; }
        }
        /// <summary>
        /// Get Set campo estado
        /// </summary>
        public EEstado Estado
        {
            get { return this.estado; }
            set { this.estado = value; }
        }
        /// <summary>
        /// Get Set trackinID
        /// </summary>
        public string TackingID
        {
            get { return this.trackinID; }
            set { this.trackinID = value; }
        }
        #endregion

        #region Enum
        /// <summary>
        /// Enum: Ingresado, EnViaje, Entregado
        /// </summary>
        public enum EEstado {Ingresado, EnViaje, Entregado }
        #endregion

        #region Constructor
        /// <summary>
        /// Constructor string direccionEntrega y string trackingID
        /// </summary>
        /// <param name="direccionEntrega"></param>
        /// <param name="trackingID"></param>
        public Paquete(string direccionEntrega, string trackingID)
        {
            this.direccionEntrega = direccionEntrega;
            this.trackinID = trackingID;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Dos paquetes son iguales si comparten el mismo trackingID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator ==(Paquete p1, Paquete p2)
        {
            if (p1.trackinID == p2.trackinID)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Dos paquetes son distintos si no contienen el mismo tracking ID
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <returns></returns>
        public static bool operator !=(Paquete p1, Paquete p2)
        {
            return !(p1 == p2);
        }
        /// <summary>
        /// Muestra todos los datos de un solo paquete
        /// </summary>
        /// <param name="elemento"></param>
        /// <returns></returns>
        public string MostrarDatos(IMostrar<Paquete> elemento)
        {
            return string.Format("{0} para {1}",this.TackingID,this.DireccionEntrega);
        }
        /// <summary>
        /// Publica los datos de un paquete
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return MostrarDatos((IMostrar<Paquete>)this); 
        }

        
        /// <summary>
        /// Se informa cambio de estado de paquete con evento informaestado, y luego inserta en base de datos el paquete
        /// </summary>
        public void MockCicloDeVida()
        {
            EventArgs a = new EventArgs();

            this.estado = EEstado.Ingresado;
            this.InformaEstado.Invoke(this, new EventArgs());
            Thread.Sleep(10000);
            this.estado = EEstado.EnViaje;
            this.InformaEstado.Invoke(this, new EventArgs());
            Thread.Sleep(10000);
            this.estado = EEstado.Entregado;
            this.InformaEstado.Invoke(this, new EventArgs());

            PaqueteDAO.Insetar(this);

        }

        #endregion
    }
}
