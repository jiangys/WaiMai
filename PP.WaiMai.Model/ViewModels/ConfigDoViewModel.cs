using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.ViewModels
{
    /// <summary>
    /// 订餐是否进行中
    /// </summary>
    public class ConfigDoOrderViewModel
    {
        public string DoTime { get; set; }
        public bool IsDo { get; set; }
    }
    public class ConfigDoModeTypeViewModel
    {
        public DateTime DoTime { get; set; }
        public bool IsDayMode { get; set; }
    }
}
