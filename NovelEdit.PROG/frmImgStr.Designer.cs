namespace NovelEdit.PROG
{
    partial class frmImgStr
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
            this.rtbImgString = new System.Windows.Forms.RichTextBox();
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.btnString2Img = new System.Windows.Forms.Button();
            this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.pbImg = new System.Windows.Forms.PictureBox();
            this.pbString2Img = new System.Windows.Forms.PictureBox();
            this.lblImgPath = new System.Windows.Forms.Label();
            this.btnImgSave = new System.Windows.Forms.Button();
            this.lblImgType = new System.Windows.Forms.Label();
            this.lblFileSize = new System.Windows.Forms.Label();
            this.lblImgSize = new System.Windows.Forms.Label();
            this.lblSaveFileName = new System.Windows.Forms.Label();
            this.lblSaveFileType = new System.Windows.Forms.Label();
            this.txtSaveFileName = new System.Windows.Forms.TextBox();
            this.cbxSaveFileType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbString2Img)).BeginInit();
            this.SuspendLayout();
            // 
            // rtbImgString
            // 
            this.rtbImgString.Location = new System.Drawing.Point(363, 82);
            this.rtbImgString.Name = "rtbImgString";
            this.rtbImgString.Size = new System.Drawing.Size(474, 378);
            this.rtbImgString.TabIndex = 0;
            this.rtbImgString.Text = "";
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(590, 29);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 1;
            this.btnOpenFile.Text = "打开图片";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // btnString2Img
            // 
            this.btnString2Img.Location = new System.Drawing.Point(674, 29);
            this.btnString2Img.Name = "btnString2Img";
            this.btnString2Img.Size = new System.Drawing.Size(75, 23);
            this.btnString2Img.TabIndex = 2;
            this.btnString2Img.Text = "字符转图片";
            this.btnString2Img.UseVisualStyleBackColor = true;
            this.btnString2Img.Click += new System.EventHandler(this.btnString2Img_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // pbImg
            // 
            this.pbImg.Location = new System.Drawing.Point(18, 301);
            this.pbImg.Name = "pbImg";
            this.pbImg.Size = new System.Drawing.Size(142, 159);
            this.pbImg.TabIndex = 3;
            this.pbImg.TabStop = false;
            // 
            // pbString2Img
            // 
            this.pbString2Img.Location = new System.Drawing.Point(195, 301);
            this.pbString2Img.Name = "pbString2Img";
            this.pbString2Img.Size = new System.Drawing.Size(142, 159);
            this.pbString2Img.TabIndex = 3;
            this.pbString2Img.TabStop = false;
            // 
            // lblImgPath
            // 
            this.lblImgPath.AutoSize = true;
            this.lblImgPath.Location = new System.Drawing.Point(22, 28);
            this.lblImgPath.Name = "lblImgPath";
            this.lblImgPath.Size = new System.Drawing.Size(65, 12);
            this.lblImgPath.TabIndex = 4;
            this.lblImgPath.Text = "图片名称：";
            // 
            // btnImgSave
            // 
            this.btnImgSave.Location = new System.Drawing.Point(758, 29);
            this.btnImgSave.Name = "btnImgSave";
            this.btnImgSave.Size = new System.Drawing.Size(75, 23);
            this.btnImgSave.TabIndex = 5;
            this.btnImgSave.Text = "图片保存";
            this.btnImgSave.UseVisualStyleBackColor = true;
            this.btnImgSave.Click += new System.EventHandler(this.btnImgSave_Click);
            // 
            // lblImgType
            // 
            this.lblImgType.AutoSize = true;
            this.lblImgType.Location = new System.Drawing.Point(22, 53);
            this.lblImgType.Name = "lblImgType";
            this.lblImgType.Size = new System.Drawing.Size(65, 12);
            this.lblImgType.TabIndex = 4;
            this.lblImgType.Text = "文件类型：";
            // 
            // lblFileSize
            // 
            this.lblFileSize.AutoSize = true;
            this.lblFileSize.Location = new System.Drawing.Point(22, 78);
            this.lblFileSize.Name = "lblFileSize";
            this.lblFileSize.Size = new System.Drawing.Size(65, 12);
            this.lblFileSize.TabIndex = 4;
            this.lblFileSize.Text = "文件大小：";
            // 
            // lblImgSize
            // 
            this.lblImgSize.AutoSize = true;
            this.lblImgSize.Location = new System.Drawing.Point(22, 103);
            this.lblImgSize.Name = "lblImgSize";
            this.lblImgSize.Size = new System.Drawing.Size(65, 12);
            this.lblImgSize.TabIndex = 4;
            this.lblImgSize.Text = "图片尺寸：";
            // 
            // lblSaveFileName
            // 
            this.lblSaveFileName.AutoSize = true;
            this.lblSaveFileName.Location = new System.Drawing.Point(22, 174);
            this.lblSaveFileName.Name = "lblSaveFileName";
            this.lblSaveFileName.Size = new System.Drawing.Size(65, 12);
            this.lblSaveFileName.TabIndex = 6;
            this.lblSaveFileName.Text = "文件名称：";
            // 
            // lblSaveFileType
            // 
            this.lblSaveFileType.AutoSize = true;
            this.lblSaveFileType.Location = new System.Drawing.Point(22, 207);
            this.lblSaveFileType.Name = "lblSaveFileType";
            this.lblSaveFileType.Size = new System.Drawing.Size(65, 12);
            this.lblSaveFileType.TabIndex = 7;
            this.lblSaveFileType.Text = "文件类型：";
            // 
            // txtSaveFileName
            // 
            this.txtSaveFileName.Location = new System.Drawing.Point(94, 170);
            this.txtSaveFileName.Name = "txtSaveFileName";
            this.txtSaveFileName.Size = new System.Drawing.Size(243, 21);
            this.txtSaveFileName.TabIndex = 8;
            // 
            // cbxSaveFileType
            // 
            this.cbxSaveFileType.FormattingEnabled = true;
            this.cbxSaveFileType.Items.AddRange(new object[] {
            ".Jpg",
            ".Png",
            ".Bmp",
            ".Gif"});
            this.cbxSaveFileType.Location = new System.Drawing.Point(94, 203);
            this.cbxSaveFileType.Name = "cbxSaveFileType";
            this.cbxSaveFileType.Size = new System.Drawing.Size(243, 20);
            this.cbxSaveFileType.TabIndex = 9;
            // 
            // frmImgStr
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(856, 477);
            this.Controls.Add(this.cbxSaveFileType);
            this.Controls.Add(this.txtSaveFileName);
            this.Controls.Add(this.lblSaveFileType);
            this.Controls.Add(this.lblSaveFileName);
            this.Controls.Add(this.btnImgSave);
            this.Controls.Add(this.lblImgSize);
            this.Controls.Add(this.lblFileSize);
            this.Controls.Add(this.lblImgType);
            this.Controls.Add(this.lblImgPath);
            this.Controls.Add(this.pbString2Img);
            this.Controls.Add(this.pbImg);
            this.Controls.Add(this.btnString2Img);
            this.Controls.Add(this.btnOpenFile);
            this.Controls.Add(this.rtbImgString);
            this.Name = "frmImgStr";
            this.Text = "图片和字符串相互转换 ";
            ((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbString2Img)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbImgString;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.Button btnString2Img;
        private System.Windows.Forms.SaveFileDialog saveFileDialog1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.PictureBox pbImg;
        private System.Windows.Forms.PictureBox pbString2Img;
        private System.Windows.Forms.Label lblImgPath;
        private System.Windows.Forms.Button btnImgSave;
        private System.Windows.Forms.Label lblImgType;
        private System.Windows.Forms.Label lblFileSize;
        private System.Windows.Forms.Label lblImgSize;
        private System.Windows.Forms.Label lblSaveFileName;
        private System.Windows.Forms.Label lblSaveFileType;
        private System.Windows.Forms.TextBox txtSaveFileName;
        private System.Windows.Forms.ComboBox cbxSaveFileType;
    }
}