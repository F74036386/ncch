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

        private void initComboBox2()
        {
            comboBoxGrade.Enabled = false;
            comboBoxClass.Enabled = false;
            comboBoxDepartment.Enabled = true;
            comboBoxDepartment.Text = "請先選系所";

            if (!Directory.Exists(@"./data"))
            {
                Directory.CreateDirectory(@"./data");
            }
            if (!File.Exists(@"./data/departmentName.txt"))
            {
                //mainform. isTemOutBusy = true;

                //mainform.fatchMenu();
                if (!File.Exists(@"./data/tempOut.txt")) mainform.fetchMenuByFile();
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
                comboBoxDepartment.TextChanged += new EventHandler(slectDepart);
                comboBoxGrade.TextChanged += new EventHandler(slectGrade);
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
        }

        private void slectDepart(object sender, EventArgs e)
        {
            if (comboBoxDepartment.SelectedIndex == 0) return;
            comboBoxGrade.Enabled = true;
            comboBoxGrade.Items.Clear();
            comboBoxGrade.Items.Add("請選年級");
            string depart = comboBoxDepartment.Text.ToCharArray()[0].ToString() + comboBoxDepartment.Text.ToCharArray()[1].ToString();

            int num = mainform.howManyGradeInTheDepart(depart);
            for (int i = 1; i <= num; i++)
            {
                comboBoxGrade.Items.Add(i.ToString());
            }
            comboBoxGrade.SelectedIndex = 0;
        }

        private void slectGrade(object sender, EventArgs e)
        {
            if (comboBoxGrade.SelectedIndex == 0) return;
            comboBoxClass.Items.Clear();
            comboBoxClass.Enabled = true;
            comboBoxClass.Items.Add("請選班級");
            string depart = comboBoxDepartment.Text.ToCharArray()[0].ToString() + comboBoxDepartment.Text.ToCharArray()[1].ToString();
            int grade = Int32.Parse(comboBoxGrade.Text);
            int num = mainform.howManyClassInTheDepart(depart, grade);
            if (num == 1)
            {
                comboBoxClass.Items.Add("只有一班");
            }
            if (num == 2)
            {
                comboBoxClass.Items.Add("甲班");
                comboBoxClass.Items.Add("乙班");
            }
            if (num == 3)
            {
                comboBoxClass.Items.Add("甲班");
                comboBoxClass.Items.Add("乙班");
                comboBoxClass.Items.Add("丙班");
            }
            comboBoxClass.SelectedIndex = 0;
        }

        private void initComboBox()
        {
            comboBoxGrade.Items.Add("1");
            comboBoxGrade.Items.Add("2");
            comboBoxGrade.Items.Add("3");
            comboBoxGrade.Items.Add("4");
            comboBoxGrade.Items.Add("5");
            comboBoxGrade.Items.Add("6");
            comboBoxGrade.Items.Add("7");


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
                if (!File.Exists(@"./data/tempOut.txt")) mainform.fetchMenuByFile();
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
