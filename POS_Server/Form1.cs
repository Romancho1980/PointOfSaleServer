using POS_Server.Context;
using POS_Server.Models;
using POS_Server.Services;
using POS_Server.Views;

namespace POS_Server
{
    public partial class Form1 : Form
    {
        // Данные 



        public ApplicationDbContext dbContext;
        public DbService dbService;
        public ClientAccount? SelectedClientAccount { get; set; }
        public string SelectedAccount { get; set; }



        public Form1()
        {
            dbContext = new ApplicationDbContext();
            dbService = new DbService(dbContext);
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            timer1.Stop();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            timer1.Start();
            listBox1.Items.Clear();
            var data = dbService.GetAllClients();
            foreach (var item in data)
            {
                listBox1.Items.Add(item.Name + " " + item.Surname);
            }

        }

        private void RefreshData()
        {
            var data = dbService.GetAllClients().ToList();
            int index = listBox1.SelectedIndex;

            if (index != -1)
                SelectedClientAccount = data[index];

            if (SelectedClientAccount != null)
            {
                label12.Text = SelectedClientAccount.Name;
                label11.Text = SelectedClientAccount.Surname;
                label10.Text = SelectedClientAccount.INN;
                label9.Text = SelectedClientAccount.Passport;
                label8.Text = SelectedClientAccount.City;
                label18.Text = SelectedClientAccount.Account;
                label20.Text = $"{SelectedClientAccount.Balance.ToString()} руб";
            }
        }
        private void listBox1_Click(object sender, EventArgs e)
        {
            RefreshData();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            AddClient newForm = new AddClient();
            newForm.ShowDialog();

            var EditingData = new ClientAccount();
            EditingData = newForm.GetUpdatedData();

            dbService.AddClient(EditingData);
            Form1_Load(sender, e);
        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (SelectedClientAccount != null)
            {
                AddClient newForm = new AddClient(SelectedClientAccount);
                var EditingData = new ClientAccount();
                newForm.ShowDialog();
                EditingData = newForm.GetUpdatedData();
                dbService.UpdateClient(EditingData);

                Form1_Load(sender, e);
                RefreshData();
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (SelectedClientAccount != null)
            {
                dbService.DeleteClient(SelectedClientAccount);
                Form1_Load(sender, e);
                var clients = dbService.GetAllClients().ToList();
                if (clients.Count() > 0)
                {
                    SelectedClientAccount = clients[clients.Count() - 1];
                    listBox1.SelectedIndex = clients.Count() - 1;
                    RefreshData();
                }
                else
                {
                    SelectedClientAccount=null;
                }
            }
        }
    }
}
