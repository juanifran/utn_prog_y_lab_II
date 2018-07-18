using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MainCorreo
{
    public partial class Form1 : Form
    {
        #region Campos
        Correo correo;
        #endregion

        #region Constructor
        /// <summary>
        /// Inicializar Correo
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            this.correo = new Correo();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Agrega un paquete a la lista del correo y une metodo a evento
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnAgregar_Click(object sender, EventArgs e)
        {
            string dirrecion = "ninguna";
            string id = "ninguna";
            dirrecion = this.txtDireccion.Text;
            id = this.mtxtTrackingID.Text;

            if (dirrecion != string.Empty && id != string.Empty)
            {
                Paquete p1 = new Paquete(dirrecion, id);
                p1.InformaEstado += paq_InformaEstado;

                try
                {
                    this.correo += p1;
                }
                catch (TrackingIdRepetidoException tide)
                {
                    TrackingIdRepetidoException excep = new TrackingIdRepetidoException("id repetido", tide);
                    MessageBox.Show(string.Format("{0}{1}", excep.InnerException.Message, excep.Message));
                }
            }
        }
        /// <summary>
        /// cierra todos los hilos activos
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.correo.FinEntregas();
        }
        /// <summary>
        /// llama a ActualizarEstados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        public void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                this.ActualizarEstados();
            }
        }
        /// <summary>
        /// Evento click de Mostrar muestra todos los paquetes del correo
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnMostrar_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        /// <summary>
        /// Actualiza el estado del paquete en cada listbox
        /// </summary>
        void ActualizarEstados()
        {
            this.lstEstadoIngresado.Items.Clear();
            this.lstEstadoEnViaje.Items.Clear();
            this.lstEstadoEntregado.Items.Clear();

            foreach (Paquete item in this.correo.Paquetes)
            {
                switch (item.Estado)
                {
                    case Paquete.EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(item);
                        break;
                    case Paquete.EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(item);
                        break;
                    case Paquete.EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(item);
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra el elemento recibido en rtbMostrar y luego guarda en texto con método de extensión
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        void MostrarInformacion<T>(IMostrar<T> elemento) 
        {
            if (!object.ReferenceEquals(elemento, null))
            {
                this.rtbMostrar.Text = elemento.MostrarDatos(elemento);

                if (!(elemento.MostrarDatos(elemento)).Guardar("salida.txt"))
                    MessageBox.Show("No se pudo guardar en texto");
            }

            
        }
        /// <summary>
        /// Muestra informacion del item seleccionado en Text Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MostrarToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
        #endregion
    }
}
