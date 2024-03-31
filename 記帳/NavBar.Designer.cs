namespace 記帳
{
    partial class NavBar
    {
        /// <summary> 
        /// 設計工具所需的變數。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清除任何使用中的資源。
        /// </summary>
        /// <param name="disposing">如果應該處置受控資源則為 true，否則為 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 元件設計工具產生的程式碼

        /// <summary> 
        /// 此為設計工具支援所需的方法 - 請勿使用程式碼編輯器修改
        /// 這個方法的內容。
        /// </summary>
        private void InitializeComponent()
        {
            this.NotebookButton = new System.Windows.Forms.Button();
            this.AccountButton = new System.Windows.Forms.Button();
            this.AddButton = new System.Windows.Forms.Button();
            this.ChartButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // NotebookButton
            // 
            this.NotebookButton.Location = new System.Drawing.Point(3, 3);
            this.NotebookButton.Name = "NotebookButton";
            this.NotebookButton.Size = new System.Drawing.Size(130, 122);
            this.NotebookButton.TabIndex = 0;
            this.NotebookButton.Text = "記事本";
            this.NotebookButton.UseVisualStyleBackColor = true;
            this.NotebookButton.Click += new System.EventHandler(this.NavBarButton_Click);
            // 
            // AccountButton
            // 
            this.AccountButton.Location = new System.Drawing.Point(139, 3);
            this.AccountButton.Name = "AccountButton";
            this.AccountButton.Size = new System.Drawing.Size(135, 119);
            this.AccountButton.TabIndex = 1;
            this.AccountButton.Text = "帳戶";
            this.AccountButton.UseVisualStyleBackColor = true;
            this.AccountButton.Click += new System.EventHandler(this.NavBarButton_Click);
            // 
            // AddButton
            // 
            this.AddButton.Location = new System.Drawing.Point(280, 3);
            this.AddButton.Name = "AddButton";
            this.AddButton.Size = new System.Drawing.Size(120, 119);
            this.AddButton.TabIndex = 2;
            this.AddButton.Text = "記一筆";
            this.AddButton.UseVisualStyleBackColor = true;
            this.AddButton.Click += new System.EventHandler(this.NavBarButton_Click);
            // 
            // ChartButton
            // 
            this.ChartButton.Location = new System.Drawing.Point(406, 3);
            this.ChartButton.Name = "ChartButton";
            this.ChartButton.Size = new System.Drawing.Size(119, 119);
            this.ChartButton.TabIndex = 3;
            this.ChartButton.Text = "圖表分析";
            this.ChartButton.UseVisualStyleBackColor = true;
            this.ChartButton.Click += new System.EventHandler(this.NavBarButton_Click);
            // 
            // NavBar
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ChartButton);
            this.Controls.Add(this.AddButton);
            this.Controls.Add(this.AccountButton);
            this.Controls.Add(this.NotebookButton);
            this.Name = "NavBar";
            this.Size = new System.Drawing.Size(540, 125);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button NotebookButton;
        private System.Windows.Forms.Button AccountButton;
        private System.Windows.Forms.Button AddButton;
        private System.Windows.Forms.Button ChartButton;
    }
}
