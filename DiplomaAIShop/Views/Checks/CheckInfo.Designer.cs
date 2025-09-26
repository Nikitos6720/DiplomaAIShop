namespace DiplomaAIShop.Views
{
    partial class CheckInfo
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CheckInfo));
            button1 = new Button();
            Price = new Label();
            label2 = new Label();
            CheckDate = new Label();
            CheckId = new Label();
            label1 = new Label();
            button3 = new Button();
            flowLayoutPanel1 = new FlowLayoutPanel();
            label3 = new Label();
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
            // Price
            // 
            Price.AutoSize = true;
            Price.Font = new Font("Nova Square", 15.75F);
            Price.Location = new Point(492, 61);
            Price.Name = "Price";
            Price.RightToLeft = RightToLeft.No;
            Price.Size = new Size(93, 39);
            Price.TabIndex = 10;
            Price.Text = "Price";
            Price.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Nova Square", 15.75F);
            label2.Location = new Point(492, 29);
            label2.Name = "label2";
            label2.Size = new Size(174, 39);
            label2.TabIndex = 9;
            label2.Text = "Total price";
            // 
            // CheckDate
            // 
            CheckDate.AutoSize = true;
            CheckDate.Location = new Point(68, 43);
            CheckDate.Name = "CheckDate";
            CheckDate.Size = new Size(110, 21);
            CheckDate.TabIndex = 8;
            CheckDate.Text = "21.08.2000";
            // 
            // CheckId
            // 
            CheckId.AutoSize = true;
            CheckId.Font = new Font("Audiowide", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CheckId.Location = new Point(195, 16);
            CheckId.Name = "CheckId";
            CheckId.Size = new Size(73, 30);
            CheckId.TabIndex = 7;
            CheckId.Text = "1234";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Audiowide", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(58, 13);
            label1.Name = "label1";
            label1.Size = new Size(131, 31);
            label1.TabIndex = 6;
            label1.Text = "Check №";
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
            button3.Text = "CLOSE";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // flowLayoutPanel1
            // 
            flowLayoutPanel1.AutoScroll = true;
            flowLayoutPanel1.Dock = DockStyle.Bottom;
            flowLayoutPanel1.Location = new Point(0, 127);
            flowLayoutPanel1.Name = "flowLayoutPanel1";
            flowLayoutPanel1.Size = new Size(1132, 470);
            flowLayoutPanel1.TabIndex = 13;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Nova Square", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(41, 80);
            label3.Name = "label3";
            label3.Size = new Size(106, 44);
            label3.TabIndex = 14;
            label3.Text = "Lines";
            // 
            // CheckInfo
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 11, 1);
            ClientSize = new Size(1132, 597);
            ControlBox = false;
            Controls.Add(label3);
            Controls.Add(flowLayoutPanel1);
            Controls.Add(button3);
            Controls.Add(Price);
            Controls.Add(label2);
            Controls.Add(CheckDate);
            Controls.Add(CheckId);
            Controls.Add(label1);
            Controls.Add(button1);
            Font = new Font("Nova Square", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ForeColor = Color.FromArgb(255, 213, 153);
            Name = "CheckInfo";
            Tag = "Check information";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button button1;
        private Label Price;
        private Label label2;
        private Label CheckDate;
        private Label CheckId;
        private Label label1;
        private Button button3;
        private FlowLayoutPanel flowLayoutPanel1;
        private Label label3;
    }
}