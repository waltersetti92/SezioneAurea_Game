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
using System.Media;
using System.IO;
using Newtonsoft.Json.Linq;

namespace Sezione_Aureawe
{

    public partial class Activity : UserControl
    {
        public Main parentForm { get; set; }
        public int trial = 0;
        public int timeleft = 10;
        public string k;
        public string put_started;
        public string get_status_uda;
        public int wait;
        public string data_started1;


        public async void PutStarted()
        {
            await uda_server_communication.Server_Request("api/uda/put/?i=1&k=7&data=" + parentForm.data_start);

        }
        public Activity()
        {
            InitializeComponent();
            timeleft = 10;
            resetOperations();
            wait = 0;
            get_status_uda = "api/uda/get/?i=1";

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
            Feedback.ForeColor = Color.Yellow;
            Feedback.Visible = true;
            this.Feedback.Location = new Point(485, 518);
            btn_DUE.Enabled = false;
            btn_DUE.BackColor = Color.Yellow;
            btn_UNO.Enabled = false;
            btn_UNO.BackColor = Color.Yellow;
            Feedback.Text = "RISPOSTA CORRETTA";
            parentForm.contatore_iniziale = 0;
            this.Update();
            PutStarted();
        }
        public void Wrong_Answer()
        {
            parentForm.playbackResourceAudio("failure");
            Feedback.ForeColor = Color.DarkRed;
            Feedback.Visible = true;
            this.Feedback.Location = new Point(485, 518);
            btn_DUE.Enabled = false;
            btn_DUE.BackColor = Color.DarkRed;
            btn_UNO.Enabled = false;
            btn_UNO.BackColor = Color.DarkRed;
            Feedback.Text = "RISPOSTA SBAGLIATA";
            parentForm.contatore_iniziale = 0;
            this.Update();
            PutStarted();
        }
        public void Out_of_time()
        {
            btn_UNO.Enabled = false;
            btn_DUE.Enabled = false;
            timer1.Stop();
            timerLabel.Text = "";
            parentForm.playbackResourceAudio("failure");
            Feedback.ForeColor = Color.DarkRed;
            btn_DUE.BackColor = Color.DarkRed;
            btn_UNO.BackColor = Color.DarkRed;
            this.Feedback.Location = new Point(171, 518);
            Feedback.Visible = true;
            PutStarted();
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
        public async void Images_Sounds(string a, string b, string c, string d)
        {
            while (true)
            {
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (status != 9 && status != 8)
                {
                    if (status == 11 || status == 12)
                    {
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                    if (status == 13)
                    {
                        this.Hide();
                        parentForm.Abort_UDA();
                        break;
                    }
                    else if (status == 10 || status == 7)
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
                Thread.Sleep(400);
            }
            while (true)
            {
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (status != 9 && status != 8)
                {
                    if (status == 11 || status == 12)
                    {
                        System.Diagnostics.Process.GetCurrentProcess().Kill();
                    }
                    if (status == 13)
                    {
                        this.Hide();
                        parentForm.Abort_UDA();
                        break;
                    }
                    else if (status == 10 || status == 7)
                    {
                        pbTwo.WaitOnLoad = true;
                        pbTwo.ImageLocation = Main.resourcesPath + "\\" + b + ".png";
                        pbTwo.Visible = true;
                        this.Update();
                        parentForm.playbackResourceAudio(d);
                        Thread.Sleep(2000);
                        wait = 1;
                        break;
                    }
                }
                Thread.Sleep(400);
            }
            Thread.Sleep(1000);
        }
        public void setOperationsIcons(int i)
        {
            resetOperations();

            if (i == 1)
            {
                Images_Sounds("TeoremaPitagora", "circle", "Suono3_True", "Suono3_False");
            }
            else if (i == 2)
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
            timer1.Stop();
      
        }

        private void btn_UNO_Click(object sender, EventArgs e)
        {
        }
        public async void Putwaitdata()
        {
            await uda_server_communication.Server_Request("api/uda/put/?i=1&k=14&data=" + parentForm.data_start);

        }
        public void updateCountdown()
        {
            
        }

        private async void timer1_Tick(object sender, EventArgs e)
        {
            if (timeleft > 0)
            {
                timerLabel.Visible = true;
                while (true)
                {
                    k = parentForm.Status_Changed(parentForm.activity_form);
                    int status = int.Parse(k);
                    string response = null;
                    if (status != 9 && status != 8)
                    {
                        if (status == 11 || status == 12)
                        {
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }
                        if (status == 13)
                        {
                            this.Hide();
                            parentForm.Abort_UDA();
                            break;
                        }
                        if  (status == 10 && wait == 1 || status==7 && wait==1)
                        {
                            //Putwaitdata();
                            await uda_server_communication.Server_Request(parentForm.wait_data());
                        }
                        timeleft--;
                        timerLabel.Text = timeleft.ToString();
                        this.Update();
                        Thread.Sleep(1000);                                                                                    
                        if (status == 14)
                        {
                            parentForm.contatore_iniziale = 1;
                            JToken data = await uda_server_communication.Server_Request_datasent(get_status_uda);
                            if (!(data is JArray))
                            {
                                continue;
                            }
                            var explorers = data.ToObject<JArray>();
                            foreach (var explorer in data)
                            {
                                Dictionary<string, object> exp = explorer.ToObject<Dictionary<string, object>>();
                                string timestamp = (string)explorer["timestamp"];
                                if (timestamp == null || timestamp == "0000-00-00 00:00:00")
                                {
                                    continue;
                                }
                                response = (string)explorer["answer"];
                                break;
                            }
                            if (response == null) { break; }
                            timerLabel.Visible = false;
                            timer1.Stop();
                            
                            if (parentForm.trial_1 == 1 || parentForm.trial_1 == 4 || parentForm.trial_1 == 5)
                            {
                                if (String.Equals(response, "1"))
                                {
                                    Correct_Answer();
                                    Thread.Sleep(4000);
                                    PutStarted();
                                    parentForm.step++;                                
                                    this.Hide();
                                    timeleft = 10;
                                    parentForm.onStart(parentForm.onstart_form);
                                }
                                else
                                {
                                    Wrong_Answer();
                                    Thread.Sleep(4000);
                                    PutStarted();
                                    parentForm.step++;                                    
                                    this.Hide();
                                    timeleft = 10;
                                    parentForm.onStart(parentForm.onstart_form);
                                }

                            }
                            else if (parentForm.trial_1 == 2 || parentForm.trial_1 == 3)
                            {
                                if (String.Equals(response, "2"))
                                {
                                    Correct_Answer();
                                    Thread.Sleep(4000);
                                    PutStarted();
                                    parentForm.step++;
                         
                                    this.Hide();
                                    timeleft = 10;
                                    parentForm.onStart(parentForm.onstart_form);
                                }
                                else
                                {
                                    Wrong_Answer();
                                    Thread.Sleep(4000);
                                    PutStarted();
                                    parentForm.step++;
                              
                                    this.Hide();
                                    timeleft = 10;
                                    parentForm.onStart(parentForm.onstart_form);
                                }
                            }

                        }
                        break;
                    }
                    Thread.Sleep(400);
                }

                if (timeleft == 0)
                {
                    Out_of_time();
                    if (parentForm.trial_1 == 1 || parentForm.trial_1 == 4 || parentForm.trial_1 == 5)
                    {
                        Feedback.Text = "HAI FINITO IL TEMPO! L'IMMAGINE GIUSTA ERA LA UNO";
                        this.Update();
                        PutStarted();
                    }
                    else if (parentForm.trial_1 == 2 || parentForm.trial_1 == 3)
                    {
                        Feedback.Text = "HAI FINITO IL TEMPO! L'IMMAGINE GIUSTA ERA LA DUE";
                        this.Update();
                        PutStarted();
                    }
                    Thread.Sleep(4000);
                    while (true)
                    {
                        k = parentForm.Status_Changed(parentForm.activity_form);
                        int status = int.Parse(k);
                        if (status == 11 || status == 12)
                        {
                            System.Diagnostics.Process.GetCurrentProcess().Kill();
                        }
                        if (status == 13)
                        {
                            this.Hide();
                            parentForm.Abort_UDA();
                            break;
                        }
                        if (status == 7 || status == 10)
                        {
                            parentForm.step++;
                      
                            this.Hide();
                            timeleft = 10;
                            parentForm.onStart(parentForm.onstart_form);
                            break;
                        }
                        parentForm.contatore_iniziale = 0;
                        Thread.Sleep(400);
                    }
                }
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
