using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.ViewModels
{
    /// <summary>
    /// 首页显示
    /// </summary>
    public class SarcasmHomeViewModel
    {
        public string UserName { get; set; }
        public string CreateTime { get; set; }
        public string Content { get; set; }
        public int CommentCount { get; set; }

    }
}
