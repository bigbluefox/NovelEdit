using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEdit.MODEL
{
    /// <summary>
    /// 
    /// </summary>
    public class ReplaceTbModel
    {
        /// <summary>
        /// Id
        /// </summary>

        public int Id { get; set; }

        /// <summary>
        /// 文本
        /// </summary>

        public string Code { get; set; }

        /// <summary>
        /// 替换文本
        /// </summary>

        public string Value { get; set; }

        /// <summary>
        /// 序数段
        /// </summary>

        public int OrdKey { get; set; }

        /// <summary>
        /// 序号（Id + OrdKey）
        /// </summary>

        public int Ord { get; set; }

        /// <summary>
        /// 删除标志（0-正常；1-已经删除；）
        /// </summary>

        public int IsDel { get; set; }

        /// <summary>
        /// 记录行号
        /// </summary>

        public int RowNumber { get; set; }

        /// <summary>
        /// 记录总数
        /// </summary>

        public int RecordCount { get; set; }
    }
}
