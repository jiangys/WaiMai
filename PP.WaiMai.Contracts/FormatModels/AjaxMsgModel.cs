using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.WaiMai.Contracts.Enums;

namespace PP.WaiMai.Contracts.FormatModels
{
  public  class AjaxMsgModel
    {
        public AjaxMsgStateEnum State { get; set; }
        public string Msg { get; set; }
        public string BackUrl { get; set; }
        public object Data { get; set; }//数据对象
    }
}
