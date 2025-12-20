namespace Petshop_Projesi_Otomasyon
{
    partial class Form1
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
            this.btnMusteriIslemleri = new System.Windows.Forms.Button();
            this.btnHayvanislemleri = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnMusteriIslemleri
            // 
            this.btnMusteriIslemleri.Location = new System.Drawing.Point(80, 94);
            this.btnMusteriIslemleri.Name = "btnMusteriIslemleri";
            this.btnMusteriIslemleri.Size = new System.Drawing.Size(167, 52);
            this.btnMusteriIslemleri.TabIndex = 0;
            this.btnMusteriIslemleri.Text = "MÜŞTERİ  İŞLEMLERİ";
            this.btnMusteriIslemleri.UseVisualStyleBackColor = true;
            this.btnMusteriIslemleri.Click += new System.EventHandler(this.btnMusteriIslemleri_Click);
            // 
            // btnHayvanislemleri
            // 
            this.btnHayvanislemleri.Location = new System.Drawing.Point(80, 173);
            this.btnHayvanislemleri.Name = "btnHayvanislemleri";
            this.btnHayvanislemleri.Size = new System.Drawing.Size(167, 49);
            this.btnHayvanislemleri.TabIndex = 1;
            this.btnHayvanislemleri.Text = "HAYVAN İŞLEMLERİ";
            this.btnHayvanislemleri.UseVisualStyleBackColor = true;
            this.btnHayvanislemleri.Click += new System.EventHandler(this.btnHayvanislemleri_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnHayvanislemleri);
            this.Controls.Add(this.btnMusteriIslemleri);
            this.Name = "Form1";
            this.Text = "AnaMenü";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnMusteriIslemleri;
        private System.Windows.Forms.Button btnHayvanislemleri;
    }
}

