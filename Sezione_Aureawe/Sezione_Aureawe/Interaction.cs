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
        public bool pause_val;
        public string k;
        public string completed;
        public Interaction()
        {
            InitializeComponent();
            resetOperations();
            Start_Sequences();
            completed = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/put/?i=3&k=16";

        }
        private void resetOperations()
        {
            star1.Visible = false;
            star2.Visible = false;
            pezzo0.Visible = false;
            //gioca_btn.Visible = false;
            star3.Visible = false;
            star4.Visible = false;
            star5.Visible = false;
            star6.Visible = false;
            pezzo1.Visible = false;
            pezzo2.Visible = false;
            pezzo3.Visible = false;
            pezzo4.Visible = false;
            pezzo5.Visible = false;
            lbl_fin1.Visible = false;
            lbl_fin2.Visible = false;
            star1.Visible = false;
            this.Update();
            star2.Visible = false;
            this.Update();
            //Listen.Enabled = true;
        }

        public void setPos(int w, int h)
        {

            int offset = 0;
            Location = new Point(offset, offset);
            Width = w - 1 * offset;
            Height = h - 1 * offset;

        }
        public void loop_w()
        {
            while (true)
            {
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (status == 7 || status == 10 || status==15)
                {

                    break;
                }
                if (status == 11 || status == 12)
                {
                    Application.Exit();
                    Environment.Exit(0);
                    break;
                }
                if (status == 13)
                {
                    this.Hide();
                    parentForm.Abort_UDA();
                    break;
                }
            }
        }
        public void First_Sequence()
        {

           // star2.WaitOnLoad = true;
            star2.Visible = true;          
            this.Update();
            parentForm.playbackResourceAudio("Suono1_True");
            Thread.Sleep(3000);
            loop_w();
            star2.Visible = false;
            this.Update();
           // star1.WaitOnLoad = true;
            star1.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono2_True");
            Thread.Sleep(3000);
            loop_w();
            if(parentForm.step==1)
            parentForm.activity(parentForm.activity_form);
        }

        private void Interaction_Load(object sender, EventArgs e)
        {
            resetOperations();
        }

        private void star2_Click(object sender, EventArgs e)
        {

        }
        private void Sequence_1()
        {
            First_Sequence();
            star1.Visible = false;
            this.Update();
            star3.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono3_True");
            Thread.Sleep(3000);
            loop_w();
            if (parentForm.step == 2)
                parentForm.activity(parentForm.activity_form);
        }

        private void Sequence_2()
        {
            Sequence_1();
            star3.Visible = false;
            this.Update();
            star4.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono4_True");
            Thread.Sleep(3000);
            loop_w();
            if (parentForm.step == 3)
                parentForm.activity(parentForm.activity_form);
        }
        private void Sequence_3()
        {
            Sequence_2();
            star4.Visible = false;
            this.Update();
            star5.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono5_True");
            Thread.Sleep(3000);
            loop_w();
            if (parentForm.step == 4)
                parentForm.activity(parentForm.activity_form);
        }
        private void Sequence_4()
        {
            Sequence_3();
            star5.Visible = false;
            this.Update();
            star6.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono6_True");
            Thread.Sleep(3000);
            loop_w();
            if (parentForm.step == 5)
                parentForm.activity(parentForm.activity_form);
        }

        private async void final_sequence()
        {
            star2.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono1_True");
            Thread.Sleep(3000);
            pezzo0.Visible = true;
            this.Update();
            star1.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono2_True");
            Thread.Sleep(3000);
            pezzo1.Visible = true;
            star3.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono3_True");
            Thread.Sleep(3000);
            pezzo2.Visible = true;
            star4.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono4_True");
            Thread.Sleep(3000);
            pezzo3.Visible = true;
            star5.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono5_True");
            Thread.Sleep(3000);
            pezzo4.Visible = true;
            star6.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono6_True");
            Thread.Sleep(3000);
            pezzo5.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono7_True");
            Thread.Sleep(3000);
            parentForm.playbackResourceAudio("success");
            lbl_fin1.Visible = true;
            lbl_fin2.Visible = true;
            await uda_server_communication.Server_Request(completed);
        }

        public void Start_Sequences()
        {
            while (pause_val)
            {
                resetOperations();
                this.Update();
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status1 = int.Parse(k);
                if (parentForm.step == 1 && (status1==7 || status1==10))
                {
                    First_Sequence();
                    //while (true)
                    //{
                    //    k = parentForm.Status_Changed(parentForm.activity_form);
                    //    int status = int.Parse(k);
                    //    if (status == 7 || status == 10)
                    //    {
                    //        parentForm.activity(parentForm.activity_form);
                    //        break;
                    //    }
                    //    if (status==11|| status == 12)
                    //    {
                    //        Application.Exit();
                    //        Environment.Exit(0);
                    //    }
                    //   if (status==13)
                    //    {
                    //        this.Hide();
                    //        parentForm.Abort_UDA();
                    //        break;
                    //    }
                    //}

                }
                else if (parentForm.step == 2 && (status1 == 7 || status1 == 10))
                {
                    Sequence_1();
                    //while (true)
                    //{
                    //    k = parentForm.Status_Changed(parentForm.activity_form);
                    //    int status = int.Parse(k);
                    //    if (status == 7 || status == 10)
                    //    {
                    //        parentForm.activity(parentForm.activity_form);
                    //        break;
                    //    }
                    //    if (status == 11 || status == 12)
                    //    {
                    //        Application.Exit();
                    //        Environment.Exit(0);
                    //    }
                    //    if (status == 13)
                    //    {
                    //        this.Hide();
                    //        parentForm.Abort_UDA();
                    //        break;
                    //    }
                    //}


                }
                else if (parentForm.step == 3 && (status1 == 7 || status1 == 10))
                {
                    Sequence_2();
                    //while (true)
                    //{
                    //    k = parentForm.Status_Changed(parentForm.activity_form);
                    //    int status = int.Parse(k);
                    //    if (status == 7 || status == 10)
                    //    {
                    //        parentForm.activity(parentForm.activity_form);
                    //        break;
                    //    }
                    //    if (status == 11 || status == 12)
                    //    {
                    //        Application.Exit();
                    //        Environment.Exit(0);
                    //    }
                    //    if (status == 13)
                    //    {
                    //        this.Hide();
                    //        parentForm.Abort_UDA();
                    //        break;
                    //    }
                      
                    //}
                }
                else if (parentForm.step == 4 && (status1 == 7 || status1 == 10))
                {
                    Sequence_3();
                   // while (true)
                    //{
                    //    k = parentForm.Status_Changed(parentForm.activity_form);
                    //    int status = int.Parse(k);
                    //    if (status == 7 || status == 10)
                    //    {
                    //        parentForm.activity(parentForm.activity_form);
                    //        break;
                    //    }
                    //    if (status == 11 || status == 12)
                    //    {
                    //        Application.Exit();
                    //        Environment.Exit(0);
                    //    }
                    //    if (status == 13)
                    //    {
                    //        this.Hide();
                    //        parentForm.Abort_UDA();
                    //        break;
                    //    }
                    //}

                }
                else if (parentForm.step == 5 && (status1 == 7 || status1 == 10))
                {
                    Sequence_4();

                    //while (true)
                    //{
                    //    k = parentForm.Status_Changed(parentForm.activity_form);
                    //    int status = int.Parse(k);
                    //    if (status == 7 || status == 10)
                    //    {
                    //        parentForm.activity(parentForm.activity_form);
                    //        break;
                    //    }
                    //    if (status == 11 || status == 12)
                    //    {
                    //        Application.Exit();
                    //        Environment.Exit(0);
                    //    }
                    //    if (status == 13)
                    //    {
                    //        this.Hide();
                    //        parentForm.Abort_UDA();
                    //        break;
                    //    }
                    //}
                }
                else if (parentForm.step == 6 && (status1 == 7 || status1 == 10))
                {
                    while (true)
                    {
                        k = parentForm.Status_Changed(parentForm.activity_form);
                        int status = int.Parse(k);
                        if (status == 7 || status == 10)
                        {
                            final_sequence();
                            break;
                        }
                        if (status == 11 || status == 12)
                        {
                            Application.Exit();
                            Environment.Exit(0);
                        }
                        if (status == 13)
                        {
                            this.Hide();
                            parentForm.Abort_UDA();
                            break;
                        }
                    }                  
                }

                break;
            }

        }
        private void button1_Click(object sender, EventArgs e)
        {
            

        }
               
        

        private void gioca_btn_Click(object sender, EventArgs e)
        {

            
        }

        private void star4_Click(object sender, EventArgs e)
        {

        }

        private void star3_Click(object sender, EventArgs e)
        {

        }

        private void star5_Click(object sender, EventArgs e)
        {

        }

        private void star7_Click(object sender, EventArgs e)
        {

        }
    }
}
