using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WHTR.WaiMai.Contracts.Models;
using WHTR.WaiMai.Contracts.Services;
using WHTR.WaiMai.Contracts.ViewModels;
using WHTR.WaiMai.DaoCfg;

namespace WHTR.WaiMai.Services
{
    public class ConfigService : IConfigService
    {
        private ISqlMapper _sqlMap = WaiMaiSqlMapper.Instance("SqlMapper.config");
        public string GetConfigValue(string configName)
        {
            return (string)_sqlMap.QueryForObject("qryConfigValue", configName);
        }

        public void Update(Config config)
        {
            _sqlMap.Update("updConfigValue", config);
        }
    }
}
