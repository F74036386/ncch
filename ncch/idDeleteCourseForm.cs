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
    public partial class idDeleteCourseForm : Form
    {
       Form1 mainform;
        public idDeleteCourseForm()
        {
            InitializeComponent();
        }
        public idDeleteCourseForm(ref Form1 form)

        {
            mainform = form;
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}