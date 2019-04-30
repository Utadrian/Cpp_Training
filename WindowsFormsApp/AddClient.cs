using DataAccess.ClassLibrary;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp
{
    public partial class AddClient : Form
    {
        private readonly IClientsDataRepository _clientsDataRepository;
        private readonly IBanksDataRepository _banksDataRepository;

        public AddClient()
        {
            _clientsDataRepository = new ClientsDataRepository();
            _banksDataRepository = new BanksDataRepository();
            InitializeComponent();

            BindBanks();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                _clientsDataRepository.AddNewClient(textBox1.Text, textBox2.Text, DateTime.Parse(textBox3.Text), (int)comboBox1.SelectedValue);
            }
            catch(CNPTriggerException)
            {
                MessageBox.Show("Ne pare rău dar data naşterii introdusă nu corespunde cu CNP-ul. Vă rugăm reîncercaţi!");
                Close();
                return;
            }

            var formPopup = new AddAccount();
            formPopup.ShowDialog(this);

            Close();
        }

        private void BindBanks()
        {
            var banks = _banksDataRepository.GetAllBanks();
            comboBox1.DataSource = banks;
            comboBox1.DisplayMember = "Nume";
            comboBox1.ValueMember = "IdBancă";
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
