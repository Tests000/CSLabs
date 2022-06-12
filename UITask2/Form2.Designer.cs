
namespace UITask2
{
    partial class Form2
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
            this.button1 = new System.Windows.Forms.Button();
            this.DateField = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.CountField = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.PriceField = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.nameField = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(16, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(268, 23);
            this.button1.TabIndex = 17;
            this.button1.Text = "Добавить";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // DateField
            // 
            this.DateField.Location = new System.Drawing.Point(148, 187);
            this.DateField.Name = "DateField";
            this.DateField.Size = new System.Drawing.Size(149, 22);
            this.DateField.TabIndex = 16;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(18, 190);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(100, 17);
            this.label4.TabIndex = 15;
            this.label4.Text = "Дата выпуска";
            // 
            // CountField
            // 
            this.CountField.Location = new System.Drawing.Point(148, 129);
            this.CountField.Name = "CountField";
            this.CountField.Size = new System.Drawing.Size(149, 22);
            this.CountField.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(26, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "Количество";
            // 
            // PriceField
            // 
            this.PriceField.Location = new System.Drawing.Point(148, 71);
            this.PriceField.Name = "PriceField";
            this.PriceField.Size = new System.Drawing.Size(149, 22);
            this.PriceField.TabIndex = 12;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(69, 71);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(43, 17);
            this.label2.TabIndex = 11;
            this.label2.Text = "Цена";
            // 
            // nameField
            // 
            this.nameField.Location = new System.Drawing.Point(148, 19);
            this.nameField.Name = "nameField";
            this.nameField.Size = new System.Drawing.Size(149, 22);
            this.nameField.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 19);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 17);
            this.label1.TabIndex = 9;
            this.label1.Text = "Наименование";
            // 
            // Form2
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(312, 322);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.DateField);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.CountField);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.PriceField);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.nameField);
            this.Controls.Add(this.label1);
            this.Name = "Form2";
            this.Text = "Добавить";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox DateField;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox CountField;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox PriceField;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox nameField;
        private System.Windows.Forms.Label label1;
    }
}