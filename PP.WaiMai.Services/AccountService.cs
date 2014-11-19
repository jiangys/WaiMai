using IBatisNet.DataMapper;
using PP.WaiMai.Contracts.Models;
using PP.WaiMai.Contracts.Services;
using PP.WaiMai.DaoCfg;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Services
{
    public class AccountService : IAccountService
    {
        private ISqlMapper _sqlMap = WaiMaiSqlMapper.Instance("SqlMapper.config");
        public IList<Contracts.Models.Account> GetList()
        {
            return _sqlMap.QueryForList<Account>("qryAllAccount", null);
        }

        public Contracts.Models.Account GetAccountById(int id)
        {
            return _sqlMap.QueryForObject<Account>("qryAccountByID", id);
        }

        public Contracts.Models.Account GetAccountByIPAddress(string ipAddress)
        {
            return _sqlMap.QueryForObject<Account>("qryAccountByIPAddress", ipAddress);
        }

        public int Add(Account model)
        {
            var id = _sqlMap.Insert("InsAccount", model) as int?;
            return id ?? -1;
        }

        public bool UpdateForAmount(Account model)
        {
            return _sqlMap.Update("updAccountForAmount", model) > 1;
        }

        public bool UpdateForPassword(Account model)
        {
            return _sqlMap.Update("updAccountForPassword", model) > 1;
        }

        public bool Delete(int Id)
        {
            return _sqlMap.Delete("delOrder", Id) > 1;
        }

    }
}
