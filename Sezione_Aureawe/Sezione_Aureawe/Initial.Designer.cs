namespace Sezione_Aureawe
{
    partial class Initial
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.labLuda = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.title_uda = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_uda)).BeginInit();
            this.SuspendLayout();
            // 
            // labLuda
            // 
            this.labLuda.AutoSize = true;
            this.labLuda.BackColor = System.Drawing.Color.Transparent;
            this.labLuda.Font = new System.Drawing.Font("Quicksand", 51F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labLuda.ForeColor = System.Drawing.Color.Gold;
            this.labLuda.Location = new System.Drawing.Point(31, 216);
            this.labLuda.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.labLuda.Name = "labLuda";
            this.labLuda.Size = new System.Drawing.Size(0, 152);
            this.labLuda.TabIndex = 2;
            this.labLuda.Click += new System.EventHandler(this.labLuda_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(690, 439);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(548, 302);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            // 
            // title_uda
            // 
            this.title_uda.Image = global::Sezione_Aureawe.Properties.Resources.Screenshot_from_2022_10_13_15_30_13;
            this.title_uda.Location = new System.Drawing.Point(173, 245);
            this.title_uda.Name = "title_uda";
            this.title_uda.Size = new System.Drawing.Size(1588, 106);
            this.title_uda.TabIndex = 4;
            this.title_uda.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Quicksand", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(455, 394);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(733, 54);
            this.label1.TabIndex = 5;
            this.label1.Text = "Scegli le immagini che più si legano alla ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Quicksand", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(455, 483);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(753, 54);
            this.label2.TabIndex = 6;
            this.label2.Text = "sezione aurea e ricostruisci la sua forma! ";
            // 
            // Initial
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(146)))), ((int)(((byte)(207)))));
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.title_uda);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.labLuda);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Initial";
            this.Size = new System.Drawing.Size(1764, 746);
            this.Load += new System.EventHandler(this.Initial_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.title_uda)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labLuda;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.PictureBox title_uda;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
    }
}
