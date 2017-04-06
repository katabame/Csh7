using Codeplex.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace Csh7
{
    public class Push7
    {
        const string END_POINT = "https://api.push7.jp/api/v1/"; // must ending with slash

        /// <summary>
        /// get push7 Application infomation with app number
        /// </summary>
        /// <param name="appNumber"></param>
        /// <param name="datakey"></param>
        /// <returns>specified datakey value or any exception</returns>
        public static string GetInfo(string appNumber, string datakey)
        {
            WebClient client = new WebClient();
            var response = client.DownloadString(END_POINT + appNumber + "/head");
            var json = DynamicJson.Parse(response);

            if(json.IsDefined("error"))
            {
                throw new ArgumentException("An error occured. Reason: " + json["error"], "appNumber");
            }

            if(!json.IsDefined(datakey))
            {
                throw new ArgumentException("Specified datakey is not found. datakey: " + datakey, "datakey");
            }

            return json.datakey;
        }

        // delay push is not write in official docment. do not implementing.
        /// <summary>
        /// create push via push7 with some argments
        /// </summary>
        /// <param name="appNumber"></param>
        /// <param name="title"></param>
        /// <param name="content"></param>
        /// <param name="iconURL"></param>
        /// <param name="URL"></param>
        /// <param name="apikey"></param>
        /// <returns>pushid or any exception</returns>
        public static string Push(string appNumber, string title, string content, string iconURL, string URL, string apikey)
        {
            var obj = new
            {
                title = title,
                body = content,
                icon = iconURL,
                url = URL,
                apikey = apikey
            };

            var requestBody = DynamicJson.Serialize(obj);

            WebClient client = new WebClient();
            client.Headers[HttpRequestHeader.ContentType] = "application/json;charset=UTF-8";
            client.Encoding = Encoding.UTF8;

            var response = client.UploadString(END_POINT + appNumber + "/send", requestBody);
            var json = DynamicJson.Parse(response);

            if (json.IsDefined("error"))
            {
                throw new ArgumentException("An error occured. Reason: " + json["error"], "appNumber");
            }

            return json.pushid;
        }
    }
}
