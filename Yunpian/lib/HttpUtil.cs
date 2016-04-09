using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Yunpian.model;

namespace Yunpian.lib
{
    public class HttpUtil
    {

        public static Result HttpPost(string Url, Dictionary<string,string> parms)
        {
            StringBuilder sb = new StringBuilder();
            foreach(var item in parms)
            {
                if (sb.Length != 0)
                    sb.Append("&");
                sb.Append(HttpUtility.UrlEncode(item.Key) + '='+ HttpUtility.UrlEncode(item.Value));
            }
            byte[] dataArray = Encoding.UTF8.GetBytes(sb.ToString());
            // Console.Write(Encoding.UTF8.GetString(dataArray));

            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(Url);
            request.Timeout = 5000;
            request.ReadWriteTimeout = 5000;
            request.Method = "POST";
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = dataArray.Length;
            //request.CookieContainer = cookie;
            
            try
            {
                Stream dataStream = request.GetRequestStream();
                dataStream.Write(dataArray, 0, dataArray.Length);
                dataStream.Close();
                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(response.GetResponseStream(), Encoding.UTF8);
                String res = reader.ReadToEnd();
                reader.Close();
                //Console.Write("\nResponse Content:\n" + res + "\n");
                return new Result((int)response.StatusCode, res);
            }
            catch (WebException e)
            {
                using (WebResponse response = e.Response)
                {
                    HttpWebResponse httpResponse = (HttpWebResponse)response;
                    Console.WriteLine(e);
                    if(response == null)
                    {
                        return new Result(-1, e.ToString());
                    }
                    using (Stream data = response.GetResponseStream())
                    using (var reader = new StreamReader(data))
                    {
                        string text = reader.ReadToEnd();
                        // Console.WriteLine(text);
                        return new Result((int)httpResponse.StatusCode, text,e);
                    }
                }
            }
        }
        public static bool CheckReturnJsonStatus(string retrunJsonResult)
        {
            Dictionary<string, string> jsonMap = JsonConvert.DeserializeObject<Dictionary<string, string>>(retrunJsonResult);
            if (jsonMap.ContainsKey("status") && jsonMap["status"].Equals("success", StringComparison.OrdinalIgnoreCase))
            {
                return true;
            }

            return false;
        }

        public static bool CheckMultiReturnJsonStatus(string returnJsonResult)
        {
            JArray jarray = JArray.Parse(returnJsonResult);
            bool isAllSuccess = true;
            foreach (var item in jarray.Children())
            {
                if (CheckReturnJsonStatus(item.ToString()) == false)
                {
                    isAllSuccess = false;
                    break;
                }
            }

            return isAllSuccess;
        }
    }
}
