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
    public partial class Form1 : Form
    {
        private readonly IBanksDataRepository _banksDataRepository;
        public Form1()
        {
            _banksDataRepository = new BanksDataRepository();
            InitializeComponent();

            BindBanks();
        }

        private void BindBanks()
        {
            var banks = _banksDataRepository.GetAllBanks();
            comboBox1.DataSource = banks;
            comboBox1.DisplayMember = "Name";
            comboBox1.ValueMember = "Id";
        }
    }
}
