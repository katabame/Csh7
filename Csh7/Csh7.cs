using Codeplex.Data;
using System;
using System.Net;
using System.Text;

namespace Csh7
{
	public class Push7
    {
        const string END_POINT = "https://api.push7.jp/api/v1/"; // must ending with slash
		static string appNumber = null;
		static string apiKey = null;

		/// <summary>
		/// initialize Client with appNumber and apiKey. when initialized this, you can use methods without specify appNumber and apiKey.
		/// </summary>
		/// <param name="appNumber"></param>
		/// <param name="apiKey"></param>
		public static void Client(string appNumber, string apiKey)
		{
			Push7.appNumber = appNumber;
			Push7.apiKey = apiKey;
		}

		/// <summary>
		/// get push7 Application infomation with app number
		/// </summary>
		/// <param name="datakey"></param>
		/// <param name="appNumber"></param>
		/// <returns>specified datakey value or any exception</returns>
		public static string GetInfo(string datakey, string appNumber = null)
        {
			if (appNumber == null && Push7.appNumber != null)
			{
				appNumber = Push7.appNumber;
			}
			else if (appNumber == null && Push7.appNumber == null)
			{
				throw new ArgumentException("You need set appNumber with Push7.Client() or argument!", appNumber);
			}

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

            return json[datakey];
        }

		// delay push is not write in official docment. do not implementing.
		/// <summary>
		/// create push via push7 with some argments
		/// </summary>
		/// <param name="title"></param>
		/// <param name="content"></param>
		/// <param name="iconURL"></param>
		/// <param name="URL"></param>
		/// <param name="appNumber"></param>
		/// <param name="apikey"></param>
		/// <returns>pushid or any exception</returns>
		public static string Push(string title, string content, string iconURL, string URL, string appNumber = null, string apiKey = null)
        {
			if (appNumber == null && Push7.appNumber != null)
			{
				appNumber = Push7.appNumber;
			}
			else if (appNumber == null && Push7.appNumber == null)
			{
				throw new ArgumentException("You need set appNumber with Push7.Client() or argument!", appNumber);
			}

			if (apiKey == null && Push7.apiKey != null)
			{
				apiKey = Push7.apiKey;
			}
			else if (apiKey == null && Push7.apiKey == null)
			{
				throw new ArgumentException("You need set apiKey with Push7.Client() or argument!", apiKey);
			}

            var obj = new
            {
                title = title,
                body = content,
                icon = iconURL,
                url = URL,
                apikey = apiKey
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
