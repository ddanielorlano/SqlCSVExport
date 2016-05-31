using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SqlExport
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        private Exporter _exporter;
        private string _savePath;
        private SqlConnection _connection;
        private StringBuilder _sbRecordsRead;
        private void button1_Click(object sender, EventArgs e)
        {
            string server, db, table, login, password;

            server = serverBox.Text;
            db = databaseBox.Text;
            table = tableBox.Text;
            login = loginBox.Text;
            password = passwordBox.Text;

            if (string.IsNullOrWhiteSpace(password) && string.IsNullOrWhiteSpace(login))
            {
                _exporter = new Exporter(server,db,table);
            }
            else
            {
                _exporter = new Exporter(server, db, login, password,table);
            }
            ReadFromDb();

            

        }
        private void ReadFromDb()
        {
            var connection = _exporter.Connect();
            try
            {
                int count;
                _sbRecordsRead = _exporter.ReadFromDb(connection,out count);
                MessageBox.Show($"{count} Reacords Read!");
                exportBtn.Enabled = true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
            }
        }

        private void clearBtn_Click(object sender, EventArgs e)
        {
            serverBox.Text = "";
            databaseBox.Text = "";
            tableBox.Text = "";
            loginBox.Text = "";
            passwordBox.Text = "";
            exportBtn.Enabled = false;
            openFileBtn.Visible = false;

        }

        private void exportBtn_Click(object sender, EventArgs e)
        {
            saveFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                _savePath = saveFileDialog1.FileName;
                _exporter.WriteToFile(_sbRecordsRead,_savePath);
                openFileBtn.Visible = true;
            }
            
        }
        private void openFileBtn_Click(object sender, EventArgs e)
        {
            Process.Start(_savePath);
        }
        private void Form1_Load(object sender, EventArgs e)
        {
          
        }
    }
}
