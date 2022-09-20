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
using System.IO.Pipes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace Sezione_Aureawe
{
    public partial class Interaction : UserControl
    {
        public Main parentForm { get; set; }
        public bool pause_val;
        public string k;
        public string completed;
        public int go_on;
        public string started_uda;
        public string data_st;
        public static readonly string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        public static readonly string resourcesPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources";
        private const string background_image = "galaxy.jpg";
        public Interaction()
        {

            go_on = 0;
           
            InitializeComponent();
            //star_invisible();
            resetOperations();
            Start_Sequences();
            completed = "api/uda/put/?i=1&k=16";
           // BackgroundImageLayout = ImageLayout.Stretch;
           // BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image);

        }
        public void video_reproduction_final(string video1)
        {
            var Nicolo = new NamedPipeClientStream("mpv-pipe");
            Nicolo.Connect();
            StreamReader reader1 = new StreamReader(Nicolo);
            StreamWriter writer1 = new StreamWriter(Nicolo);
            writer1.WriteLine("set pause yes");
            // System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer1.WriteLine($"loadfile {video1}");
            // System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer1.WriteLine("set seek 0 absolute");
            //System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer1.WriteLine("set fullscreen yes");
            writer1.WriteLine("set ontop yes");
            writer1.WriteLine("set pause no");
            writer1.Flush();
            Dictionary<string, object> getPos = new Dictionary<string, object>();
            getPos.Add("command", new List<string> { "get_property", "time-pos" });
            getPos.Add("request_id", 89);
            //writer1.WriteLine(JsonConvert.SerializeObject(getPos));
            //System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(getPos));
            //System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer1.Flush();
            bool started = false;
            bool wait_video = true;
            while (wait_video)
            {
                writer1.WriteLine(JsonConvert.SerializeObject(getPos));
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(getPos));
                writer1.Flush();
                string response = reader1.ReadLine();
                JObject json_parsed = JObject.Parse(response);
                System.Diagnostics.Debug.WriteLine(json_parsed);

                if (!started)
                {
                    var id = json_parsed["request_id"];
                    if (id != null && (int)id == 89)
                    {
                        started = true;
                    }
                }
                if (started)
                {
                    var id = json_parsed["request_id"];
                    var error = json_parsed["error"];

                    if (id != null && (int)id == 89 && error != null && (string)error == "property unavailable")
                    {
                        wait_video = false;
                    }
                }

            }

            System.Diagnostics.Debug.WriteLine(reader1.ReadLine());

        }
        public void resetOperations()
        {
            star1.Visible = false;
            star2.Visible = false;
            pezzo0.Visible = false;
            star3.Visible = false;
            star4.Visible = false;
            star5.Visible = false;
            star6.Visible = false;
            pezzo1.Visible = false;
            pezzo2.Visible = false;
            pezzo3.Visible = false;
            pezzo4.Visible = false;
            pezzo5.Visible = false;
            lbl_fin2.Visible = false;
            star1.Visible = false;
            star2.Visible = false;
            this.Update();
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
                go_on = 0;
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (status == 7 || status == 10 || status==15)
                {
                    go_on=1;
                        if (status == 10)
                            start_after_resume();
                    break;
                }
                if (status == 11 || status == 12)
                {
                    System.Diagnostics.Process.GetCurrentProcess().Kill();
                    break;
                }
                if (status == 13)
                {
                    this.Hide();
                    parentForm.Abort_UDA();
                    break;
                }
                Thread.Sleep(400);
            }
        }

        public void star_invisible()
        {
            star1.Image = null;
            star2.Image = null;
            star3.Image = null;
            star4.Image = null;
            star5.Image = null;
            star6.Image = null;
            pezzo0.Image = null;
            pezzo1.Image = null;
            pezzo2.Image = null;
            pezzo3.Image = null;
            pezzo4.Image = null;
            pezzo5.Image = null;
            pB_Indizio.Image = null;
            lbl_fin1.Text = null;
            this.Update();
        }
        public void First_Sequence()
        {
            pB_Indizio.Visible = false;
            lbl_fin1.Visible = false; 
            star2.WaitOnLoad = true;
            star2.ImageLocation=  Main.resourcesPath + "\\" + "stella.png";
            star2.Visible = true;           
            this.Update();
            parentForm.playbackResourceAudio("Suono1_True");
            Thread.Sleep(3000);
            star_invisible();
            loop_w();
            star_invisible();
            //star2.Visible = false;
            this.Update();
            // 
            if (go_on == 1)
            {
                star1.WaitOnLoad = true;
                star1.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star1.Visible = true;                
                this.Update();
                parentForm.playbackResourceAudio("Suono2_True");
                Thread.Sleep(3000);
                star_invisible();
                loop_w();
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (parentForm.step == 1 && status != 13)
                parentForm.activity(parentForm.activity_form);
            }
           
        }

        private void Interaction_Load(object sender, EventArgs e)
        {
            pB_Indizio.Visible = false;
            star_invisible();           
            lbl_fin1.Visible = false;    
        }

        private void star2_Click(object sender, EventArgs e)
        {

        }
        private void Sequence_1()
        {
            First_Sequence();
            //star1.Visible = false;
            this.Update();
            if (go_on == 1)
            {
                star3.WaitOnLoad = true;
                star3.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star3.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono3_True");
                Thread.Sleep(3000);
                star_invisible();
                loop_w();
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (parentForm.step == 2 && status!=13)
                    parentForm.activity(parentForm.activity_form);
            }
           
        }

        private void Sequence_2()
        {
            Sequence_1();
           
            this.Update();
            if (go_on == 1)
            {
                star4.WaitOnLoad = true;
                star4.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star4.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono4_True");
                Thread.Sleep(3000);
                star_invisible();
                loop_w();
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (parentForm.step == 3 && status!=13)
                    parentForm.activity(parentForm.activity_form);
            }

        }
        private void Sequence_3()
        {
            Sequence_2();
            //star4.Visible = false;
            this.Update();
            if (go_on == 1)
            {
                star5.WaitOnLoad = true;
                star5.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star5.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono5_True");
                Thread.Sleep(3000);
                star_invisible();
                loop_w();
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (parentForm.step == 4 && status!=13)
                    parentForm.activity(parentForm.activity_form);
            }

        }
        private void Sequence_4()
        {
            Sequence_3();
            //star5.Visible = false;
            this.Update();
            if (go_on == 1)
            {
                star6.WaitOnLoad = true;
                star6.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star6.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono6_True");
                Thread.Sleep(3000);
                star_invisible();
                loop_w();
                k = parentForm.Status_Changed(parentForm.activity_form);
                int status = int.Parse(k);
                if (parentForm.step == 5 && status!=13)
                    parentForm.activity(parentForm.activity_form);
            }

        }

        private async void final_sequence()
        {
            star2.WaitOnLoad = true;
            star2.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
            star2.Visible = true;
            this.Update();
            parentForm.playbackResourceAudio("Suono1_True");
            loop_w();
            if (go_on == 1)
            {
                Thread.Sleep(3000);
                pezzo0.WaitOnLoad = true;
                pezzo0.ImageLocation = Main.resourcesPath + "\\" + "Pezzo_0.png";
                pezzo0.Visible = true;
                this.Update();
                star1.WaitOnLoad = true;
                star1.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star1.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono2_True");
            }   
            loop_w();
            if (go_on == 1)
            {
                Thread.Sleep(3000);
                pezzo1.WaitOnLoad = true;
                pezzo1.ImageLocation = Main.resourcesPath + "\\" + "Pezzo_1.png";
                pezzo1.Visible = true;
                this.Update();
                star3.WaitOnLoad = true;
                star3.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star3.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono3_True");
            }
            loop_w();
            if (go_on == 1)
            {
                Thread.Sleep(3000);
                pezzo2.WaitOnLoad = true;
                pezzo2.ImageLocation = Main.resourcesPath + "\\" + "Pezzo_2.png";
                pezzo2.Visible = true;
                this.Update();
                star4.WaitOnLoad = true;
               star4.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star4.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono4_True");
            }

            loop_w();
            if (go_on == 1)
            {
                Thread.Sleep(3000);
                pezzo3.WaitOnLoad = true;
                pezzo3.ImageLocation = Main.resourcesPath + "\\" + "Pezzo_3.png";
                pezzo3.Visible = true;
                this.Update();
                star5.WaitOnLoad = true;
                star5.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star5.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono5_True");
            }

            loop_w();
            if (go_on == 1)
            {
                Thread.Sleep(3000);
                pezzo4.WaitOnLoad = true;
                pezzo4.ImageLocation = Main.resourcesPath + "\\" + "Pezzo_4.png";
                pezzo4.Visible = true;
                this.Update();
                star6.WaitOnLoad = true;
                star6.ImageLocation = Main.resourcesPath + "\\" + "stella.png";
                star6.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono6_True");
            }
            
            loop_w();
            if (go_on == 1)
            {
                Thread.Sleep(3000);
                pezzo5.WaitOnLoad = true;
                pezzo5.ImageLocation = Main.resourcesPath + "\\" + "Pezzo_5.png";
                pezzo5.Visible = true;
                this.Update();
                parentForm.playbackResourceAudio("Suono7_True");
            }
         
            loop_w();
            if (go_on == 1)
            {
                Thread.Sleep(3000);
                parentForm.playbackResourceAudio("success");
                lbl_fin1.Visible = true;
                this.Update();
                lbl_fin2.Visible = true;
                this.Update();
            }           
            await uda_server_communication.Server_Request(completed);
            Thread.Sleep(6000);
            //video_reproduction_final(parentForm.final_video);
            parentForm.video_reproduction(parentForm.final_video);
            indizio();
        }
        public async void Image_Indizio(string a)
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
                    else if (status==10|| status == 7 || status==16)
                    {
                        
                        pB_Indizio.WaitOnLoad = true;
                        pB_Indizio.ImageLocation = Main.resourcesPath + "\\" + a + ".png";
                        pB_Indizio.Visible = true;
                        this.Update();
                        lbl_fin1.Text = "ECCO L'INDIZIO!";
                        //lbl_fin1.Visible = true;
                        this.Update();
                        break;
                    }
                }
                Thread.Sleep(400);
            }
            

        }
        public void indizio()
        {
            lbl_fin2.Text = "";
            this.Update();
            star_invisible();
            Thread.Sleep(400);
            Image_Indizio(uda_server_communication.indizio + "_" + uda_server_communication.turno);
             Thread.Sleep(2000);
        }
        public async void start_after_resume()
        {
            await uda_server_communication.Server_Request(parentForm.started_uda);
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
                  
                }
                else if (parentForm.step == 2 && (status1 == 7 || status1 == 10))
                {
                   
                    Sequence_1();


                }
                else if (parentForm.step == 3 && (status1 == 7 || status1 == 10))
                {
                    Sequence_2();

                }
                else if (parentForm.step == 4 && (status1 == 7 || status1 == 10))
                {
                    Sequence_3();
                   

                }
                else if (parentForm.step == 5 && (status1 == 7 || status1 == 10))
                {
                    Sequence_4();

                
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
                        Thread.Sleep(400);
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

        private void pezzo0_Click(object sender, EventArgs e)
        {

        }

        private void pB_Indizio_Click(object sender, EventArgs e)
        {

        }
    }
}
