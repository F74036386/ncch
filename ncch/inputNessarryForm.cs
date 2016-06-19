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
    public partial class inputNessarryForm : Form
    {
        Form1 mainform;
        public inputNessarryForm()
        {
            InitializeComponent();
        }
        public inputNessarryForm(Form1 form)
        {
            mainform = form;
            InitializeComponent();
        }

        
        private void inputbutton_Click(object sender, EventArgs e)
        {

        }
    }
}
