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
    public partial class AddAccount : Form
    {
        public AddAccount()
        {
            InitializeComponent();

            BindCombobBox();
        }

        public void BindCombobBox()
        {
            var stringList = new List<string>() {"<Selectaţi din listă>", "Credit", "Debit" };
            comboBox1.DataSource = stringList;
        }

        private void comboBox1_SelectionChangeCommitted(object sender, EventArgs e)
        {

        }
    }
}
