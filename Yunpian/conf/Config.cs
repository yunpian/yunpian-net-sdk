using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yunpian.conf
{
    public class Config
    
    {
        public string apikey;
        public string apiSecret;



        public Config(string apikey,string apiSecret)
        {
            this.apikey = apikey;
            this.apiSecret = apiSecret;
        }
        public Config(string apikey)
        {
            this.apikey = apikey;
            this.apiSecret = null;
        }


        public static string sms_host = "https://sms.yunpian.com";
        public static string voice_host = "https://voice.yunpian.com";
        public static string flow_host = "https://flow.yunpian.com";


        // test 
        //public static string sms_host = "http://192.168.199.163:8081";
        //public static string voice_host = "http://192.168.199.163:8081";
        //public static string flow_host = "http://192.168.199.163:8081";


        public static string version = "/v2";
        // 获取user信息url
        public static string url_get_user = sms_host + version + "/user/get.json";
        public static string url_set_user = sms_host + version + "/user/set.json";

        // 发送单条短信
        public static string url_send_single_sms = sms_host + version + "/sms/single_send.json";
        // 发送批量短信
        public static string url_send_batch_sms = sms_host + version + "/sms/batch_send.json";
        // 发送个性化短信
        public static string url_send_multi_sms = sms_host + version + "/sms/multi_send.json";
        // 发送指定模板短信
        public static string url_send_tpl_single_sms = sms_host + version + "/sms/tpl_single_send.json";
        public static string url_send_tpl_batch_sms = sms_host + version + "/sms/tpl_batch_send.json";
        // 获取状态报告
        public static string url_pull_sms_status = sms_host + version + "/sms/pull_status.json";



        // 获取默认短信模板
        public static string url_get_default_tpl = sms_host + version + "/tpl/get_default.json";
        // 获取短信模板
        public static string url_get_tpl = sms_host + version + "/tpl/get.json";
        // 增加短信模板
        public static string url_add_tpl = sms_host + version + "/tpl/add.json";
        // 修改短信模板
        public static string url_upd_tpl = sms_host + version + "/tpl/upd.json";
        // 删除短信模板
        public static string url_del_tpl = sms_host + version + "/tpl/del.json";



        // 发送语音短信url
        public static string url_send_voice = voice_host + version + "/voice/send.json";
        // 状态报告
        public static string url_pull_voice_status = voice_host + version + "/voice/send.json";

        // 查询流量包
        public static string url_get_flow_package = flow_host + version + "/flow/get_package.json";
        // 流量包充值
        public static string url_recharge_flow = flow_host + version + "/flow/recharge.json";
        // 状态报告
        public static string url_pull_flow_status = flow_host + version + "/flow/pull_status.json";
    }
}
