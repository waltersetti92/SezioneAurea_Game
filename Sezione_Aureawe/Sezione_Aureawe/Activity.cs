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
            button1.Visible = false;
            btn_UNO.Enabled = true;
            btn_DUE.Enabled = true;
            btn_UNO.BackColor = Color.LightGray;
            btn_DUE.BackColor = Color.LightGray;
        }
        public void setPos(int w, int h)
        {

            int offset = 0;
            Location = new Point(offset, offset);
            Width = w - 1 * offset;
            Height = h - 1 * offset;

        }
        public void Correct_Answer()
        {
            parentForm.playbackResourceAudio("success");
            Feedback.ForeColor = Color.Green;
            Feedback.Visible = true;
            this.Feedback.Location = new Point(485, 518);
            btn_DUE.Enabled = false;
            btn_DUE.BackColor = Color.Green;
            btn_UNO.Enabled = false;
            btn_UNO.BackColor = Color.Green;
            Feedback.Text = "RISPOSTA CORRETTA";
        }
        public void Wrong_Answer()
        {

            parentForm.playbackResourceAudio("failure");
            Feedback.ForeColor = Color.Red;
            Feedback.Visible = true;
            this.Feedback.Location = new Point(485, 518);
            btn_DUE.Enabled = false;
            btn_DUE.BackColor = Color.Red;
            btn_UNO.Enabled = false;
            btn_UNO.BackColor = Color.Red;
            Feedback.Text = "RISPOSTA SBAGLIATA";

        }
        public void Out_of_time()
        {

            btn_UNO.Enabled = false;
            btn_DUE.Enabled = false;
            timer1.Stop();
            timerLabel.Text = "";
            parentForm.playbackResourceAudio("failure");
            Feedback.ForeColor = Color.Red;
            btn_DUE.BackColor = Color.Red;
            btn_UNO.BackColor = Color.Red;
            this.Feedback.Location = new Point(171, 518);
            Feedback.Visible = true;

        }
        public void Appear_Button()
        {
            timerLabel.Text = "6";
            timerLabel.Visible = true;
            this.Update();
            label1.Visible = true;
            this.Update();
            btn_UNO.Visible = true;
            this.Update();
            btn_DUE.Visible = true;
            timer1.Start();
            this.Update();

        }
        public void Images_Sounds(string a,string b, string c, string d)
        {
            pbOne.WaitOnLoad = true;
            pbOne.ImageLocation = Main.resourcesPath + "\\" + a + ".png";
            pbOne.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio(c);
            Thread.Sleep(3000);
            pbTwo.WaitOnLoad = true;
            pbTwo.ImageLocation = Main.resourcesPath + "\\" + b + ".png";
            pbTwo.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio(d);
            Thread.Sleep(3000);

        }
        public void setOperationsIcons(int i)
        {
            resetOperations();
          
            if (i == 1)
            {
                Images_Sounds("TeoremaPitagora","circle","Suono3_True","Suono3_False");                            
            }
            else if (i==2)
            {
                Images_Sounds("numberlines", "fibonacci", "Suono4_False", "Suono4_True");            
            }
            Appear_Button();
           
        }
        
        private void Activity_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            timer1.Stop();
                   
        }

        private void btn_UNO_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timerLabel.Visible = false;
            if (trial == 1)
            {
                Correct_Answer();
            }
            else if (trial == 2)
            {
                Wrong_Answer();
            }
            button1.Visible = true;
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
                Out_of_time();    
                Feedback.Text = "HAI FINITO IL TEMPO! L'IMMAGINE GIUSTA ERA LA UNO";
                button1.Visible = true;
            }
           
            
           
        }

        private void btn_DUE_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            timerLabel.Visible = false;
            if (trial == 1)
            {
                Wrong_Answer();
            }
            else if (trial==2)
            {
                Correct_Answer();
            }
            button1.Visible = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            parentForm.step++;
            this.Hide();
            parentForm.onStart();


        }
    }
}
