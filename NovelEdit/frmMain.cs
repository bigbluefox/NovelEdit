using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//using NovelEdit.MODEL;
//using NovelEdit.BLL;
//using NovelEdit.COMMON;

namespace NovelEdit.COM
{
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

        #region frmMain

        /// <summary>
        /// frmMain
        /// </summary>
        public frmMain()
        {
            InitializeComponent();
        }

        #endregion


        #region 保存文件

        /// <summary>
        /// 保存文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnSave_Click(object sender, EventArgs e)
        {
            using (var conn = new SqlConnection("Data Source=.;Initial Catalog=SINOCAL;Persist Security Info=True;User ID=sa;Password=sa"))
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


            //var bll = new ReplaceTbBll();
            //var list = bll.GetReplaceTbList();
            //foreach (var m in list)
            //{
            //    rtbContent.AppendText(m.Code + "\n");
            //}

        }

        #endregion


        private readonly OpenFileDialog _dialog = new OpenFileDialog
        {
            Multiselect = false,
            Filter = "Text文件(*.txt;*.bat;*.webconfig;*.cs;*.aspx)|*.txt;*.bat;*.webconfig;*.cs;*.aspx"
        };


        #region 打开文件

        /// <summary>
        /// 打开文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOpenFile_Click(object sender, EventArgs e)
        {

           //using( var conn = new SqlConnection("Data Source=.;Initial Catalog=SINOCAL;Persist Security Info=True;User ID=sa;Password=sa"))
           //{
           //    var strSql = "select * from [dbo].[ReplaceTb]";

           //    SqlCommand cmd = new SqlCommand(strSql, conn);
           //    SqlDataAdapter da = new SqlDataAdapter(strSql, conn);
           //    DataSet ds = new DataSet();
           //    da.Fill(ds);
           //}


            //MessageBox.Show(((Button)sender).Name + @" was Clicked.");

            //var strDbConnectionString = "";
            //strDbConnectionString = System.Configuration.ConfigurationManager.AppSettings["FilePageUploadServiceAddress"];


            //string connectionString = System.Configuration.SpecialSetting.ConnectionString["connectionString"]
                //.ConfigurationManager.ConnectionStrings[connectionName].ConnectionString.ToString();

            //rtbContent.AppendText(connectionString + "\n");

            

            foreach (string key in ConfigurationSettings.AppSettings)
            {
                rtbContent.AppendText(key + ":" + ConfigurationSettings.AppSettings[key] + "\n");

            }

            var p = System.Configuration.ConfigurationSettings.AppSettings["ConnectionString"];
            rtbContent.AppendText(p + "\n");
            //var s = System.Configuration.ConfigurationManager.AppSettings[""];

            DialogResult r = _dialog.ShowDialog();
            //MessageBox.Show(r.ToString());
            if (r.ToString() == "OK")
            {
                //FileInfo file = _dialog.
                //MessageBox.Show(_dialog.ValidateNames.ToString());
                rtbContent.AppendText(_dialog.FileName +"\n");
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



    }
}
