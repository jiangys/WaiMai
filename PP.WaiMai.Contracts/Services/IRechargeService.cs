using PP.WaiMai.Contracts.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Contracts.Services
{
    public interface IRechargeService
    {
        IList<Recharge> GetList();
        int Add(Recharge model);
        bool Delete(int Id);
    }
}
