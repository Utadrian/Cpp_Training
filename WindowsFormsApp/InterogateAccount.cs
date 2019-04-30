using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DataAccess.ClassLibrary;

namespace WindowsFormsApp
{
    public partial class InterogateAccount : Form
    {
        public IClientsDataRepository _clientsDataRepository;

        public InterogateAccount()
        {
            _clientsDataRepository = new ClientsDataRepository();
            InitializeComponent();
            BindCombo();
        }

        public void BindCombo()
        {
            List<AccountTypes> _comboFiller = new List<AccountTypes>();
            _comboFiller.Add(new AccountTypes { id = 1, data = "Credit" });
            _comboFiller.Add(new AccountTypes { id = 2, data = "Debit" });
            comboBox1.DataSource = _comboFiller;
            comboBox1.DisplayMember = "data";
            comboBox1.ValueMember = "id";
        }

        public void BindGrid()
        {
            Object output = new object();
            output = _clientsDataRepository.GetAccountDetails(textBox2.Text, int.Parse(textBox1.Text), (int)comboBox1.SelectedValue);
            if ((int)comboBox1.SelectedValue == 1)
            {
                List<CompleteCreditAccounts> creditAccounts = new List<CompleteCreditAccounts>();
                creditAccounts.Add((CompleteCreditAccounts)output);
                dataGridView1.DataSource = creditAccounts;
            }
            else
            {
                List<CompleteDebitAccounts> debitAccounts = new List<CompleteDebitAccounts>();
                debitAccounts.Add((CompleteDebitAccounts)output);
                dataGridView1.DataSource = debitAccounts;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindGrid();
        }

        private void Form5_Load(object sender, EventArgs e)
        {

        }
    }
}
