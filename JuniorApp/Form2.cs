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
    public partial class fmAccess : Form
    {
        string dbName = "";
        public fmAccess()
        {
            InitializeComponent();
            lbAccName.Text = "Нажмите Open, что бы выбрать базу Access";
        }

        private void btOpAcc_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbName = openFileDialog1.FileName;
                lbAccName.Text = dbName;
            }
            else
            {
                MessageBox.Show("Необходимо указать , c какой базой Access нужно работать!", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void btExit_Click(object sender, EventArgs e)
        {

        }








    }
}
