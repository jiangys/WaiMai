using PP.WaiMai.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Contracts.Services
{
    public interface IAccountService
    {
        IList<Account> GetList();
        Account GetAccountById(int id);
        Account GetAccountByIPAddress(string ipAddress);
        /// <summary>
        /// 增加一条数据
        /// </summary>
        int Add(Account model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateForAmount(Account model);
        /// <summary>
        /// 更新一条数据
        /// </summary>
        bool UpdateForPassword(Account model);
        /// <summary>
        /// 删除一条数据
        /// </summary>
        bool Delete(int Id);
    }
}
