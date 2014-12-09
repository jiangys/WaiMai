using PP.WaiMai.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.IService
{
    partial interface IUserService : IBaseService<User>
    {
        User Login(string loginName, string password);
    }
}
