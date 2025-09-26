namespace DiplomaAIShop.Controls
{
    partial class ProductObject
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
            button3 = new Button();
            ProductName = new Label();
            ProductCategory = new Label();
            ProductPrice = new Label();
            panel1 = new Panel();
            panel2 = new Panel();
            SuspendLayout();
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.Dock = DockStyle.Bottom;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 143, 1);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 143, 1);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Audiowide", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(245, 143, 1);
            button3.Location = new Point(0, 275);
            button3.Margin = new Padding(5, 4, 5, 4);
            button3.Name = "button3";
            button3.Size = new Size(340, 65);
            button3.TabIndex = 8;
            button3.Text = "ADD TO CART";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // ProductName
            // 
            ProductName.Dock = DockStyle.Top;
            ProductName.Font = new Font("Audiowide", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductName.Location = new Point(0, 1);
            ProductName.Margin = new Padding(4, 0, 4, 0);
            ProductName.Name = "ProductName";
            ProductName.Size = new Size(340, 100);
            ProductName.TabIndex = 9;
            ProductName.Text = "Intel Core i5 12400F";
            ProductName.TextAlign = ContentAlignment.BottomCenter;
            // 
            // ProductCategory
            // 
            ProductCategory.Dock = DockStyle.Top;
            ProductCategory.Font = new Font("Audiowide", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductCategory.Location = new Point(0, 101);
            ProductCategory.Margin = new Padding(4, 0, 4, 0);
            ProductCategory.Name = "ProductCategory";
            ProductCategory.Size = new Size(340, 126);
            ProductCategory.TabIndex = 10;
            ProductCategory.Text = "Processor";
            ProductCategory.TextAlign = ContentAlignment.TopCenter;
            // 
            // ProductPrice
            // 
            ProductPrice.Dock = DockStyle.Top;
            ProductPrice.Font = new Font("Audiowide", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ProductPrice.Location = new Point(0, 227);
            ProductPrice.Margin = new Padding(4, 0, 4, 0);
            ProductPrice.Name = "ProductPrice";
            ProductPrice.Size = new Size(340, 59);
            ProductPrice.TabIndex = 11;
            ProductPrice.Text = "300₴";
            ProductPrice.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(245, 143, 1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 340);
            panel1.Name = "panel1";
            panel1.Size = new Size(340, 1);
            panel1.TabIndex = 12;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(245, 143, 1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(340, 1);
            panel2.TabIndex = 13;
            // 
            // ProductObject
            // 
            AutoScaleDimensions = new SizeF(8F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 22, 22);
            Controls.Add(ProductPrice);
            Controls.Add(ProductCategory);
            Controls.Add(ProductName);
            Controls.Add(button3);
            Controls.Add(panel1);
            Controls.Add(panel2);
            Font = new Font("Audiowide", 9F);
            ForeColor = Color.FromArgb(255, 213, 153);
            Margin = new Padding(4, 3, 4, 3);
            Name = "ProductObject";
            Size = new Size(340, 341);
            ResumeLayout(false);
        }

        #endregion

        private Button button3;
        private Label ProductName;
        private Label ProductCategory;
        private Label ProductPrice;
        private Panel panel1;
        private Panel panel2;
    }
}
