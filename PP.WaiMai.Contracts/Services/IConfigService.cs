using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.WaiMai.Contracts.Models;
using PP.WaiMai.Contracts.ViewModels;

namespace PP.WaiMai.Contracts.Services
{
    public interface IConfigService
    {
        string GetConfigValue(string configName);
        void Update(Config config);
    }
}
