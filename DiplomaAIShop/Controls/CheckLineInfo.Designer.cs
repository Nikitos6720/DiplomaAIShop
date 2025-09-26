namespace DiplomaAIShop.Controls
{
    partial class CheckLineInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckLineInfo));
            ProductName = new Label();
            ProductPrice = new Label();
            numericUpDown1 = new NumericUpDown();
            label1 = new Label();
            LinePrice = new Label();
            panel2 = new Panel();
            panel1 = new Panel();
            button1 = new Button();
            CategoryName = new Label();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            SuspendLayout();
            // 
            // ProductName
            // 
            ProductName.AutoSize = true;
            ProductName.Location = new Point(20, 12);
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(182, 28);
            ProductName.TabIndex = 0;
            ProductName.Text = "Product name";
            // 
            // ProductPrice
            // 
            ProductPrice.AutoSize = true;
            ProductPrice.Font = new Font("Audiowide", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductPrice.Location = new Point(620, 16);
            ProductPrice.Name = "ProductPrice";
            ProductPrice.Size = new Size(63, 23);
            ProductPrice.TabIndex = 1;
            ProductPrice.Text = "Price";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(22, 11, 1);
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.Font = new Font("Nova Square", 11.25F);
            numericUpDown1.ForeColor = Color.FromArgb(255, 213, 153);
            numericUpDown1.Location = new Point(812, 10);
            numericUpDown1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(125, 35);
            numericUpDown1.TabIndex = 19;
            numericUpDown1.ValueChanged += numericUpDown1_ValueChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Audiowide", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(726, 16);
            label1.Name = "label1";
            label1.Size = new Size(71, 23);
            label1.TabIndex = 20;
            label1.Text = "Count";
            // 
            // LinePrice
            // 
            LinePrice.AutoSize = true;
            LinePrice.Font = new Font("Audiowide", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            LinePrice.Location = new Point(955, 15);
            LinePrice.Name = "LinePrice";
            LinePrice.Size = new Size(61, 23);
            LinePrice.TabIndex = 22;
            LinePrice.Text = "Total";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(245, 143, 1);
            panel2.Dock = DockStyle.Bottom;
            panel2.Location = new Point(0, 51);
            panel2.Name = "panel2";
            panel2.Size = new Size(1082, 1);
            panel2.TabIndex = 26;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(245, 143, 1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1082, 1);
            panel1.TabIndex = 25;
            // 
            // button1
            // 
            button1.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(1039, 6);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 27;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CategoryName
            // 
            CategoryName.AutoSize = true;
            CategoryName.Location = new Point(248, 12);
            CategoryName.Name = "CategoryName";
            CategoryName.Size = new Size(198, 28);
            CategoryName.TabIndex = 28;
            CategoryName.Text = "Category Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Audiowide", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(475, 17);
            label2.Name = "label2";
            label2.Size = new Size(139, 23);
            label2.TabIndex = 29;
            label2.Text = "Price per 1 el";
            // 
            // CheckLineInfo
            // 
            AutoScaleDimensions = new SizeF(16F, 28F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 22, 22);
            Controls.Add(label2);
            Controls.Add(CategoryName);
            Controls.Add(button1);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(LinePrice);
            Controls.Add(label1);
            Controls.Add(numericUpDown1);
            Controls.Add(ProductPrice);
            Controls.Add(ProductName);
            Font = new Font("Audiowide", 11F);
            ForeColor = Color.FromArgb(255, 213, 153);
            Margin = new Padding(5, 4, 5, 4);
            Name = "CheckLineInfo";
            Size = new Size(1082, 52);
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label ProductName;
        private Label ProductPrice;
        private NumericUpDown numericUpDown1;
        private Label label1;
        private Label LinePrice;
        private Panel panel2;
        private Panel panel1;
        private Button button1;
        private Label CategoryName;
        private Label label2;
    }
}
