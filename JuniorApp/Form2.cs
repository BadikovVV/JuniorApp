using System;
using System.IO;
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
        string dbConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =";
        string dbCreateStr = "";
        string hasTable = "SELECT count(name) from MSysObjects where MSysObjects.Type=1 and name  = \"Junior\";";
        string crTable = "create table Junior (ID COUNTER, FirstName char,LastName char);";
        string getLast = "select ID,FirstName,LastName from Junior where ID = (select max(ID) from Junior);";
        string insStr = "insert into Junior(FirstName,LastName)  ";

        private OleDbConnection myDbConn =null;
        public fmAccess()
        {
            InitializeComponent();
            lbAccName.Text = "Нажмите Open, что бы выбрать базу Access";
        }
        private void ErrorsInfo(OleDbException err)
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
            }
            MessageBox.Show("Возникли ошибки при работе с БД Access! Обратитесь к системному администратору!", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            myDbConn.Dispose();
            myDbConn = null;
        }
        private bool MakeConnString() {
            bool retVar = false,newOleDB=false,oldOleDB=false ;
            //TODO: добавить анализ расширения и наличие необходимого oleDB провайдера
            string flExt = Path.GetExtension(dbName);
            OleDbEnumerator enumerator = new OleDbEnumerator();
            DataRow[] foundRows = enumerator.GetElements().Select("SOURCES_DESCRIPTION LIKE 'Microsoft.ACE.OLEDB%'");  // 'Microsoft Jet 4.0 OLE DB Provider'");
            if (flExt == "mdb") // старая версия
            {
                //dataView.RowFilter = "Name LIKE '%jo%'"     // values that contain 'jo'

            }
            else
            {
                DataRow[] foundRows = enumerator.GetElements().Select("",);
            }
            return retVar;
        }
        private void MakeDbConnection() 
        {
            myDbConn = new OleDbConnection(dbConStr);
            
            try
            {
                myDbConn.Open();
            }
            catch (OleDbException err)
            {
                ErrorsInfo(err);

            }
        }
        private void btOpAcc_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                dbName = openFileDialog1.FileName;
                lbAccName.Text = dbName;
                if (MakeConnString()== false) // нужного провайдера нет и не можем создать строку подключения
                {
                    MessageBox.Show("Нет необходимого OLEDB провайдера для работы с Access!", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                dbConStr += dbName;
                MakeDbConnection();
                if (myDbConn != null) { //активируем кнопки , если удачно открыли файл
                    this.btCreate.Enabled = true;
                    this.btAdd.Enabled = true;
                    this.btLast.Enabled = true;
                }
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

        private void btCreate_Click(object sender, EventArgs e)
        {
            if (myDbConn.State == ConnectionState.Open) {
                // analyzing is there table with name Junior in DataBase
                OleDbCommand oleDbCommand = new OleDbCommand(hasTable, myDbConn);
                try
                {
                    OleDbDataReader oleDbData= oleDbCommand.ExecuteReader();
                    int rez = oleDbData.GetInt32(0);
                    oleDbData.Close(); 
                    if (rez>0) //таблица с таким именем (Junior) уже есть в БазеДанных
                    {
                        MessageBox.Show("Tаблица с таким именем (Junior) уже есть в выбранной БазеДанных", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        oleDbData.Close();
                    }
                    else // таблицы Junior  нет в БД, создаем её
                    {
                        oleDbCommand = null;
                        // creating a table
                        oleDbCommand = new OleDbCommand(crTable, myDbConn);
                        oleDbCommand.ExecuteNonQuery();
                    }
                }
                catch (OleDbException err)
                {
                    ErrorsInfo(err);
                }
            }

            
        }
    }
}
