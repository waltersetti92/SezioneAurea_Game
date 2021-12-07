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



namespace Sezione_Aureawe
{
    public partial class Main : Form
    {
        public static readonly string appPath = Path.GetDirectoryName(Application.ExecutablePath);
        public static readonly string resourcesPath = Path.GetDirectoryName(Application.ExecutablePath) + "\\resources";
        private const string background_image = "galaxy.jpg";
        private UserControl currUC = null;
        public int step;
        public string new_status;
        public string get_data_uda;
        public string activity_form;
        public string onstart_form;
        public string started_uda;
        public string wait_data;
        public string idle_status;
        public int interaction_sequences = 0;
        public SoundPlayer player = null;
        public ManualResetEvent resetEvent = new ManualResetEvent(true);
        public bool ShouldPause = true;
        public string data_start;
        public string pause_uda;
        public static System.Diagnostics.Process proc;
        public Main()
        {
            step = 1;
            pause_uda = "";
            wait_data = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/put/?i=3&k=14" + "&data=" + "{\"answer\": \"Scegli l'immagine che si lega alla sezione aurea\", \"input_type\":[\"1\",\"2\"]}";
            started_uda = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/put/?i=3&k=7" + "&data=" + data_start;
            //started_uda = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/put/?i=3&k=7";
            get_data_uda = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/get/?i=3";  // url per ottenere lo stato dell'UDA             
            idle_status = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/put/?i=3&k=0";
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
            //System.Diagnostics.Debug.WriteLine("ciao");
            var Nicolo = new NamedPipeClientStream("mpv-pipe");
            Nicolo.Connect();
            StreamWriter writer = new StreamWriter(Nicolo);
            writer.WriteLine("quit");
        }
        public void video_reproduction(string video1)
        {
            string video = "C:\\Users\\wsetti\\Documents\\Video_LUDA\\UDA_Inglese_0.mov";
            var Nicolo = new NamedPipeClientStream("mpv-pipe");
            Nicolo.Connect();
            StreamReader reader = new StreamReader(Nicolo);
            StreamWriter writer = new StreamWriter(Nicolo);
            writer.WriteLine("set pause yes");
            // System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer.WriteLine($"loadfile {video}");
            // System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer.WriteLine("set seek 0 absolute");
            //System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer.WriteLine("set fullscreen yes");
            //System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer.WriteLine("set ontop yes");
            //System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer.WriteLine("set pause no");
            //System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer.Flush();
            // while ()
            Dictionary<string, object> getPos = new Dictionary<string, object>();
            getPos.Add("command", new List<string> { "get_property", "percent-pos" });
            getPos.Add("request_id", 88);


            writer.WriteLine(JsonConvert.SerializeObject(getPos));
            System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(getPos));
            // System.Diagnostics.Debug.WriteLine(reader.ReadLine());
            writer.Flush();
            bool started = false;
            bool wait_video = true;
            while (wait_video)
            {
                writer.WriteLine(JsonConvert.SerializeObject(getPos));
                System.Diagnostics.Debug.WriteLine(JsonConvert.SerializeObject(getPos));
                writer.Flush();
                string response = reader.ReadLine();
                JObject json_parsed = JObject.Parse(response);

                if (!started)
                {
                    var id = json_parsed["request_id"];
                    if (id != null && (int)id == 88)
                    {
                        started = true;
                    }
                }
                if (started)
                {
                    var id = json_parsed["request_id"];
                    var error = json_parsed["error"];

                    if (id != null && (int)id == 88 && error != null && (string)error == "property unavailable")
                    {
                        //     System.Diagnostics.Debug.WriteLine(response);
                        wait_video = false;
                        // and property not available
                    }
                }
            }
            System.Diagnostics.Debug.WriteLine(reader.ReadLine());
        }

        public string Status_Changed(string k)
        {
            this.BeginInvoke((Action)delegate ()
            {
                int status = int.Parse(k);
                if (status == 6)
                {
                    video_reproduction("C:\\Users\\wsetti\\Documents\\Video_LUDA\\UDA_Inglese_0.mov");
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

                    Application.Exit();
                    Environment.Exit(0);

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
            currUC = initial1;
        }
        public void onStart(string k)
        {
            initial1.Visible = false;
            interaction1.Visible = true;
            interaction1.pause_val = ShouldPause;
            currUC = interaction1;
            Thread.Sleep(1000);
            interaction1.Start_Sequences();
        }
        public void activity(string k)
        {
            Thread.Sleep(1500);
            interaction1.Visible = false;
            activity1.Visible = true;
            activity1.trial++;
            activity1.setOperationsIcons(activity1.trial);
            currUC = activity1;
        }

        public void playbackResourceAudio(string audioname)
        {

            string s = resourcesPath + "\\" + audioname + ".wav";
            player = new SoundPlayer(s);
            player.Play();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            string mpvcommand = "--idle --input-ipc-server=\\\\.\\pipe\\mpv-pipe";
            proc = new System.Diagnostics.Process();
            proc.StartInfo.FileName = "C:\\Users\\wsetti\\Documents\\Video_LUDA\\mpv";
            proc.StartInfo.Arguments = mpvcommand;
            proc.StartInfo.WindowStyle = System.Diagnostics.ProcessWindowStyle.Hidden;
            proc.Start();
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
    }
}
