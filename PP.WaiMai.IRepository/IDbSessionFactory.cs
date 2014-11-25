using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PP.WaiMai.IRepository
{
    public interface IDbSessionFactory
    {
        IDbSession GetCurrentDbSession();
    }
}
