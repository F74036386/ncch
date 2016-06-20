using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ncch
{
    public partial class updateForm : Form
    {
        Form1 mainform;
        public updateForm()
        {
            InitializeComponent();
            iniComboBox();
        }

        public updateForm(Form1 mform)
        {
            InitializeComponent();
            mainform = mform;
        }

        private void iniComboBox()       //  have not written
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
