namespace WindowsFormsApplication1
{
    partial class fmAccess
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
            this.btOpAcc = new System.Windows.Forms.Button();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.lbAccName = new System.Windows.Forms.Label();
            this.btCreate = new System.Windows.Forms.Button();
            this.btAdd = new System.Windows.Forms.Button();
            this.btLast = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btOpAcc
            // 
            this.btOpAcc.Location = new System.Drawing.Point(78, 31);
            this.btOpAcc.Name = "btOpAcc";
            this.btOpAcc.Size = new System.Drawing.Size(136, 23);
            this.btOpAcc.TabIndex = 0;
            this.btOpAcc.Text = "Открыть";
            this.btOpAcc.UseVisualStyleBackColor = true;
            this.btOpAcc.Click += new System.EventHandler(this.btOpAcc_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.Filter = "Access new(*.accdb)|*.accdb|Access old(*.mdb)|*.mdb|All(*.*)|*.*";
            // 
            // lbAccName
            // 
            this.lbAccName.AutoSize = true;
            this.lbAccName.Location = new System.Drawing.Point(2, 9);
            this.lbAccName.Name = "lbAccName";
            this.lbAccName.Size = new System.Drawing.Size(260, 13);
            this.lbAccName.TabIndex = 1;
            this.lbAccName.Text = "Нажмите \"Открыть\", что бы выбрать базу Access";
            // 
            // btCreate
            // 
            this.btCreate.Enabled = false;
            this.btCreate.Location = new System.Drawing.Point(78, 60);
            this.btCreate.Name = "btCreate";
            this.btCreate.Size = new System.Drawing.Size(136, 23);
            this.btCreate.TabIndex = 2;
            this.btCreate.Text = "Создаем таблицу";
            this.btCreate.UseVisualStyleBackColor = true;
            // 
            // btAdd
            // 
            this.btAdd.Enabled = false;
            this.btAdd.Location = new System.Drawing.Point(78, 89);
            this.btAdd.Name = "btAdd";
            this.btAdd.Size = new System.Drawing.Size(136, 23);
            this.btAdd.TabIndex = 3;
            this.btAdd.Text = "Добавляем запись";
            this.btAdd.UseVisualStyleBackColor = true;
            // 
            // btLast
            // 
            this.btLast.Enabled = false;
            this.btLast.Location = new System.Drawing.Point(78, 118);
            this.btLast.Name = "btLast";
            this.btLast.Size = new System.Drawing.Size(136, 23);
            this.btLast.TabIndex = 4;
            this.btLast.Text = "Последняя запись";
            this.btLast.UseVisualStyleBackColor = true;
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(78, 147);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(136, 23);
            this.btExit.TabIndex = 5;
            this.btExit.Text = "Выход";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // fmAccess
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(301, 179);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btLast);
            this.Controls.Add(this.btAdd);
            this.Controls.Add(this.btCreate);
            this.Controls.Add(this.lbAccName);
            this.Controls.Add(this.btOpAcc);
            this.Name = "fmAccess";
            this.Text = "Работаем с Access";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.fmAccess_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btOpAcc;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Label lbAccName;
        private System.Windows.Forms.Button btCreate;
        private System.Windows.Forms.Button btAdd;
        private System.Windows.Forms.Button btLast;
        private System.Windows.Forms.Button btExit;

    }
}