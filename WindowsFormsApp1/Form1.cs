using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        OleDbConnection connection = new OleDbConnection("Provider=Microsoft.Jet.Oledb.4.0;Data Source=personel.mdb");

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            connection.Open();
            OleDbCommand person_Command = new OleDbCommand("select * from kişi", connection);
            OleDbDataReader person_Read = person_Command.ExecuteReader();

            while (person_Read.Read())
            {
                string name = person_Read["adı"].ToString();
                int job_id = person_Read.GetInt32(2);
                int car_id = Convert.ToInt32(person_Read[3]);

                OleDbCommand job_Command = new OleDbCommand("select meslek_adı from meslek where meslek_id=" +job_id, connection);

                OleDbDataReader job_Read = job_Command.ExecuteReader();
                job_Read.Read();

                string job_name = job_Read["meslek_adı"].ToString();

                OleDbCommand car_command = new OleDbCommand("select araba_adı from araba where araba_id=" + car_id, connection);
                OleDbDataReader car_read = car_command.ExecuteReader();
                car_read.Read();

                string car_name = car_read["araba_adı"].ToString();

                listBox1.Items.Add(name + "\t" + job_name + "\t" + car_name);


            }

            connection.Close();
        }
    }
}
