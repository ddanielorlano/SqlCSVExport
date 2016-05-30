namespace SqlExport
{
    partial class Form1
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.serverBox = new System.Windows.Forms.TextBox();
            this.loginBox = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.passwordBox = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.connectBtn = new System.Windows.Forms.Button();
            this.exportBtn = new System.Windows.Forms.Button();
            this.tableBox = new System.Windows.Forms.TextBox();
            this.databaseBox = new System.Windows.Forms.TextBox();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.clearBtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.openFileBtn = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Server:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(96, 115);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Login:";
            // 
            // serverBox
            // 
            this.serverBox.Location = new System.Drawing.Point(99, 19);
            this.serverBox.Name = "serverBox";
            this.serverBox.Size = new System.Drawing.Size(161, 20);
            this.serverBox.TabIndex = 1;
            // 
            // loginBox
            // 
            this.loginBox.Location = new System.Drawing.Point(138, 112);
            this.loginBox.Name = "loginBox";
            this.loginBox.Size = new System.Drawing.Size(125, 20);
            this.loginBox.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(76, 137);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(56, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Password:";
            // 
            // passwordBox
            // 
            this.passwordBox.Location = new System.Drawing.Point(138, 137);
            this.passwordBox.Name = "passwordBox";
            this.passwordBox.Size = new System.Drawing.Size(125, 20);
            this.passwordBox.TabIndex = 5;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 45);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(56, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Database:";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 74);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(37, 13);
            this.label6.TabIndex = 9;
            this.label6.Text = "Table:";
            // 
            // connectBtn
            // 
            this.connectBtn.BackColor = System.Drawing.SystemColors.Window;
            this.connectBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.connectBtn.Location = new System.Drawing.Point(164, 200);
            this.connectBtn.Name = "connectBtn";
            this.connectBtn.Size = new System.Drawing.Size(108, 23);
            this.connectBtn.TabIndex = 7;
            this.connectBtn.Text = "Read From Table";
            this.connectBtn.UseVisualStyleBackColor = false;
            this.connectBtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // exportBtn
            // 
            this.exportBtn.BackColor = System.Drawing.SystemColors.Window;
            this.exportBtn.Enabled = false;
            this.exportBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.exportBtn.Location = new System.Drawing.Point(164, 229);
            this.exportBtn.Name = "exportBtn";
            this.exportBtn.Size = new System.Drawing.Size(108, 23);
            this.exportBtn.TabIndex = 8;
            this.exportBtn.Text = "Export Table";
            this.exportBtn.UseVisualStyleBackColor = false;
            this.exportBtn.Click += new System.EventHandler(this.exportBtn_Click);
            // 
            // tableBox
            // 
            this.tableBox.Location = new System.Drawing.Point(99, 71);
            this.tableBox.Name = "tableBox";
            this.tableBox.Size = new System.Drawing.Size(161, 20);
            this.tableBox.TabIndex = 3;
            // 
            // databaseBox
            // 
            this.databaseBox.Location = new System.Drawing.Point(99, 45);
            this.databaseBox.Name = "databaseBox";
            this.databaseBox.Size = new System.Drawing.Size(161, 20);
            this.databaseBox.TabIndex = 2;
            // 
            // clearBtn
            // 
            this.clearBtn.BackColor = System.Drawing.SystemColors.Window;
            this.clearBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.clearBtn.Location = new System.Drawing.Point(30, 200);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(75, 23);
            this.clearBtn.TabIndex = 10;
            this.clearBtn.Text = "Clear Values";
            this.clearBtn.UseVisualStyleBackColor = false;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.serverBox);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.databaseBox);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.tableBox);
            this.groupBox1.Controls.Add(this.loginBox);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.passwordBox);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(269, 174);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            // 
            // openFileBtn
            // 
            this.openFileBtn.BackColor = System.Drawing.SystemColors.Window;
            this.openFileBtn.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.openFileBtn.Location = new System.Drawing.Point(30, 229);
            this.openFileBtn.Name = "openFileBtn";
            this.openFileBtn.Size = new System.Drawing.Size(75, 23);
            this.openFileBtn.TabIndex = 9;
            this.openFileBtn.Text = "Open File";
            this.openFileBtn.UseVisualStyleBackColor = false;
            this.openFileBtn.Visible = false;
            this.openFileBtn.Click += new System.EventHandler(this.openFileBtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(288, 264);
            this.Controls.Add(this.openFileBtn);
            this.Controls.Add(this.connectBtn);
            this.Controls.Add(this.exportBtn);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.clearBtn);
            this.Name = "Form1";
            this.Text = "SQL Table Exporter";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox serverBox;
        private System.Windows.Forms.TextBox loginBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox passwordBox;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button connectBtn;
        private System.Windows.Forms.Button exportBtn;
        private System.Windows.Forms.TextBox tableBox;
        private System.Windows.Forms.TextBox databaseBox;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button openFileBtn;
    }
}

