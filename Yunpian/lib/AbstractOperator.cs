using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yunpian.conf;

namespace Yunpian.lib
{
    public class AbstractOperator
    {
        public Config config;
        public AbstractOperator(Config config)
        {
            this.config = config;
        }
    }
}
