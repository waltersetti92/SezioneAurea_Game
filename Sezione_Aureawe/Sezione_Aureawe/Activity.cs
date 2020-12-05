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
    public partial class Activity : UserControl
    {
        public Main parentForm { get; set; }
        public int trial = 0;
        public int timeleft=6;
        public Activity()
        {
            InitializeComponent();
            resetOperations();
        }
        private void resetOperations()
        {
            label1.Visible = false;
            btn_UNO.Visible = false;
            btn_DUE.Visible = false;
            pbOne.Visible = false;
            pbTwo.Visible = false;
            timerLabel.Visible = false;
            Feedback.Visible = false;
        }
        public void setPos(int w, int h)
        {

            int offset = 0;
            Location = new Point(offset, offset);
            Width = w - 1 * offset;
            Height = h - 1 * offset;

        }
        public void setOperationsIcons(int i)
        {         
            pbOne.WaitOnLoad = true;
            pbTwo.WaitOnLoad = true;
            if (i == 1)
            {
                pbOne.ImageLocation = Main.resourcesPath + "\\" + "TeoremaPitagora" + ".png";
                pbOne.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono3_True");
                Thread.Sleep(3200);
                pbTwo.ImageLocation = Main.resourcesPath + "\\" + "circle" + ".png";
                pbTwo.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono3_False");
                Thread.Sleep(3200);
                label1.Visible = true;
                this.Update();
                btn_UNO.Visible = true;
                this.Update();
                btn_DUE.Visible = true;
                this.Update();
                timerLabel.Visible = true;
                this.Update();
            }
            timer1.Start();
        }
        
        private void Activity_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Stop();
           
        }

        private void btn_UNO_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (timeleft > 0)
            {
                timeleft--;
                timerLabel.Text = timeleft.ToString();
            }
            if (timeleft == 0)
            {
                btn_UNO.Enabled = false;
                btn_DUE.Enabled = false;
                timer1.Stop();
                timerLabel.Text = "";
                parentForm.playbackResourceAudio("failure");
                Feedback.ForeColor = Color.Red;
                Feedback.Visible = true;
                if (trial == 1)
                {
                    Feedback.Text = "HAI FINITO IL TEMPO! L'IMMAGINE GIUSTA ERA LA UNO";
                }
            }
           
        }

        private void btn_DUE_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }
    }
}
