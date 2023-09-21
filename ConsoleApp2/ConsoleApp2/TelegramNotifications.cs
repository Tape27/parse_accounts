using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp2
{
    internal class TelegramNotifications
    {
        private static string Token = "6632750876:AAGxffynJjL0251teohIj_d1p6-ZSwHkSA0";
        public TelegramNotifications() 
        { 
            
        }

        public static async Task SendAccount(int id, int price)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.telegram.org/bot{Token}/sendMessage?text=id: lolz.market/{id} price:{price}&chat_id=620080242");
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
        public static async Task SendError(string error)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create($"https://api.telegram.org/bot{Token}/sendMessage?text=ALARM!!!!   {error}$&chat_id=620080242");
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

    }
}
