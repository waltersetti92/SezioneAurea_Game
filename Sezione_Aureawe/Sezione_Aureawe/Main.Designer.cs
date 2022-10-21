namespace Sezione_Aureawe
{
    partial class Main
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
            this.activity1 = new Sezione_Aureawe.Activity();
            this.interaction1 = new Sezione_Aureawe.Interaction();
            this.initial1 = new Sezione_Aureawe.Initial();
            this.SuspendLayout();
            // 
            // activity1
            // 
            this.activity1.BackColor = System.Drawing.SystemColors.Info;
            this.activity1.Location = new System.Drawing.Point(204, 229);
            this.activity1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.activity1.Name = "activity1";
            this.activity1.parentForm = null;
            this.activity1.Size = new System.Drawing.Size(1101, 528);
            this.activity1.TabIndex = 2;
            // 
            // interaction1
            // 
            this.interaction1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(146)))), ((int)(((byte)(207)))));
            this.interaction1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.interaction1.Location = new System.Drawing.Point(72, 35);
            this.interaction1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.interaction1.Name = "interaction1";
            this.interaction1.parentForm = null;
            this.interaction1.Size = new System.Drawing.Size(1150, 562);
            this.interaction1.TabIndex = 1;
            this.interaction1.Load += new System.EventHandler(this.interaction1_Load);
            // 
            // initial1
            // 
            this.initial1.AutoSize = true;
            this.initial1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.initial1.BackColor = System.Drawing.Color.Transparent;
            this.initial1.Location = new System.Drawing.Point(33, 18);
            this.initial1.Margin = new System.Windows.Forms.Padding(6, 8, 6, 8);
            this.initial1.Name = "initial1";
            this.initial1.parentForm = null;
            this.initial1.Size = new System.Drawing.Size(1761, 746);
            this.initial1.TabIndex = 0;
            this.initial1.Load += new System.EventHandler(this.initial1_Load);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(3)))), ((int)(((byte)(146)))), ((int)(((byte)(207)))));
            this.BackgroundImage = global::Sezione_Aureawe.Properties.Resources.matematica;
            this.ClientSize = new System.Drawing.Size(1617, 1037);
            this.Controls.Add(this.activity1);
            this.Controls.Add(this.interaction1);
            this.Controls.Add(this.initial1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "Main";
            this.Text = "Golden_Section";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Initial initial1;
        private Interaction interaction1;
        private Activity activity1;
    }
}

