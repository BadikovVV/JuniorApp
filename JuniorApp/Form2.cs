﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class fmAccess : Form
    {
        string dbName = "";
        string dbConStr = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source =";
        private OleDbConnection myDbConn =null;
        public fmAccess()
        {
            InitializeComponent();
            lbAccName.Text = "Нажмите Open, что бы выбрать базу Access";
        }
        private void makeDbConnection() 
        {
            myDbConn = new OleDbConnection(dbConStr);
            try
            {
                myDbConn.Open();
            }
            catch (OleDbException err)
            {
                string errMsgs = "";
                for (int i = 0; i < err.Errors.Count; i++)
                {
                    errMsgs += "Index #" + i + "\n" +
                          "Message: " + err.Errors[i].Message + "\n" +
                          "NativeError: " + err.Errors[i].NativeError + "\n" +
                          "Source: " + err.Errors[i].Source + "\n" +
                          "SQLState: " + err.Errors[i].SQLState + "\n";
                    System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                    log.Source = "My Application";
                    log.WriteEntry(errMsgs);
                    MessageBox.Show("Возникли ошибки при работе с БД Access! Обратитесь к системному администратору!", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    myDbConn.Dispose();
                    myDbConn = null;
                }
            }
        }
        private void btOpAcc_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbName = openFileDialog1.FileName;
                lbAccName.Text = dbName;
                dbConStr += dbName;
                makeDbConnection();

            }
            else
            {
                MessageBox.Show("Необходимо указать , c какой базой Access нужно работать!", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            
        }

        private void btExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void fmAccess_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (myDbConn != null)
                myDbConn.Close();
        }












    }
}
