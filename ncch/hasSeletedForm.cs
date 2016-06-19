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
    public partial class hasSeletedForm : Form
    {
        Form1 mainform;
        public hasSeletedForm()
        {
            InitializeComponent();
        }
        public hasSeletedForm(Form1 fom1)
        {
            mainform = fom1;
            InitializeComponent();
            iniDataGrid();
            iniLabel();
        }
        private void iniLabel()
        {
            label1.Text = "共 " + mainform.allPointOfAlreadySlectedCourse().ToString() + " 學分";
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
           
            for (int i = 0; i < mainform.amountOfCourseHasSelected; i++)
            {
                courseData c=mainform.courseChoosedList[i];
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

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
