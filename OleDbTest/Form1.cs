using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OleDbTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            string connectionString = "Provider=Search.CollatorDSO;Extended Properties=\"Application=Windows\"";
            OleDbConnection connection = new OleDbConnection(connectionString);

            string query =
               "SELECT System.ItemName FROM SystemIndex " +
               "WHERE scope ='file:" + @"D:\" +
               "'";
            OleDbCommand command = new OleDbCommand(query, connection);
            connection.Open();

            List<string> result = new List<string>();

            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                result.Add(reader.GetString(0));

                Debug.WriteLine(reader.GetString(0));       
            }

            connection.Close();
        }


    }
}
