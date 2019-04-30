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
    public partial class FinancialTransaction : Form
    {
        public IClientsDataRepository _clientsDataRepository;

        public FinancialTransaction()
        {
            _clientsDataRepository = new ClientsDataRepository();

            InitializeComponent();

            BindCombo();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        public void BindCombo()
        {
            List<AccountTypes> _comboFiller1 = new List<AccountTypes>();
            _comboFiller1.Add(new AccountTypes { id = 1, data = "Credit" });
            _comboFiller1.Add(new AccountTypes { id = 2, data = "Debit" });
            comboBox1.DataSource = _comboFiller1;
            comboBox1.DisplayMember = "data";
            comboBox1.ValueMember = "id";
            List<AccountTypes> _comboFiller2 = new List<AccountTypes>();
            _comboFiller2.Add(new AccountTypes { id = 1, data = "Credit" });
            _comboFiller2.Add(new AccountTypes { id = 2, data = "Debit" });
            comboBox2.DataSource = _comboFiller2;
            comboBox2.DisplayMember = "data";
            comboBox2.ValueMember = "id";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("Sunteţi siguri că doriţi să faceţi această tranzacţie?", "Atenţie!", MessageBoxButtons.YesNo);
            if (dialogResult == DialogResult.Yes)
            {
                if (_clientsDataRepository.PerformFinancialTransaction(textBox3.Text,
                int.Parse(textBox1.Text),
                int.Parse(textBox2.Text),
                (AccType)comboBox1.SelectedValue,
                (AccType)comboBox2.SelectedValue,
                int.Parse(textBox4.Text)) == true)
                {
                    MessageBox.Show("Tranzacţie reuşită!");
                }
                else
                {
                    MessageBox.Show("Tranzacţie eşuată!");
                }
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {

        }

        private void Form6_Load_1(object sender, EventArgs e)
        {

        }
    }
}
