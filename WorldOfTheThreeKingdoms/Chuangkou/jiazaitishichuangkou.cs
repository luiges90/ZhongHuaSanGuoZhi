using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace WorldOfTheThreeKingdoms
{

    
    public partial class jiazaitishichuangkou : Form
    {
        public jiazaitishichuangkou()
        {
            InitializeComponent();
        }

        private void jiazaitishichuangkou_Load(object sender, EventArgs e)
        {
            this.tishi1.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox2.SizeMode = PictureBoxSizeMode.Zoom;
            this.pictureBox1.BackColor = System.Drawing.Color.Transparent;
            this.pictureBox2.BackColor = System.Drawing.Color.Transparent;
            pictureBox1.Image = Image.FromFile("Resources/ScenarioLoading/jindulan.png");
            pictureBox2.Image = Image.FromFile("Resources/ScenarioLoading/LOGO.png");
            Random ran = new Random();
            if (File.Exists("Resources/ScenarioLoading/MODBackground.jpg"))
            {
                this.BackgroundImage = Image.FromFile("Resources/ScenarioLoading/MODBackground.jpg"); 
            }
            else
            {
                int a = ran.Next(1, 28);
                if (File.Exists("Resources/ScenarioLoading/Background" + a + ".jpg"))
                {
                    this.BackgroundImage = Image.FromFile("Resources/ScenarioLoading/Background" + a + ".jpg");
                }

                else
                {
                    this.BackgroundImage = Image.FromFile("Resources/ScenarioLoading/Background0.jpg");

                }
            }

        }

        private void tishi1_Click(object sender, EventArgs e)
        {

        }



    }
}
