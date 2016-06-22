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
using System.Data.SqlClient;


namespace ncch
{

    public partial class Form1 : Form
    {
        /***** definition *****/
        private string deptDataPath = @"./data/deptData.txt";


        /********************class menber varible*******************/
        private Label[][] courseTableLabel;
        public bool isTemOutBusy;
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

        public Form1()                   //  to initial 
        {
            isTemOutBusy = true;
            isCourseIdBusy = false;
            isFatchCourseBusy = false;
            if (!Directory.Exists((@"./data"))) Directory.CreateDirectory(@"./data");
            if (!File.Exists(@"./data/tempOut.txt")) fetchMenuByFile();
            isTemOutBusy = false;
            InitializeComponent();
            initialCourseTableLabel();
            iniCourseDataTable();
            iniCourseChooseList();
            iniToolTipOfLabelForTable();
            iniContextMenuStripTable();
            iniDataGrid();
        }

        public courseData searchCourseById(string departId, string courseId)////     has not written
        {
            if (!File.Exists(@"./data/courseData" + departId + ".txt"))
            {
                Console.WriteLine(">error: can't find course file " + departId);
                return null;
            }

            Regex findID = new Regex(courseId, RegexOptions.Compiled);
            StreamReader fin = new StreamReader(@"./data/courseData" + departId + ".txt");

            string cur;
            while((cur = fin.ReadLine()) != null)
                if (findID.IsMatch(cur))    return dataStringToCourseData(cur);

            return null;
        }

        public void inputNessarry(string departId,string grade,string cls)////    has not written
        {
           //use function addCourseToTable(courseData course)   to add course;
            
            return;
        }

        public void inputNessarryByLin(string departId, string grade, string cls)////    has not written
        {
            //use function addCourseToTable(courseData course)   to add course;
            if (!File.Exists(@"./data/courseOut" + departId + ".txt"))
            {
                MessageBox.Show("沒有該系所的課程資料，請先更新");
                return;
            }
            StreamReader sr = new StreamReader(@"./data/courseOut" + departId + ".txt");
            string alldata = sr.ReadToEnd();
            sr.Close();
            if (alldata == null) return;
            Console.WriteLine("did" + departId);
            string[] lines = Regex.Split(alldata, "\n");
            foreach (string cur in lines)
            {
                if (cur != null)
                {
                    courseData co = dataStringToCourseData(cur);
                    if(co==null)continue;
                    if (co.necessary == "必修")
                    {
                        if (co.grade == grade)
                        {   
                            if (co.cls == null || co.cls == cls)
                            {
                                if (co.courseId == "") continue;
                                addCourseToTable(co);
                            }
                        }
                    }
                }
            }

            return;
        }

        public void serchForDataGrid(string department, bool checkConflic)////      has not written
        {
            /////use  addCourseToDataGridView(courseData c) to add course
            /////use  isconflict(courseData c)       to check isconflic
            if (checkConflic)
            {

            }
            else
            {

            }
        }

        public void serchForDataGridByLin(string departId, bool checkConflic)////     just for debug
        {
            /////use  addCourseToDataGridView(courseData c) to add course
            /////use  isconflict(courseData c)       to check isconflic
            if (!File.Exists(@"./data/courseOut" + departId + ".txt"))
            {
                MessageBox.Show("沒有該系所的課程資料，請先更新");
                return;
            }
            StreamReader sr = new StreamReader(@"./data/courseOut" + departId + ".txt");
            string alldata = sr.ReadToEnd();
            sr.Close();
            if (alldata == null) return;
            Console.WriteLine("did" + departId);
            string[] lines = Regex.Split(alldata, "\n");
            if (checkConflic)
            {
                foreach (string cur in lines)
                {
                    if (cur != null)
                    {
                        courseData co = dataStringToCourseData(cur);
                        if (!isconflict(co)) addCourseToDataGridView(co);
                    }
                }
            }
            else
            {
                foreach (string cur in lines)
                {
                    if (cur != null)
                    {
                        courseData co = dataStringToCourseData(cur);
                        addCourseToDataGridView(co);
                    }
                }
            }
        }

        public int howManyClassInTheDepart(string dId, int grade)///has not written
        {
            return 1;
        }
       
        public int howManyGradeInTheDepart(string dId)   ///has not written
        {
            return 1;
        }
       
        private void addCourseToDataGridView(courseData c)
        {
            if (c == null) return;
            string[] row = new string[13];
            row[0] = c.departmentId;
            row[1] = c.courseId;
            row[2] = c.name;
            row[3] = c.grade;
            row[4] = c.teacher;
            row[5] = c.time;
            row[6] = c.place;
            row[7] = c.english;
            row[8] = c.necessary;
            row[9] = c.cls;
            row[10] = c.point;
            row[11] = c.type;
            row[12] = c.other;
            dataGridView1.Rows.Add(row);
        }
  
        public courseData serchCourseByIdByLin(string departId, string courseId)////     just for debug
        {
            if(!File.Exists(@"./data/courseOut" + departId + ".txt")){
                MessageBox.Show("沒有該系所的課程資料，請先更新");
                return null;
            }
            StreamReader sr = new StreamReader(@"./data/courseOut" + departId + ".txt");
            string alldata = sr.ReadToEnd();
            sr.Close();
            if (alldata == null) return null;
            Console.WriteLine("did" + departId);
            Console.WriteLine("cId" + courseId);
            string[] lines = Regex.Split(alldata, "\n");
            foreach (string cur in lines)
            {
                if (cur != null)
                {
                    string[] kk = Regex.Split(cur, "\t");
                    Regex findCId = new Regex(@"courseId=.*?", RegexOptions.Compiled);
                    foreach (string gg in kk)
                    {
                        if (findCId.IsMatch(gg))
                        {
                            string ww = findCId.Replace(gg, "");
                            if (ww == courseId)
                            {
                                courseData co = dataStringToCourseData(cur);
                                return co;
                            }
                            break;
                        }
                    }
                }
            }
            return null;
        }

        public int allPointOfAlreadySlectedCourse()
        {
            int k = 0;
            for (int i = 0; i < amountOfCourseHasSelected; i++)
            {
               if(courseChoosedList[i].point!=null){
                   k += Int32.Parse(courseChoosedList[i].point);
            
               }
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

        private void iniDataGrid()
        {
            dataGridView1.ColumnCount = 13;
            dataGridView1.Columns[0].Name = "系所代號";
            dataGridView1.Columns[1].Name = "課程代號";
            dataGridView1.Columns[2].Name = "課程名稱";
            dataGridView1.Columns[3].Name = "課程年級";
            dataGridView1.Columns[4].Name = "授課教師";
            dataGridView1.Columns[5].Name = "上課時間";
            dataGridView1.Columns[6].Name = "上課地點";
            dataGridView1.Columns[7].Name = "英授";
            dataGridView1.Columns[8].Name = "必選修";
            dataGridView1.Columns[9].Name = "班級";
            dataGridView1.Columns[10].Name = "學分數";
            dataGridView1.Columns[11].Name = "課程類別";
            dataGridView1.Columns[12].Name = "備註";
           
            while (isTemOutBusy) { ;}           //  avoid open same file by two way in the same time;
            isTemOutBusy = true;
            StreamReader sr1 = new StreamReader(@"./data/tempOut.txt");

            string tem1 = sr1.ReadLine();
            //Console.WriteLine("tem " + tem1);
            while (tem1 != null)
            {
                comboBoxShow.Items.Add(tem1);
                tem1 = sr1.ReadLine();
            }
            sr1.Close();
            isTemOutBusy = false;
            comboBoxShow.SelectedIndex = 0;
            comboBoxShow.DropDownStyle = ComboBoxStyle.DropDownList;
            checkBoxKeepFromCoinsedance.Checked = false;
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
                  //  courseTableLabel[i][j].Text = i.ToString() + "," + j.ToString() ;      //  to test the label location
                   courseTableLabel[i][j].Text = "";
                    courseTableLabel[i][j].AutoSize = true;
                }
            }    
            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            for (int i = 1; i < 6; i++)
            {
                courseTableLabel[0][i].Text = "第 " + (i - 1).ToString() + " 節\n\n";

            }

            courseTableLabel[0][6].Text = "第N節\n\n";
            for (int i = 6; i < 11; i++)
            {
                courseTableLabel[0][i + 1].Text = "第 " + (i - 1).ToString() + " 節\n\n";

            }
            courseTableLabel[0][12].Text = "第A節\n\n";
            courseTableLabel[0][13].Text = "第B節\n\n";
            courseTableLabel[0][14].Text = "第C節\n\n";

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

        private void addCourseToCourseChooseList(courseData course)
        {
            int k = -1;
            for (int i = 0; i < amountOfCourseHasSelected; i++)
            {
                if (Convert.ToInt16(courseChoosedList[i].point) > Convert.ToInt16(course.point))
                {
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
                for (int j = amountOfCourseHasSelected; j > k; j--)
                {
                    courseChoosedList[j] = courseChoosedList[j - 1];
                }
                courseChoosedList[k] = course;
            }
            amountOfCourseHasSelected++;
        }

        private void deleteCourseFromCourseChooseList(courseData course)
        {
            int k = -1;
            for (int i = 0; i < amountOfCourseHasSelected; i++)
            {
                if ((course.departmentId == courseChoosedList[i].departmentId) && (course.courseId == courseChoosedList[i].courseId))
                {
                    courseChoosedList[i] = null;
                    k = i;
                }
            }
            if (k >= 0)
            {
                for (int j = k; j < (amountOfCourseHasSelected - 1); j++)
                {
                    courseChoosedList[j] = courseChoosedList[j + 1];
                }
                courseChoosedList[amountOfCourseHasSelected - 1] = null;
            }
            amountOfCourseHasSelected--;
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

        public void fetchMenuByFile()
        {
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
                      courseTableLabel[weekday][starttime + 1].Text = course.departmentId+" "+course.courseId +"\n"+ course.name;
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
              courseTableLabel[weekday][starttime + 1].Text = course.departmentId + " " + course.courseId + "\n" + course.name;
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
                      //  courseTableLabel[weekday][starttime + 1].Text = "\n("+weekday.ToString()+","+(starttime+1).ToString()+")\n";
                        courseTableLabel[weekday][starttime + 1].Text = "\n\n";
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
              //  courseTableLabel[weekday][starttime + 1].Text =   weekday.ToString() + "," + (starttime + 1).ToString() + "\n";
                courseTableLabel[weekday][starttime + 1].Text = "\n\n";
                toolTipTable[weekday][starttime] = null;
                deleteLabelColar(courseTableLabel[weekday][starttime + 1]); 
            }
            MessageBox.Show(course.departmentId + course.courseId + "  " + course.name + "\n退選成功");
        }

        bool isconflict(courseData course)                  //to check the course time is conflict or not
        {
            if (course == null) return false;
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
                if ((course.departmentId==courseChoosedList[i].departmentId)&&(course.courseId==courseChoosedList[i].courseId))
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
            else if (course.necessary == "必修")
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
                        else if (courseTableData[i][j].necessary == "必修")
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

        private string makeSaveString(courseData course)
        {
            string ss = "departmentId=" + course.departmentId + "\tcoueseId=" + course.courseId + "\tcls=" + course.cls + "\tgrade=" + course.grade + "\ttype=" + course.type + "\tenglish=" + course.english + "\tname=" + course.name + "\tnecessary=" + course.necessary + "\tpoint=" + course.point + "\tteacher=" + course.teacher + "\ttime=" + course.time + "\tplace=" + course.place + "\tother=" + course.other;
            return ss;
        }

        private void saveChosedCourse()
        {
            if (!Directory.Exists(@"./data")) Directory.CreateDirectory(@"./data");
            StreamWriter sw = new StreamWriter(@"./data/choosingCouseSave.txt");
            for (int i = 0; i < amountOfCourseHasSelected; i++)
            {
                sw.WriteLine(makeSaveString(courseChoosedList[i]));
            }
            sw.Close();
            MessageBox.Show("課表儲存完成");
        }

        private void restartCourseTable()
        {
            while (courseChoosedList[0] != null)
            {
                deleteCourseFromTable(courseChoosedList[0]);                
            }
            MessageBox.Show("課表重設完成");
        }

        private void insertChosedCourseFromSave()
        {    
            if (!Directory.Exists(@"./data")) Directory.CreateDirectory(@"./data");
            if (File.Exists(@"./data/choosingCouseSave.txt"))
            {
                StreamReader sr = new StreamReader(@"./data/choosingCouseSave.txt");
                string temp = sr.ReadLine();
                while (temp != null)
                {
                    courseData co = dataStringToCourseData(temp);
                    if (co != null)
                    {
                        addCourseToTable(co);
                    }
                    temp = sr.ReadLine();
                }
                sr.Close();
                MessageBox.Show("匯入課表完成");
            }
            else
            {
                MessageBox.Show("沒有已儲存的課表");
            }
        }

        private courseData dataStringToCourseData(string s)
        {
            if (s == null) return null;
            courseData co = new courseData();
            //Console.WriteLine(s);
            string[] lines= Regex.Split(s, "\t");
           
            Regex findDId = new Regex(@"departmentId=.*?", RegexOptions.Compiled);
            Regex findCId = new Regex(@"courseId=.*?", RegexOptions.Compiled);
            Regex findCls = new Regex(@"cls=.*?", RegexOptions.Compiled);
            Regex findGrade = new Regex(@"grade=.*?", RegexOptions.Compiled);
            Regex findType = new Regex(@"type=.*?", RegexOptions.Compiled);
            Regex findEnglish = new Regex(@"english=.*?", RegexOptions.Compiled);
            Regex findName = new Regex(@"name=.*?", RegexOptions.Compiled);
            Regex findNecessary = new Regex(@"necessary=.*?", RegexOptions.Compiled);
            Regex findPoint = new Regex(@"point=.*?", RegexOptions.Compiled);
            Regex findTeacher = new Regex(@"teacher=.*?", RegexOptions.Compiled);
            Regex findTime = new Regex(@"time=.*?", RegexOptions.Compiled);
            Regex findPlace = new Regex(@"place=.*?", RegexOptions.Compiled);
            Regex findOther = new Regex(@"other=.*?", RegexOptions.Compiled);

            foreach (string cur in lines)
            {   
                if (findDId.IsMatch(cur))
                {
                    co.departmentId = findDId.Replace(cur, "");
                }
                if (findCId.IsMatch(cur))
                {
                    co.courseId = findCId.Replace(cur, "");
                }
                if (findCls.IsMatch(cur))
                {
                    co.cls = findCls.Replace(cur, "");
                }
                if (findGrade.IsMatch(cur))
                {
                    co.grade = findGrade.Replace(cur, "");
                }
                if (findType.IsMatch(cur))
                {
                    co.type = findType.Replace(cur, "");
                }
                if (findEnglish.IsMatch(cur))
                {
                    co.english = findEnglish.Replace(cur, "");
                }
                if (findName.IsMatch(cur))
                {
                    co.name = findName.Replace(cur, "");
                }
                if (findNecessary.IsMatch(cur))
                {
                    co.necessary = findNecessary.Replace(cur, "");
                }
                if (findPoint.IsMatch(cur))
                {
                    co.point = findPoint.Replace(cur, "");
                }
                if (findTeacher.IsMatch(cur))
                {
                    co.teacher = findTeacher.Replace(cur, "");
                }
                if (findTime.IsMatch(cur))
                {
                    co.time = findTime.Replace(cur, "");
                }
                if (findPlace.IsMatch(cur))
                {
                    co.place = findPlace.Replace(cur, "");
                }
                if (findOther.IsMatch(cur))
                {
                    co.other = findOther.Replace(cur, "");
                }
            }

          //  Console.WriteLine("a"+co.departmentId);
            if (co.departmentId == null) return null;
            return co;
        }

        private void 依序號加選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idAddCourse ii = new idAddCourse(this);
            ii.Show();
        }

        private void 依序號退選ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            idDeleteCourseForm ii = new idDeleteCourseForm(this);
            ii.Show();
        }

        private void 匯入必修ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            inputNessarryForm ii = new inputNessarryForm(this);
            ii.Show();
        }

        private void 查看已選課程ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            hasSeletedForm ii = new hasSeletedForm(this);
            ii.Show();
        }

        private void 課表設定ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            tableSettingForm ii = new tableSettingForm(this);
            ii.Show();
        }

        private void 課程更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            updateForm ii = new updateForm(this);
            ii.Show();
        }

        private void 儲存課表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            saveChosedCourse();
        }

        private void 匯入課表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            insertChosedCourseFromSave();
        }

        private void 課表重設ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            restartCourseTable();
        }

        private void serch_Click(object sender, EventArgs e)
        {
            string dep = comboBoxShow.Text.ToCharArray()[0].ToString() + comboBoxShow.Text.ToCharArray()[1].ToString();
            dataGridView1.Rows.Clear();
            serchForDataGrid(dep, checkBoxKeepFromCoinsedance.Checked);
        }


        /*****************************************************************************/
        /****************************** code by wwolfyTC *****************************/
        /*****************************************************************************/

        private void btnDebug_Click(object sender, EventArgs e)
        {
            Console.WriteLine(">begin debug");
            //fatchMenu();
            //fatchCourse("A9");

            courseData dat = searchCourseById("A9", "010");
            Console.WriteLine(dat.ToString());

            Console.WriteLine(">end debug");
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


            StreamWriter fout = new StreamWriter(deptDataPath);

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
            }
            fout.Flush(); fout.Close();

            Console.WriteLine(">done!");
            isTemOutBusy = false;
            isCourseIdBusy = false;
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

            StreamWriter fout = new StreamWriter(@"./data/courseData" + e.Argument + ".txt");

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
                            id = findHtmlTag.Replace(cur, "");
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
                            fout.WriteLine("departmentId=" + (string)e.Argument + 
                                "\tcourseId=" + id + 
                                "\tcls=" + cls + 
                                "\tgrade=" + grade + 
                                "\ttype=" + type + 
                                "\tenglish=" + english + 
                                "\tname=" + name + 
                                "\tnecessary=" + necessary + 
                                "\tpoint=" + point + 
                                "\tteacher=" + teacher + 
                                "\ttime=" + time + 
                                "\tplace=" + place + 
                                "\tother=" + other);
                            break;
                    }
                }
            }
            fout.Flush();
            fout.Close();
            isFatchCourseBusy = false;
            Console.WriteLine(">fatchCourseFinish");

        }

        public void fatchMenu()
        {
            if (backgroundFatchMenu.IsBusy == false)
            {
                backgroundFatchMenu.RunWorkerAsync();

            }
        }

        public void fatchCourse(string dept)
        {
            if (backgroundFatchCourse.IsBusy == false)
            {
                backgroundFatchCourse.RunWorkerAsync(dept);
            }
            else
            {
                Console.WriteLine(">error: background worker of course fatch is busy!");
            }
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

        public override string ToString()
        {
            return (departmentId + " " + courseId);
        }
    }
}
