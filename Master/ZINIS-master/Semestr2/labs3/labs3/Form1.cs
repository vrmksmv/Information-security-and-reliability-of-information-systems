using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace labs3
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void click_de_Click(object sender, EventArgs e)
        {

        }
        string alphabet = "ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        void Deshifr(string text) 
        {
            if (text != null)
            {
                text = text.ToUpper();
                char[] a = text.ToCharArray();
                for (int i= 0; i<a.Length;i++)
                {
                    
                }
            }
        }
    }
}
