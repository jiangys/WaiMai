using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Util
{
    public class IPAddress
    {
        //获取内网IP
        public static string GetInternalIP()
        {
            System.Net.IPHostEntry host;
            string localIP = "?";
            host = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName());
            foreach (System.Net.IPAddress ip in host.AddressList)
            {
                if (ip.AddressFamily.ToString() == "InterNetwork")
                {
                    localIP = ip.ToString();
                    break;
                }
            }
            return localIP;
        }
    }
}
