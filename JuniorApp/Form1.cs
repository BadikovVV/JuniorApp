using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btExit_Click(object sender, EventArgs e)
        {
            //this.Close();
            Application.Exit();
        }

        private void btAccess_Click(object sender, EventArgs e)
        {
           fmAccess fm= new fmAccess();
           fm.ShowDialog();

        }

        private void btMSSql_Click(object sender, EventArgs e)
        {

        }
    }
}
