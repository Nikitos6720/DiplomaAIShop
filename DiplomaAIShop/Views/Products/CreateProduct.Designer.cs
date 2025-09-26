namespace DiplomaAIShop.Views
{
    partial class CreateProduct
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CreateProduct));
            button3 = new Button();
            button1 = new Button();
            richTextBox1 = new RichTextBox();
            label2 = new Label();
            textBox1 = new TextBox();
            label1 = new Label();
            label3 = new Label();
            numericUpDown1 = new NumericUpDown();
            numericUpDown2 = new NumericUpDown();
            label4 = new Label();
            comboBox1 = new ComboBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).BeginInit();
            SuspendLayout();
            // 
            // button3
            // 
            button3.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 143, 1);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 143, 1);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Audiowide", 11F);
            button3.ForeColor = Color.FromArgb(255, 213, 153);
            button3.Location = new Point(988, 13);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(131, 48);
            button3.TabIndex = 12;
            button3.Text = "CREATE";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // button1
            // 
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Transparent;
            button1.FlatAppearance.MouseOverBackColor = Color.Transparent;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Image = (Image)resources.GetObject("button1.Image");
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 11;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BackColor = Color.FromArgb(22, 11, 1);
            richTextBox1.BorderStyle = BorderStyle.FixedSingle;
            richTextBox1.ForeColor = Color.FromArgb(255, 213, 153);
            richTextBox1.Location = new Point(604, 101);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.ScrollBars = RichTextBoxScrollBars.Vertical;
            richTextBox1.Size = new Size(516, 484);
            richTextBox1.TabIndex = 16;
            richTextBox1.Text = "";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nova Square", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(619, 69);
            label2.Name = "label2";
            label2.Size = new Size(95, 19);
            label2.TabIndex = 15;
            label2.Text = "Description";
            // 
            // textBox1
            // 
            textBox1.BackColor = Color.FromArgb(22, 11, 1);
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Font = new Font("Nova Square", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            textBox1.ForeColor = Color.FromArgb(255, 213, 153);
            textBox1.Location = new Point(12, 101);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(516, 26);
            textBox1.TabIndex = 14;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Nova Square", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(27, 69);
            label1.Name = "label1";
            label1.Size = new Size(51, 19);
            label1.TabIndex = 13;
            label1.Text = "Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nova Square", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(27, 258);
            label3.Name = "label3";
            label3.Size = new Size(72, 19);
            label3.TabIndex = 17;
            label3.Text = "Quantity";
            // 
            // numericUpDown1
            // 
            numericUpDown1.BackColor = Color.FromArgb(22, 11, 1);
            numericUpDown1.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown1.Font = new Font("Nova Square", 11.25F);
            numericUpDown1.ForeColor = Color.FromArgb(255, 213, 153);
            numericUpDown1.Location = new Point(12, 290);
            numericUpDown1.Maximum = new decimal(new int[] { 100000, 0, 0, 0 });
            numericUpDown1.Name = "numericUpDown1";
            numericUpDown1.Size = new Size(516, 26);
            numericUpDown1.TabIndex = 18;
            // 
            // numericUpDown2
            // 
            numericUpDown2.BackColor = Color.FromArgb(22, 11, 1);
            numericUpDown2.BorderStyle = BorderStyle.FixedSingle;
            numericUpDown2.DecimalPlaces = 2;
            numericUpDown2.Font = new Font("Nova Square", 11.25F);
            numericUpDown2.ForeColor = Color.FromArgb(255, 213, 153);
            numericUpDown2.Location = new Point(12, 394);
            numericUpDown2.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            numericUpDown2.Name = "numericUpDown2";
            numericUpDown2.Size = new Size(516, 26);
            numericUpDown2.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Nova Square", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(27, 362);
            label4.Name = "label4";
            label4.Size = new Size(48, 19);
            label4.TabIndex = 19;
            label4.Text = "Price";
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(22, 11, 1);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.Font = new Font("Nova Square", 11.25F);
            comboBox1.ForeColor = Color.FromArgb(255, 213, 153);
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(12, 194);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(516, 26);
            comboBox1.TabIndex = 21;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Nova Square", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(27, 162);
            label5.Name = "label5";
            label5.Size = new Size(76, 19);
            label5.TabIndex = 22;
            label5.Text = "Category";
            // 
            // CreateProduct
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 11, 1);
            ClientSize = new Size(1132, 597);
            ControlBox = false;
            Controls.Add(label5);
            Controls.Add(comboBox1);
            Controls.Add(numericUpDown2);
            Controls.Add(label4);
            Controls.Add(numericUpDown1);
            Controls.Add(label3);
            Controls.Add(richTextBox1);
            Controls.Add(label2);
            Controls.Add(textBox1);
            Controls.Add(label1);
            Controls.Add(button3);
            Controls.Add(button1);
            Font = new Font("Nova Square", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(255, 213, 153);
            Name = "CreateProduct";
            Tag = "Create product";
            Load += CreateProduct_Load;
            ((System.ComponentModel.ISupportInitialize)numericUpDown1).EndInit();
            ((System.ComponentModel.ISupportInitialize)numericUpDown2).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button3;
        private Button button1;
        private RichTextBox richTextBox1;
        private Label label2;
        private TextBox textBox1;
        private Label label1;
        private Label label3;
        private NumericUpDown numericUpDown1;
        private NumericUpDown numericUpDown2;
        private Label label4;
        private ComboBox comboBox1;
        private Label label5;
    }
}