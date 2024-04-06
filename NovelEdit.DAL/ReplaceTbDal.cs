using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEdit.DAL
{
    /// <summary>
    /// 
    /// </summary>
    public class ReplaceTbDal
    {
        #region 数据库连接串

        /// <summary>
        /// 数据库连接串
        /// </summary>
        protected string SqlConnectionString = ConfigurationSettings.AppSettings["ConnectionString"];

        #endregion

        #region 获取替换文本数据集

        /// <summary>
        /// 获取替换文本数据集
        /// </summary>
        /// <returns></returns>
        public DataSet GetReplaceTbData()
        {
            using (var conn = new SqlConnection(SqlConnectionString))
            {
                var strSql = "select * from [dbo].[ReplaceTb]";
                //var cmd = new SqlCommand(strSql, conn);
                var da = new SqlDataAdapter(strSql, conn);
                var ds = new DataSet();
                da.Fill(ds);
                return ds;
                //if (ds.Tables[0].Rows.Count > 0)
                //{
                //    return ds;
                //}
            }

        }

        #endregion



    }
}
