
namespace labs3
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.click_de = new System.Windows.Forms.Button();
            this.Text = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // click_de
            // 
            this.click_de.Location = new System.Drawing.Point(80, 178);
            this.click_de.Name = "click_de";
            this.click_de.Size = new System.Drawing.Size(75, 23);
            this.click_de.TabIndex = 0;
            this.click_de.Text = "button1";
            this.click_de.UseVisualStyleBackColor = true;
            this.click_de.Click += new System.EventHandler(this.click_de_Click);
            // 
            // Text
            // 
            this.Text.Location = new System.Drawing.Point(12, 12);
            this.Text.Multiline = true;
            this.Text.Name = "Text";
            this.Text.Size = new System.Drawing.Size(192, 160);
            this.Text.TabIndex = 1;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Text);
            this.Controls.Add(this.click_de);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button click_de;
        private System.Windows.Forms.TextBox Text;
    }
}

