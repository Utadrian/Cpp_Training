using System;
using DataAccess.ClassLibrary;
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

    public partial class Form4 : Form
    {
        public IDebitAccountsRepository _debitAccountsRepository;
        public ICreditAccountsRepository _creditAcountsRepository;

        public Form4()
        {
            _debitAccountsRepository = new DebitAccountsRepository();
            _creditAcountsRepository = new CreditAccountsRepository();
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            BindDebitAccounts();
            BindCreditAccounts();
        }

        private void BindCreditAccounts()
        {
            var accounts = _debitAccountsRepository.GetDebitAccounts(textBox1.Text);
            dataGridView2.DataSource = accounts;
        }

        private void BindDebitAccounts()
        {
            var accounts = _creditAcountsRepository.GetCreditAccounts(textBox1.Text);
            dataGridView1.DataSource = accounts;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }
    }
}
