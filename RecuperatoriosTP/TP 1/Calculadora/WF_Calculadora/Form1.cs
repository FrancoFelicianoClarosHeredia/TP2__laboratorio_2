using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Calculadora_Class;

namespace WF_Calculadora
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// Motodo que permite habilitar el diseñador de la planilla
        /// </summary>
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Metodo para limpiar los textos ingresados
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.txtNumero1.Clear();
            this.txtNumero2.Clear();
            this.txtResultado.Items.Clear();
        }

        /// <summary>
        /// Metodo dedicado a realizar la operacion matematica elegida
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            string operacion = cmbOperacion.Text;
            Numero num1 = new Numero(txtNumero1.Text);
            Numero num2 = new Numero(txtNumero2.Text);
            double resultado = Calculadora.operar(num1, num2, operacion);

            this.txtResultado.Items.Clear();
            this.txtResultado.Items.Add(resultado);
        }
    }
}
