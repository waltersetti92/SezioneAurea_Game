﻿namespace Sezione_Aureawe
{
    partial class Activity
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
            this.pbOne = new System.Windows.Forms.PictureBox();
            this.pbTwo = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_UNO = new System.Windows.Forms.Button();
            this.btn_DUE = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pbOne)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTwo)).BeginInit();
            this.SuspendLayout();
            // 
            // pbOne
            // 
            this.pbOne.BackColor = System.Drawing.Color.Transparent;
            this.pbOne.Image = global::Sezione_Aureawe.Properties.Resources.group1;
            this.pbOne.Location = new System.Drawing.Point(435, 174);
            this.pbOne.Name = "pbOne";
            this.pbOne.Size = new System.Drawing.Size(214, 179);
            this.pbOne.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOne.TabIndex = 22;
            this.pbOne.TabStop = false;
            // 
            // pbTwo
            // 
            this.pbTwo.BackColor = System.Drawing.Color.Transparent;
            this.pbTwo.Location = new System.Drawing.Point(702, 174);
            this.pbTwo.Name = "pbTwo";
            this.pbTwo.Size = new System.Drawing.Size(219, 179);
            this.pbTwo.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbTwo.TabIndex = 23;
            this.pbTwo.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Snap ITC", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.Blue;
            this.label1.Location = new System.Drawing.Point(523, 369);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(378, 27);
            this.label1.TabIndex = 24;
            this.label1.Text = "QUALE IMMAGINE SCEGLI?";
            // 
            // btn_UNO
            // 
            this.btn_UNO.Font = new System.Drawing.Font("Snap ITC", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_UNO.ForeColor = System.Drawing.Color.Blue;
            this.btn_UNO.Location = new System.Drawing.Point(558, 413);
            this.btn_UNO.Name = "btn_UNO";
            this.btn_UNO.Size = new System.Drawing.Size(76, 40);
            this.btn_UNO.TabIndex = 25;
            this.btn_UNO.Text = "UNO";
            this.btn_UNO.UseVisualStyleBackColor = true;
            this.btn_UNO.Click += new System.EventHandler(this.btn_UNO_Click);
            // 
            // btn_DUE
            // 
            this.btn_DUE.Font = new System.Drawing.Font("Snap ITC", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_DUE.ForeColor = System.Drawing.Color.Blue;
            this.btn_DUE.Location = new System.Drawing.Point(767, 413);
            this.btn_DUE.Name = "btn_DUE";
            this.btn_DUE.Size = new System.Drawing.Size(76, 40);
            this.btn_DUE.TabIndex = 26;
            this.btn_DUE.Text = "DUE";
            this.btn_DUE.UseVisualStyleBackColor = true;
            // 
            // Activity
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.btn_DUE);
            this.Controls.Add(this.btn_UNO);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pbTwo);
            this.Controls.Add(this.pbOne);
            this.Name = "Activity";
            this.Size = new System.Drawing.Size(985, 592);
            this.Load += new System.EventHandler(this.Activity_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbOne)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbTwo)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pbOne;
        private System.Windows.Forms.PictureBox pbTwo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_UNO;
        private System.Windows.Forms.Button btn_DUE;
    }
}
