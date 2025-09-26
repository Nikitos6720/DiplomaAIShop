namespace DiplomaAIShop.Views
{
    partial class CategoryInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CategoryInfo));
            button1 = new Button();
            CategoryName = new Label();
            CategoryDescription = new RichTextBox();
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
            // CategoryName
            // 
            CategoryName.AutoSize = true;
            CategoryName.Dock = DockStyle.Bottom;
            CategoryName.Font = new Font("Nova Square", 14F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CategoryName.Location = new Point(0, 70);
            CategoryName.Name = "CategoryName";
            CategoryName.Size = new Size(86, 34);
            CategoryName.TabIndex = 2;
            CategoryName.Text = "label1";
            // 
            // CategoryDescription
            // 
            CategoryDescription.BackColor = Color.FromArgb(22, 11, 1);
            CategoryDescription.BorderStyle = BorderStyle.None;
            CategoryDescription.Dock = DockStyle.Bottom;
            CategoryDescription.ForeColor = Color.FromArgb(255, 213, 153);
            CategoryDescription.Location = new Point(0, 104);
            CategoryDescription.Name = "CategoryDescription";
            CategoryDescription.Size = new Size(1132, 72);
            CategoryDescription.TabIndex = 3;
            CategoryDescription.Text = "";
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 176);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1132, 421);
            flowLayoutPanel1.TabIndex = 4;
            // 
            // CategoryInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 11, 1);
            ClientSize = new Size(1132, 597);
            ControlBox = false;
            Controls.Add(CategoryName);
            Controls.Add(CategoryDescription);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button1);
            Font = new Font("Nova Square", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(255, 213, 153);
            Name = "CategoryInfo";
            Tag = "Category information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label CategoryName;
        private RichTextBox CategoryDescription;
        private FlowLayoutPanel flowLayoutPanel1;
    }
}