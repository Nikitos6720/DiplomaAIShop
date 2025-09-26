namespace DiplomaAIShop.Views
{
    partial class CategoryList
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryList));
            button1 = new Button();
            button3 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            SuspendLayout();
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
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
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
            button3.TabIndex = 7;
            button3.Text = "CREATE";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Location = new Point(0, 68);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1132, 529);
            flowLayoutPanel1.TabIndex = 6;
            // 
            // CategoryList
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 11, 1);
            ClientSize = new Size(1132, 597);
            ControlBox = false;
            Controls.Add(button3);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Font = new Font("Nova Square", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(255, 213, 153);
            Name = "CategoryList";
            Tag = "Category list";
            ResumeLayout(false);
        }

        #endregion

        private Button button1;
        private Button button3;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}