namespace DiplomaAIShop.Views.General
{
    partial class ErrorMessageBox
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
            label1 = new Label();
            button3 = new Button();
            panel1 = new Panel();
            panel2 = new Panel();
            ErrorMessage = new RichTextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Orbitron Black", 11F);
            label1.ForeColor = Color.FromArgb(245, 143, 1);
            label1.Location = new Point(15, 11);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(101, 27);
            label1.TabIndex = 0;
            label1.Text = "ERROR";
            // 
            // button3
            // 
            button3.BackColor = Color.Transparent;
            button3.FlatAppearance.BorderSize = 0;
            button3.FlatAppearance.MouseDownBackColor = Color.FromArgb(245, 143, 1);
            button3.FlatAppearance.MouseOverBackColor = Color.FromArgb(245, 143, 1);
            button3.FlatStyle = FlatStyle.Flat;
            button3.Font = new Font("Audiowide", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button3.ForeColor = Color.FromArgb(245, 143, 1);
            button3.Location = new Point(249, 91);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(72, 30);
            button3.TabIndex = 9;
            button3.Text = "OK";
            button3.UseVisualStyleBackColor = false;
            button3.Click += button3_Click;
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(245, 143, 1);
            panel1.Dock = DockStyle.Bottom;
            panel1.Location = new Point(0, 126);
            panel1.Name = "panel1";
            panel1.Size = new Size(328, 2);
            panel1.TabIndex = 10;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(245, 143, 1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(328, 2);
            panel2.TabIndex = 11;
            // 
            // ErrorMessage
            // 
            ErrorMessage.BackColor = Color.FromArgb(22, 11, 1);
            ErrorMessage.BorderStyle = BorderStyle.None;
            ErrorMessage.Font = new Font("Nova Square", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ErrorMessage.ForeColor = Color.FromArgb(255, 213, 153);
            ErrorMessage.Location = new Point(15, 41);
            ErrorMessage.Name = "ErrorMessage";
            ErrorMessage.Size = new Size(307, 43);
            ErrorMessage.TabIndex = 12;
            ErrorMessage.Text = "";
            // 
            // ErrorMessageBox
            // 
            AutoScaleDimensions = new SizeF(13F, 26F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 11, 1);
            ClientSize = new Size(328, 128);
            ControlBox = false;
            Controls.Add(ErrorMessage);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Controls.Add(button3);
            Controls.Add(label1);
            Font = new Font("Nova Square", 11F);
            ForeColor = Color.FromArgb(255, 213, 153);
            Margin = new Padding(4);
            MaximumSize = new Size(350, 150);
            MinimumSize = new Size(350, 150);
            Name = "ErrorMessageBox";
            ShowIcon = false;
            SizeGripStyle = SizeGripStyle.Hide;
            StartPosition = FormStartPosition.CenterParent;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Button button3;
        private Panel panel1;
        private Panel panel2;
        private RichTextBox ErrorMessage;
    }
}