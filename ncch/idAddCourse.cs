using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace ncch
{
    public partial class idAddCourse : Form
    {
        Form1 mainform;
        public idAddCourse()
        {
            InitializeComponent();
            iniComboBox();
        }
        public idAddCourse( Form1 form1)
        {
            mainform = form1;
            InitializeComponent();
            iniComboBox();
        }
        private void iniComboBox()       //  have not written
        {
            if (!File.Exists(@"./data/deptData.txt")) mainform.fetchMenu();

            while (mainform.isTemOutBusy) {; }           //  avoid open same file by two way in the same time;
            mainform.isTemOutBusy = true;

            StreamReader sr1 = new StreamReader(@"./data/deptData.txt");

            string tem1 = sr1.ReadLine();
            Console.WriteLine("tem" + tem1);
            while (tem1 != null)
            {
                comboBox1.Items.Add(tem1);
                tem1 = sr1.ReadLine();
            }
            sr1.Close();
            mainform.isTemOutBusy = false;
            comboBox1.SelectedIndex = 0;
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string cId="";
            string de = comboBox1.Text.Substring(0, 2);
            if (textBox2.Text != "") cId = textBox2.Text;
            courseData cour = mainform.searchCourseById(de, cId);
            if (cour != null)
            {
                mainform.addCourseToTable(cour);
            }
            else
            {
                MessageBox.Show("沒有找到該課程");
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) buttonAdd_Click(null, null);
        }

    }
}
