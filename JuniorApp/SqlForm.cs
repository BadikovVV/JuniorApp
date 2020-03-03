using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;


namespace WindowsFormsApplication1
{
    public partial class fmMSSQL: Form
    {
       
        string dbConStr = "Data Source=wufvl0011034\\SQLTest;Initial Catalog=juniorDB;Integrated Security=True;TransparentNetworkIPResolution=False";
        string crTable = "create table Junior (ID int IDENTITY(1,1), FirstName varchar(30),LastName varchar(30));";
        string getLast = "select ID,FirstName,LastName from Junior where ID = (select max(ID) from Junior);";
        string insStr = "insert into Junior(FirstName,LastName) Values (\'{0}\',\'{1}\'); ";

        //private OleDbConnection myDbConn =null;
        private SqlConnection myDbConn = null;
        public fmMSSQL()
        {
            InitializeComponent();
            txtConnStr.Text = dbConStr;
            this.btCreate.Enabled = false;
            this.btAdd.Enabled = false;
            this.btLast.Enabled = false;
            MessageBox.Show("Для подключения к MS SQL необходимо указать строку подключения. \nЕё пример указан в текстовом поле на форме.", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);


        }
        private void ErrorsInfo( SqlException err) //OleDbException err)
        {
            string errMsgs = "";
            for (int i = 0; i < err.Errors.Count; i++)
            {
                errMsgs += "Index #" + i + "\n" +
                      "Message: " + err.Errors[i].Message + "\n" +
                      "Server: " + err.Errors[i].Server + "\n" +
                      "Source: " + err.Errors[i].Source + "\n" +
                      "SQLState: " + err.Errors[i].State + "\n";
                System.Diagnostics.EventLog log = new System.Diagnostics.EventLog();
                log.Source = "My Application";
                log.WriteEntry(errMsgs);
            }
            MessageBox.Show("Возникли ошибки при работе с MS SQL! Обратитесь к системному администратору!", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            myDbConn.Dispose();
            myDbConn = null;
        }
        private bool FindTable(string tableName)
        {
            // всё просто - получаем по подключению схему данных и тутже ывбираем из нее таблицу снужным названием
            // если она там есть , то вернется набор с именем  и его длина будет больше 0
            // если её там нет , то вертенся пустой набор с 0 длинной.
            bool retVar = myDbConn.GetSchema("TABLES").Select("TABLE_NAME=\'" + tableName + "\'").Length > 0;
            // was for OLEDB GetOleDbSchemaTable(OleDbSchemaGuid.Tables,new object[] { null, null, null, "TABLE" }).Select("TABLE_NAME=\'"+tableName+"\'").Length>0;
            return retVar;
        }
        private bool MakeConnString() {
            bool retVar = true;
            dbConStr = txtConnStr.Text;
            try
            {
                SqlConnectionStringBuilder tmpSql = new SqlConnectionStringBuilder(dbConStr);
            }
            catch (System.Collections.Generic.KeyNotFoundException ex)
            {

                MessageBox.Show("Неверная строка подключения к MS SQL!\n" + ex.Message, "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retVar = false;
            }
            catch (System.FormatException ex)
            {
                MessageBox.Show("Неверная строка подключения к MS SQL!\n"+ ex.Message, "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                retVar = false;
            }
            catch (ArgumentException e)
            {
                MessageBox.Show("Неверная строка подключения к MS SQL!\n" +string.Format("{0}: {1}", e.GetType().Name, e.Message),"Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning); ;
                retVar = false;
            }

            return retVar;
        }
        private void MakeDbConnection() 
        {
            myDbConn = new SqlConnection(dbConStr);
            try
            {
                myDbConn.Open();
            }
            catch (SqlException err)// (OleDbException err)
            {
                ErrorsInfo(err);
            }
        }
        private void btOpSql_Click(object sender, EventArgs e)
        {
            if (MakeConnString() == true) 
            {
                MakeDbConnection();
                if (myDbConn != null)
                { //активируем кнопки , если удачно подключились к базе
                    this.btCreate.Enabled = true;
                    this.btAdd.Enabled = true;
                    this.btLast.Enabled = true;
                }
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
                        SqlCommand sqlCommand = null;
                        // creating the table
                        sqlCommand = new SqlCommand(crTable, myDbConn);
                        sqlCommand.ExecuteNonQuery();
                    }
                }
                catch (SqlException err)
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
                //insStr + string.Format(" Values (\'{0}\',\'{1}\');", currDT.ToShortDateString(), currDT.ToShortTimeString());
                try
                {
                    SqlCommand sqlCommand = null;
                    // добавляем запись
                    sqlCommand = new SqlCommand( string.Format(insStr, currDT.ToShortDateString(), currDT.ToLongTimeString()), myDbConn);
                    sqlCommand.ExecuteNonQuery();
                }
                catch (SqlException err)
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
                    SqlCommand oleDbCommand = null;
                    // ищем последнюю запись
                    oleDbCommand = new SqlCommand(getLast, myDbConn);
                    SqlDataReader dataReader= oleDbCommand.ExecuteReader();
                    if (dataReader.Read())
                    {
                        string msgStr = string.Format("Последняя запись в таблице \nID = {0}\nFirstName = {1}\nLastName={2}", dataReader.GetValue(0).ToString(), dataReader.GetString(1).Trim(), dataReader.GetString(2).Trim());
                        MessageBox.Show(msgStr, "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        
                    }
                    else
                    {
                        MessageBox.Show("Данных в таблице нет!\n Их нужно добавить, нажав кнопку \'Добавляем запись\'", "Тестовое приложение", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                    dataReader.Close();
                }
                catch (SqlException err)
                {

                    ErrorsInfo(err);
                }
            }
        }


    }
}
