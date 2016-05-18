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


namespace ncch
{
    public partial class Form1 : Form
    {
       /*
        Label[] index;
        Label[] Monday;
        Label[] Tuesday;
        Label[] Wednesday;
        Label[] Thursday;
        Label[] Friday;
        Label[] Saturday;
        Label[] Sunday;
       */
        Label[][] classTable;
        string mainUrl;
    
        public Form1()
        {
            InitializeComponent();
            initialGui();
        }



        private void setComboBox()
        {
            comboBoxGrade.Items.Add("1");
            comboBoxGrade.Items.Add("2");
            comboBoxGrade.Items.Add("3");
            comboBoxGrade.Items.Add("4");

            comboBoxClass.Items.Add("甲班");
            comboBoxClass.Items.Add("乙班");
            comboBoxClass.Items.Add("丙班");

          //  comboBoxDepartment.Items.Add();

        }


        private void initialGui()
        {           
            //  initial the table of class
           
          
            
            classTable=new Label [8][];

            for(int i=0;i<8;i++){
                classTable[i]=new Label[14];
                for(int j=0;j<14;j++){
                    classTable[i][j]=new Label();
                    classTable[i][j].Visible=true;
                    classTable[i][j].BackColor=Color.White;
                    tableLayoutPanel1.Controls.Add(classTable[i][j],i,j);
                   // classTable[i][j].Text=i.ToString()+","+j.ToString();      //  to test the label location
                    classTable[i][j].AutoSize = true;
                }
            }

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            for (int i = 1; i < 11; i++)
            {
                classTable[0][i].Text = "第 "+(i-1).ToString()+" 節";

            }

            classTable[0][11].Text = "第A節";
            classTable[0][12].Text = "第B節";
            classTable[0][13].Text = "第C節";
       

            classTable[1][0].Text = "星期一";
            classTable[2][0] .Text= "星期二";
            classTable[3][0] .Text= "星期三";
            classTable[4][0] .Text= "星期四";
            classTable[5][0] .Text= "星期五";
            classTable[6][0] .Text= "星期六";
            classTable[7][0] .Text= "星期日";



            setComboBox();





            
            /*   index=new Label[13];                       //creat label array
             Monday=new Label[13];
             Tuesday = new Label[13];
             Wednesday = new Label[13];
             Thursday = new Label[13];
             Friday = new Label[13];
             Saturday = new Label[13];
             Sunday = new Label[13];
            
            for (int i = 0; i < 13; i++)
             {  
              
                 index[i] = new Label();                    //creat label
                 Monday[i] = new Label();
                 Tuesday[i] = new Label();
                 Wednesday[i] = new Label();
                 Thursday[i] = new Label();
                 Friday[i] = new Label();
                 Saturday[i] = new Label();
                 Sunday[i] = new Label();

                 index[i].Visible = true;                        //set visible of label
                 Monday[i].Visible = true;
                 Tuesday[i].Visible = true;
                 Wednesday[i].Visible = true;
                 Thursday[i].Visible = true;
                 Friday[i].Visible = true;
                 Saturday[i].Visible = true;
                 Sunday[i].Visible = true;
            
                 index[i].BackColor = Color.Yellow;                 // set color to label
                 Monday[i].BackColor = Color.Yellow;
                 Tuesday[i].BackColor = Color.Yellow;
                 Wednesday[i].BackColor = Color.Yellow;
                 Thursday[i].BackColor = Color.Yellow;
                 Friday[i].BackColor = Color.Yellow;
                 Saturday[i].BackColor = Color.Yellow;
                 Sunday[i].BackColor = Color.Yellow;

                 this.tableLayoutPanel1.Controls.Add(this.index[i], 0, i);       //add label to table
                 this.tableLayoutPanel1.Controls.Add(this.Monday[i], 1, i);
                 this.tableLayoutPanel1.Controls.Add(this.Tuesday[i], 2, i);
                 this.tableLayoutPanel1.Controls.Add(this.Wednesday[i], 3, i);
                 this.tableLayoutPanel1.Controls.Add(this.Thursday[i], 4, i);
                 this.tableLayoutPanel1.Controls.Add(this.Friday[i] ,5, i);
                 this.tableLayoutPanel1.Controls.Add(this.Saturday[i], 6, i);
                 this.tableLayoutPanel1.Controls.Add(this.Sunday[i], 7, i);
             }
             * */

        }
        
        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            StreamWriter sw=new StreamWriter(@"./classhtml.txt");
          

          using (WebClient client = new WebClient())
         {
            string htmlCode = client.DownloadString(mainUrl);
            sw.Write(htmlCode);
         }
          sw.Flush();
          sw.Close();

        }

        private void comboBoxDepartment_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBoxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
