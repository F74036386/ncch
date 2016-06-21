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
            initComboBox();
        }
        private void initComboBox()
        {
            comboBoxGrade.Items.Add("1");
            comboBoxGrade.Items.Add("2");
            comboBoxGrade.Items.Add("3");
            comboBoxGrade.Items.Add("4");

            comboBoxClass.Items.Add("甲班");
            comboBoxClass.Items.Add("乙班");
            comboBoxClass.Items.Add("丙班");

            if (!Directory.Exists(@"./data"))
            {
                Directory.CreateDirectory(@"./data");
            }
            if (!File.Exists(@"./data/departmentName.txt"))
            {
               //mainform. isTemOutBusy = true;

               //mainform.fatchMenu();

               while (mainform.isTemOutBusy) { ;}           //  avoid open same file by two way in the same time;
               mainform.isTemOutBusy = true;
                StreamReader sr1 = new StreamReader(@"./data/tempOut.txt");

                StreamWriter sw1 = new StreamWriter(@"./data/departmentName.txt");

                string tem1 = sr1.ReadLine();

                while (tem1 != null)
                {
                    char[] temch = tem1.ToCharArray();

                    if (temch[0] == 'A')
                    {
                        tem1 = sr1.ReadLine();
                        continue;
                    }
                    else if (temch[0] == 'Z' && temch[1] == '0')
                    {
                        tem1 = sr1.ReadLine();
                        continue;

                    }
                    else if (temch[0] == 'S' && temch[1] == '0')
                    {
                        tem1 = sr1.ReadLine();
                        continue;
                    }
                    else if (temch[0] == 'R' && temch[1] == 'Z')
                    {
                        tem1 = sr1.ReadLine();
                        continue;
                    }
                    else if (temch[0] == 'C' && temch[1] == '0')
                    {
                        tem1 = sr1.ReadLine();
                        continue;
                    }

                    else if (temch[0] == 'E' && temch[1] == '0')
                    {
                        tem1 = sr1.ReadLine();
                        continue;

                    }
                    sw1.WriteLine(tem1);
                    sw1.Flush();
                    tem1 = sr1.ReadLine();
                }
                sw1.Close();
                sr1.Close();
                mainform.isTemOutBusy = false;
            }
          
            StreamReader sr = new StreamReader(@"./data/departmentName.txt");
            string tem = sr.ReadLine();

            while (tem != null)
            {
                comboBoxDepartment.Items.Add(tem);
                tem = sr.ReadLine();
            }
            sr.Close();
            comboBoxClass.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepartment.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxGrade.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxDepartment.SelectedIndex = 0;
            comboBoxGrade.SelectedIndex = 0;
            comboBoxClass.SelectedIndex = 0;


        }
        
        private void inputbutton_Click(object sender, EventArgs e)
        {
            string depart = comboBoxDepartment.Text.ToCharArray()[0].ToString()+comboBoxDepartment.Text.ToCharArray()[1].ToString();
            string grade = comboBoxGrade.Text;
            string cla = comboBoxClass.Text;
            mainform.inputNessarry(depart, grade, cla);
        }
    }
}
