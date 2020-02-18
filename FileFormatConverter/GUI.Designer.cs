namespace FileFormatConfigurator
{
    partial class GUI
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
            this.label4 = new System.Windows.Forms.Label();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.btnDataFormatGenerate = new System.Windows.Forms.Button();
            this.btnExportBrowser = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImportBrowser = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tbImportPath = new System.Windows.Forms.TextBox();
            this.tbExportPath = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbExcel = new System.Windows.Forms.CheckBox();
            this.cbSql = new System.Windows.Forms.CheckBox();
            this.cbJson = new System.Windows.Forms.CheckBox();
            this.cbCsv = new System.Windows.Forms.CheckBox();
            this.cbXml = new System.Windows.Forms.CheckBox();
            this.tabController = new System.Windows.Forms.TabControl();
            this.StatusTextBox = new System.Windows.Forms.RichTextBox();
            this.tabPage1.SuspendLayout();
            this.tabController.SuspendLayout();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(13, 168);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(36, 16);
            this.label4.TabIndex = 12;
            this.label4.Text = "Status";
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.btnDataFormatGenerate);
            this.tabPage1.Controls.Add(this.btnExportBrowser);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.btnImportBrowser);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.tbImportPath);
            this.tabPage1.Controls.Add(this.tbExportPath);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.cbExcel);
            this.tabPage1.Controls.Add(this.cbSql);
            this.tabPage1.Controls.Add(this.cbJson);
            this.tabPage1.Controls.Add(this.cbCsv);
            this.tabPage1.Controls.Add(this.cbXml);
            this.tabPage1.Location = new System.Drawing.Point(4, 25);
            this.tabPage1.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabPage1.Size = new System.Drawing.Size(901, 113);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Data Format";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // btnDataFormatGenerate
            // 
            this.btnDataFormatGenerate.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDataFormatGenerate.Location = new System.Drawing.Point(6, 13);
            this.btnDataFormatGenerate.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnDataFormatGenerate.Name = "btnDataFormatGenerate";
            this.btnDataFormatGenerate.Size = new System.Drawing.Size(94, 93);
            this.btnDataFormatGenerate.TabIndex = 4;
            this.btnDataFormatGenerate.Text = "Generate";
            this.btnDataFormatGenerate.UseVisualStyleBackColor = true;
            this.btnDataFormatGenerate.Click += new System.EventHandler(this.btnDataFormatGenerate_Click);
            // 
            // btnExportBrowser
            // 
            this.btnExportBrowser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExportBrowser.Location = new System.Drawing.Point(853, 51);
            this.btnExportBrowser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnExportBrowser.Name = "btnExportBrowser";
            this.btnExportBrowser.Size = new System.Drawing.Size(32, 22);
            this.btnExportBrowser.TabIndex = 14;
            this.btnExportBrowser.Text = "...";
            this.btnExportBrowser.UseVisualStyleBackColor = true;
            this.btnExportBrowser.Click += new System.EventHandler(this.btnExportBrowser_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(104, 15);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(127, 16);
            this.label1.TabIndex = 0;
            this.label1.Text = "lmport File or Folder Path";
            // 
            // btnImportBrowser
            // 
            this.btnImportBrowser.Font = new System.Drawing.Font("Arial", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImportBrowser.Location = new System.Drawing.Point(853, 14);
            this.btnImportBrowser.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.btnImportBrowser.Name = "btnImportBrowser";
            this.btnImportBrowser.Size = new System.Drawing.Size(32, 22);
            this.btnImportBrowser.TabIndex = 13;
            this.btnImportBrowser.Text = "...";
            this.btnImportBrowser.UseVisualStyleBackColor = true;
            this.btnImportBrowser.Click += new System.EventHandler(this.btnImportBrowser_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(133, 54);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(97, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Export Folder Path";
            // 
            // tbImportPath
            // 
            this.tbImportPath.Location = new System.Drawing.Point(236, 14);
            this.tbImportPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbImportPath.Name = "tbImportPath";
            this.tbImportPath.Size = new System.Drawing.Size(613, 22);
            this.tbImportPath.TabIndex = 2;
            this.tbImportPath.Text = "C:\\Users\\asdfk\\source\\repos\\FileFormatConverter\\TestFile";
            // 
            // tbExportPath
            // 
            this.tbExportPath.Location = new System.Drawing.Point(236, 51);
            this.tbExportPath.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tbExportPath.Name = "tbExportPath";
            this.tbExportPath.Size = new System.Drawing.Size(613, 22);
            this.tbExportPath.TabIndex = 3;
            this.tbExportPath.Text = "C:\\Users\\asdfk\\source\\repos\\FileFormatConverter\\Output";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(156, 86);
            this.label3.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(74, 16);
            this.label3.TabIndex = 10;
            this.label3.Text = "Output Format";
            // 
            // cbExcel
            // 
            this.cbExcel.AutoSize = true;
            this.cbExcel.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbExcel.Location = new System.Drawing.Point(236, 85);
            this.cbExcel.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbExcel.Name = "cbExcel";
            this.cbExcel.Size = new System.Drawing.Size(61, 20);
            this.cbExcel.TabIndex = 5;
            this.cbExcel.Text = "Excel";
            this.cbExcel.UseVisualStyleBackColor = true;
            // 
            // cbSql
            // 
            this.cbSql.AutoSize = true;
            this.cbSql.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbSql.Location = new System.Drawing.Point(488, 84);
            this.cbSql.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbSql.Name = "cbSql";
            this.cbSql.Size = new System.Drawing.Size(51, 20);
            this.cbSql.TabIndex = 9;
            this.cbSql.Text = "SQL";
            this.cbSql.UseVisualStyleBackColor = true;
            // 
            // cbJson
            // 
            this.cbJson.AutoSize = true;
            this.cbJson.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbJson.Location = new System.Drawing.Point(302, 85);
            this.cbJson.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbJson.Name = "cbJson";
            this.cbJson.Size = new System.Drawing.Size(60, 20);
            this.cbJson.TabIndex = 6;
            this.cbJson.Text = "JSON";
            this.cbJson.UseVisualStyleBackColor = true;
            // 
            // cbCsv
            // 
            this.cbCsv.AutoSize = true;
            this.cbCsv.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbCsv.Location = new System.Drawing.Point(431, 84);
            this.cbCsv.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbCsv.Name = "cbCsv";
            this.cbCsv.Size = new System.Drawing.Size(52, 20);
            this.cbCsv.TabIndex = 8;
            this.cbCsv.Text = "CSV";
            this.cbCsv.UseVisualStyleBackColor = true;
            // 
            // cbXml
            // 
            this.cbXml.AutoSize = true;
            this.cbXml.Font = new System.Drawing.Font("Georgia", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbXml.Location = new System.Drawing.Point(368, 84);
            this.cbXml.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.cbXml.Name = "cbXml";
            this.cbXml.Size = new System.Drawing.Size(56, 20);
            this.cbXml.TabIndex = 7;
            this.cbXml.Text = "XML";
            this.cbXml.UseVisualStyleBackColor = true;
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.tabPage1);
            this.tabController.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.tabController.Location = new System.Drawing.Point(12, 12);
            this.tabController.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(909, 142);
            this.tabController.TabIndex = 15;
            // 
            // StatusTextBox
            // 
            this.StatusTextBox.Font = new System.Drawing.Font("Consolas", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.StatusTextBox.Location = new System.Drawing.Point(16, 187);
            this.StatusTextBox.Name = "StatusTextBox";
            this.StatusTextBox.Size = new System.Drawing.Size(908, 462);
            this.StatusTextBox.TabIndex = 16;
            this.StatusTextBox.Text = "";
            // 
            // GUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(932, 661);
            this.Controls.Add(this.StatusTextBox);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.label4);
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "GUI";
            this.Text = "File Format Converter";
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabController.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.Button btnDataFormatGenerate;
        private System.Windows.Forms.Button btnExportBrowser;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnImportBrowser;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox tbImportPath;
        private System.Windows.Forms.TextBox tbExportPath;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.CheckBox cbExcel;
        private System.Windows.Forms.CheckBox cbSql;
        private System.Windows.Forms.CheckBox cbJson;
        private System.Windows.Forms.CheckBox cbCsv;
        private System.Windows.Forms.CheckBox cbXml;
        private System.Windows.Forms.TabControl tabController;
        private System.Windows.Forms.RichTextBox StatusTextBox;
    }
}

