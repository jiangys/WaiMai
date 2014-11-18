using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WHTR.WaiMai.Contracts.ViewModels
{
    public class RestaurantViewModel
    {
        public int Id { get; set; }
        public string RestaurantName { get; set; }
        public int SendOutCount { get; set; }
        public string TakeoutPhone { get; set; }
        public bool IsEnable { get; set; }
    }
}
