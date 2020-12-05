using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sezione_Aureawe
{
    public partial class Activity : UserControl
    {
        public Main parentForm { get; set; }
        public int trial = 0;
        private static readonly string[] operations_texts = new string[] { "TeoremaPitagora", "circle" };
        private readonly List<string> currOperationsLabels = new List<string>(); // displayed labels of the operations
        private readonly List<PictureBox> currOperationsIcons = new List<PictureBox>();
        private readonly List<string> currOperationsTexts = new List<string>();
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
            if(i==1)
            pbOne.ImageLocation = Main.resourcesPath + "\\" + "TeoremaPitagora" + ".png";
        

            pbTwo.WaitOnLoad = true;
            if (i == 1)
            pbTwo.ImageLocation = Main.resourcesPath + "\\" + "circle" + ".png";
        }

        private void Activity_Load(object sender, EventArgs e)
        {

        }

        private void btn_UNO_Click(object sender, EventArgs e)
        {

        }
    }
}
