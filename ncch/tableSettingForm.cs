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
    public partial class tableSettingForm : Form
    {
        private Form1 mainForm;
        public tableSettingForm()
        {
            InitializeComponent();
        }
        public tableSettingForm(Form1 form)
        {
            mainForm = form;
            InitializeComponent();
            iniLabel();
        }
        private void iniLabel()
        {
            labelChoose.BackColor = mainForm.chooseColor;
            labelGeneral.BackColor = mainForm.generalEduColor;
            labelNessarry.BackColor = mainForm.necessaryColor;
            labelGeneral.Text = "\n通識顏色\n";
            labelNessarry.Text = "\n必修底色\n";
            labelChoose.Text = "\n選修顏色\n";
        }
        private void buttonNessarry_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Color cc= colorDialog1.Color;  // 回傳選擇顏色，並且設定 Textbox 的背景顏色
                labelNessarry.BackColor = cc;
                mainForm.necessaryColor=cc;
                mainForm.setAllLabelColar();
            }
        }

        private void buttonChoose_Click(object sender, EventArgs e)
        {
             if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Color cc= colorDialog1.Color;  // 回傳選擇顏色，並且設定 Textbox 的背景顏色
                labelChoose.BackColor=cc;
                mainForm.chooseColor= cc;
                mainForm.setAllLabelColar();
            }
        }

        private void buttonGeneral_Click(object sender, EventArgs e)
        {
             if (colorDialog1.ShowDialog() != DialogResult.Cancel)
            {
                Color cc= colorDialog1.Color;  // 回傳選擇顏色，並且設定 Textbox 的背景顏色
                labelGeneral.BackColor=cc ;
                mainForm.generalEduColor = cc;
                mainForm.setAllLabelColar();
            }
        }
    }
}
