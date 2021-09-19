using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.OleDb;
using System.Xml;
namespace WindowsFormsApplication12
{
    public partial class Form3 : Form
    {
        public Form3(int s,int d,string n)
        {
            InitializeComponent();
            scoree = s;
            nickn = n;
            vded = d;
        }
        string nickn;
        int scoree,vded;
        DataSet ds;
        OleDbConnection conn;
        OleDbDataAdapter adapt;
        private void Form3_Load(object sender, EventArgs e)
        {
        
         
          
     
            string sPath = Application.StartupPath + @"\db.accdb";
            int pos;

            bool turn = true;
           ds = new DataSet();

            ds.ReadXml(Application.StartupPath +@"\led.xml");
            pos = -1;
            
          
            dataGridView1.DataSource = ds.Tables[0];
            for (int i = 0; i < 10; i++) { if (Convert.ToInt32(dataGridView1.Rows[i].Cells[2].Value.ToString()) < scoree && turn) { pos = i; turn = false; } }
            if (pos >= 0)
            {
                for (int i = 8; i > pos - 1; i--) { dataGridView1.Rows[i + 1].Cells[1].Value = dataGridView1.Rows[i].Cells[1].Value; dataGridView1.Rows[i + 1].Cells[2].Value = dataGridView1.Rows[i].Cells[2].Value; }

                dataGridView1.Rows[pos].Cells[1].Value = nickn;
                dataGridView1.Rows[pos].Cells[2].Value = scoree;
                dataGridView1.Rows[pos].Cells[3].Value = vded;
            }
            ds.WriteXml(Application.StartupPath + @"\led.xml");


        }
    }
}
