using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Contracts.ViewModels
{
    public class OrderViewModel
    {
        public int Id { get; set; }

        public string MenuName { get; set; }
        public int TotalCount { get; set; }
        public decimal TotalPrice { get; set; }
        public string NickName { get; set; }
        /// <summary>
        /// 下单时间
        /// </summary>
        public DateTime CreateDate { get; set; }
    }
}
