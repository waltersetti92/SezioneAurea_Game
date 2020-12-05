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
            this.Listen = new System.Windows.Forms.Button();
            this.gioca_btn = new System.Windows.Forms.Button();
            this.star3 = new System.Windows.Forms.PictureBox();
            this.pezzo1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.star1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pezzo0)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.star3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pezzo1)).BeginInit();
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
            // Listen
            // 
            this.Listen.Font = new System.Drawing.Font("Snap ITC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Listen.ForeColor = System.Drawing.Color.Blue;
            this.Listen.Location = new System.Drawing.Point(27, 651);
            this.Listen.Name = "Listen";
            this.Listen.Size = new System.Drawing.Size(332, 30);
            this.Listen.TabIndex = 3;
            this.Listen.Text = "ASCOLTA LA SEQUENZA";
            this.Listen.UseVisualStyleBackColor = true;
            this.Listen.Click += new System.EventHandler(this.button1_Click);
            // 
            // gioca_btn
            // 
            this.gioca_btn.Font = new System.Drawing.Font("Snap ITC", 12.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.gioca_btn.ForeColor = System.Drawing.Color.Blue;
            this.gioca_btn.Location = new System.Drawing.Point(374, 651);
            this.gioca_btn.Name = "gioca_btn";
            this.gioca_btn.Size = new System.Drawing.Size(105, 30);
            this.gioca_btn.TabIndex = 4;
            this.gioca_btn.Text = "GIOCA!";
            this.gioca_btn.UseVisualStyleBackColor = true;
            this.gioca_btn.Visible = false;
            this.gioca_btn.Click += new System.EventHandler(this.gioca_btn_Click);
            // 
            // star3
            // 
            this.star3.BackColor = System.Drawing.Color.Transparent;
            this.star3.Image = global::Sezione_Aureawe.Properties.Resources.stella;
            this.star3.Location = new System.Drawing.Point(411, 131);
            this.star3.Name = "star3";
            this.star3.Size = new System.Drawing.Size(100, 50);
            this.star3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.star3.TabIndex = 5;
            this.star3.TabStop = false;
            // 
            // pezzo1
            // 
            this.pezzo1.Image = global::Sezione_Aureawe.Properties.Resources.Pezzo_1;
            this.pezzo1.Location = new System.Drawing.Point(234, 175);
            this.pezzo1.Name = "pezzo1";
            this.pezzo1.Size = new System.Drawing.Size(218, 186);
            this.pezzo1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pezzo1.TabIndex = 6;
            this.pezzo1.TabStop = false;
            // 
            // Interaction
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.BackgroundImage = global::Sezione_Aureawe.Properties.Resources.Transparency_background;
            this.Controls.Add(this.star3);
            this.Controls.Add(this.star1);
            this.Controls.Add(this.pezzo1);
            this.Controls.Add(this.gioca_btn);
            this.Controls.Add(this.Listen);
            this.Controls.Add(this.star2);
            this.Controls.Add(this.pezzo0);
            this.Name = "Interaction";
            this.Size = new System.Drawing.Size(767, 696);
            this.Load += new System.EventHandler(this.Interaction_Load);
            ((System.ComponentModel.ISupportInitialize)(this.star1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pezzo0)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.star3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pezzo1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox star1;
        private System.Windows.Forms.PictureBox star2;
        private System.Windows.Forms.PictureBox pezzo0;
        private System.Windows.Forms.Button Listen;
        private System.Windows.Forms.Button gioca_btn;
        private System.Windows.Forms.PictureBox star3;
        private System.Windows.Forms.PictureBox pezzo1;
    }
}
