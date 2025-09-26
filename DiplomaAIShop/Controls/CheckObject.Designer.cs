namespace DiplomaAIShop.Controls
{
    partial class CheckObject
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

        #region Код, автоматически созданный конструктором компонентов

        /// <summary> 
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            CheckId = new Label();
            CheckDate = new Label();
            label2 = new Label();
            Price = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Audiowide", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(8, 9);
            label1.Name = "label1";
            label1.Size = new Size(131, 31);
            label1.TabIndex = 0;
            label1.Text = "Check №";
            label1.DoubleClick += CheckObject_decimalClick;
            // 
            // CheckId
            // 
            CheckId.AutoSize = true;
            CheckId.Font = new Font("Audiowide", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckId.Location = new Point(145, 14);
            CheckId.Name = "CheckId";
            CheckId.Size = new Size(63, 26);
            CheckId.TabIndex = 1;
            CheckId.Text = "1234";
            CheckId.DoubleClick += CheckObject_decimalClick;
            // 
            // CheckDate
            // 
            CheckDate.AutoSize = true;
            CheckDate.Location = new Point(18, 39);
            CheckDate.Name = "CheckDate";
            CheckDate.Size = new Size(133, 23);
            CheckDate.TabIndex = 2;
            CheckDate.Text = "21.08.2000";
            CheckDate.DoubleClick += CheckObject_decimalClick;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(281, 13);
            label2.Name = "label2";
            label2.Size = new Size(117, 23);
            label2.TabIndex = 3;
            label2.Text = "Total price";
            label2.DoubleClick += CheckObject_decimalClick;
            // 
            // Price
            // 
            Price.AutoSize = true;
            Price.Location = new Point(288, 39);
            Price.Name = "Price";
            Price.RightToLeft = RightToLeft.No;
            Price.Size = new Size(63, 23);
            Price.TabIndex = 4;
            Price.Text = "Price";
            Price.TextAlign = ContentAlignment.MiddleCenter;
            Price.DoubleClick += CheckObject_decimalClick;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(245, 143, 1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 118);
            panel1.Name = "panel1";
            panel1.Size = new Size(500, 1);
            panel1.TabIndex = 6;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(245, 143, 1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(500, 1);
            panel2.TabIndex = 7;
            // 
            // CheckObject
            // 
            AutoScaleMode = AutoScaleMode.None;
            BackColor = Color.FromArgb(22, 22, 22);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(Price);
            Controls.Add(label2);
            Controls.Add(CheckDate);
            Controls.Add(CheckId);
            Controls.Add(label1);
            Font = new Font("Audiowide", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(255, 213, 153);
            Name = "CheckObject";
            Size = new Size(500, 119);
            DoubleClick += CheckObject_decimalClick;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label CheckId;
        private Label CheckDate;
        private Label label2;
        private Label Price;
        private Panel panel1;
        private Panel panel2;
    }
}
