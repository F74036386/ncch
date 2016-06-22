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
            iniComboBox();
        }

        private void iniComboBox()       //  have not written
        {
                comboBox1.Items.Add("目錄");
                if (!File.Exists(@"./data/deptData.txt")) mainform.fetchMenu();
                while (mainform.isTemOutBusy) { ;}           //  avoid open same file by two way in the same time;
                mainform.isTemOutBusy = true;
                StreamReader sr1 = new StreamReader(@"./data/deptData.txt");
                
                string tem1 = sr1.ReadLine();
                Console.WriteLine("tem"+tem1);
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
            LUpdateStatus.Text = "更新中，請稍候...";
            LUpdateStatus.Update();

            if (comboBox1.Text == "目錄")
            {
                mainform.fetchMenu();
            }
            else
            {
                string de = comboBox1.Text.Substring(0, 2);
                mainform.fetchCourse(de);
            }

            LUpdateStatus.Text = "更新完成!";
        }
    }
}
