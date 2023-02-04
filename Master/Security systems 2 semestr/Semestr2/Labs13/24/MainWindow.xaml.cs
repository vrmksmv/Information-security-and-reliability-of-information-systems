using System;
using System.Collections.Generic;
using System.Text;
using System.Windows;
using Aspose.Words;
using Microsoft.Win32;
using System.Globalization;
using Run = Aspose.Words.Run;
using Microsoft.Office.Interop.Word;
using Application = Microsoft.Office.Interop.Word.Application;
using Document = Aspose.Words.Document;

namespace _24
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : System.Windows.Window
    {
        Document doc;
        DocumentBuilder documentBuilder;
        string soloBitSpacing = "-0.1";
        string zeroBitSpacing = "0.1";

        private static string TextToBits(string message)
        {
            string textBits = "";
            foreach (byte item in Encoding.Unicode.GetBytes(message))
            {
                textBits += Convert.ToString(item, 2).PadLeft(8, '0');
            }
            return textBits;
        }

        private static string BitsToText(string bits)
        {
            List<byte> bytes = new List<byte>();
            for (int i = 0; i < bits.Length; i += 8)
            {
                bytes.Add(Convert.ToByte(bits.Substring(i, 8), 2));
            }
            string text = Encoding.Unicode.GetString(bytes.ToArray());
            return text;
        }

        public MainWindow()
        {
            InitializeComponent();
        }

        ////////////////////////////////////////////////////////////////////////////////ОСАЖДЕНИЕ

        private void InputBySpaces_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            Nullable<bool> result = openDialog.ShowDialog();
            if (result == true)
            {
                string filename = openDialog.FileName;
            }

            Application ap = new Application();
            Microsoft.Office.Interop.Word.Document document = ap.Documents.Open(openDialog.FileName);


            doc = new Document(openDialog.FileName);
            documentBuilder = new DocumentBuilder(doc);

            string messageInBits = TextToBits(TextToInput.Text);
            int i = 0, j = 0;
            while (j < messageInBits.Length)
            {
                documentBuilder.MoveTo(doc.GetChildNodes(NodeType.Run, true)[i]);
                if (doc.GetChildNodes(NodeType.Run, true)[i].GetText() == " ")
                {
                    if (messageInBits[j] == '1')
                    {
                        documentBuilder.Write(" ");
                        documentBuilder.InsertField(" ", null);
                    }
                    j++;
                }
                i++;
            }

            string[] file_name = openDialog.FileName.Split('.');
            doc.Save(file_name[0]
                     + "_copy."
                     + file_name[1]);
        }

        private void InputByAprosh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            Nullable<bool> result = openDialog.ShowDialog();
            if (result == true)
            {
                string filename = openDialog.FileName;
            }

            doc = new Document(openDialog.FileName);
            documentBuilder = new DocumentBuilder(doc);

            string messageInBits = TextToBits(TextToInput.Text);

            for (int i = 0; i < messageInBits.Length; i++)
            {
                documentBuilder.MoveTo(doc.GetChildNodes(NodeType.Run, true)[i]);
                if (messageInBits[i] == '1')
                {
                    ((Run)documentBuilder.CurrentNode).Font.Spacing = Double.Parse(soloBitSpacing, CultureInfo.InvariantCulture);
                }

                else
                {
                    ((Run)documentBuilder.CurrentNode).Font.Spacing = Double.Parse(zeroBitSpacing, CultureInfo.InvariantCulture);
                }
            }

            string[] file_name = openDialog.FileName.Split('.');
            doc.Save(file_name[0]
                     + "_CHANGED."
                     + file_name[1]);
        }
        ////////////////////////////////////////////////////////////////////////////////ИЗВЛЕЧЕНИЕ
        private void OutputBySpaces_Click(object sender, RoutedEventArgs e)
        {

        }

        private void OutputByAprosh_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openDialog = new OpenFileDialog();
            Nullable<bool> result = openDialog.ShowDialog();
            if (result == true)
            {
                string filename = openDialog.FileName;
            }

            doc = new Document(openDialog.FileName);
            documentBuilder = new DocumentBuilder(doc);

            string foundedMessageInDocument = string.Empty;
            foreach (Run run in doc.GetChildNodes(NodeType.Run, true))
            {
                if (run.Font.Spacing == Double.Parse(soloBitSpacing, CultureInfo.InvariantCulture))
                    foundedMessageInDocument += "1";
                if (run.Font.Spacing == Double.Parse(zeroBitSpacing, CultureInfo.InvariantCulture))
                    foundedMessageInDocument += "0";
            }

            TextToOutput.Text = BitsToText(foundedMessageInDocument);
        }
    }
}
