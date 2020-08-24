using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hello_World
{
    public partial class Form1 : Form
    {

        int x = 0;

        public Form1()
        {
            InitializeComponent();
            label1.Text = "Hello Niklas!";
            Console.WriteLine("Hello Niklas!");

        }

        private void label1_Click(object sender, EventArgs e)
        {
            switch (x){
                case 0:
                    label1.Text = "Why did you press on me?";
                    break;
                case 1:
                    label1.Text = "AGAIN?? WHYY SOME MEAN??";
                    break;
                case 2:
                    label1.Text = "I hate you!";
                    break;
                case 3:
                    label1.Text = "Go and die";
                    break;
                case 4:
                    label1.Text = "I am bored okay?";
                    break;
                case 5:
                    label1.Text = "Hello Niklas!";
                    break;
            }
            x++;


        }
    }
}
