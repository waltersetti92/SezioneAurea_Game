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
        public int interaction;
        public SoundPlayer player = null;
        public Main()
        {
            InitializeComponent();
            initial1.parentForm = this;
            initial1.Visible = false;
            home();
            BackgroundImageLayout = ImageLayout.Stretch;
            BackgroundImage = Image.FromFile(resourcesPath + "\\" + background_image);
           
        }

        public void home()
        {
            if (currUC != null) currUC.Visible = false;
            initial1.Show();
            currUC = initial1;
        }

        private void Main_Load(object sender, EventArgs e)
        {
            Size size = this.Size; 
            initial1.setPos(size.Width, size.Height);
        }

        private void initial1_Load(object sender, EventArgs e)
        {

        }
    }
}
