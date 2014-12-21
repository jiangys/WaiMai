using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.ViewModels
{
    /// <summary>
    /// 我的消费
    /// </summary>
    public class ExpendViewModel
    {
        //日期
        public DateTime CreateDate { get; set; }
        /// <summary>
        /// 消费金额
        /// </summary>
        public decimal ConsumeAmount { get; set; }
        /// <summary>
        /// 充值金额
        /// </summary>
        public decimal RechargeAmount { get; set; }
        /// <summary>
        /// 详细说明
        /// </summary>
        public string Description { get; set; }
    }
}
