using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHTR.Domain;

namespace WHTR.WaiMai.Contracts.Models
{
    /// <summary>
    /// 餐厅管理类
    /// </summary>
    public class RestaurantModel : EntityBase
    {
        public string RestaurantName { get; set; }
        public string Phone { get; set; }
        public bool IsEnable { get; set; }
    }
}
