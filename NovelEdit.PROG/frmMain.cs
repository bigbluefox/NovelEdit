using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using NovelEdit.BLL;

namespace NovelEdit.PROG
{
    /// <summary>
    /// 
    /// </summary>
    public partial class frmMain : Form
    {
        /*         
        1.你需要创建一个windows 应用程序项目
        2.然后你需要为你的项目添加数据库 如果有现成的就添加现有项 直接吧数据库弄进来 没有就新建 不知道你使用的是什么呢？
        * 不同的数据库对应不同的命名空间不同的类，但是用法都一样
        3.就是你的程序处理阶段，如果你要将处理后数据放进excel 那就有点麻烦了 关于c#操作excel 你看看其他教程吧
        4.然后就是再创建一个项目安装程序 把你的程序打包好 这里包括了配置你的程序默认安装路径、写注册表项，进驻系统进程等等设置 然后发布 
        5.出来的成品就是一个安装程序了 正如你看到的其他安装程序一样
        整个程序做出来需要用到的技术无非就是.net构架下的任何一种语言 我习惯用c# 至于工具 就是vs2005 vs2008版本了        
        */

        public frmMain()
        {
            InitializeComponent();

            // 这是取得当前的屏幕除任务栏外的工作域大小
            var ww = SystemInformation.WorkingArea.Width;
            var wh = SystemInformation.WorkingArea.Height;

                //这是取得当前的屏幕包括任务栏的工作域大小
            var sw = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
            var sh = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

            //this.WindowsState = MaximumSize;
        }

        #region 保存文件

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {

            using (
                var conn =
                    new SqlConnection(
                        "Data Source=.;Initial Catalog=SINOCAL;Persist Security Info=True;User ID=sa;Password=sa"))
            {
                var strSql = "select * from [dbo].[ReplaceTb]";

                SqlCommand cmd = new SqlCommand(strSql, conn);
                SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
                DataSet ds = new DataSet();
                da.Fill(ds);

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        DataRow dr = ds.Tables[0].Rows[i];
                        rtbContent.AppendText(i + "-" + dr["Code"] + "-" + dr["Value"] + "\n");
                    }
                }
            }

            var bll = new ReplaceTbBll();
            var list = bll.GetReplaceTbList();
            foreach (var m in list)
            {
                rtbContent.AppendText(m.Code + "\n");
            }
        }

        #endregion


        #region 打开文件对话框初始化

        /// <summary>
        /// 打开文件对话框初始化
        /// </summary>
        private readonly OpenFileDialog _dialog = new OpenFileDialog
        {
            Multiselect = false,
            Filter = "Text文件(*.txt;*.bat;*.webconfig;*.cs;*.aspx)|*.txt;*.bat;*.webconfig;*.cs;*.aspx"
        };

        #endregion


        #region 打开文件

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {

            DialogResult r = _dialog.ShowDialog();
            //MessageBox.Show(r.ToString());
            if (r.ToString() == "OK")
            {
                //FileInfo file = _dialog.
                //MessageBox.Show(_dialog.ValidateNames.ToString());
                rtbContent.AppendText(_dialog.FileName + "\n");
                //rtbContent.AppendText(_dialog.SafeFileName + "\n");
                //rtbContent.AppendText(_dialog.Filter + "\n");
                //rtbContent.AppendText(_dialog.CheckFileExists.ToString() + "\n");
                //rtbContent.AppendText(_dialog.CheckPathExists.ToString() + "\n");
                //rtbContent.AppendText(_dialog.ValidateNames.ToString() + "\n");

                //rtbContent.AppendText(Encoding.Default.EncodingName + "\n");

                var strFileWithPath = _dialog.FileName;
                StreamReader sr = null;
                var i = 0;
                try
                {
                    sr = new StreamReader(strFileWithPath, Encoding.Default);
                    var strLine = sr.ReadLine();
                    while (strLine != null)
                    {
                        //rtbContent.AppendText(i + "-" + strLine + "\n");
                        rtbContent.AppendText(strLine + "\n");
                        strLine = sr.ReadLine();
                        i += 1;
                    }
                }
                catch (Exception ex)
                {
                    rtbContent.AppendText(ex.Message + "\n");
                }
                finally
                {
                    if (sr != null) sr.Close();
                }


            }

        }

        #endregion

        private void btnImgTest_Click(object sender, EventArgs e)
        {
            frmImgStr frm = new frmImgStr();
            frm.Show();
        }

    }
}
