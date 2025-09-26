using System.Windows.Forms.DataVisualization.Charting;

namespace DiplomaAIShop.Views.Diagram
{
    partial class SellingDiagram
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SellingDiagram));
            panel1 = new Panel();
            button1 = new Button();
            chart = new();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(button1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1132, 64);
            panel1.TabIndex = 0;
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
            button1.TabIndex = 12;
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // SellingDiagram
            // 
            AutoScaleDimensions = new SizeF(11F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(22, 11, 1);
            ClientSize = new Size(1132, 597);
            ControlBox = false;
            Controls.Add(panel1);
            Font = new Font("Nova Square", 9F);
            ForeColor = Color.FromArgb(255, 213, 153);
            Name = "SellingDiagram";
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            //
            // Chart
            //
            chart.Dock = DockStyle.Fill;
            chart.BackColor = Color.FromArgb(22, 11, 1);
            chart.ForeColor = Color.FromArgb(245, 143, 1);
            chart.ChartAreas.Add(new ChartArea());
            chart.ChartAreas[0].BackColor = Color.FromArgb(22, 11, 1);
            chart.ChartAreas[0].AxisX.Title = "Dates";
            chart.ChartAreas[0].AxisX.TitleForeColor = Color.FromArgb(245, 143, 1);
            chart.ChartAreas[0].AxisX.LineColor = Color.FromArgb(245, 143, 1);
            chart.ChartAreas[0].AxisX.LabelStyle.ForeColor = Color.FromArgb(245, 143, 1);
            chart.ChartAreas[0].AxisX.MajorGrid.LineColor = Color.FromArgb(10, 245, 143, 1);
            chart.ChartAreas[0].AxisY.Title = "Sales";
            chart.ChartAreas[0].AxisY.LineColor = Color.FromArgb(245, 143, 1);
            chart.ChartAreas[0].AxisY.LabelStyle.ForeColor = Color.FromArgb(245, 143, 1);
            chart.ChartAreas[0].AxisY.MajorGrid.LineColor = Color.FromArgb(10, 245, 143, 1);
            Controls.Add(chart);
        }

        #endregion

        private Panel panel1;
        private Button button1;
        private Chart chart;
    }
}