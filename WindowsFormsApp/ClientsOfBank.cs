using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataAccess.ClassLibrary
{

    public partial class Form3 : Form
    {
        public IClientsDataRepository _clientsDataRepository;
        public IBanksDataRepository _banksDataRepository;

        public Form3()
        {
            _clientsDataRepository = new ClientsDataRepository();
            _banksDataRepository = new BanksDataRepository();
            InitializeComponent();

            BindBanks();
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }

        private void BindBanks()
        {
            var banks = _banksDataRepository.GetAllBanks();
            comboBox1.DataSource = banks;
            comboBox1.DisplayMember = "Nume";
            comboBox1.ValueMember = "IdBancă";
        }

        private void BindClients()
        {
            var clients = _clientsDataRepository.GetAllClients((int)comboBox1.SelectedValue);
            dataGridView1.DataSource = clients;
        }

        private void comboBox1_SelectionChangeCommitted_1(object sender, EventArgs e)
        {
            BindClients();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
