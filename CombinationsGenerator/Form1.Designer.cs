
namespace CombinationsGenerator
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.Results = new System.Windows.Forms.TextBox();
            this.ChooseCsvFile = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Results
            // 
            this.Results.Location = new System.Drawing.Point(12, 38);
            this.Results.Multiline = true;
            this.Results.Name = "Results";
            this.Results.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.Results.Size = new System.Drawing.Size(775, 400);
            this.Results.TabIndex = 4;
            // 
            // ChooseCsvFile
            // 
            this.ChooseCsvFile.Location = new System.Drawing.Point(12, 12);
            this.ChooseCsvFile.Name = "ChooseCsvFile";
            this.ChooseCsvFile.Size = new System.Drawing.Size(170, 20);
            this.ChooseCsvFile.TabIndex = 5;
            this.ChooseCsvFile.Text = "Choose csv file...";
            this.ChooseCsvFile.UseVisualStyleBackColor = true;
            this.ChooseCsvFile.Click += new System.EventHandler(this.ChooseCsvFile_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ChooseCsvFile);
            this.Controls.Add(this.Results);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "CombinationGenerator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox Results;
        private System.Windows.Forms.Button ChooseCsvFile;
    }
}

