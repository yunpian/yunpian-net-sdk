using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yunpian.conf;
using Yunpian.model;

namespace Yunpian.lib
{
    public class FlowOperator:AbstractOperator
    {
        public FlowOperator(Config config) : base(config) { }

        public Result getPackage(Dictionary<string,string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_get_flow_package, parms);
        }
        public Result recharge(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_recharge_flow, parms);
        }
        public Result pullStatus(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_pull_flow_status, parms);
        }
    }
}
