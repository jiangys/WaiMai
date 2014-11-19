using IBatisNet.DataMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PP.WaiMai.Contracts.Models;
using PP.WaiMai.Contracts.Services;
using PP.WaiMai.Contracts.ViewModels;
using PP.WaiMai.DaoCfg;

namespace PP.WaiMai.Services
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
