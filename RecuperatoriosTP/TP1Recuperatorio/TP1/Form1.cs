using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TP1
{
    public partial class Form1 : Form
    {
        
        public Form1()
        {
            InitializeComponent();
            
        }

        private void BtnOperar_Click(object sender, EventArgs e)
        {
            Numero num1 = new Numero(TxtBox1.Text);
            Numero num2 = new Numero(TxtBox2.Text);
            LblResu.Text = Calculadora.Operar(num1, num2, CmbBox.Text).ToString();
        }

        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.limpiar();
        }

        private void limpiar()
        {
            this.TxtBox1.Text = "";
            this.TxtBox2.Text = "";
            this.LblResu.Text = "";
            this.CmbBox.Text = "";
        }

        private void BtnCerrar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void BtnCDecimal_Click(object sender, EventArgs e)
        {
            this.LblResu.Text = (Numero.BinarioDecimal(LblResu.Text));
        }

        private void BtnCBinario_Click(object sender, EventArgs e)
        {
            this.LblResu.Text = (Numero.DecimalBinario(LblResu.Text));
        }
    }
}
