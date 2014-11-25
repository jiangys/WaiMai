using PP.WaiMai.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.Repository
{
    public partial class DbSession : IDbSession
    {
        public int SaveChange()
        {
            //从线程中找到EF上下文 进行批量提交
            return new DBContextFactory().GetDbContext().SaveChanges();
        }
    }
}
