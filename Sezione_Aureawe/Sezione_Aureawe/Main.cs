using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;
using System.IO.Pipes;
using System.Text;
using System.Collections.Generic;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Diagnostics;

namespace Sezione_Aureawe
{
    public partial class Main : Form
    {
        public static readonly string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        public static readonly string resourcesPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources";
        private const string background_image = "galaxy.jpg";
        private UserControl currUC = null;
        public int step;
        public int trial_1;
        public string new_status;
        public string get_data_uda;
        public string activity_form;
        public string onstart_form;
        public string started_uda;
        public string idle_status;
        public int interaction_sequences = 0;
        public SoundPlayer player = null;
        public ManualResetEvent resetEvent = new ManualResetEvent(true);
        public bool ShouldPause = true;
        public string data_start;
        public string pause_uda;
        public static System.Diagnostics.Process proc;
        public int turno = 0;
        public int contatore_iniziale = 0;
        public string MPV = resourcesPath + "\\" + "mpv.com";
        public string initial_video = Path.GetDirectoryName(Application.ExecutablePath) + "\\..\\..\\..\\..\\..\\Video_GAMES\\Sezione_Aurea\\iniziale.mov";
        public string final_video = Path.GetDirectoryName(Application.ExecutablePath) + "\\..\\..\\..\\..\\..\\Video_GAMES\\Sezione_Aurea\\finale.mov";
        public int recap_video = 0;
        public string wait_data()
        {
            int[] can_answer;
            if (uda_server_communication.explorers.Length == 0)
            {
                can_answer = new int[0];
            } else
            {
                can_answer = new int[] { uda_server_communication.explorers[
                    turno % uda_server_communication.explorers.Length] };
            }
            turno += 1;
            Dictionary<String, object> request = new Dictionary<String, object>();
            request.Add("question", "Scegli l'immagine che si lega alla sezione aurea");
            request.Add("input_type", new string[] { "1", "2" });
            request.Add("can_answer", can_answer);

            string data = JsonConvert.SerializeObject(request);
            return "api/uda/put/?i=3&k=14&data=" + data;
        }
        public Main()
        {
            step = 1;
            trial_1 = 0;
            pause_uda = "";
            started_uda = "api/uda/put/?i=3&k=7" + "&data=" + data_start;
            //started_uda =  url_luda + "api/uda/put/?i=3&k=7";
            get_data_uda = "api/uda/get/?i=3";              
            idle_status = "api/uda/put/?i=3&k=0";
            Business_Logic BL = new Business_Logic(this);
            AppDomain.CurrentDomain.ProcessExit += new EventHandler(OnProcessExit);
            InitializeComponent();
            initial1.parentForm = this;
            interaction1.parentForm = this;
            activity1.parentForm = this;
            initial1.Visible = false;
            interaction1.Visible = false;
            activity1.Visible = false;
            home();
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image);
        }
        static void OnProcessExit(object sender, EventArgs e)
        {
        }
        public void video_reproduction(string video1)
        {
            string mpvcommand = "--fullscreen --ontop " + video1;
            ProcessStartInfo proc = new ProcessStartInfo(MPV);
            proc.WindowStyle = ProcessWindowStyle.Hidden;
            proc.Arguments = mpvcommand;
            Process cmd  = Process.Start(proc);
            cmd.WaitForExit();
        }

        public string Status_Changed(string k)
        {
            this.BeginInvoke((Action)delegate ()
            {
                int status = int.Parse(k);
                if (status == 0)
                {
                    interaction1.Visible = false;
                    initial1.Visible = true;
                    k = "5";

                }
                if (status == 6)
                {
                    initial1.Visible = false;
                    video_reproduction(initial_video);
                    onStart(activity_form);
                }
                if (status == 8)
                {


                }
                if (status == 9)
                {


                }
                if (status == 11 || status == 12)
                {
                  System.Diagnostics.Process.GetCurrentProcess().Kill();

                }
                if (status == 15)
                {

                }

            });
            return k;
        }

        public async void Restart_UDA()
        {

        }

        public async void Abort_UDA()
        {
            await uda_server_communication.Server_Request(idle_status);
            activity1.trial = 0;
            trial_1 = 0;
            step = 1;
            if (currUC != null) currUC.Visible = false;
            initial1.Show();
            currUC = initial1;
            while (true)
            {
                string k = activity_form;
                int status = int.Parse(k);
                if (status == 6 || status == 7)
                {
                    break;
                }
            }
        }
        public void home()
        {
            if (currUC != null) currUC.Visible = false;
            initial1.Show();
            contatore_iniziale = 0;
            currUC = initial1;
        }
        public void onStart(string k)
        {
            interaction1.star_invisible();
            Thread.Sleep(400);
            interaction1.Visible = true;
            interaction1.pause_val = ShouldPause;
            currUC = interaction1;
            //Thread.Sleep(400);
            contatore_iniziale = 0;
         
            interaction1.resetOperations();
            interaction1.Start_Sequences();
        }
        public void activity(string k)
        {
            Thread.Sleep(1500);
            interaction1.Visible = false;
            activity1.Visible = true;
            trial_1++;
            activity1.setOperationsIcons(trial_1);
            currUC = activity1;
        }

        public void playbackResourceAudio(string audioname)
        {

            string s = resourcesPath + "\\" + audioname + ".wav";
            player = new SoundPlayer(s);
            player.Play();
        }

        static private void StopMPV ()
        {
            //System.Diagnostics.Debug.WriteLine("ciao");
            var Nicolo = new NamedPipeClientStream("mpv-pipe");
            Nicolo.Connect();
            StreamWriter writer = new StreamWriter(Nicolo);
            writer.WriteLine("quit");
        }
        private void Main_Load(object sender, EventArgs e)
        {
            Size size = this.Size;
            initial1.setPos(size.Width, size.Height);
            interaction1.setPos(size.Width, size.Height);
            activity1.setPos(size.Width, size.Height);
        }
        public void closeMessage()
        {

        }
        private void initial1_Load(object sender, EventArgs e)
        {

        }

        private void interaction1_Load(object sender, EventArgs e)
        {

        }
    }
}
