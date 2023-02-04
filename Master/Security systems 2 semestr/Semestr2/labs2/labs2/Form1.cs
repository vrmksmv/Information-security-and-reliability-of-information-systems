using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace labs2
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            openFileDialog1.Filter = "Text files(*.txt)|*.txt|All files(*.*)|*.*";
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
        string Names = "ВЕРА";
        string Alphabet = "АБВГДЕЁЖЗIЙКЛМНОПРСТУЎФХЦЧШЫЬЭЮЯ*/";
        string Shifr = "АВЕРБГДЁЖЗIЙКЛМНОПРСТУЎФХЦЧШЫЬЭЮЯ*/";
        string alphabet = "АБВГДЕЁЖЗIЙКЛМНОПРСТУЎФХЦЧШЫЬЭЮЯ";
        string alphabet2 = "ЕРБГДЁЖЗIЙКЛМНОПРСТУЎФХЦЧШЫЬЭЮЯАВ";//Разделить фамилию


        private void Form1_Load(object sender, EventArgs e)
        {
            
            char[] b = Shifr.ToCharArray();
            example.Text = example.Text + b[0]; 
            for(int i = 1; i<b.Length;i++ )
            {
                if (i%4 == 0)
                {
                    example.Text += "\n";
                }                
                example.Text += b[i];
                
            }
            YES.Text = alphabet;
            NO.Text = alphabet2;
        }

        void Shifrovanie(string text)
        {
            if (text != null)
            {
                text = text.ToUpper();
                char[] a = text.ToCharArray();
                char[] b = Shifr.ToCharArray();
                int ys = b.Length - 4;
                int chel;
                for (int i  = 0; i< a.Length; i++)
                {
                    if (alphabet.Contains(a[i]))
                    {
                        int pos = Shifr.IndexOf(a[i]);
                        a[i] = Shifr[(pos + 4) % Shifr.Length];
                         
                    }
                    deshifr.Text += a[i];
                }
               
            }
        }

        void Deshfir(string text) 
        {
            if (text != null)
            {

                text = text.ToUpper();
                char[] a = text.ToCharArray();
                char[] b = Shifr.ToCharArray();
                int ys = b.Length - 5;
                for (int i = 0; i < a.Length; i++)
                {
                    if (alphabet.Contains(a[i]))
                    {
                        int pos = Shifr.IndexOf(a[i]);
                        a[i] = Shifr[(pos - 4 + Shifr.Length) % Shifr.Length];
                    }
                    encrypt.Text += a[i];
                }
                
            }
        }

       
        void CesarShifr(string text) 
        {
            if(text != null) 
            {
                text = text.ToUpper();

                string key = "ВЕРА";
                char[] a = alphabet.ToCharArray();
                char[] b = alphabet2.ToCharArray();
                char[] c = text.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (alphabet.Contains(c[i]))
                    {
                        int pos = alphabet.IndexOf(c[i]);
                        c[i] = b[pos];
                    }
                    decript2.Text += c[i];
                }
                

            }
        }

        static Dictionary<char, int> ToFrequencyDictionary(string source)
        {
            Dictionary<char, int> result = new Dictionary<char, int>();

            foreach (var symbol in source)
            {
                if (result.ContainsKey(symbol))
                    result[symbol]++;
                else
                    result[symbol] = 1;
            }

            return result;
        }

        void CesarDeShifr(string text)
        {
            if (text != null)
            {
                text = text.ToUpper();
                string key = "ВЕРА";
                char[] a = alphabet.ToCharArray();
                char[] b = alphabet2.ToCharArray();
                char[] c = text.ToCharArray();
                for (int i = 0; i < c.Length; i++)
                {
                    if (alphabet.Contains(c[i]))
                    {
                        int pos = alphabet2.IndexOf(c[i]);
                        c[i] = a[pos];
                    }
                    encrypt1.Text += c[i];
                }
                

            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            deshifr.Text = null;
            Shifrovanie(encrypt.Text);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            encrypt.Text = null;
            Deshfir(deshifr.Text);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            decript2.Text = null;
            CesarShifr(encrypt1.Text);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            encrypt1.Text = null;
            CesarDeShifr(decript2.Text);
        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.Cancel)
                return;
            string filename = openFileDialog1.FileName;
            // читаем файл в строку
            string fileText = System.IO.File.ReadAllText(filename);
            encrypt.Text = fileText;
            encrypt1.Text = fileText;
            MessageBox.Show("Файл открыт");
        }

        private void gist_Click(object sender, EventArgs e)
        {
            chart1.Series["Count"].Points.Clear();
            chart2.Series["Count"].Points.Clear();

            if (radioButton1.Checked)
            {
                var frequencies = ToFrequencyDictionary(encrypt.Text);
                foreach (var item in frequencies)
                {
                    chart1.Series["Count"].Points.AddXY(item.Key.ToString(), item.Value);
                }
                var frequencies1 = ToFrequencyDictionary(deshifr.Text);
                foreach (var item in frequencies1)
                {
                    chart2.Series["Count"].Points.AddXY(item.Key.ToString(), item.Value);
                }
            }
            else if (radioButton2.Checked)
            {
                var frequencies3 = ToFrequencyDictionary(encrypt1.Text);
                foreach (var item in frequencies3)
                {
                    chart1.Series["Count"].Points.AddXY(item.Key.ToString(), item.Value);
                }
                var frequencies4 = ToFrequencyDictionary(decript2.Text);
                foreach (var item in frequencies4)
                {
                    chart2.Series["Count"].Points.AddXY(item.Key.ToString(), item.Value);
                }
            }
            else 
            {
                MessageBox.Show("Укажите алгоритм шифрования");
            }
        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }
    }
}
