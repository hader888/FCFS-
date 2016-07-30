using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace project_FCFS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            
        }
        public ArrayList H = new ArrayList();
        public void InsortionSort(ArrayList H)
        {
            Process HHH = new Process();
            for (int l = 0; l < H.Count; l++)
            {
                for (int sorted = 0; sorted < H.Count - 1; sorted++)
                {
                    if (((Process)H[sorted]).Arrival > ((Process)H[sorted + 1]).Arrival)
                    {
                        HHH = (Process)H[sorted + 1];
                        H[sorted + 1] = (Process)H[sorted];
                        H[sorted] = HHH;
                    }
                }
            }
        }

         private void Form1_Load(object sender, EventArgs e)
        {

        }
       

        
        class Process
        {
           public string Name;
           public int Arrival;
           public int Burst;
           public int Start;
           public int Finish;
           public int TurnAround;
           public int Wait;
           public Process(String Name, int Arrival, int Burst)
           {
               this.Name = Name;
               this.Arrival = Arrival;
               this.Burst = Burst;
           }

           public Process()
           {
               // TODO: Complete member initialization
           }

          


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Process Object = new Process();
            Object.Name = textBox1.Text;
            Object.Arrival = int.Parse(textBox2.Text);
            Object.Burst = int.Parse(textBox3.Text);
            H.Add(Object);
            string[] row = { textBox1.Text, textBox2.Text, textBox3.Text };
            var ListViewItem = new ListViewItem(row);
            listView3.Items.Add(ListViewItem);
            foreach (Control x in this.Controls)
            {
                if (x is TextBox)
                    x.Text = "";
            }
        }



        private void button2_Click(object sender, EventArgs e)
        {


            Process Object = new Process();
            InsortionSort(H);
            for (int i = 0; i < H.Count; i++)
            {
                if (i == 0)
                {
                    ((Process)H[0]).Start = ((Process)H[0]).Arrival;
                    ((Process)H[0]).Finish = (((Process)H[0]).Start) + (((Process)H[0]).Burst);
                    ((Process)H[0]).Wait = (((Process)H[0]).Start) - (((Process)H[0]).Arrival);
                    ((Process)H[0]).TurnAround = (((Process)H[0]).Finish) - (((Process)H[0]).Arrival);
                }
                else
                {
                    if (((Process)H[i]).Arrival <= ((Process)H[i - 1]).Finish)
                    {
                        ((Process)H[i]).Start = ((Process)H[i - 1]).Finish;
                    }
                    else
                    {
                        ((Process)H[i]).Start = ((Process)H[i]).Arrival;
                    }


                    ((Process)H[i]).Finish = (((Process)H[i]).Start) + (((Process)H[i]).Burst);
                    ((Process)H[i]).TurnAround = (((Process)H[i]).Finish) - (((Process)H[i]).Arrival);
                    ((Process)H[i]).Wait = (((Process)H[i]).TurnAround) - (((Process)H[i]).Burst);

                }
                label8.Text = ((Process)H[0]).Start.ToString();

            }
            for (int i = 0; i < H.Count; i++)
            {
                ListViewItem LVI = new ListViewItem(((Process)H[i]).Name);
                LVI.SubItems.Add(((Process)H[i]).Arrival.ToString());
                LVI.SubItems.Add(((Process)H[i]).Burst.ToString());
                LVI.SubItems.Add(((Process)H[i]).Start.ToString());
                LVI.SubItems.Add(((Process)H[i]).Finish.ToString());
                LVI.SubItems.Add(((Process)H[i]).Wait.ToString());
                LVI.SubItems.Add(((Process)H[i]).TurnAround.ToString());
                listView1.Items.Add(LVI);
                listView2.Items.Add(((Process)H[i]).Name);
                listView4.Items.Add(((Process)H[i]).Finish.ToString());

            }
            int point_size = 1;
            for (int l = 0; l < H.Count; l++)
            {
                Label point = new Label();
                point.Location = new Point(point_size * 20, 40);
                point.Text = ((Process)H[l]).Name;
                point.BorderStyle = BorderStyle.Fixed3D;
                point.Size = new Size(((Process)H[l]).Burst * 20, 40);
                point.BackColor = Color.Brown;
                groupBox1.Controls.Add(point);
                point_size += ((Process)H[l]).Burst;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            double AverageOfTurnAround;
            double Sum = 0;
            for (int i = 0; i < H.Count; i++)
            {
                Sum = Sum + ((Process)H[i]).TurnAround;
            }

            AverageOfTurnAround = Sum / (H.Count);
            label6.Text = AverageOfTurnAround .ToString();

        }

        private void button4_Click(object sender, EventArgs e)
        {
            double AverageOfWait;
            double Sum = 0;
            for (int i = 0; i < H.Count; i++)
            {
                Sum = Sum + ((Process)H[i]).Wait;
            }

            AverageOfWait = Sum / (H.Count);
            label7.Text = AverageOfWait.ToString();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();
            listView3.Items.Clear();
            listView2.Items.Clear();
            listView4.Items.Clear();
            label8.Text = "";
            label6.Text = "";
            label7.Text = "";
        }
    }
}
