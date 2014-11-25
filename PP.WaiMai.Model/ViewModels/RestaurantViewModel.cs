using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.ViewModels
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
