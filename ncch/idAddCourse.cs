﻿using System;
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
    public partial class idAddCourse : Form
    {
        Form1 mainForm;
        public idAddCourse()
        {
            InitializeComponent();
        }
        public idAddCourse(ref Form1 form1)
        {
            mainForm = form1;
            InitializeComponent();
        }
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            string dId="";
            string cId="";
            if (textBox1.Text != "") dId = textBox1.Text;
            if (textBox2.Text != "") dId = textBox2.Text;
            courseData cour = mainForm.serchCourseById(dId, cId);
            if (cour != null)
            {
                mainForm.addCourseToTable(cour);
                MessageBox.Show("成功加選");
            }
            else
            {
                MessagwBox.Show("找不到該課程");
            }
        }
    }
}