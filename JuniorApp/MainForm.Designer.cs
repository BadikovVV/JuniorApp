namespace WindowsFormsApplication1
{
    partial class MainForm
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
            this.btAccess = new System.Windows.Forms.Button();
            this.btMSSql = new System.Windows.Forms.Button();
            this.btExit = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btAccess
            // 
            this.btAccess.Location = new System.Drawing.Point(81, 12);
            this.btAccess.Name = "btAccess";
            this.btAccess.Size = new System.Drawing.Size(75, 23);
            this.btAccess.TabIndex = 0;
            this.btAccess.Text = "Access";
            this.btAccess.UseVisualStyleBackColor = true;
            this.btAccess.Click += new System.EventHandler(this.btAccess_Click);
            // 
            // btMSSql
            // 
            this.btMSSql.Location = new System.Drawing.Point(81, 41);
            this.btMSSql.Name = "btMSSql";
            this.btMSSql.Size = new System.Drawing.Size(75, 22);
            this.btMSSql.TabIndex = 1;
            this.btMSSql.Text = "MS SQL";
            this.btMSSql.UseVisualStyleBackColor = true;
            this.btMSSql.Click += new System.EventHandler(this.btMSSql_Click);
            // 
            // btExit
            // 
            this.btExit.Location = new System.Drawing.Point(81, 69);
            this.btExit.Name = "btExit";
            this.btExit.Size = new System.Drawing.Size(75, 22);
            this.btExit.TabIndex = 2;
            this.btExit.Text = "Exit";
            this.btExit.UseVisualStyleBackColor = true;
            this.btExit.Click += new System.EventHandler(this.btExit_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(240, 119);
            this.Controls.Add(this.btExit);
            this.Controls.Add(this.btMSSql);
            this.Controls.Add(this.btAccess);
            this.Name = "MainForm";
            this.Text = "Тестовое приложение";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btAccess;
        private System.Windows.Forms.Button btMSSql;
        private System.Windows.Forms.Button btExit;
    }
}

