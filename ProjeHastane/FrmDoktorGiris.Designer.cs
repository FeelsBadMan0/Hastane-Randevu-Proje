﻿namespace ProjeHastane
{
    partial class FrmDoktorGiris
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmDoktorGiris));
            this.btnHastaGiris = new System.Windows.Forms.Button();
            this.mskTC = new System.Windows.Forms.MaskedTextBox();
            this.txtDoktorSifre = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btnHastaGiris
            // 
            this.btnHastaGiris.Location = new System.Drawing.Point(257, 254);
            this.btnHastaGiris.Name = "btnHastaGiris";
            this.btnHastaGiris.Size = new System.Drawing.Size(91, 34);
            this.btnHastaGiris.TabIndex = 13;
            this.btnHastaGiris.Text = "Giriş Yap";
            this.btnHastaGiris.UseVisualStyleBackColor = true;
            this.btnHastaGiris.Click += new System.EventHandler(this.btnHastaGiris_Click);
            // 
            // mskTC
            // 
            this.mskTC.Location = new System.Drawing.Point(222, 149);
            this.mskTC.Mask = "00000000000";
            this.mskTC.Name = "mskTC";
            this.mskTC.Size = new System.Drawing.Size(165, 31);
            this.mskTC.TabIndex = 11;
            this.mskTC.ValidatingType = typeof(int);
            // 
            // txtDoktorSifre
            // 
            this.txtDoktorSifre.Location = new System.Drawing.Point(222, 194);
            this.txtDoktorSifre.Name = "txtDoktorSifre";
            this.txtDoktorSifre.Size = new System.Drawing.Size(165, 31);
            this.txtDoktorSifre.TabIndex = 10;
            this.txtDoktorSifre.UseSystemPasswordChar = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(84, 197);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(50, 23);
            this.label3.TabIndex = 9;
            this.label3.Text = "Şifre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(84, 152);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 23);
            this.label2.TabIndex = 8;
            this.label2.Text = "TC Kimlik No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe Script", 26.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(88, 43);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(389, 57);
            this.label1.TabIndex = 7;
            this.label1.Text = "Doktor Giriş Paneli";
            // 
            // FrmDoktorGiris
            // 
            this.AcceptButton = this.btnHastaGiris;
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 23F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.LightSeaGreen;
            this.ClientSize = new System.Drawing.Size(562, 342);
            this.Controls.Add(this.btnHastaGiris);
            this.Controls.Add(this.mskTC);
            this.Controls.Add(this.txtDoktorSifre);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Corbel", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(5);
            this.MaximizeBox = false;
            this.Name = "FrmDoktorGiris";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Doktor Giriş";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnHastaGiris;
        private System.Windows.Forms.MaskedTextBox mskTC;
        private System.Windows.Forms.TextBox txtDoktorSifre;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
    }
}