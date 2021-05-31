using System;
using System.Drawing;
using System.Windows.Forms;
using System.Media;
using System.IO;
using System.Threading;


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
        public int interaction_sequences = 0;
        public SoundPlayer player = null;
        public ManualResetEvent resetEvent = new ManualResetEvent(true);
        public bool ShouldPause = true;

        public Main()
        {
            step = 1;
            started_uda = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/put/?i=3&k=7";
            get_data_uda = "https://www.sagosoft.it/_API_/cpim/luda/www/luda_20210111_1500//api/uda/get/?i=3";  // url per ottenere lo stato dell'UDA  
            Business_Logic BL = new Business_Logic(this);
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
        public string Status_Changed(string k)
        {
            this.BeginInvoke((Action)delegate ()
            {
                int status = int.Parse(k);
                if (status == 6)
                {
                    onStart(activity_form);
                }
                if (status == 8)
                {


                }
                if (status == 9)
                {


                }
                if (status == 11)
                {
                    Application.Exit();

                }
                if (status == 13)
                {

                    activity1.trial = 0;
                    activity1.timeleft = 10;
                    step = 1;
                    onStart(activity_form);

                }
                if (status == 15)
                {

                }

            });
            return k;
        }

        public async void Restart_UDA()
        {
            await uda_server_communication.Server_Request(started_uda);
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
