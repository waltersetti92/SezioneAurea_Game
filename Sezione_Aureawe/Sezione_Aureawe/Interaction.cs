﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace Sezione_Aureawe
{
    public partial class Interaction : UserControl
    {
        public Main parentForm { get; set; }
        public Interaction()
        {
            InitializeComponent();
            star1.Visible = false;
            star2.Visible = false;
            pezzo0.Visible = false;
            home_first_scene();
        }

        public void home_first_scene()
        {
            Thread.Sleep(1000);
            star1.Visible = true;
            this.Update();
            
        }
        public void setPos(int w, int h)
        {

            int offset = 0;
            Location = new Point(offset, offset);
            Width = w - 1 * offset;
            Height = h - 1 * offset;

        }
        private void Interaction_Load(object sender, EventArgs e)
        {

        }

        private void star2_Click(object sender, EventArgs e)
        {

        }
    }
}
