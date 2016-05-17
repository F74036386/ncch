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
    public partial class Form1 : Form
    {
        Label[] index;
        Label[] Monday;
        Label[] Tuesday;
        Label[] Wednesday;
        Label[] Thursday;
        Label[] Friday;
        Label[] Saturday;
        Label[] Sunday;

        Label[][] classTable;
    
        public Form1()
        {
            InitializeComponent();
            initialTable();
        }

        private void initialTable()
        {           
            //  initial the table of class
            
            classTable=new Label [8][];

            for(int i=0;i<8;i++){
                classTable[i]=new Label[13];
                for(int j=0;j<13;j++){
                    classTable[i][j]=new Label();
                    classTable[i][j].Visible=true;
                    classTable[i][j].BackColor=Color.White;
                    this.tableLayoutPanel1.Controls.Add(this.classTable[i][j],i,j);
                    classTable[i][j].Text=i.ToString()+","+j.ToString();
                }
            }

            tableLayoutPanel1.CellBorderStyle = TableLayoutPanelCellBorderStyle.OutsetDouble;
            
            
            
            
            
            
            
            
            
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

        }
    }
}
