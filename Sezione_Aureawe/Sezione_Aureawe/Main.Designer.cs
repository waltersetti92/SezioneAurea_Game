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
            this.activity1.Location = new System.Drawing.Point(-27, 33);
            this.activity1.Name = "activity1";
            this.activity1.parentForm = null;
            this.activity1.Size = new System.Drawing.Size(734, 343);
            this.activity1.TabIndex = 2;
            // 
            // interaction1
            // 
            this.interaction1.BackColor = System.Drawing.SystemColors.Control;
            this.interaction1.BackgroundImage = global::Sezione_Aureawe.Properties.Resources.Transparency_background;
            this.interaction1.Location = new System.Drawing.Point(-117, 33);
            this.interaction1.Name = "interaction1";
            this.interaction1.parentForm = null;
            this.interaction1.Size = new System.Drawing.Size(767, 365);
            this.interaction1.TabIndex = 1;
            // 
            // initial1
            // 
            this.initial1.BackColor = System.Drawing.Color.Transparent;
            this.initial1.Location = new System.Drawing.Point(22, 12);
            this.initial1.Name = "initial1";
            this.initial1.parentForm = null;
            this.initial1.Size = new System.Drawing.Size(904, 537);
            this.initial1.TabIndex = 0;
            this.initial1.Load += new System.EventHandler(this.initial1_Load);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(1078, 674);
            this.Controls.Add(this.activity1);
            this.Controls.Add(this.interaction1);
            this.Controls.Add(this.initial1);
            this.Name = "Main";
            this.Text = "Golden_Section";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Main_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private Initial initial1;
        private Interaction interaction1;
        private Activity activity1;
    }
}

