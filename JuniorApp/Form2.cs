using System;
using System.IO;
using System.Data;
using System.Data.OleDb;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class fmAccess : Form
    {
        string dbName = "";
        string dbConStr = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source =";
       // string dbCreateStr = "";
       // string hasTable = "SELECT count(name) from MSysObjects where MSysObjects.Type=1 and name  = \"Junior\";";
        string crTable = "create table Junior (ID COUNTER, FirstName char,LastName char);";
        string getLast = "select ID,FirstName,LastName from Junior where ID = (select max(ID) from Junior);";
        string insStr = "insert into Junior(FirstName,LastName) Values (\'{0}\',\'{1}\'); ";

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
        private bool FindTable(string tableName)
        {
            // всё просто - получаем по подключению схему данных и тутже ывбираем из нее таблицу снужным названием
            // если она там есть , то вернется набор с именем  и его длина будет больше 0
            // если её там нет , то вернется пустой набор с длина == 0 .
            bool retVar = myDbConn.GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[] { null, null, null, "TABLE" }).Select("TABLE_NAME=\'"+tableName+"\'").Length>0;
            return retVar;
        }
        private bool MakeConnString() {
            bool retVar = true;
            //поиск провайдера построен по тому же принципу как и поиск таблицы в базе 
            string flExt = Path.GetExtension(dbName);
            OleDbEnumerator enumerator = new OleDbEnumerator();
            bool isNewOle = (enumerator.GetElements().Select("SOURCES_DESCRIPTION LIKE 'Microsoft.ACE.OLEDB%'").Length>0 )|| (enumerator.GetElements().Select("SOURCES_DESCRIPTION LIKE '%Access Database Engine OLE DB%'").Length>0)  ;  // new OleDB provider
            bool isOldOle = enumerator.GetElements().Select("SOURCES_DESCRIPTION = 'Microsoft Jet 4.0 OLE DB Provider'").Length > 0; // old OleDB provider
            if (isNewOle) // новая версия
            {

                dbConStr += (dbName + "; Persist Security Info=False ");//"; Persist Security Info=False;");
            }
            else
            {
                if (flExt==".mdb" && isOldOle)
                {
                    dbConStr = "Provider = Microsoft.Jet.OLEDB.4.0; Data Source =" + dbName + "; Persist Security Info=False;User ID=Admin;Password=";
                }
                else
                {
                    retVar = false;
                }
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
             //   dbConStr += dbName;
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
                try
                {
                    if (FindTable("Junior")) //таблица с таким именем (Junior) уже есть в БазеДанных
                    {
                        MessageBox.Show("Tаблица с таким именем (Junior) уже есть в выбранной БазеДанных", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    else // таблицы Junior  нет в БД, создаем её
                    {
                        OleDbCommand oleDbCommand = null;
                        // creating the table
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

        private void btAdd_Click(object sender, EventArgs e)
        {
            if (!FindTable("Junior")) //проверка на наличие таблицы именем (Junior) 
            {
                MessageBox.Show("Tаблица с  именем Junior отсутствует в выбранной БазеДанных\n Её нужно создать , нажав кнопку \'Создаем таблицу\'", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else // таблица есть, добавляем записи
            {
                // так как не была заявлена интерактивность в ТЗ,
                // то в качестве FirstName записываем дату, а в качестве LastName записываем время 
                DateTime currDT = DateTime.Now;
                try
                {
                    OleDbCommand oleDbCommand = null;
                    // добавляем запись
                    oleDbCommand = new OleDbCommand( string.Format(insStr, currDT.ToShortDateString(), currDT.ToLongTimeString()), myDbConn);
                    oleDbCommand.ExecuteNonQuery();
                }
                catch (OleDbException err)
                {
                    ErrorsInfo(err);
                }

            }
        }

        private void btLast_Click(object sender, EventArgs e) // выбираем последнюю запись
        {
            if (!FindTable("Junior")) //проверка на наличие таблицы именем (Junior) 
            {
                MessageBox.Show("Tаблица с  именем Junior отсутствует в выбранной БазеДанных\n Её нужно создать , нажав кнопку \'Создаем таблицу\'", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else // таблица есть, выводим последнюю запись
            {
                try
                {
                    OleDbCommand oleDbCommand = null;
                    // ищем последнюю запись
                    oleDbCommand = new OleDbCommand(getLast, myDbConn);
                    OleDbDataReader dataReader= oleDbCommand.ExecuteReader();
                    if (dataReader.Read())
                    {
                        string msgStr = string.Format("Последняя запись в таблице \nID = {0}\nFirstName = {1}\nLastName={2}", dataReader.GetValue(0).ToString(), dataReader.GetString(1).Trim(), dataReader.GetString(2).Trim());
                        MessageBox.Show(msgStr, "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        dataReader.Close();
                    }
                    else
                    {
                        MessageBox.Show("Данных в таблице нет!\n Их нужно добавить, нажав кнопку \'Добавляем запись\'", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
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
