using System.IO;
using System.Net;
using System.Reflection;

namespace ConsoleApp2
{
    internal class TelegramNotifications
    {
        private static string token = "6632750876:AAGxffynJjL0251teohIj_d1p6-ZSwHkSA0";
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        LogError log = new LogError(path + "\\Logs.txt");
        public int maxPrice = -1;

        public TelegramNotifications()
        {
            
        }
        public TelegramNotifications(int maxPrice)
        {
            this.maxPrice = maxPrice;
        }

        public async Task SendAccount(int id, int price)
        {
            if (maxPrice != -1 && maxPrice < price) { return; }
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.telegram.org/bot{token}/sendMessage?text=id: lolz.market/{id} price:{price}&chat_id=620080242");
                request.Method = "GET";
                request.Headers.Add("sec-ch-ua: \"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
                request.Headers.Add("sec-ch-ua-mobile: ?0");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36";
                request.Headers.Add("sec-ch-ua-platform: \"Windows\"");
                request.Headers.Add("Upgrade-Insecure-Requests: 1");
                request.Headers.Add("Sec-Fetch-Site: same-origin");
                request.Headers.Add("Sec-Fetch-Mode: navigate");
                request.Headers.Add("Sec-Fetch-User: ?1");
                request.Headers.Add("Sec-Fetch-Dest: document");
                request.Headers.Add("Accept-Language: ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
                request.Headers.Add("Cookie: stel_ln=ru");
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var html = reader.ReadToEnd();
            }
            catch (Exception ex) { log.WriteLog("Не смог отправить сообщение в телеграм, повторная отправка " + ex.Message); await SendAccount(id, price); }

        }
        public async Task SendError(string error)
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.telegram.org/bot{token}/sendMessage?text=ALARM!! {error}&chat_id=620080242");
                request.Method = "GET";
                request.Headers.Add("sec-ch-ua: \"Chromium\";v=\"116\", \"Not)A;Brand\";v=\"24\", \"Google Chrome\";v=\"116\"");
                request.Accept = "text/html,application/xhtml+xml,application/xml;q=0.9,image/avif,image/webp,image/apng,*/*;q=0.8,application/signed-exchange;v=b3;q=0.7";
                request.Headers.Add("sec-ch-ua-mobile: ?0");
                request.UserAgent = "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36";
                request.Headers.Add("sec-ch-ua-platform: \"Windows\"");
                request.Headers.Add("Upgrade-Insecure-Requests: 1");
                request.Headers.Add("Sec-Fetch-Site: same-origin");
                request.Headers.Add("Sec-Fetch-Mode: navigate");
                request.Headers.Add("Sec-Fetch-User: ?1");
                request.Headers.Add("Sec-Fetch-Dest: document");
                request.Headers.Add("Accept-Language: ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
                request.Headers.Add("Cookie: stel_ln=ru");
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var html = reader.ReadToEnd();
            }
            catch (Exception ex) { log.WriteLog("Не смог отправить сообщение в телеграм, повторная отправка " + ex.Message); await SendError(error); }
        }
    }

}
