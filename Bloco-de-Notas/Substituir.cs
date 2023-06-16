using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloco_de_Notas
{
    public partial class Substituir : Form
    {
        public Substituir()
        {
            InitializeComponent();
        }

        private void btnCancelar_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSubstitui_Click(object sender, EventArgs e)
        {
            //duplica o conteudo do richTextBox e faz a troca na variavel texto e dps coloca denovo no richTextBox
            
            String busca = txtBxLocaliza.Text;
            String nova = txtBxSubstitui.Text;
            String texto = ((Form1)this.Owner).rchTxtBxConteudo.Text;

            ((Form1)this.Owner).rchTxtBxConteudo.Text = texto.Replace(busca, nova);
            
            this.Close();
        }

        private void Substituir_Load(object sender, EventArgs e)
        {

        }

        private void txtBxLocaliza_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
