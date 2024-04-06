using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NovelEdit.COMMON
{
    /// <summary>
    /// 表转换为List
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class DataTableToList<T>
    {
        private readonly DataTable _dt;

        /// <summary>
        ///  构造函数
        /// </summary>
        /// <param name="dt">要转换的datatable</param>
        public DataTableToList(DataTable dt)
        {
            _dt = dt;
        }

        /// <summary>
        /// 将DataTable转成List实体类
        /// 设置实体类中属性为public和可写的属性
        /// </summary>
        /// <returns></returns>
        public List<T> ToList()
        {
            var list = new List<T>();
            if (_dt == null || _dt.Rows.Count == 0)
            {
                return list;
            }
            Type objType = typeof (T);
            foreach (DataRow dr in _dt.Rows)
            {
                try
                {
                    object obj = System.Activator.CreateInstance(objType); //创建实例
                    foreach (System.Reflection.PropertyInfo pi in objType.GetProperties()) //遍历T类的所有属性
                    {
                        try
                        {
                            if (!pi.PropertyType.IsPublic || !pi.CanWrite || !_dt.Columns.Contains(pi.Name)) continue;
                            Type pType = Type.GetType(pi.PropertyType.FullName); //属性类型
                            var value = dr[pi.Name].ToString();
                            if (pType != null)
                                objType.GetProperty(pi.Name).SetValue(obj, Convert.ChangeType(value, pType), null); //赋值
                        }
                        catch (Exception ex)
                        {
                            //Utility.WriteLog("DataTableToList", ex.Message); 
                        }
                    }
                    list.Add((T) obj);
                }
                catch (Exception ex)
                {
                    //Utility.WriteLog("DataTableToList", ex.Message); 
                }
            }
            return list;
        }
    }
}