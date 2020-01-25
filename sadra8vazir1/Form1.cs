using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Collections;

namespace sadra8vazir1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        int[,] x = new int[8, 8];
      
        Stack stki = new Stack();
        Stack stkj = new Stack();
        private void showx()
        {
            string s = "";
            //listBox1.Items.Clear();
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (x[i, j] != 0)
                        s += x[i, j].ToString() + " | ";
                    else
                        s += "   | ";

                }
                listBox1.Items.Add(s);
              
                s = "";
            }
            listBox1.Items.Add("=====================");


        }
        private bool checkx(int ii, int jj)
        {
            ///////////////////////////++++++++++++++++++++++++++++++///////////
            int c = 0;
            for (int j = 0; j < 8; j++)
                if (x[ii, j] == 1)
                    c++;
            if (c > 1)
                return false;
            c = 0;
            for (int i = 0; i < 8; i++)
                if (x[i, jj] == 1)
                    c++;
            if (c > 1)
                return false;
            //////////////////////////////*******************//////////////
            c = 0;
            for (int i = ii + 1, j = jj + 1; i < 8 && j < 8; i++, j++)
                if (x[i, j] == 1)
                    c++;
            if (c > 0)
                return false;
            c = 0;
            for (int i = ii - 1, j = jj - 1; i >= 0 && j >= 0; i--, j--)
                if (x[i, j] == 1)
                    c++;
            if (c > 0)
                return false;
            c = 0;
            for (int i = ii - 1, j = jj + 1; i >= 0 && j < 8; i--, j++)
                if (x[i, j] == 1)
                    c++;
            if (c > 0)
                return false;
            c = 0;
            for (int i = ii + 1, j = jj - 1; i < 8 && j >= 0; i++, j--)
                if (x[i, j] == 1)
                    c++;
            if (c > 0)
                return false;

            return true;
        }


        private void button1_Click(object sender, EventArgs e)
        {
int i,j;
            for ( i = 0; i < 8; i++)
               for ( j = 0; j < 8; j++)
                    x[i, j] = 0;
            listBox1.Items.Clear();

            int count = 0;
            i = 0; j = 0;
            x[0, 0] = 1;
            while (i<8)
            {
                while(j<8)
                {
                    x[i, j] = 1;
                    count++;
                    if (checkx(i, j))
                    {
                        showx();
                        stki.Push(i);
                        stkj.Push(j);
                        break;
                    }

                    else
                    {
                        x[i, j] = 0;
                        j++;
                        if (j >= 8)
                        {
                            //MessageBox.Show(i.ToString() + " f  " + j.ToString());
                            while (true)
                            {
                                i = int.Parse(stki.Pop().ToString());
                                j = int.Parse(stkj.Pop().ToString());
                                x[i, j] = 0;
                                j++;
                                if (j < 8)
                                    break;
                            }
                            // MessageBox.Show(i.ToString()+"   "+j.ToString());

                        }
                    }
                }
                i++;
                j = 0;
            }
            MessageBox.Show(count.ToString());

        }

        }
    }

