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
        [Description("资金部")]
        资金部 = 1,
        [Description("技术部")]
        技术部 = 2,
        [Description("风控部")]
        风控部 = 3,
        [Description("其它")]
        其它 = 99
    }
}
