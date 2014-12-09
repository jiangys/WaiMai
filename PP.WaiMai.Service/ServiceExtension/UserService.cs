using PP.WaiMai.IService;
using PP.WaiMai.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Service
{
    public partial class UserService : BaseService<User>, IUserService
    {
        public UserService()
            : base()
        {

        }
        public User Login(string loginName, string password)
        {
            //处理成加密状态的密码
            //loginPwd = Uxiaoyuan.Common.Utlity.EncryptHelper.GetMd5(loginPwd);
            var user = DbSessionContext.UserRepository.GetListBy(u => u.UserName == loginName
                && u.Password == password);
            if (user != null && user.Count() > 0)
            {
                return user.FirstOrDefault();
            }
            return null;
        }
    }
}
