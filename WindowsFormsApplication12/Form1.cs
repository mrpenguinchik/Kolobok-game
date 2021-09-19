using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

using System.Threading;

namespace WindowsFormsApplication12
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
  
        private void Form1_Load(object sender, EventArgs e)
        {


      
    
        }
      
   
        private void timer1_Tick(object sender, EventArgs e)
        {

      

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string nickname;
            Form2 f2 = new Form2();
            nickname = textBox1.Text;
            Hide();
            f2.ShowDialog(); 
             int score = f2.score;
            int vded = f2.vded;
            Hide();
            Form3 f3 = new Form3(score,vded, nickname);
            f3.ShowDialog();
            Show();
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {


           
        }

        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {

      

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }


    }
}

