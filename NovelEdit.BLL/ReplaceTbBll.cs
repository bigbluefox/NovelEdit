using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NovelEdit.MODEL;
using NovelEdit.DAL;
using NovelEdit.COMMON;


namespace NovelEdit.BLL
{
    /// <summary>
    /// 
    /// </summary>
    public class ReplaceTbBll
    {

        #region 获取替换文本数据列表

        /// <summary>
        /// 获取替换文本数据列表
        /// </summary>
        /// <returns></returns>
        public List<ReplaceTbModel> GetReplaceTbList()
        {
            var list = new List<ReplaceTbModel>();
            var dal = new ReplaceTbDal();
            DataSet ds = dal.GetReplaceTbData();
            if (ds.Tables.Count == 0) return list;
            return ds.Tables[0].Rows.Count == 0 ? list : new DataTableToList<ReplaceTbModel>(ds.Tables[0]).ToList();
        }

        #endregion

    }
}
