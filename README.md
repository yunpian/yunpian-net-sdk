
# SDK使用指南

---
## C \#
### 添加依赖包

```
Newtonsoft.Json.dll
Yunpian.dll
```

### 使用


```
using System;
using System.Collections.Generic;
using Yunpian.conf;
using Yunpian.lib;
using Yunpian.model;
using System.Web;
using System.Text;
namespace YunpianSDKTest
{
    class Program
    {
        static void Main(string[] args)
        {
            //设置apikey
            Config config = new Config("your apikey");
            Dictionary<string, string> data = new Dictionary<string, string>();
            Result result = null;

            // 获取用户信息
            UserOperator user = new UserOperator(config);
            result = user.get(data);
            Console.WriteLine(result);

            // 获取模板信息
            TplOperator tpl = new TplOperator(config);
            data.Clear();
            data.Add("tpl_id", "1");
            result = tpl.getDefault(data);
            Console.WriteLine(result);


            // 发送单条短信
            SmsOperator sms = new SmsOperator(config);
            data.Clear();
            data.Add("mobile", "14012341234");
            data.Add("text", "【yunpian】您的验证码是9981");
            result = sms.singleSend(data);
            Console.WriteLine(result);

            // 发送模板短信(不推荐使用)
            //data.Clear();
            //string tpl_value = HttpUtility.UrlEncode(
            //HttpUtility.UrlEncode("#code#", Encoding.UTF8) + "=" +
            //HttpUtility.UrlEncode("1234", Encoding.UTF8) + "&" +
            //HttpUtility.UrlEncode("#company#", Encoding.UTF8) + "=" +
            //HttpUtility.UrlEncode("云片网", Encoding.UTF8), Encoding.UTF8);
            //data.Add("mobile", "14012341231,123,13012312312");
            //data.Add("tpl_value", tpl_value);
            //data.Add("tpl_id", "1");
            //result = sms.tplSingleSend(data);
            //Console.WriteLine(result);

            // 发送批量短信
            data.Clear();
            data.Add("mobile", "14012341231,123,13012312312");
            data.Add("text", "【yunpian】您的验证码是9981");
            result = sms.batchSend(data);
            Console.WriteLine(result);
            // 发送个性化短信
            data.Clear();
            data.Add("mobile", "14022341231,123,13112312312,13112312312");
            data.Add("text", "【yunpian】您的验证码是9981,【yunpian】您的验证码是1981,【yunpian】您的验证码是9921,【yunpian】您的验证码是9981");
            result = sms.multiSend(data);
            Console.WriteLine(result);

            // 发送语音
            VoiceOperator voice = new VoiceOperator(config);
            data.Clear();
            data.Add("code", "1421");
            data.Add("mobile", "13012312312");
            result = voice.send(data);
            Console.WriteLine(result);

            // 发送流量
            FlowOperator flow = new FlowOperator(config);
            data.Clear();
            result = flow.getPackage(data);
            Console.WriteLine(result);

            data.Clear();
            data.Add("sn", "1008601");
            data.Add("mobile", "18712341234");
            result = flow.recharge(data);
            Console.WriteLine(result);
            Console.ReadLine();

        }
    }
}
```



