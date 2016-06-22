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
    public partial class idDeleteCourseForm : Form
    {
       Form1 mainform;
        public idDeleteCourseForm()
        {
            InitializeComponent();
            iniComboBox();
        }
        public idDeleteCourseForm( Form1 form)

        {
            mainform = form;
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

        private void button1_Click(object sender, EventArgs e)
        {
            string cId = "";
            string de = comboBox1.Text.Substring(0, 2);
            if (textBox2.Text != "") cId = textBox2.Text;
            courseData co = mainform.searchCourseById(de,cId);
            if (co == null)
            {
                MessageBox.Show("代碼錯誤");
            }
            else
            {
                mainform.deleteCourseFromTable(co);
            }
        }

        private void textBox2_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) button1_Click(null, null);
        }

    }
}
