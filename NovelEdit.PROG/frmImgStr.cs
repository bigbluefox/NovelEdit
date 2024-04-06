using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelEdit.PROG
{
    public partial class frmImgStr : Form
    {
        public frmImgStr()
        {
            InitializeComponent();
            cbxSaveFileType.SelectedIndex = 0;
        }


        #region 打开文件对话框初始化

        /// <summary>
        /// 打开文件对话框初始化
        /// </summary>
        private readonly OpenFileDialog _opendialog = new OpenFileDialog
        {
            Multiselect = false,
            Title = "打开图片文件",
            CheckFileExists = true,
            CheckPathExists = true,
            Filter = "图片文件(*.jpg;*.png;*.bmp;*.gif)|*.jpg;*.png;*.bmp;*.gif"
        };

        #endregion


        #region 打开文件对话框初始化

        /// <summary>
        /// 打开文件对话框初始化
        /// </summary>
        private readonly SaveFileDialog _savedialog = new SaveFileDialog
        {
            Title = "保存图片文件",
            CheckFileExists = false,
            CheckPathExists = true,
            RestoreDirectory = true,
            Filter = "图片文件(*.jpg;*.png;*.bmp;*.gif)|*.jpg;*.png;*.bmp;*.gif|JPEG文件|*.jpg|PNG文件|*.png|BMP文件|*.bmp|GIF文件|*.gif"
        };

        #endregion




        #region 图片转字符

        /// <summary>
        /// 图片转字符
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {

            DialogResult r = _opendialog.ShowDialog();
            //MessageBox.Show(r.ToString());
            if (r == DialogResult.OK)
            {
                var strFileName = _opendialog.FileName;
                //rtbImgString.AppendText(_opendialog.FileName + "\n");

                var fi = new FileInfo(strFileName);

                lblImgPath.Text += _opendialog.FileName;
                lblFileSize.Text += (fi.Length / 1024).ToString() + "kb";
                lblImgSize.Text += "";
                lblImgType.Text += fi.Extension;

                txtSaveFileName.Text = fi.Name.Split('.')[0];
                cbxSaveFileType.SelectedText = fi.Extension;

                var idx = 0;
                cbxSaveFileType.SelectedIndex = -1;
                for (int i = 0; i < cbxSaveFileType.Items.Count; i++)
                {
                    //MessageBox.Show(cbxSaveFileType.Items[i].ToString());
                    if (String.Equals(cbxSaveFileType.Items[i].ToString(), fi.Extension, StringComparison.CurrentCultureIgnoreCase))
                    {
                        cbxSaveFileType.SelectedIndex = i;
                        //MessageBox.Show(i.ToString());
                    }
                }


                pbImg.SizeMode = PictureBoxSizeMode.Zoom;
                //pbImg.Size = DefaultSize;
                //pbImg.Size = MinimumSize;
                pbImg.ImageLocation = strFileName;

                file = _opendialog.FileName;

                var s = Img2String();
                rtbImgString.Text = s;

                byte[] buf = Convert.FromBase64String(s);//把字符串读到字节数组中
                MemoryStream ms = new MemoryStream(buf);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                lblImgSize.Text += img.Width + "*" + img.Height;// + "*" + img.PhysicalDimension + "*" + img.PixelFormat;

            }
            else
            {
                pbImg.Image = null;
                cbxSaveFileType.SelectedIndex = 0;
            }
        }

        #endregion

        string file = "";

        #region save picture to DB as string

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public string Img2String()
        {
            try
            {
                Stream s = File.Open(file, FileMode.Open, FileAccess.Read);
                int leng = 0;
                if (s.Length < Int32.MaxValue)
                {
                    leng = (int)s.Length;
                }
                byte[] by = new byte[leng];
                s.Read(by, 0, leng);//把图片读到字节数组中
                s.Close();

                string str = Convert.ToBase64String(by);//把字节数组转换成字符串
                //StreamWriter sw = File.CreateText("G:\\11.txt");//存入11.txt文件
                //sw.Write(str);
                //sw.Close();
                //sw.Dispose();

                return str;
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
        #endregion

        #region 字符转图片

        /// <summary>
        /// 字符转图片
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnString2Img_Click(object sender, EventArgs e)
        {
            ShowPictureOfString();
        }

        #endregion

        #region show picture from the string of DB
        /// <summary>
        /// 
        /// </summary>
        public void ShowPictureOfString()
        {
            try
            {
                //StreamReader sr = new StreamReader("G:\\11.txt");
                //string s = sr.ReadToEnd();
                //sr.Close();

                var s = rtbImgString.Text;

                byte[] buf = Convert.FromBase64String(s);//把字符串读到字节数组中
                MemoryStream ms = new MemoryStream(buf);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                pbString2Img.SizeMode = PictureBoxSizeMode.Zoom;

                pbString2Img.Image = img;
                //img.Save("12.jpg", System.Drawing.Imaging.ImageFormat.Jpeg);
                ms.Close();
                ms.Dispose();


            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion


        #region 图片保存

        /// <summary>
        /// 图片保存
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnImgSave_Click(object sender, EventArgs e)
        {
            var strFileName = txtSaveFileName.Text;
            var strExt = cbxSaveFileType.SelectedItem.ToString();

            if (!string.IsNullOrEmpty(strFileName))
            {
                strFileName += strExt.ToLower();
            }
            else
            {
                strFileName += cbxSaveFileType.Items[0].ToString().ToLower();
            }
            _savedialog.FileName = strFileName;

            DialogResult r = _savedialog.ShowDialog();

            //MessageBox.Show(r.ToString());
            if (r == DialogResult.OK)
            {

                //MessageBox.Show(strFileName);
                //return;

                var str = rtbImgString.Text;
                //var sr = new StreamReader(str);
                //string s = sr.ReadToEnd();
                //sr.Close();
                if (string.IsNullOrEmpty(str)) return;
                byte[] buf = Convert.FromBase64String(str); //把字符串读到字节数组中
                MemoryStream ms = new MemoryStream(buf);
                System.Drawing.Image img = System.Drawing.Image.FromStream(ms);

                img.Save(_savedialog.FileName, System.Drawing.Imaging.ImageFormat.Jpeg);

            }

        }

        #endregion









    }
}
