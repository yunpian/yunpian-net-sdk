using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Yunpian.conf;
using Yunpian.model;

namespace Yunpian.lib
{
    public class VoiceOperator:AbstractOperator
    { 
        public VoiceOperator(Config config) : base(config)
        {
            
        }
        public Result send(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_voice, parms);
        }
        public Result pullStatus(Dictionary<string,string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_pull_voice_status, parms);
        }
    }
}
