namespace 記帳
{
    partial class Account
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
            this.groupByResultTextBox = new System.Windows.Forms.TextBox();
            this.typeCheckBox = new System.Windows.Forms.CheckBox();
            this.contentCheckBox = new System.Windows.Forms.CheckBox();
            this.payMethodCheckBox = new System.Windows.Forms.CheckBox();
            this.propertyCheckBox = new System.Windows.Forms.CheckBox();
            this.groupByBtn = new System.Windows.Forms.Button();
            this.navBar1 = new 記帳.NavBar();
            this.startDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.endDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.SuspendLayout();
            // 
            // groupByResultTextBox
            // 
            this.groupByResultTextBox.Location = new System.Drawing.Point(90, 432);
            this.groupByResultTextBox.Multiline = true;
            this.groupByResultTextBox.Name = "groupByResultTextBox";
            this.groupByResultTextBox.Size = new System.Drawing.Size(600, 158);
            this.groupByResultTextBox.TabIndex = 7;
            // 
            // typeCheckBox
            // 
            this.typeCheckBox.AutoSize = true;
            this.typeCheckBox.Location = new System.Drawing.Point(90, 251);
            this.typeCheckBox.Name = "typeCheckBox";
            this.typeCheckBox.Size = new System.Drawing.Size(138, 28);
            this.typeCheckBox.TabIndex = 24;
            this.typeCheckBox.Text = "消費類型";
            this.typeCheckBox.UseVisualStyleBackColor = true;
            // 
            // contentCheckBox
            // 
            this.contentCheckBox.AutoSize = true;
            this.contentCheckBox.Location = new System.Drawing.Point(90, 292);
            this.contentCheckBox.Name = "contentCheckBox";
            this.contentCheckBox.Size = new System.Drawing.Size(138, 28);
            this.contentCheckBox.TabIndex = 25;
            this.contentCheckBox.Text = "消費內容";
            this.contentCheckBox.UseVisualStyleBackColor = true;
            // 
            // payMethodCheckBox
            // 
            this.payMethodCheckBox.AutoSize = true;
            this.payMethodCheckBox.Location = new System.Drawing.Point(90, 332);
            this.payMethodCheckBox.Name = "payMethodCheckBox";
            this.payMethodCheckBox.Size = new System.Drawing.Size(138, 28);
            this.payMethodCheckBox.TabIndex = 26;
            this.payMethodCheckBox.Text = "付款方式";
            this.payMethodCheckBox.UseVisualStyleBackColor = true;
            // 
            // propertyCheckBox
            // 
            this.propertyCheckBox.AutoSize = true;
            this.propertyCheckBox.Location = new System.Drawing.Point(90, 371);
            this.propertyCheckBox.Name = "propertyCheckBox";
            this.propertyCheckBox.Size = new System.Drawing.Size(138, 28);
            this.propertyCheckBox.TabIndex = 27;
            this.propertyCheckBox.Text = "消費屬性";
            this.propertyCheckBox.UseVisualStyleBackColor = true;
            // 
            // groupByBtn
            // 
            this.groupByBtn.Location = new System.Drawing.Point(583, 58);
            this.groupByBtn.Name = "groupByBtn";
            this.groupByBtn.Size = new System.Drawing.Size(107, 35);
            this.groupByBtn.TabIndex = 28;
            this.groupByBtn.Text = "Group By";
            this.groupByBtn.UseVisualStyleBackColor = true;
            this.groupByBtn.Click += new System.EventHandler(this.GroupBy_Clicked);
            // 
            // navBar1
            // 
            this.navBar1.Location = new System.Drawing.Point(134, 656);
            this.navBar1.Name = "navBar1";
            this.navBar1.Size = new System.Drawing.Size(530, 139);
            this.navBar1.TabIndex = 2;
            // 
            // startDateTimePicker
            // 
            this.startDateTimePicker.Location = new System.Drawing.Point(210, 61);
            this.startDateTimePicker.Name = "startDateTimePicker";
            this.startDateTimePicker.Size = new System.Drawing.Size(200, 36);
            this.startDateTimePicker.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(86, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 24);
            this.label1.TabIndex = 30;
            this.label1.Text = "開始日期";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(86, 111);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(106, 24);
            this.label2.TabIndex = 32;
            this.label2.Text = "結束日期";
            // 
            // endDateTimePicker
            // 
            this.endDateTimePicker.Location = new System.Drawing.Point(210, 103);
            this.endDateTimePicker.Name = "endDateTimePicker";
            this.endDateTimePicker.Size = new System.Drawing.Size(200, 36);
            this.endDateTimePicker.TabIndex = 31;
            // 
            // Account
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 851);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.endDateTimePicker);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.startDateTimePicker);
            this.Controls.Add(this.groupByBtn);
            this.Controls.Add(this.propertyCheckBox);
            this.Controls.Add(this.payMethodCheckBox);
            this.Controls.Add(this.contentCheckBox);
            this.Controls.Add(this.typeCheckBox);
            this.Controls.Add(this.groupByResultTextBox);
            this.Controls.Add(this.navBar1);
            this.Name = "Account";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Account";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private NavBar navBar1;
        private System.Windows.Forms.TextBox groupByResultTextBox;
        private System.Windows.Forms.CheckBox typeCheckBox;
        private System.Windows.Forms.CheckBox contentCheckBox;
        private System.Windows.Forms.CheckBox payMethodCheckBox;
        private System.Windows.Forms.CheckBox propertyCheckBox;
        private System.Windows.Forms.Button groupByBtn;
        private System.Windows.Forms.DateTimePicker startDateTimePicker;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker endDateTimePicker;
    }
}