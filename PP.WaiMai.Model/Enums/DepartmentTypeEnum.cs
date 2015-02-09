using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.Enums
{
    public enum DepartmentTypeEnum
    {

        [Description("客服部")]
        客服部 = 1,
        [Description("推广中心")]
        推广中心 = 2,
        [Description("运营中心")]
        运营中心 = 3,
        [Description("行政中心")]
        行政中心 = 4,
        [Description("品牌中心")]
        品牌中心 = 5,
        [Description("移动事业部")]
        移动事业部 = 6,
        [Description("技术中心")]
        技术中心 = 7,
        [Description("配资部")]
        配资部 = 8,
        [Description("总裁办")]
        总裁办 = 9,
        [Description("其它")]
        其它 = 99
    }
}
