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
using System.Net;
using System.Text.RegularExpressions;


namespace ncch
{
    public partial class Form1 : Form
    {

        Label[][] classTable;
        bool isTemOutBusy;

        public Form1()
        {
            isTemOutBusy = false;
            Console.WriteLine("hh");
            InitializeComponent();
            initialGui();
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
          
          

            
            if(!Directory.Exists(@"./data")){
                Directory.CreateDirectory(@"./data");
            }
            if(File.Exists(@"./dataGridView1/departmentName.txt"))
            {
                isTemOutBusy = true;
 
                fatchMenu();
      
                while (isTemOutBusy) { ;}           //  avoid open same file by two way in the same time;
        
                StreamReader sr1 = new StreamReader(@"tempOut.txt");
               
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
            }
            Console.WriteLine("kk");
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


        private void initialGui()
        {
            //  initial the table of class
            classTable = new Label[8][];

            for (int i = 0; i < 8; i++)
            {
                classTable[i] = new Label[14];
                for (int j = 0; j < 14; j++)
                {
                    classTable[i][j] = new Label();
                    classTable[i][j].Visible = true;
                    classTable[i][j].BackColor = Color.White;
                    tableLayoutPanel1.Controls.Add(classTable[i][j], i, j);
                    // classTable[i][j].Text=i.ToString()+","+j.ToString();      //  to test the label location
                    classTable[i][j].AutoSize = true;
                }
            }

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            for (int i = 1; i < 11; i++)
            {
                classTable[0][i].Text = "第 " + (i - 1).ToString() + " 節";

            }

            classTable[0][11].Text = "第A節";
            classTable[0][12].Text = "第B節";
            classTable[0][13].Text = "第C節";


            classTable[1][0].Text = "星期一";
            classTable[2][0].Text = "星期二";
            classTable[3][0].Text = "星期三";
            classTable[4][0].Text = "星期四";
            classTable[5][0].Text = "星期五";
            classTable[6][0].Text = "星期六";
            classTable[7][0].Text = "星期日";

            initComboBox();



        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {


            fatchMenu();
            fatchCourse("F7"); 

        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void fatchMenu()
        {
            if (backgroundFatchMenu.IsBusy == false)
            {
                backgroundFatchMenu.RunWorkerAsync();
               
            }
        }

        private void backgroundFatchMenu_DoWork(object sender, DoWorkEventArgs e)
        {   //implement by backgroundWorker (thread)
            Regex findLSpaces = new Regex(@"\s*\(\s*", RegexOptions.Compiled);
            Regex findRSpaces = new Regex(@"\s*）\s*", RegexOptions.Compiled);
            Regex findUnnecessarySpaces = new Regex(@"\s+", RegexOptions.Compiled);
            Regex findTitle = new Regex(@">.*<", RegexOptions.Compiled);

            Console.WriteLine(">start fatching");
            WebClient web = new WebClient();
            byte[] html = web.DownloadData("http://course-query.acad.ncku.edu.tw/qry/");
            Console.WriteLine(">download finished");

            //change encoding
            string input = Encoding.UTF8.GetString(html);

            string[] lines = Regex.Split(input, "\n");

            Console.WriteLine(">matching data...");
            MatchCollection datas = null;
            int idx;
            for (idx = 0; idx < lines.Length; idx++)
            {
                if (Regex.IsMatch(lines[idx], "課程資訊請洽超連結網頁之相關人員!"))
                {
                    break;
                }
            }

            for (; idx < lines.Length; idx++)
            {
                if (Regex.IsMatch(lines[idx], "<li>"))
                {
                    datas = Regex.Matches(lines[idx], @"<a.*?a>");
                    break;
                }
            }

            if (idx >= lines.Length || datas == null)
            {
                //failed
                Console.WriteLine(">failed to match data");
                return;
            }

            StreamWriter fout = new StreamWriter("tempOut.txt");    //for debug

            string tmp;
            foreach (Match cur in datas)
            {
                tmp = findTitle.Match(cur.Value).Value;
                tmp = findLSpaces.Replace(tmp, "(");
                tmp = findRSpaces.Replace(tmp, ")");
                tmp = findUnnecessarySpaces.Replace(tmp, " ");
                string title = tmp.Substring(5, tmp.Length - 6);
                string id = tmp.Substring(2, 2);

                fout.WriteLine(id + "  " + title);
            }

            fout.Flush(); fout.Close();

            Console.WriteLine(">done!");
            isTemOutBusy = false;
        }

        private void fatchCourse(string depr)
        {
            if (backgroundFatchCourse.IsBusy == false)
            {
                isTemOutBusy = true;
                backgroundFatchCourse.RunWorkerAsync(depr);
                isTemOutBusy = false;
            }
        }

        private void backgroundFatchCourse_DoWork(object sender, DoWorkEventArgs e)
        {
            Regex findHtmlTag = new Regex(@"<.*?>", RegexOptions.Compiled);
            Regex findTD = new Regex(@"<TD.*?TD>", RegexOptions.Compiled);

            Console.WriteLine(">start fatching");
            WebClient web = new WebClient();
            byte[] html = web.DownloadData("http://course-query.acad.ncku.edu.tw/qry/qry001.php?dept_no=" + (string)e.Argument);
            Console.WriteLine(">download finished");

            string input = Encoding.UTF8.GetString(html);

            string[] lines = Regex.Split(input, "\n");

            StreamWriter fout = new StreamWriter("courseOut.txt");

            int i = 0;
            string id = null,
                cls = null,
                grade = null,
                type = null,
                english = null,
                name = null,
                necessary = null,
                point = null,
                teacher = null,
                time = null,
                place = null,
                other = null;

            foreach (string cur in lines)
            {   //bug here
                if (findTD.IsMatch(cur))
                {
                    switch (++i)
                    {
                        case 3:
                            id = (string)e.Argument + findHtmlTag.Replace(cur, "");
                            break;
                        case 6:
                            cls = findHtmlTag.Replace(cur, ""); ;
                            break;
                        case 7:
                            grade = findHtmlTag.Replace(cur, "");
                            break;
                        case 8:
                            type = findHtmlTag.Replace(cur, "");
                            break;
                        case 10:
                            english = findHtmlTag.Replace(cur, "");
                            break;
                        case 11:
                            name = findHtmlTag.Replace(cur, "");
                            break;
                        case 12:
                            necessary = findHtmlTag.Replace(cur, "");
                            break;
                        case 13:
                            string tmp = findHtmlTag.Replace(cur, "");
                            point = tmp.Substring(0, 1);
                            teacher = tmp.Substring(1);
                            break;
                        case 16:
                            time = findHtmlTag.Replace(cur, "");
                            break;
                        case 17:
                            place = findHtmlTag.Replace(cur, "");
                            break;
                        case 18:
                            other = findHtmlTag.Replace(cur, "");
                            break;
                        case 23:
                            i = 0;
                            fout.WriteLine(id + "\t" + cls + "\t" + grade + "\t" + type + "\t" + english + "\t" + name + "\t" + necessary + "\t" + point + "\t" + teacher + "\t" + time + "\t" + place + "\t" + other);
                            break;
                    }
                }
            }
            fout.Flush();
            fout.Close();
        }
    }
}
