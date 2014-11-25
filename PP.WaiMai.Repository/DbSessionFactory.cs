using PP.WaiMai.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Repository
{
    public class DbSessionFactory : IDbSessionFactory
    {
        public IDbSession GetCurrentDbSession()
        {
            //线程内唯一
            IDbSession dbSession = (DbSession)CallContext.GetData(typeof(DbSession).FullName);
            if (dbSession == null)
            {
                //创建实体产品对象
                dbSession = new DbSession();//使用 ef操作数据库的对象
                CallContext.SetData(typeof(DbSession).FullName, dbSession);
            }
            return dbSession;
        }
    }
}
