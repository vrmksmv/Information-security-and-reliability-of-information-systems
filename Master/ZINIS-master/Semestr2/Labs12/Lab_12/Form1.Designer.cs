namespace Lab_12
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
            this.originalImage = new System.Windows.Forms.PictureBox();
            this.redImage = new System.Windows.Forms.PictureBox();
            this.greenImage = new System.Windows.Forms.PictureBox();
            this.blueImage = new System.Windows.Forms.PictureBox();
            this.stegOpenFile = new System.Windows.Forms.Button();
            this.colorImage = new System.Windows.Forms.PictureBox();
            this.stegText = new System.Windows.Forms.TextBox();
            this.stegButton = new System.Windows.Forms.Button();
            this.stegImage = new System.Windows.Forms.PictureBox();
            this.deStegImage = new System.Windows.Forms.PictureBox();
            this.deStegOpenFile = new System.Windows.Forms.Button();
            this.deStegText = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.redImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.stegImage)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStegImage)).BeginInit();
            this.SuspendLayout();
            // 
            // originalImage
            // 
            this.originalImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.originalImage.Location = new System.Drawing.Point(16, 16);
            this.originalImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.originalImage.Name = "originalImage";
            this.originalImage.Size = new System.Drawing.Size(255, 256);
            this.originalImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.originalImage.TabIndex = 0;
            this.originalImage.TabStop = false;
            this.originalImage.Click += new System.EventHandler(this.originalImage_Click);
            // 
            // redImage
            // 
            this.redImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.redImage.Location = new System.Drawing.Point(288, 16);
            this.redImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.redImage.Name = "redImage";
            this.redImage.Size = new System.Drawing.Size(255, 256);
            this.redImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.redImage.TabIndex = 1;
            this.redImage.TabStop = false;
            // 
            // greenImage
            // 
            this.greenImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.greenImage.Location = new System.Drawing.Point(560, 16);
            this.greenImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.greenImage.Name = "greenImage";
            this.greenImage.Size = new System.Drawing.Size(255, 256);
            this.greenImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.greenImage.TabIndex = 2;
            this.greenImage.TabStop = false;
            // 
            // blueImage
            // 
            this.blueImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.blueImage.Location = new System.Drawing.Point(832, 16);
            this.blueImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.blueImage.Name = "blueImage";
            this.blueImage.Size = new System.Drawing.Size(255, 256);
            this.blueImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.blueImage.TabIndex = 3;
            this.blueImage.TabStop = false;
            // 
            // stegOpenFile
            // 
            this.stegOpenFile.BackColor = System.Drawing.Color.Transparent;
            this.stegOpenFile.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stegOpenFile.Location = new System.Drawing.Point(16, 276);
            this.stegOpenFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stegOpenFile.Name = "stegOpenFile";
            this.stegOpenFile.Size = new System.Drawing.Size(256, 46);
            this.stegOpenFile.TabIndex = 4;
            this.stegOpenFile.Text = "Открыть файл";
            this.stegOpenFile.UseVisualStyleBackColor = false;
            this.stegOpenFile.Click += new System.EventHandler(this.openFile_Click);
            // 
            // colorImage
            // 
            this.colorImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.colorImage.Location = new System.Drawing.Point(1104, 16);
            this.colorImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.colorImage.Name = "colorImage";
            this.colorImage.Size = new System.Drawing.Size(255, 256);
            this.colorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.colorImage.TabIndex = 5;
            this.colorImage.TabStop = false;
            // 
            // stegText
            // 
            this.stegText.Location = new System.Drawing.Point(288, 288);
            this.stegText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stegText.Name = "stegText";
            this.stegText.Size = new System.Drawing.Size(1072, 22);
            this.stegText.TabIndex = 6;
            // 
            // stegButton
            // 
            this.stegButton.BackColor = System.Drawing.Color.Transparent;
            this.stegButton.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.stegButton.Location = new System.Drawing.Point(1376, 287);
            this.stegButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stegButton.Name = "stegButton";
            this.stegButton.Size = new System.Drawing.Size(256, 34);
            this.stegButton.TabIndex = 7;
            this.stegButton.Text = "Осадить";
            this.stegButton.UseVisualStyleBackColor = false;
            this.stegButton.Click += new System.EventHandler(this.stegButton_Click);
            // 
            // stegImage
            // 
            this.stegImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.stegImage.Location = new System.Drawing.Point(1376, 16);
            this.stegImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.stegImage.Name = "stegImage";
            this.stegImage.Size = new System.Drawing.Size(255, 256);
            this.stegImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.stegImage.TabIndex = 8;
            this.stegImage.TabStop = false;
            // 
            // deStegImage
            // 
            this.deStegImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.deStegImage.Location = new System.Drawing.Point(16, 326);
            this.deStegImage.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deStegImage.Name = "deStegImage";
            this.deStegImage.Size = new System.Drawing.Size(255, 256);
            this.deStegImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.deStegImage.TabIndex = 9;
            this.deStegImage.TabStop = false;
            // 
            // deStegOpenFile
            // 
            this.deStegOpenFile.BackColor = System.Drawing.Color.Transparent;
            this.deStegOpenFile.Font = new System.Drawing.Font("MS Reference Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deStegOpenFile.Location = new System.Drawing.Point(1376, 325);
            this.deStegOpenFile.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deStegOpenFile.Name = "deStegOpenFile";
            this.deStegOpenFile.Size = new System.Drawing.Size(256, 34);
            this.deStegOpenFile.TabIndex = 10;
            this.deStegOpenFile.Text = "Извлечь";
            this.deStegOpenFile.UseVisualStyleBackColor = false;
            this.deStegOpenFile.Click += new System.EventHandler(this.deStegOpenFile_Click);
            // 
            // deStegText
            // 
            this.deStegText.Location = new System.Drawing.Point(288, 326);
            this.deStegText.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.deStegText.Name = "deStegText";
            this.deStegText.Size = new System.Drawing.Size(1072, 22);
            this.deStegText.TabIndex = 11;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.ClientSize = new System.Drawing.Size(1763, 596);
            this.Controls.Add(this.deStegText);
            this.Controls.Add(this.deStegOpenFile);
            this.Controls.Add(this.deStegImage);
            this.Controls.Add(this.stegImage);
            this.Controls.Add(this.stegButton);
            this.Controls.Add(this.stegText);
            this.Controls.Add(this.colorImage);
            this.Controls.Add(this.stegOpenFile);
            this.Controls.Add(this.blueImage);
            this.Controls.Add(this.greenImage);
            this.Controls.Add(this.redImage);
            this.Controls.Add(this.originalImage);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "Form1";
            this.Text = "Лабораторная №12 - Исследование стеганографического метода на основе преобразован" +
    "ия наименее значащих бит";
            ((System.ComponentModel.ISupportInitialize)(this.originalImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.redImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.greenImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.blueImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.colorImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.stegImage)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.deStegImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox originalImage;
        private System.Windows.Forms.PictureBox redImage;
        private System.Windows.Forms.PictureBox greenImage;
        private System.Windows.Forms.PictureBox blueImage;
        private System.Windows.Forms.Button stegOpenFile;
        private System.Windows.Forms.PictureBox colorImage;
        private System.Windows.Forms.TextBox stegText;
        private System.Windows.Forms.Button stegButton;
        private System.Windows.Forms.PictureBox stegImage;
        private System.Windows.Forms.PictureBox deStegImage;
        private System.Windows.Forms.Button deStegOpenFile;
        private System.Windows.Forms.TextBox deStegText;
    }
}

