﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Text;
using System.IO;

namespace Sezione_Aureawe
{
    public partial class Initial : UserControl
    {
        public Main parentForm { get; set; }
        public static readonly string resourcesPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources";
        public Initial()
        {
            InitializeComponent();
          //  SetStyle(ControlStyles.SupportsTransparentBackColor, true);
           // SetStyle(ControlStyles.Opaque, true);
            //labLuda.BackColor = Color.Transparent;
          //  this.BackColor = Color.Transparent;
          //  labLuda.Font = new System.Drawing.Font(pfc.Families[0], 58, FontStyle.Bold);
            //pfc.AddFontFile(resourcesPath+"\\Quicksand-Regular.ttf");

            //labLuda.Font = new System.Drawing.Font(pfc.Families[0], 58, FontStyle.Bold);

        }
        public void setPos(int w, int h)
        {
            int offset = 100;
            Location = new Point(offset, offset);
            Width = w - 2 * offset;
            Height = h - 2 * offset;
            title_uda.Location = new Point(w/2- title_uda.Width /2 - offset + 50, 10);
            label1.Location = new Point(w / 2 - title_uda.Width / 2 - offset + 280, 200);
            label2.Location = new Point(w / 2 - title_uda.Width / 2 - offset + 280, 250);
        }

        private void Initial_Load(object sender, EventArgs e)
        {

        }

        private void labLuda_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            //this.Visible = false;
            //parentForm.onStart();
        }
    }
}
