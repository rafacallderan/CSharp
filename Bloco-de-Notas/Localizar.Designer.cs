
namespace Bloco_de_Notas
{
    partial class Localizar
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnCancelar = new System.Windows.Forms.Button();
            this.btnSubstitui = new System.Windows.Forms.Button();
            this.txtBxLocaliza = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.chckBxCaseSensitive = new System.Windows.Forms.CheckBox();
            this.chckBxPalavraInteira = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // btnCancelar
            // 
            this.btnCancelar.Location = new System.Drawing.Point(259, 42);
            this.btnCancelar.Name = "btnCancelar";
            this.btnCancelar.Size = new System.Drawing.Size(136, 23);
            this.btnCancelar.TabIndex = 11;
            this.btnCancelar.Text = "Cancelar";
            this.btnCancelar.UseVisualStyleBackColor = true;
            this.btnCancelar.Click += new System.EventHandler(this.btnCancelar_Click);
            // 
            // btnSubstitui
            // 
            this.btnSubstitui.Location = new System.Drawing.Point(259, 9);
            this.btnSubstitui.Name = "btnSubstitui";
            this.btnSubstitui.Size = new System.Drawing.Size(136, 23);
            this.btnSubstitui.TabIndex = 10;
            this.btnSubstitui.Text = "Localizar todas...";
            this.btnSubstitui.UseVisualStyleBackColor = true;
            this.btnSubstitui.Click += new System.EventHandler(this.btnSubstitui_Click);
            // 
            // txtBxLocaliza
            // 
            this.txtBxLocaliza.Location = new System.Drawing.Point(69, 12);
            this.txtBxLocaliza.Name = "txtBxLocaliza";
            this.txtBxLocaliza.Size = new System.Drawing.Size(175, 20);
            this.txtBxLocaliza.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Localizar:";
            // 
            // chckBxCaseSensitive
            // 
            this.chckBxCaseSensitive.AutoSize = true;
            this.chckBxCaseSensitive.Location = new System.Drawing.Point(14, 47);
            this.chckBxCaseSensitive.Name = "chckBxCaseSensitive";
            this.chckBxCaseSensitive.Size = new System.Drawing.Size(202, 17);
            this.chckBxCaseSensitive.TabIndex = 12;
            this.chckBxCaseSensitive.Text = "Diferenciar maiúsculas de minúsculas\r\n";
            this.chckBxCaseSensitive.UseVisualStyleBackColor = true;
            // 
            // chckBxPalavraInteira
            // 
            this.chckBxPalavraInteira.AutoSize = true;
            this.chckBxPalavraInteira.Location = new System.Drawing.Point(14, 70);
            this.chckBxPalavraInteira.Name = "chckBxPalavraInteira";
            this.chckBxPalavraInteira.Size = new System.Drawing.Size(135, 17);
            this.chckBxPalavraInteira.TabIndex = 13;
            this.chckBxPalavraInteira.Text = "Coincidir palavra inteira";
            this.chckBxPalavraInteira.UseVisualStyleBackColor = true;
            // 
            // Localizar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 99);
            this.Controls.Add(this.chckBxPalavraInteira);
            this.Controls.Add(this.chckBxCaseSensitive);
            this.Controls.Add(this.btnCancelar);
            this.Controls.Add(this.btnSubstitui);
            this.Controls.Add(this.txtBxLocaliza);
            this.Controls.Add(this.label1);
            this.Name = "Localizar";
            this.Text = "Localizar";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnCancelar;
        private System.Windows.Forms.Button btnSubstitui;
        public System.Windows.Forms.TextBox txtBxLocaliza;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckBox chckBxCaseSensitive;
        private System.Windows.Forms.CheckBox chckBxPalavraInteira;
    }
}
