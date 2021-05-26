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
using System.Media;
using System.IO;

namespace Sezione_Aureawe
{
    
    public partial class Activity : UserControl
    {
        public Main parentForm { get; set; }
        public int trial = 0;
        public int timeleft=10;
        public string k;
        public string put_wait_data;
        public string put_started;
        public string get_status_uda;
        public Activity()
        {
            put_wait_data = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/put/?i=3&k=14";
            put_started = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/put/?i=3&k=7";
            InitializeComponent();
            resetOperations();
            get_status_uda = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/get/?i=3";
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
            this.Update();        
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
            this.Update();
            


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
            timerLabel.Text = "10";
            timerLabel.Visible = true;
            this.Update();
            label1.Visible = true;
            this.Update();
            timer1.Start();
            this.Update();

        }
        public async void Images_Sounds(string a,string b, string c, string d)
        {
            while (true)
            {
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (status != 9)
                {
                    pbOne.WaitOnLoad = true;
                    pbOne.ImageLocation = Main.resourcesPath + "\\" + a + ".png";
                    pbOne.Visible = true;
                    this.Update();
                    parentForm.playbackResourceAudio(c);
                    Thread.Sleep(2000);
                    break;
                }
            }
            while (true)
            {
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (status != 9)
                {
                    pbTwo.WaitOnLoad = true;
                    pbTwo.ImageLocation = Main.resourcesPath + "\\" + b + ".png";
                    pbTwo.Visible = true;
                    this.Update();
                    parentForm.playbackResourceAudio(d);
                    Thread.Sleep(2000);
                    break;
                }
            }
          
            while (true)
            {
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (status != 9)
                {
                    await uda_server_communication.Server_Request(put_wait_data);
                    break;
                }
               
            }
           
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
            else if (i == 3)
            {
                Images_Sounds("Polygon", "Pentagon", "Suono5_False", "Suono5_True");
            }
            else if (i == 4)
            {
                Images_Sounds("phi", "pigreco", "Suono6_True", "Suono6_False");
            }
            else if (i == 5)
            {
                Images_Sounds("seahorse", "semaforo", "Suono7_True", "Suono7_False");
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
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (timeleft > 0)
            {
  
                while (true)
                {
                    k = parentForm.Status_Changed(parentForm.activity_form);
                    int status = int.Parse(k);
                    if (status != 9)
                    {
                        timeleft = timeleft - 1;
                        timerLabel.Text = timeleft.ToString();
                        while(true){
                            if (status == 15)
                            {
                                string data = await uda_server_communication.Server_Request_datasent(get_status_uda);
                                timer1.Stop();
                                timerLabel.Visible = false;
                                if (trial == 1 || trial == 4 || trial == 5)
                                {
                                    if (String.Equals(data, "1"))
                                    {
                                        Correct_Answer();
                                        Thread.Sleep(4000);
                                        await uda_server_communication.Server_Request(put_started);
                                        parentForm.step++;
                                        this.Hide();
                                        timeleft = 10;
                                        parentForm.onStart(parentForm.onstart_form);
                                    }
                                    else 
                                    {
                                        Wrong_Answer();
                                        Thread.Sleep(4000);
                                        await uda_server_communication.Server_Request(put_started);
                                        parentForm.step++;
                                        this.Hide();
                                        timeleft = 10;
                                        parentForm.onStart(parentForm.onstart_form);
                                    }

                                }
                                else if (trial == 2 || trial == 3)
                                {
                                    if (String.Equals(data, "2"))
                                    {
                                        Correct_Answer();
                                        Thread.Sleep(4000);
                                        await uda_server_communication.Server_Request(put_started);
                                        parentForm.step++;
                                        this.Hide();
                                        timeleft = 10;
                                        parentForm.onStart(parentForm.onstart_form);
                                    }
                                    else 
                                    {
                                        Wrong_Answer();
                                        Thread.Sleep(4000);
                                        await uda_server_communication.Server_Request(put_started);
                                        parentForm.step++;
                                        this.Hide();
                                        timeleft = 10;
                                        parentForm.onStart(parentForm.onstart_form);
                                    }
                                }

                               }
                        
                            break;
                        }
                        break;
                    }
                }
                
            }
            if (timeleft == 0)
            {
                Out_of_time();
                if (trial == 1 || trial == 4 || trial == 5) 
                { 
                    Feedback.Text = "HAI FINITO IL TEMPO! L'IMMAGINE GIUSTA ERA LA UNO";
                this.Update();
            }
            else if (trial == 2 || trial == 3)
            {
                Feedback.Text = "HAI FINITO IL TEMPO! L'IMMAGINE GIUSTA ERA LA DUE";
                this.Update();
            }
                Thread.Sleep(4000);
                while (true)
                {
                    k = parentForm.Status_Changed(parentForm.activity_form);
                    int status = int.Parse(k);
                    if (status != 9)
                    {
                        parentForm.step++;
                        this.Hide();
                        timeleft = 10;
                        parentForm.onStart(parentForm.onstart_form);
                        await uda_server_communication.Server_Request(put_started);
                        break;
                    }
                }
            }
           
            
           
        }

        private void btn_DUE_Click(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            

        }
    }
}
