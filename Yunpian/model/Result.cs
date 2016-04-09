using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yunpian.model
{
    public class Result
    {
        public bool success;
        public int statusCode;
        public string responseText;
        public Exception e;
        public JObject data;
        public Result(int statusCode,string responseText,Exception e=null)
        {
            if (statusCode == 200)
            {
                this.success = true;
                this.data = strToObj(responseText);
            }

            else if(statusCode == 400)
            {
                this.success = false;
                this.data = strToObj(responseText);
            }
            else
            {
                this.success = false;
                this.data = null;
            }
            this.responseText = responseText;
            this.statusCode = statusCode;
            this.e = e;
            
        }
        public override string ToString()
        {
            //重写需要的输出。
            return "[success:" + success + ",statusCode:" + statusCode + ",responseText:" + responseText + ",data:" + data + "]";
        }
        public static JObject strToObj(string str)
        {
            JObject json = (JObject)JsonConvert.DeserializeObject(str);
            return json;
        }

    }
}
