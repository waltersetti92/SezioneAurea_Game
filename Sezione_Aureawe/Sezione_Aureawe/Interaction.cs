using System;
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
            gioca_btn.Visible = true;
            star1.Visible = false;
            star2.Visible = false;
            pezzo0.Visible = false;
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

        private void button1_Click(object sender, EventArgs e)
        {
            if (parentForm.step == 1)
            {
                star1.Visible = false;
                this.Update();
                star2.Visible = false;
                this.Update();
                star2.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono1_True");
                Thread.Sleep(3000);
                star2.Visible = false;
                this.Update();
                star1.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono2_True");
                Thread.Sleep(3000);
                star2.Visible = true;
                this.Update();
               // gioca_btn.Visible = true;
               // this.Update();
            }
        }

        private void gioca_btn_Click(object sender, EventArgs e)
        {
            parentForm.activity();
        }
    }
}
