using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yunpian.conf;
using Yunpian.model;

namespace Yunpian.lib
{
    public class UserOperator :AbstractOperator
    {
        public UserOperator(Config config) : base(config) { }
        public Result get(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_get_user, parms);
        }
        public Result set(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_set_user, parms);
        }
    }
}
