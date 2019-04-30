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
    public partial class Home : Form
    {

        public Home()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach(Form f in Application.OpenForms)
            {
                if(f.Text == "Adăugare Client")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                var formPopup = new AddClient();
                formPopup.Show(this);
            }


        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Afişare clienţi ai unei bănci")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                var formPopup = new Form3();
                formPopup.Show(this);
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Afişare conturi utilizator")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                var formPopup = new Form4();
                formPopup.Show(this);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Interogare Cont")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                var formPopup = new InterogateAccount();
                formPopup.Show(this);
            };
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            bool isOpen = false;
            foreach (Form f in Application.OpenForms)
            {
                if (f.Text == "Tranzacţii bancare")
                {
                    isOpen = true;
                }
            }
            if (!isOpen)
            {
                var formPopup = new FinancialTransaction();
                formPopup.Show(this);
            };
        }
    }
}
