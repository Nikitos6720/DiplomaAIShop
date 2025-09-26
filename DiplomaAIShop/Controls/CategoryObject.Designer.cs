namespace DiplomaAIShop.Controls
{
    partial class CategoryObject
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
            CategoryName = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // CategoryName
            // 
            CategoryName.Dock = DockStyle.Fill;
            CategoryName.Location = new Point(0, 1);
            CategoryName.Margin = new Padding(5, 0, 5, 0);
            CategoryName.Name = "CategoryName";
            CategoryName.Size = new Size(300, 98);
            CategoryName.TabIndex = 0;
            CategoryName.Text = "label1";
            CategoryName.TextAlign = ContentAlignment.MiddleCenter;
            CategoryName.MouseDoubleClick += OpenCategoryInformation;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(245, 143, 1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(300, 1);
            panel1.TabIndex = 1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(245, 143, 1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 99);
            panel2.Name = "panel2";
            panel2.Size = new Size(300, 1);
            panel2.TabIndex = 2;
            // 
            // CategoryObject
            // 
            AutoScaleDimensions = new SizeF(17F, 35F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 22, 22);
            Controls.Add(CategoryName);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Nova Square", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(255, 213, 153);
            Margin = new Padding(5);
            Name = "CategoryObject";
            Size = new Size(300, 100);
            ResumeLayout(false);
        }

        #endregion

        private Label CategoryName;
        private Panel panel1;
        private Panel panel2;
    }
}
