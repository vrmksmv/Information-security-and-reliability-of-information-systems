using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab8
{
    public partial class Form1 : Form
    {

        private string[] arrayW;
        private string[] arrayB;
        private string m;
        private string mm;
        private int z;
        private int now = 0;
        private int size = 0;

        public Form1()
        {
            InitializeComponent();
            buttonLast.Visible = false;
        }
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void buttonGen_Click(object sender, EventArgs e)
        {
            if(textBoxInput.Text.Length > 1)
            {
                size = textBoxInput.Text.Length;
                arrayW = new string[size];
                arrayB = new string[size];
                mm = textBoxInput.Text;
                string cur = textBoxInput.Text;
                for(int i = 0; i < size; i++)
                {
                    arrayW[i] = cur;
                    char tempLetter = cur[0];
                    cur = cur.Substring(1, size - 1) + tempLetter;
                }
                richTextBoxW1.Text = String.Join("\n", arrayW);
                Array.Sort(arrayW);
                richTextBoxW2.Text = String.Join("\n", arrayW);

                z = Array.IndexOf(arrayW, textBoxInput.Text);
                m = "";
                for(int i = 0; i < size; i++)
                {
                    m = m + arrayW[i][size - 1];
                }
                textBoxM.Text = m;
                textBoxK.Text = (z + 1).ToString();
                now = 0;
            }
        }

        private void buttonBack_Click(object sender, EventArgs e)
        {
            if (now >= size)
            {
                richTextBoxB1.Text = String.Join("\n", arrayB);
                reColorRTB();
                return;
            }
            for (int i = 0; i < size; i++)
            {
                arrayB[i] = m[i] + arrayB[i];
            }
            richTextBoxB1.Text = String.Join("\n", arrayB);
            Array.Sort(arrayB);
            now++;
            textBoxNow.Text = now.ToString();
        }


        private void buttonLast_Click(object sender, EventArgs e)
        {
            for (; now < size; now++)
            {
                for (int i = 0; i < size; i++)
                {
                    arrayB[i] = m[i] + arrayB[i];
                }
                Array.Sort(arrayB);
            }
            richTextBoxB1.Text = String.Join("\n", arrayB);
            textBoxNow.Text = now.ToString();
            reColorRTB();
        }

        private void reColorRTB()
        {
            int pos = richTextBoxB1.Text.IndexOf(mm);
            richTextBoxB1.Select(pos, mm.Length);
            richTextBoxB1.SelectionFont = new Font(richTextBoxB1.Font, FontStyle.Bold);
        }

        private void textBoxK_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
