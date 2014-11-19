using IBatisNet.Common.Utilities;
using IBatisNet.DataMapper;
using IBatisNet.DataMapper.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PP.WaiMai.DaoCfg
{
    public class WaiMaiSqlMapper
    {
        private static volatile ISqlMapper _mapper = null;

        protected static void Configure(object obj)
        {
            _mapper = null;
        }

        protected static void InitMapper(string config)
        {
            ConfigureHandler handler = new ConfigureHandler(Configure);
            DomSqlMapBuilder builder = new DomSqlMapBuilder();


            if (string.IsNullOrEmpty(config))
            {
                config = "SqlMapper.config";
            }

            _mapper = builder.ConfigureAndWatch(config, handler);
        }

        
        public static ISqlMapper Instance()
        {
            return Instance(null);
        }


        public static ISqlMapper Instance(string config)
        {

            if (_mapper == null)
            {
                lock (typeof(WaiMaiSqlMapper))
                {
                    if (_mapper == null) // double-check
                    {
                        InitMapper(config);
                    }
                }
            }
            return _mapper;
        }

        public static ISqlMapper Get()
        {
            return Instance();
        }

    }
}
