using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.IRepository
{
    public interface IDBContextFactory
    {
        DbContext GetDbContext();
    }
}
