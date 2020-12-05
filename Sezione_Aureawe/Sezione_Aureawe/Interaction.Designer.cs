namespace Sezione_Aureawe
{
    partial class Interaction
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
            this.star1 = new System.Windows.Forms.PictureBox();
            this.star2 = new System.Windows.Forms.PictureBox();
            this.pezzo0 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.star1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pezzo0)).BeginInit();
            this.SuspendLayout();
            // 
            // star1
            // 
            this.star1.BackColor = System.Drawing.Color.Transparent;
            this.star1.Image = global::Sezione_Aureawe.Properties.Resources.stella;
            this.star1.Location = new System.Drawing.Point(234, 352);
            this.star1.Name = "star1";
            this.star1.Size = new System.Drawing.Size(100, 50);
            this.star1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star1.TabIndex = 0;
            this.star1.TabStop = false;
            // 
            // star2
            // 
            this.star2.BackColor = System.Drawing.Color.Transparent;
            this.star2.Image = global::Sezione_Aureawe.Properties.Resources.stella;
            this.star2.Location = new System.Drawing.Point(187, 576);
            this.star2.Name = "star2";
            this.star2.Size = new System.Drawing.Size(100, 50);
            this.star2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star2.TabIndex = 1;
            this.star2.TabStop = false;
            this.star2.Click += new System.EventHandler(this.star2_Click);
            // 
            // pezzo0
            // 
            this.pezzo0.BackColor = System.Drawing.Color.Transparent;
            this.pezzo0.Image = global::Sezione_Aureawe.Properties.Resources.Pezzo_0;
            this.pezzo0.Location = new System.Drawing.Point(141, 399);
            this.pezzo0.Name = "pezzo0";
            this.pezzo0.Size = new System.Drawing.Size(218, 186);
            this.pezzo0.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pezzo0.TabIndex = 2;
            this.pezzo0.TabStop = false;
            // 
            // Interaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Sezione_Aureawe.Properties.Resources.Transparency_background;
            this.Controls.Add(this.star2);
            this.Controls.Add(this.pezzo0);
            this.Controls.Add(this.star1);
            this.Name = "Interaction";
            this.Size = new System.Drawing.Size(767, 696);
            this.Load += new System.EventHandler(this.Interaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.star1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pezzo0)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox star1;
        private System.Windows.Forms.PictureBox star2;
        private System.Windows.Forms.PictureBox pezzo0;
    }
}
