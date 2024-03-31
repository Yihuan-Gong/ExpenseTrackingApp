namespace 記帳
{
    partial class Chart
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
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.label2 = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.analyzeBtn = new System.Windows.Forms.Button();
            this.propertyCheckBox = new System.Windows.Forms.CheckBox();
            this.payMethodCheckBox = new System.Windows.Forms.CheckBox();
            this.contentCheckBox = new System.Windows.Forms.CheckBox();
            this.typeCheckBox = new System.Windows.Forms.CheckBox();
            this.chartTypeComboBox = new System.Windows.Forms.ComboBox();
            this.expenceTypeFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.navBar1 = new 記帳.NavBar();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.expenceTypeFlowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // chart1
            // 
            chartArea1.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chart1.Legends.Add(legend1);
            this.chart1.Location = new System.Drawing.Point(219, 390);
            this.chart1.Name = "chart1";
            series1.ChartArea = "ChartArea1";
            series1.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            series1.YValuesPerPoint = 4;
            this.chart1.Series.Add(series1);
            this.chart1.Size = new System.Drawing.Size(562, 475);
            this.chart1.TabIndex = 5;
            this.chart1.Text = "chart1";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(228, 90);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 42;
            this.label2.Text = "結束日期";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(351, 82);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(201, 36);
            this.endDateTimePicker.TabIndex = 41;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(228, 48);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 40;
            this.label1.Text = "開始日期";
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(351, 40);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(201, 36);
            this.startDateTimePicker.TabIndex = 39;
            // 
            // analyzeBtn
            // 
            this.analyzeBtn.Location = new System.Drawing.Point(795, 78);
            this.analyzeBtn.Name = "analyzeBtn";
            this.analyzeBtn.Size = new System.Drawing.Size(107, 35);
            this.analyzeBtn.TabIndex = 38;
            this.analyzeBtn.Text = "分析";
            this.analyzeBtn.UseVisualStyleBackColor = true;
            this.analyzeBtn.Click += new System.EventHandler(this.AnalyzeBtn_Clicked);
            // 
            // propertyCheckBox
            // 
            this.propertyCheckBox.AutoSize = true;
            this.propertyCheckBox.Location = new System.Drawing.Point(3, 105);
            this.propertyCheckBox.Name = "propertyCheckBox";
            this.propertyCheckBox.Size = new System.Drawing.Size(138, 28);
            this.propertyCheckBox.TabIndex = 37;
            this.propertyCheckBox.Text = "消費屬性";
            this.propertyCheckBox.UseVisualStyleBackColor = true;
            // 
            // payMethodCheckBox
            // 
            this.payMethodCheckBox.AutoSize = true;
            this.payMethodCheckBox.Location = new System.Drawing.Point(3, 71);
            this.payMethodCheckBox.Name = "payMethodCheckBox";
            this.payMethodCheckBox.Size = new System.Drawing.Size(138, 28);
            this.payMethodCheckBox.TabIndex = 36;
            this.payMethodCheckBox.Text = "付款方式";
            this.payMethodCheckBox.UseVisualStyleBackColor = true;
            // 
            // contentCheckBox
            // 
            this.contentCheckBox.AutoSize = true;
            this.contentCheckBox.Location = new System.Drawing.Point(3, 37);
            this.contentCheckBox.Name = "contentCheckBox";
            this.contentCheckBox.Size = new System.Drawing.Size(138, 28);
            this.contentCheckBox.TabIndex = 35;
            this.contentCheckBox.Text = "消費內容";
            this.contentCheckBox.UseVisualStyleBackColor = true;
            // 
            // typeCheckBox
            // 
            this.typeCheckBox.AutoSize = true;
            this.typeCheckBox.Location = new System.Drawing.Point(3, 3);
            this.typeCheckBox.Name = "typeCheckBox";
            this.typeCheckBox.Size = new System.Drawing.Size(138, 28);
            this.typeCheckBox.TabIndex = 34;
            this.typeCheckBox.Text = "消費類型";
            this.typeCheckBox.UseVisualStyleBackColor = true;
            // 
            // chartTypeComboBox
            // 
            this.chartTypeComboBox.FormattingEnabled = true;
            this.chartTypeComboBox.Location = new System.Drawing.Point(575, 82);
            this.chartTypeComboBox.Name = "chartTypeComboBox";
            this.chartTypeComboBox.Size = new System.Drawing.Size(192, 32);
            this.chartTypeComboBox.TabIndex = 43;
            // 
            // expenceTypeFlowLayoutPanel
            // 
            this.expenceTypeFlowLayoutPanel.Controls.Add(this.typeCheckBox);
            this.expenceTypeFlowLayoutPanel.Controls.Add(this.contentCheckBox);
            this.expenceTypeFlowLayoutPanel.Controls.Add(this.payMethodCheckBox);
            this.expenceTypeFlowLayoutPanel.Controls.Add(this.propertyCheckBox);
            this.expenceTypeFlowLayoutPanel.Location = new System.Drawing.Point(240, 158);
            this.expenceTypeFlowLayoutPanel.Name = "expenceTypeFlowLayoutPanel";
            this.expenceTypeFlowLayoutPanel.Size = new System.Drawing.Size(172, 157);
            this.expenceTypeFlowLayoutPanel.TabIndex = 44;
            // 
            // navBar1
            // 
            this.navBar1.Location = new System.Drawing.Point(219, 910);
            this.navBar1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(530, 139);
            this.navBar1.TabIndex = 2;
            // 
            // Chart
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1116, 1054);
            this.Controls.Add(this.expenceTypeFlowLayoutPanel);
            this.Controls.Add(this.chartTypeComboBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.analyzeBtn);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.navBar1);
            this.Name = "Chart";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Chart";
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.expenceTypeFlowLayoutPanel.ResumeLayout(false);
            this.expenceTypeFlowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private 記帳.NavBar navBar1;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Button analyzeBtn;
        private System.Windows.Forms.CheckBox propertyCheckBox;
        private System.Windows.Forms.CheckBox payMethodCheckBox;
        private System.Windows.Forms.CheckBox contentCheckBox;
        private System.Windows.Forms.CheckBox typeCheckBox;
        private System.Windows.Forms.ComboBox chartTypeComboBox;
        private System.Windows.Forms.FlowLayoutPanel expenceTypeFlowLayoutPanel;
    }
}