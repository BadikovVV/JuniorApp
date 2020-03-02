using System;

namespace WindowsFormsApplication1
{
    partial class fmMSSQL
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btConn = new System.Windows.Forms.Button();
            this.btCreate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btLast = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.txtConnStr = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btConn
            // 
            this.btConn.Location = new System.Drawing.Point(94, 76);
            this.btConn.Name = "btConn";
            this.btConn.Size = new System.Drawing.Size(143, 23);
            this.btConn.TabIndex = 0;
            this.btConn.Text = "Подплючиться к БД";
            this.btConn.UseVisualStyleBackColor = true;
            this.btConn.Click += new System.EventHandler(this.btOpSql_Click);
            // 
            // btCreate
            // 
            this.btCreate.Location = new System.Drawing.Point(94, 105);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(143, 23);
            this.btCreate.TabIndex = 1;
            this.btCreate.Text = "Создаем таблицу";
            this.btCreate.UseVisualStyleBackColor = true;
            this.btCreate.Click += new System.EventHandler(this.btCreate_Click);
            // 
            // btAdd
            // 
            this.btAdd.Location = new System.Drawing.Point(94, 134);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(143, 23);
            this.btAdd.TabIndex = 2;
            this.btAdd.Text = "Добавляем запись";
            this.btAdd.UseVisualStyleBackColor = true;
            this.btAdd.Click += new System.EventHandler(this.btAdd_Click);
            // 
            // btLast
            // 
            this.btLast.Location = new System.Drawing.Point(94, 163);
            this.btLast.Name = "btLast";
            this.btLast.Size = new System.Drawing.Size(143, 23);
            this.btLast.TabIndex = 3;
            this.btLast.Text = "Последняя запись";
            this.btLast.UseVisualStyleBackColor = true;
            this.btLast.Click += new System.EventHandler(this.btLast_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(94, 192);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(143, 23);
            this.btExit.TabIndex = 4;
            this.btExit.Text = "Выход";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // txtConnStr
            // 
            this.txtConnStr.Location = new System.Drawing.Point(5, 31);
            this.txtConnStr.Name = "txtConnStr";
            this.txtConnStr.Size = new System.Drawing.Size(314, 20);
            this.txtConnStr.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(5, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(165, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Строка подключения к MS SQL";
            // 
            // fmMSSQL
            // 
            this.ClientSize = new System.Drawing.Size(324, 230);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtConnStr);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btLast);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.btConn);
            this.Name = "fmMSSQL";
            this.Text = "Работаем с MS SQL";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmAccess_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }



        #endregion



        private System.Windows.Forms.Button btConn;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btLast;
        private System.Windows.Forms.Button btExit;
        private System.Windows.Forms.TextBox txtConnStr;
        private System.Windows.Forms.Label label1;
    }
}