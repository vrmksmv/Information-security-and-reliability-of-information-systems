using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAB_9
{
    public partial class Form1 : Form
    {
        LZMessageList LZMessageList;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            comboBox1.Items.Add(Mode.Bin);
            comboBox1.Items.Add(Mode.Quad);
            comboBox1.Items.Add(Mode.Hex);
            comboBox1.SelectedIndex = 2;

            string pathdef = "Otchot.txt";
            Path.Text = pathdef;
            var s = File.Create(pathdef);
            s.Close();

            //LZMessageList = new LZMessageList(Mode.Quad, 15, 13);
            //LZMessageList.AddText("20003020130201303130313031303133333333");
            //EncryptedMessage.Text = LZMessageList.ToString();
            //DecryptedMessage.Text = LZMessageList.GetText();
            //DeconvertedMessage.Text = LZMessageList.GetText().TextFromArbitraryBase(Mode.Quad);

            //textBox2.Text = LZMessageList.ToString();

            //Console.WriteLine(Convert.ToString(12345, 2));
            //Console.WriteLine(12345.DecimalToArbitrarySystem(4));
            //Console.WriteLine(Convert.ToString(12345, 8));
            //Console.WriteLine(Convert.ToString(12345, 16));
        }

        private void Encrypt_Click(object sender, EventArgs e)
        {
            Mode mode = Mode.Hex;
            switch (comboBox1.SelectedIndex)
            {
                case 0: mode = Mode.Bin; break;
                case 1: mode = Mode.Quad; break;
                case 2: mode = Mode.Hex; break;
            }
            LZMessageList = new LZMessageList(mode, (int)numericUpDown1.Value, (int)numericUpDown2.Value, Path.Text);
            string text = textBox1.Text;
            string convertedText = text.TextToArbitraryBase(mode);
            LZMessageList.AddText(convertedText);
            ConvertedMessage.Text = convertedText;

            EncryptedMessage.Text = LZMessageList.ToString();
        }

        private void Decrypt_Click(object sender, EventArgs e)
        {
            string message = LZMessageList.GetText();
            string textMessage = message.TextFromArbitraryBase(LZMessageList.MessageMode);
            DeconvertedMessage.Text = textMessage;
            DecryptedMessage.Text = string.Concat(message);
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "Text Files | *.txt";
            if (saveFileDialog.ShowDialog() == DialogResult.Cancel)
                return;
            Path.Text = saveFileDialog.FileName;
            var s = File.Create(saveFileDialog.FileName);
            s.Close();
        }
    }
}
