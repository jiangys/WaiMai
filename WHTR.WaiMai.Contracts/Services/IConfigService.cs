using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHTR.WaiMai.Contracts.Models;
using WHTR.WaiMai.Contracts.ViewModels;

namespace WHTR.WaiMai.Contracts.Services
{
    public interface IConfigService
    {
        string GetConfigValue(string configName);
        void Update(Config config);
    }
}
