using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yunpian.conf;
using Yunpian.model;

namespace Yunpian.lib
{
    public class TplOperator:AbstractOperator
    {
        public TplOperator(Config config) : base(config) { }
        public Result getDefault(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_get_default_tpl, parms);
        }
        public Result get(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_get_tpl, parms);
        }
        public Result add(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_add_tpl, parms);
        }
        public Result upd(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_upd_tpl, parms);
        }
        public Result del(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_del_tpl, parms);
        }
       
    }
}
