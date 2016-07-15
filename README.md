
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
    /**
     * 更多内容请参考 <url>https://www.yunpian.com/api2.0/howto.html</url>
     */

    /**
     *
     * 如您第一次使用云片网，强烈推荐先看云片网络设置教程 <url>https://blog.yunpian.com/?p=94</url>
     *
     * 使用说明
     *
     * 1、登陆 <url>http://www.yunpian.com/</url> 获取APIKEY
     * 2、使用APIKEY生成Config
     * 3、获取需要的操作类SmsOperator/UserOperator/TplOperator/FlowOperator/VoiceOperator
     * 4、通过Result来接收返回值.具体可参考示例
     *
     * 返回值参考
     * <url>https://www.yunpian.com/api2.0/sms.html</url>
     * <url>https://www.yunpian.com/api2.0/record.html</url>
     */
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

            // （这个是模板接口发送，会因为一些特殊字符产生编码问题导致发送失败，不推荐使用）
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

            // （批量发送的接口耗时比单号码发送长，如果需要更高并发速度，推荐使用single_send/tpl_single_send）
            //data.Clear();
            //data.Add("mobile", "14012341231,123,13012312312");
            //data.Add("text", "【yunpian】您的验证码是9981");
            //result = sms.batchSend(data);
            //Console.WriteLine(result);
            // 发送个性化短信
            //data.Clear();
            //data.Add("mobile", "14022341231,123,13112312312,13112312312");
            //data.Add("text", "【yunpian】您的验证码是9981,【yunpian】您的验证码是1981,【yunpian】您的验证码是9921,【yunpian】您的验证码是9981");
            //result = sms.multiSend(data);
            //Console.WriteLine(result);

            // 发送语音
            // VoiceOperator voice = new VoiceOperator(config);
            // data.Clear();
            // data.Add("code", "1421");
            // data.Add("mobile", "13012312312");
            // result = voice.send(data);
            // Console.WriteLine(result);

            // 发送流量
            // FlowOperator flow = new FlowOperator(config);
            // data.Clear();
            // result = flow.getPackage(data);
            // Console.WriteLine(result);

            // data.Clear();
            // data.Add("sn", "1008601");
            // data.Add("mobile", "18712341234");
            // result = flow.recharge(data);
            // Console.WriteLine(result);
            // Console.ReadLine();

        }
    }
}
```



