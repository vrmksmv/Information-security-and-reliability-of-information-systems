namespace Lab8
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxInput = new System.Windows.Forms.TextBox();
            this.buttonGen = new System.Windows.Forms.Button();
            this.richTextBoxW1 = new System.Windows.Forms.RichTextBox();
            this.richTextBoxW2 = new System.Windows.Forms.RichTextBox();
            this.textBoxM = new System.Windows.Forms.TextBox();
            this.textBoxK = new System.Windows.Forms.TextBox();
            this.buttonBack = new System.Windows.Forms.Button();
            this.richTextBoxB1 = new System.Windows.Forms.RichTextBox();
            this.buttonLast = new System.Windows.Forms.Button();
            this.textBoxNow = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // textBoxInput
            // 
            this.textBoxInput.Location = new System.Drawing.Point(10, 11);
            this.textBoxInput.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxInput.Name = "textBoxInput";
            this.textBoxInput.Size = new System.Drawing.Size(226, 20);
            this.textBoxInput.TabIndex = 0;
            // 
            // buttonGen
            // 
            this.buttonGen.Location = new System.Drawing.Point(239, 11);
            this.buttonGen.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonGen.Name = "buttonGen";
            this.buttonGen.Size = new System.Drawing.Size(74, 20);
            this.buttonGen.TabIndex = 1;
            this.buttonGen.Text = "Generate";
            this.buttonGen.UseVisualStyleBackColor = true;
            this.buttonGen.Click += new System.EventHandler(this.buttonGen_Click);
            // 
            // richTextBoxW1
            // 
            this.richTextBoxW1.Location = new System.Drawing.Point(10, 34);
            this.richTextBoxW1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxW1.Name = "richTextBoxW1";
            this.richTextBoxW1.Size = new System.Drawing.Size(226, 244);
            this.richTextBoxW1.TabIndex = 2;
            this.richTextBoxW1.Text = "";
            // 
            // richTextBoxW2
            // 
            this.richTextBoxW2.Location = new System.Drawing.Point(239, 35);
            this.richTextBoxW2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxW2.Name = "richTextBoxW2";
            this.richTextBoxW2.Size = new System.Drawing.Size(226, 244);
            this.richTextBoxW2.TabIndex = 3;
            this.richTextBoxW2.Text = "";
            // 
            // textBoxM
            // 
            this.textBoxM.BackColor = System.Drawing.SystemColors.Info;
            this.textBoxM.Location = new System.Drawing.Point(640, 34);
            this.textBoxM.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxM.Name = "textBoxM";
            this.textBoxM.Size = new System.Drawing.Size(226, 20);
            this.textBoxM.TabIndex = 4;
            // 
            // textBoxK
            // 
            this.textBoxK.Location = new System.Drawing.Point(469, 34);
            this.textBoxK.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxK.Name = "textBoxK";
            this.textBoxK.Size = new System.Drawing.Size(76, 20);
            this.textBoxK.TabIndex = 5;
            this.textBoxK.TextChanged += new System.EventHandler(this.textBoxK_TextChanged);
            // 
            // buttonBack
            // 
            this.buttonBack.Location = new System.Drawing.Point(469, 57);
            this.buttonBack.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonBack.Name = "buttonBack";
            this.buttonBack.Size = new System.Drawing.Size(104, 20);
            this.buttonBack.TabIndex = 6;
            this.buttonBack.Text = "Generate Next";
            this.buttonBack.UseVisualStyleBackColor = true;
            this.buttonBack.Click += new System.EventHandler(this.buttonBack_Click);
            // 
            // richTextBoxB1
            // 
            this.richTextBoxB1.BackColor = System.Drawing.SystemColors.Info;
            this.richTextBoxB1.Location = new System.Drawing.Point(640, 58);
            this.richTextBoxB1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.richTextBoxB1.Name = "richTextBoxB1";
            this.richTextBoxB1.Size = new System.Drawing.Size(226, 230);
            this.richTextBoxB1.TabIndex = 7;
            this.richTextBoxB1.Text = "";
            // 
            // buttonLast
            // 
            this.buttonLast.Location = new System.Drawing.Point(9, 344);
            this.buttonLast.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.buttonLast.Name = "buttonLast";
            this.buttonLast.Size = new System.Drawing.Size(104, 20);
            this.buttonLast.TabIndex = 8;
            this.buttonLast.Text = "Generate Last";
            this.buttonLast.UseVisualStyleBackColor = true;
            this.buttonLast.Click += new System.EventHandler(this.buttonLast_Click);
            // 
            // textBoxNow
            // 
            this.textBoxNow.Location = new System.Drawing.Point(548, 34);
            this.textBoxNow.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.textBoxNow.Name = "textBoxNow";
            this.textBoxNow.Size = new System.Drawing.Size(72, 20);
            this.textBoxNow.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Highlight;
            this.ClientSize = new System.Drawing.Size(974, 301);
            this.Controls.Add(this.textBoxNow);
            this.Controls.Add(this.buttonLast);
            this.Controls.Add(this.richTextBoxB1);
            this.Controls.Add(this.buttonBack);
            this.Controls.Add(this.textBoxK);
            this.Controls.Add(this.textBoxM);
            this.Controls.Add(this.richTextBoxW2);
            this.Controls.Add(this.richTextBoxW1);
            this.Controls.Add(this.buttonGen);
            this.Controls.Add(this.textBoxInput);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form1";
            this.Text = "Lab8";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxInput;
        private System.Windows.Forms.Button buttonGen;
        private System.Windows.Forms.RichTextBox richTextBoxW1;
        private System.Windows.Forms.RichTextBox richTextBoxW2;
        private System.Windows.Forms.TextBox textBoxM;
        private System.Windows.Forms.TextBox textBoxK;
        private System.Windows.Forms.Button buttonBack;
        private System.Windows.Forms.RichTextBox richTextBoxB1;
        private System.Windows.Forms.Button buttonLast;
        private System.Windows.Forms.TextBox textBoxNow;
    }
}

