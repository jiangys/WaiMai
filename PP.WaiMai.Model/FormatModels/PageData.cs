using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.FormatModels
{
    /// <summary>
    /// 分页模型
    /// </summary>
    public class PageData
    {
        /// <summary>
        /// 页码
        /// </summary>
        public int PageIndex { get; set; }

        /// <summary>
        /// 页容量
        /// </summary>
        public int PageSize { get; set; }

        /// <summary>
        /// 总行数（返回）
        /// </summary>
        public int total { get; set; }

        /// <summary>
        /// 页码 对应 的数据集合（返回）
        /// </summary>
        public object rows { get; set; }
    }
}
