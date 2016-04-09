using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using Yunpian.conf;
using Yunpian.model;

namespace Yunpian.lib
{
    public class SmsOperator : AbstractOperator
    {
        public SmsOperator(Config config) : base(config)
        {
        }
        public Result singleSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_single_sms, parms);
        }
        public Result batchSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_batch_sms, parms);
        }
        public Result multiSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            string text = parms["text"];
            string[] textArr = text.Split(',');
            StringBuilder sb = new StringBuilder();
            foreach (var s in textArr)
            {
                if (sb.Length != 0)
                    sb.Append(",");
                sb.Append(HttpUtility.UrlEncode(s));
            }
            parms["text"] = sb.ToString();
            return HttpUtil.HttpPost(Config.url_send_multi_sms, parms);
        }
        public Result tplSingleSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_tpl_single_sms, parms);
        }
        public Result tplBatchSend(Dictionary<string, string> parms)
        {
            parms.Add("apikey", config.apikey);
            return HttpUtil.HttpPost(Config.url_send_tpl_batch_sms, parms);
        }
    }
}
