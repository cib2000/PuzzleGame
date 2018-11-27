using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Collections;

namespace ImageGame
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = global::ImageGame.Properties.Resources.Image1.Width;
            this.Height = global::ImageGame.Properties.Resources.Image1.Height;
            this.ControlBox = false;
            this.StartPosition = FormStartPosition.CenterParent;


            
               
                for (int i = 0; i < 10; i++)
                {
                    this.Controls.Add(new 自定义图片按钮(i, global::ImageGame.Properties.Resources.Image1));
                }
            
        }
    }
}
