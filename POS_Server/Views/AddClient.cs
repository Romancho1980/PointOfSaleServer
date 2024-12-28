using POS_Server.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace POS_Server.Views
{
    public partial class AddClient : Form
    {
        ClientAccount update = new ClientAccount();
        public string Name { get; set; } = string.Empty;

        public ClientAccount GetUpdatedData()
        {
            return update;
        }
        public AddClient()
        {
            InitializeComponent();
        }
        public AddClient(ClientAccount data)
        {
            update = data;
            InitializeComponent();
            textBox1.Text = data.Name;
            textBox2.Text = data.Surname;
            textBox3.Text = data.INN;
            textBox4.Text = data.Passport;
            textBox5.Text = data.City;
            textBox6.Text = data.Account;
            textBox7.Text = data.Balance.ToString();
            textBox8.Text = data.Description;


            dateTimePicker1.Value = data.Birthday;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            update.Name = textBox1.Text;
            update.Surname = textBox2.Text;
            update.INN = textBox3.Text;
            update.Passport = textBox4.Text;
            update.City = textBox5.Text;
            update.Account = textBox6.Text;
            update.Balance = int.Parse(textBox7.Text);
            update.Description = textBox8.Text;

            update.Birthday = dateTimePicker1.Value;
            Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

    }
}
