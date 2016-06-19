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
        /********************class menber varible*******************/
        private Label[][] courseTableLabel;
        private bool isTemOutBusy;
        private bool isFatchCourseBusy;
        private bool isCourseIdBusy;
        public courseData[][] courseTableData;
        public courseData[] courseChoosedList;
        public int amountOfCourseHasSelected;
        private ToolTip[][] toolTipTable;
        private ContextMenuStrip[][] contexMenuStripTable;
        public Color generalEduColor;
        public Color necessaryColor;
        public Color chooseColor;
        public Color userDefineColor;

        /****************************function******************/

        public Form1()
        {
            isTemOutBusy = false;
            isCourseIdBusy = false;
            isFatchCourseBusy = false;
            
            InitializeComponent();
            initialCourseTableLabel();
            iniCourseDataTable();
            iniCourseChooseList();
            initComboBox();
            iniToolTipOfLabelForTable();
            iniContextMenuStripTable();
        }

        public courseData serchCourseById(string departId, string courseId)////     has not written
        {
              
           return null;
        }

        public void inputNessarry(string department,string grade,string cla)////    has not written
        {
            return;
        }

        public int allPointOfAlreadySlectedCourse()
        {
            int k = 0;
            for (int i = 0; i < amountOfCourseHasSelected; i++)
            {
                k += Int32.Parse(courseChoosedList[i].point);
            }

                return k;
        }

        private void iniContextMenuStripTable()
        {
            contexMenuStripTable=new ContextMenuStrip[8][];
            for(int i=0;i<8;i++){
                contexMenuStripTable[i]=new ContextMenuStrip[14];
                for (int j = 0; j < 14; j++)
                {
                    contexMenuStripTable[i][j] = null;
                }

            }
        }
        
        private void iniToolTipOfLabelForTable()
        {
            toolTipTable = new ToolTip[8][];
            for (int i = 0; i < 8; i++)
            {
                toolTipTable[i] = new ToolTip[14];
                for (int j = 0; j < 14; j++)
                {
                    toolTipTable[i][j] = null;
                }
            }
        }
      
        private void iniCourseChooseList()
        {
           courseChoosedList=new courseData[30];
           amountOfCourseHasSelected = 0;
           for (int i = 0; i < 30; i++)
           {
               courseChoosedList[i] = null;
           }        
        }

        private void addCourseToCourseChooseList(courseData course)
        {
            int k = -1;
            for (int i = 0; i < amountOfCourseHasSelected; i++)
            {
                if (Convert.ToInt16(courseChoosedList[i].point) > Convert.ToInt16(course.point)) {
                    k = i;
                    break;
                }
            }
            if (k == -1)
            {
                courseChoosedList[amountOfCourseHasSelected] = course;
            }
            else
            {
                for (int j = amountOfCourseHasSelected; j > k;j-- )
                {
                    courseChoosedList[j] = courseChoosedList[j - 1];
                }
                courseChoosedList[k]=course;
            }
            amountOfCourseHasSelected++;
        }
      
        private void deleteCourseFromCourseChooseList(courseData course)
        {   int k=-1;
            for (int i = 0; i < amountOfCourseHasSelected; i++)
            {
                if(courseChoosedList[i].Equals(course)){
                    courseChoosedList[i]=null;
                    k=i;
                }
            }
            if(k>=0){
                for(int j=k;k<amountOfCourseHasSelected-1;j++){
                    courseChoosedList[j]=courseChoosedList[j+1];
                }
                courseChoosedList[amountOfCourseHasSelected-1]=null;
            }
             amountOfCourseHasSelected--;
        }

        private void iniCourseDataTable()
        {
            courseTableData=new courseData[8][];
            for (int i = 0; i < 8; i++)
            {
                courseTableData[i] = new courseData[14];
                for(int j=0;j<14;j++){
                    courseTableData[i][j] = null;
                }
            }
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

        private void initialCourseTableLabel()
        {
            //  initial the table of class
            courseTableLabel = new Label[8][];

            for (int i = 0; i < 8; i++)
            {
                courseTableLabel[i] = new Label[15];
                for (int j = 0; j < 15; j++)
                {
                    courseTableLabel[i][j] = new Label();
                    courseTableLabel[i][j].Visible = true;
                    courseTableLabel[i][j].BackColor = Color.White;
                    courseTableLabel[i][j].Anchor = AnchorStyles.None;
                    courseTableLabel[i][j].Dock = DockStyle.Fill;
               

                    tableLayoutPanel1.Controls.Add(courseTableLabel[i][j], i, j);
                    courseTableLabel[i][j].Text = i.ToString() + "," + j.ToString() + "\n\n\n";      //  to test the label location
                    courseTableLabel[i][j].AutoSize = true;
                }
            }

      
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            for (int i = 1; i < 6; i++)
            {
                courseTableLabel[0][i].Text = "第 " + (i - 1).ToString() + " 節";

            }

            courseTableLabel[0][6].Text = "第N節";
            for (int i = 6; i < 11; i++)
            {
                courseTableLabel[0][i+1].Text = "第 " +(i-1).ToString() + " 節";

            }
            courseTableLabel[0][12].Text = "第A節";
            courseTableLabel[0][13].Text = "第B節";
            courseTableLabel[0][14].Text = "第C節";

            courseTableLabel[1][0].Text = "星期一";
            courseTableLabel[2][0].Text = "星期二";
            courseTableLabel[3][0].Text = "星期三";
            courseTableLabel[4][0].Text = "星期四";
            courseTableLabel[5][0].Text = "星期五";
            courseTableLabel[6][0].Text = "星期六";
            courseTableLabel[7][0].Text = "星期日";

            generalEduColor = Color.DarkOrange;
            necessaryColor = Color.LightGray;
            chooseColor = Color.MediumSeaGreen;
            userDefineColor = Color.LightSalmon;
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {

          //  fatchMenu();
            //fatchAllCourse();
           fatchCourse("F7");
        }

        private void fatchAllCourse()
        {
            while (isCourseIdBusy) { ;};
            StreamReader sr = new StreamReader(@"./data/courseId.txt");
            backgroundFatchCourse.WorkerSupportsCancellation = true; ;
            string str = sr.ReadLine();
            while (str != null)
            {
                while (backgroundFatchCourse.IsBusy) {;};

                Console.WriteLine("ll");
                while (backgroundFatchCourse.IsBusy) { ;};
                Console.WriteLine("lll");
                fatchCourse(str);
                Console.WriteLine(str);
                str = sr.ReadLine();
            }
            sr.Close();
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
            for (idx = 0; idx < lines.Length; idx++)    //find location of course data
                if (Regex.IsMatch(lines[idx], "課程資訊請洽超連結網頁之相關人員!")) break;

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

            if (!Directory.Exists(@"./data"))
            {
                Directory.CreateDirectory(@"./data");
            }


            /****************what's this?*****************/
            while (isCourseIdBusy) { ;};
            isCourseIdBusy = true;
            StreamWriter fout = new StreamWriter("./data/tempOut.txt");    //for debug
            StreamWriter fidout = new StreamWriter(@"./data/courseId.txt");

            string tmp;
            foreach (Match cur in datas)
            {
                //replace useless string data
                tmp = findTitle.Match(cur.Value).Value;
                tmp = findLSpaces.Replace(tmp, "(");
                tmp = findRSpaces.Replace(tmp, ")");
                tmp = findUnnecessarySpaces.Replace(tmp, " ");
                string title = tmp.Substring(5, tmp.Length - 6);
                string id = tmp.Substring(2, 2);

                fout.WriteLine(id + "  " + title);
                fidout.WriteLine(id);
            }
            fidout.Flush(); fidout.Close();
            fout.Flush(); fout.Close();

            Console.WriteLine(">done!");
            isTemOutBusy = false;
            isCourseIdBusy = false;
        }

        private void fatchCourse(string depr)
        {
           if(backgroundFatchCourse.IsBusy == false)
            {
                backgroundFatchCourse.RunWorkerAsync(depr);
              
            }
        }

        private void backgroundFatchCourse_DoWork(object sender, DoWorkEventArgs e)
        {
            isFatchCourseBusy = true;
            Regex findHtmlTag = new Regex(@"<.*?>", RegexOptions.Compiled);
            Regex findTD = new Regex(@"<TD.*?TD>", RegexOptions.Compiled);

            Console.WriteLine(">start fatching");
            WebClient web = new WebClient();
            byte[] html = web.DownloadData("http://course-query.acad.ncku.edu.tw/qry/qry001.php?dept_no=" + (string)e.Argument);
            Console.WriteLine(">download finished");

            string input = Encoding.UTF8.GetString(html);

            string[] lines = Regex.Split(input, "\n");

            StreamWriter fout = new StreamWriter(@"./data/courseOut"+e.Argument+".txt");

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
                            id = (string)e.Argument +"_"+ findHtmlTag.Replace(cur, "");
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
                            fout.WriteLine("id="+id + "\tcls=" + cls + "\tgrade=" + grade + "\ttype=" + type + "\tenglish=" + english + "\tname=" + name + "\tnecessary=" + necessary + "\tpoint=" + point + "\tteacher=" + teacher + "\ttime=" + time + "\tplace=" + place + "\tother=" + other);
                            break;
                    }
                }
            }
            fout.Flush();
            fout.Close();
            isFatchCourseBusy = false;
            Console.WriteLine("fatchCourseFinish");

        }

        private void input_Click(object sender, EventArgs e)
        {
            courseData aa = new courseData();
            aa.name = "aaaaaaaaaaaa";
            aa.courseId = "578";
            aa.departmentId = "A1";
            aa.time = "[5] 7~8";
            addCourseToTable(aa);
            courseData bb = new courseData();
            bb.courseId = "547";
            bb.departmentId = "A1";
            bb.time = "[5] 6~8";
            addCourseToTable(bb);
        }

        private string getTooltipString(courseData course)
        {
            string o="";
            if(course.departmentId!=""){o+=("系所代碼: "+course.departmentId+"\n");}
            if (course.courseId!= "") { o += ("課程代碼: " + course.courseId+"\n"); }
            if (course.name != "") { o += ("課程名稱: " + course.name + "\n"); }
            if (course.teacher != "") { o += ("上課老師: " + course.teacher+"\n"); }
            if (course.point!= "") { o += ("學分數: " + course.point+"學分\n"); }
            if (course.place != "") { o += ("上課地點: " + course.place+"\n"); }
            if (course.other!= "") { o += ("備註: " + course.other+ "\n"); }
            return o;
        }

        private ContextMenuStrip setContexMenuStripForLabel(ref Label label, courseData course)   //has not written
        {
            ContextMenuStrip cm = new ContextMenuStrip();
            label.ContextMenuStrip = cm;


            return cm;
        }

        public void addCourseToTable(courseData course)    //  to add course ;
        {
            if (alreadyChooseCourse(course))
            {
                MessageBox.Show(course.departmentId+course.courseId+"  "+course.name+" \n這堂課選過了喔");
                return;
            }
            if (isconflict(course))
            {
                MessageBox.Show(course.departmentId + course.courseId + "  " + course.name + "\n 這堂課的時間沒空喔");
                return;
            }
            
          char []timechar=course.time.ToCharArray();
          int i = 0;
          int weekday=0;
          int starttime=-1;
          int endtime=-1;
          bool left = false;
          bool slatch = false;

          addCourseToCourseChooseList(course);

          while (i < timechar.Length)
          {
              if (timechar[i] == '[')
              {
                  left = true;
                  slatch=false;
                  if (weekday != 0)
                  {
                      for (int j = starttime; j <= endtime; j++)
                      {
                          courseTableData[weekday][j] = course;

                          if (j != starttime)
                          {
                              tableLayoutPanel1.Controls.Remove(courseTableLabel[weekday][j + 1]);
                          }
                      }
                      courseTableLabel[weekday][starttime + 1].Text = course.departmentId+course.courseId + course.name;
                      toolTipTable[weekday][starttime] = new ToolTip();
                      toolTipTable[weekday][starttime].SetToolTip(courseTableLabel[weekday][starttime + 1],getTooltipString(course));
                      contexMenuStripTable[weekday][starttime] = setContexMenuStripForLabel(ref courseTableLabel[weekday][starttime + 1], courseTableData[weekday][starttime]);
                      addLabelColar(courseTableLabel[weekday][starttime + 1],course);
                      
                      tableLayoutPanel1.SetRowSpan(courseTableLabel[weekday][starttime + 1], endtime - starttime + 1);

                      weekday = 0;
                      starttime = -1;
                      endtime = -1;

                  }
              }
              else if (timechar[i] == ']')
              {
                  left = false;
              }
              else if(timechar[i]=='~'){
                  slatch=true;
              }
              else if (timechar[i] != '[' && timechar[i] != ']' && timechar[i] != 'N' && timechar[i] != 'A' && timechar[i] != 'B' && timechar[i] != 'C' && timechar[i] != '~' && (timechar[i] < '0' || timechar[i] >'9'))
              {

              }
              else if (left)
              {
                  weekday = Int32.Parse(timechar[i].ToString()); 
              }
              else if (slatch)
              {
                  if (timechar[i] == 'A')
                  {
                      endtime = 11;
                  }
                  else if (timechar[i] == 'B')
                  {
                      endtime = 12;
                  }
                  else if (timechar[i] == 'C')
                  {
                      endtime = 13;
                  }
                  else if (timechar[i] == 'N')
                  {
                      endtime =5;
                  }
                  else
                  {
                      endtime = (Int32.Parse(timechar[i].ToString()) < 5) ? Int32.Parse(timechar[i].ToString()) : Int32.Parse(timechar[i].ToString()) + 1;
                  }
                  slatch = false;
              }
              else{
                  if (timechar[i] == 'A')
                  {
                      starttime = 11;
                  }
                  else if (timechar[i] == 'B')
                  {
                      starttime = 12;
                  }
                  else if (timechar[i] == 'C')
                  {
                      starttime = 13;
                  }
                  else if (timechar[i] == 'N')
                  {
                      starttime = 5;
                  }
                  else
                  {
                      starttime = (Int32.Parse(timechar[i].ToString()) < 5) ? Int32.Parse(timechar[i].ToString()) : Int32.Parse(timechar[i].ToString())+1;
                  }
              }
              i++;
          }

          if (weekday != 0)
          {
              for (int j = starttime; j <= endtime; j++)
              {
                  courseTableData[weekday][j] = course;

                  if (j != starttime)
                  {
                      tableLayoutPanel1.Controls.Remove(courseTableLabel[weekday][j + 1]);
                  }
              }
              courseTableLabel[weekday][starttime + 1].Text = course.courseId+course.departmentId + course.name;
              toolTipTable[weekday][starttime] = new ToolTip();
              toolTipTable[weekday][starttime].SetToolTip(courseTableLabel[weekday][starttime + 1], getTooltipString(course));

              addLabelColar(courseTableLabel[weekday][starttime + 1],course);
              tableLayoutPanel1.SetRowSpan(courseTableLabel[weekday][starttime + 1], endtime - starttime + 1);

          }
          MessageBox.Show(course.departmentId + course.courseId + "  " + course.name + "\n加選成功");
        }       

        public void deleteCourseFromTable(courseData course)      //to delete course
        {
            if (!alreadyChooseCourse(course))
            {
                MessageBox.Show(course.departmentId + course.courseId + "  " + course.name + "\n這堂課沒選過喔!");
                return;
            }
            
            char[] timechar = course.time.ToCharArray();
            int i = 0;
            int weekday = 0;
            int starttime = -1;
            int endtime = -1;
            bool left = false;
            bool slatch = false;

            deleteCourseFromCourseChooseList(course);

            while (i < timechar.Length)
            {
                if (timechar[i] == '[')
                {
                    left = true;
                    slatch = false;
                    if (weekday != 0)
                    {
                        tableLayoutPanel1.SetRowSpan(courseTableLabel[weekday][starttime + 1], 1);
                        
                        for (int j = starttime; j <= endtime; j++)
                        {
                            courseTableData[weekday][j] = null ;

                            if (j != starttime)
                            {
                                tableLayoutPanel1.Controls.Add(courseTableLabel[weekday][j + 1]);
                                deleteLabelColar(courseTableLabel[weekday][j + 1]);
                            }
                        }
                        courseTableLabel[weekday][starttime + 1].Text = "\n("+weekday.ToString()+","+(starttime+1).ToString()+")\n";
                        toolTipTable[weekday][starttime] = null;
                        deleteLabelColar(courseTableLabel[weekday][starttime + 1]);

                        tableLayoutPanel1.SetRowSpan(courseTableLabel[weekday][starttime + 1],1);



                        weekday = 0;
                        starttime = -1;
                        endtime = -1;
                        Console.WriteLine("haha");
                    }
                }
                else if (timechar[i] == ']')
                {
                    left = false;
                }
                else if (timechar[i] == '~')
                {
                    slatch = true;
                }
                else if (timechar[i] != '[' && timechar[i] != ']' && timechar[i] != 'N' && timechar[i] != 'A' && timechar[i] != 'B' && timechar[i] != 'C' && timechar[i] != '~' && (timechar[i] < '0' || timechar[i] > '9'))
                {

                }
                else if (left)
                {
                    weekday = Int32.Parse(timechar[i].ToString());
                }
                else if (slatch)
                {
                    if (timechar[i] == 'A')
                    {
                        endtime = 11;
                    }
                    else if (timechar[i] == 'B')
                    {
                        endtime = 12;
                    }
                    else if (timechar[i] == 'C')
                    {
                        endtime = 13;
                    }
                    else if (timechar[i] == 'N')
                    {
                        endtime = 5;
                    }
                    else
                    {
                        endtime = (Int32.Parse(timechar[i].ToString()) < 5) ? Int32.Parse(timechar[i].ToString()) : Int32.Parse(timechar[i].ToString()) + 1;
                    }
                    slatch = false;

                }
                else
                {
                    if (timechar[i] == 'A')
                    {
                        starttime = 11;
                    }
                    else if (timechar[i] == 'B')
                    {
                        starttime = 12;
                    }
                    else if (timechar[i] == 'C')
                    {
                        starttime = 13;
                    }
                    else if (timechar[i] == 'N')
                    {
                        starttime = 5;
                    }
                    else
                    {
                        starttime = (Int32.Parse(timechar[i].ToString()) < 5) ? Int32.Parse(timechar[i].ToString()) : Int32.Parse(timechar[i].ToString()) + 1;
                    }

                }

                i++;
            }
            if (weekday != 0)
            {
                tableLayoutPanel1.SetRowSpan(courseTableLabel[weekday][starttime + 1], 1);
                
                for (int j = starttime; j <= endtime; j++)
                {
                    courseTableData[weekday][j] = null;
                    
                    if (j != starttime)
                    {
                        tableLayoutPanel1.Controls.Add(courseTableLabel[weekday][j + 1]);
                    }
                }
                courseTableLabel[weekday][starttime + 1].Text =   weekday.ToString() + "," + (starttime + 1).ToString() + "\n";
                toolTipTable[weekday][starttime] = null;
                deleteLabelColar(courseTableLabel[weekday][starttime + 1]); 
            }
            MessageBox.Show(course.departmentId + course.courseId + "  " + course.name + "\n退選成功");
        }

        bool isconflict(courseData course)                  //to check the course time is conflict or not
        {
            char[] timechar = course.time.ToCharArray();
            int i = 0;
            int weekday = 0;
            int starttime = -1;
            int endtime = -1;
            bool left = false;
            bool slatch = false;

            while (i < timechar.Length)
            {
                if (timechar[i] == '[')
                {
                    left = true;
                    slatch = false;
                    if (weekday != 0)
                    {
                        for (int j = starttime; j <= endtime; j++)
                        {
                            if (courseTableData[weekday][j] != null) return true; 
                        }
                        weekday = 0;
                        starttime = -1;
                        endtime = -1;
                    }
                }
                else if (timechar[i] == ']')
                {
                    left = false;
                }
                else if (timechar[i] == '~')
                {
                    slatch = true;
                }
                else if (timechar[i] != '[' && timechar[i] != ']' && timechar[i] != 'N' && timechar[i] != 'A' && timechar[i] != 'B' && timechar[i] != 'C' && timechar[i] != '~' && (timechar[i] < '0' || timechar[i] > '9'))
                {

                }
                else if (left)
                {
                    weekday = Int32.Parse(timechar[i].ToString());
                }
                else if (slatch)
                {
                    if (timechar[i] == 'A')
                    {
                        endtime = 11;
                    }
                    else if (timechar[i] == 'B')
                    {
                        endtime = 12;
                    }
                    else if (timechar[i] == 'C')
                    {
                        endtime = 13;
                    }
                    else if (timechar[i] == 'N')
                    {
                        endtime = 5;
                    }
                    else
                    {
                        endtime = (Int32.Parse(timechar[i].ToString()) < 5) ? Int32.Parse(timechar[i].ToString()) : Int32.Parse(timechar[i].ToString()) + 1;
                    }
                    slatch = false;

                }
                else
                {
                    if (timechar[i] == 'A')
                    {
                        starttime = 11;
                    }
                    else if (timechar[i] == 'B')
                    {
                        starttime = 12;
                    }
                    else if (timechar[i] == 'C')
                    {
                        starttime = 13;
                    }
                    else if (timechar[i] == 'N')
                    {
                        starttime = 5;
                    }
                    else
                    {
                        starttime = (Int32.Parse(timechar[i].ToString()) < 5) ? Int32.Parse(timechar[i].ToString()) : Int32.Parse(timechar[i].ToString()) + 1;
                    }

                }

                i++;
            }
            if (weekday != 0)
            {

                for (int j = starttime; j <= endtime; j++)
                {
                    if (courseTableData[weekday][j] != null) return true; 
                }
            }
            return false;
        }

        bool alreadyChooseCourse(courseData course)
        {
            for (int i = 0; i < amountOfCourseHasSelected; i++)
            {
                if (course.Equals(courseChoosedList[i]))
                {
                    return true;
                }
            }

                return false;
        }

        private void addLabelColar(Label ll, courseData course)
        {
            if (course.departmentId == "A9")
            {
                ll.BackColor = generalEduColor;
            }
            else if (course.departmentId == "userDefine")
            {
                ll.BackColor = userDefineColor;
            }
            else if (course.necessary == "Y")
            {
                ll.BackColor = necessaryColor;
            }
           
            else
            {
                ll.BackColor = chooseColor;

            }
        }

        private void deleteLabelColar(Label ll)
        {
            ll.BackColor = Color.White;
        }

        public void setAllLabelColar()
        {
            for (int i = 1; i < 8; i++)
            {
                for (int j = 0; j < 14; j++)
                {
                    if (courseTableData[i][j] != null)
                    {
                        if (courseTableData[i][j].departmentId == "A9")
                        {
                            
                            courseTableLabel[i][j+1].BackColor = generalEduColor;
                        }
                        else if (courseTableData[i][j].departmentId == "userDefine")
                        {
                            courseTableLabel[i][j + 1].BackColor = userDefineColor;
                        }
                        else if (courseTableData[i][j].necessary == "Y")
                        {
                            courseTableLabel[i][j + 1].BackColor = necessaryColor;
                        }
                        else
                        {
                            courseTableLabel[i][j + 1].BackColor = chooseColor;
                        }
                    }
                    else
                    {
                        courseTableLabel[i][j + 1].BackColor = Color.White;
                    }
                }

            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            courseData aa = new courseData();
            aa.name = "aaaaaaaaaaaa";
            aa.courseId = "000";
            aa.departmentId = "F7";
            aa.time = "[5] 1~3";
           
            deleteCourseFromTable(aa);
        }
    }



    public class courseData
    {
        public string courseId = null,
                     departmentId = null,
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
       
        public courseData() { }        
       
        public courseData(courseData sample)
        {
            courseId = sample.courseId;
            departmentId = sample.departmentId;
            cls = sample.cls;
            grade = sample.grade;
            type = sample.type;
            english = sample.english;
            name = sample.name;
            necessary = sample.necessary;
            point = sample.point;
            teacher = sample.teacher;
            time = sample.time;
            place = sample.place;
            other = sample.other;           
        }
    }
}
