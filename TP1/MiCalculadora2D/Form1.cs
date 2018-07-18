using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MiCalculadora2D
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Realiza el calculo usando el metodo Operar de la clase Calculadora
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnOperar_Click(object sender, EventArgs e)
        {
            Numero numero1 = new Numero(this.txtNumero1.Text);
            Numero numero2 = new Numero(this.txtNumero2.Text);
            lblResultado.Text = Calculadora.Operar(numero1, numero2, this.cmbOperacion.Text).ToString();

        }
        /// <summary>
        /// Limpia los valores de los campos de texto, el label
        /// y el combobox de la interfaz
        /// </summary>
        public void LimpiarForm()
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.lblResultado.Text = "";
            this.cmbOperacion.SelectedIndex = -1;
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.LimpiarForm();
        }

        private void btnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();

        }

        private void btnConvertirABinario_Click(object sender, EventArgs e)
        {
            long num = Convert.ToInt32(txtNumero1.Text);
            if (num > 0)
            {
                String bin = "";
                while (num > 0)
                {
                    if (num % 2 == 0)
                    {
                        lblResultado.Text = bin = "0" + bin;
                    }
                    else
                    {
                        lblResultado.Text = bin = "1" + bin;
                    }
                    num = (long)(num / 2);
                }
                lblResultado.Text = bin;
            }
            else
            {
                if (num < 0)
                    MessageBox.Show("Solo numeros positivos");
            }
        }
     


        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            decimal conversor = 0;
            lblResultado.Text = conversor.ToString(txtNumero1.Text);
        }
        
    }
}
