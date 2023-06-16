using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bloco_de_Notas
{
    public partial class Form1 : Form
    {
        bool alterado;
        int zoom = 100;

        public Form1()
        {
            InitializeComponent();
            //para q nao tenha nenhum arquivo aberto na inicializaçao do bloco
            this.Text = "";

            barraDeStatusToolStripMenuItem.Checked = true;
            this.atualizaPosicao();
        }


        private void atualizaPosicao()
        {
            int linha = rchTxtBxConteudo.GetLineFromCharIndex(rchTxtBxConteudo.SelectionStart);
            int coluna = rchTxtBxConteudo.SelectionStart - rchTxtBxConteudo.GetFirstCharIndexFromLine(linha);
            tlStrpSttsLblPosicionamento.Text = "Ln: " + linha.ToString() + "Col: " + coluna.ToString();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void editarToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void rchTxtBxConteudo_TextChanged(object sender, EventArgs e)
        {
            alterado = true;
        }

        private void abrirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!alterado)
            {
                this.abrir();
            }
            else
            {
                if(MessageBox.Show("Arquivo alterado. Deseja salvar?", "Bloco de Notas", 
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.abrir();
                }
                else
                {
                    if(this.Text != "")  //significa que ja existe um arquivo aberto
                    {
                        this.salvar(this.Text);
                    }
                    else
                    {
                        this.salvarComo();
                    }
                }
            }
        }

        private void abrir()
        {
            if (opnFlDlgAbrir.ShowDialog() == DialogResult.OK)
            {
                //coloca o nome do arquivo como titulo do formulario
                this.Text = opnFlDlgAbrir.FileName;
                using (StreamReader reader = new StreamReader(opnFlDlgAbrir.OpenFile()))
                {
                    rchTxtBxConteudo.Text = reader.ReadToEnd();
                    alterado = false;
                }
            }
        }

        private void salvar(String arquivo)
        {
            if(arquivo != "")
            {
                StreamWriter buffer = new StreamWriter(arquivo);
                buffer.Write(rchTxtBxConteudo.Rtf);
                buffer.Close();
                this.Text = arquivo;
                alterado = false;
            }
            else
            {
                MessageBox.Show("Nome do Arquivo invávildo!", "Salvar", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }        
        } 

        private void salvarComo()
        {
            if(svFlDlgAbrir.ShowDialog() == DialogResult.OK)
            {
                this.salvar(svFlDlgAbrir.FileName);
            }
        }

        private void salvarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.Text != "")  //significa que ja existe um arquivo aberto
            {
                this.salvar(this.Text);
            }
            else
            {
                this.salvarComo();
            }
        }

        private void salvarComoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.salvarComo();
        }

        private void desfazerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchTxtBxConteudo.Undo();
        }

        private void recortarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rchTxtBxConteudo.SelectedText != "")
            {
                Clipboard.SetDataObject(rchTxtBxConteudo.SelectedRtf);
                rchTxtBxConteudo.SelectedRtf = "";
            }
        }

        private void copiarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rchTxtBxConteudo.SelectedRtf != "")
            {
                Clipboard.SetDataObject(rchTxtBxConteudo.SelectedRtf);
            }
        }

        private void colarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Clipboard.GetDataObject().GetDataPresent(DataFormats.Text))
            {
                rchTxtBxConteudo.SelectedText = (String)Clipboard.GetData(DataFormats.Text);
            }
        }

        private void excluirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rchTxtBxConteudo.SelectedRtf != "")
            {
                rchTxtBxConteudo.SelectedRtf = "";
            }
        }

        private void buscarComOBingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(rchTxtBxConteudo.SelectedRtf != "")
            {
                String texto = rchTxtBxConteudo.SelectedText;
                texto.Replace(' ', '+');
                System.Diagnostics.Process.Start("microsoft-edge:https://www.bing.com/search?q=" + texto);
            }
            else{
                MessageBox.Show("É necesário selecionar um termo para pesquisar.", "Buscar com o Bing",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void selecionarTudoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            rchTxtBxConteudo.SelectAll();
        }

        private void horadataToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Ira sempre colocar em uma linha abaixo de onde esta o cursor
            rchTxtBxConteudo.SelectedText = System.Environment.NewLine + DateTime.Now;
        }

        private void quebraAutomaticaDeLinhaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(quebraAutomaticaDeLinhaToolStripMenuItem.CheckState == CheckState.Checked)
            {
                quebraAutomaticaDeLinhaToolStripMenuItem.CheckState = CheckState.Unchecked;
                rchTxtBxConteudo.WordWrap = false;
            }
            else
            {
                quebraAutomaticaDeLinhaToolStripMenuItem.CheckState = CheckState.Checked;
                rchTxtBxConteudo.WordWrap = true;
            }
        }

        private void configurarPáginaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pgStpDlgConfiguraPagina.ShowDialog();
        }

        private void imprimirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            prImprimirntDlg.ShowDialog();
        }

        private void sairToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void novaJanelaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form1 frm = new Form1();
            frm.Show();
        }

        private void novoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!alterado)
            {
                // Limpa/exclui o nome de titulo do arquivo e conteudo
                this.Text = "";
                rchTxtBxConteudo.Text = "";
            }
            else
            {
                if (MessageBox.Show("Arquivo alterado. Deseja salvar?", "Bloco de Notas",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    this.Text = "";
                    rchTxtBxConteudo.Text = "";
                }
                else
                {
                    if (this.Text != "")  //significa que ja existe um arquivo aberto
                    {
                        this.salvar(this.Text);
                    }
                    else
                    {
                        this.salvarComo();
                    }
                }
            }
        }

        private void fonteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(fntDlgFonte.ShowDialog() == DialogResult.OK)
            {
                rchTxtBxConteudo.SelectionFont = fntDlgFonte.Font;
            }
        }

        private void barraDeStatusToolStripMenuItem_Click(object sender, EventArgs e)
        {
            barraDeStatusToolStripMenuItem.Checked = !barraDeStatusToolStripMenuItem.Checked;
            sttsStrpInformacoes.Visible = !sttsStrpInformacoes.Visible;
        }


        private void atualizaZoom()
        {
            tlStrpSttsLblZoom.Text = this.zoom.ToString() + "%";
        }

        private void ampliarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //aumenta o tamanho da fonte!
            this.zoom++;
            rchTxtBxConteudo.Font = new Font(rchTxtBxConteudo.Font.FontFamily, rchTxtBxConteudo.Font.Size + 1, rchTxtBxConteudo.Font.Style);
            this.atualizaZoom();
        }

        private void reduzirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //diminui o tamanho da fonte!
            this.zoom--;
            rchTxtBxConteudo.Font = new Font(rchTxtBxConteudo.Font.FontFamily, rchTxtBxConteudo.Font.Size - 1, rchTxtBxConteudo.Font.Style);
            this.atualizaZoom();
        }

        private void restaurarZoomPadrãoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.zoom = 100;
            rchTxtBxConteudo.Font = new Font(rchTxtBxConteudo.Font.FontFamily, 12, rchTxtBxConteudo.Font.Style);
            this.atualizaZoom();
        }

        private void corToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(clrDlgCor.ShowDialog() == DialogResult.OK)
            {
                rchTxtBxConteudo.SelectionColor = clrDlgCor.Color;
            }
        }

        private void substituirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Substituir frm = new Substituir();
            frm.txtBxLocaliza.Text = rchTxtBxConteudo.SelectedText;
            frm.Show(this);
        }

        private void localizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Localizar frm = new Localizar();
            frm.txtBxLocaliza.Text = rchTxtBxConteudo.SelectedText;
            frm.Show(this);
        }
    }
}
