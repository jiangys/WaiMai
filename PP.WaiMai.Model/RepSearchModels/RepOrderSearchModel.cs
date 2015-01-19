using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Model.RepSearchModels
{
    public class RepOrderSearchModel
    {
        public int? page { get; set; }
        public string beginTime { get; set; }
        public string endTime { get; set; }
        public string userName { get; set; }
    }
}
