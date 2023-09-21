using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Request
    {
        static HttpClientHandler httpClientHandler = new HttpClientHandler();
        public static async Task<string> MarketRequest()
        {
            try
            {
                HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://lolz.market/steam/cs-go-prime?order_by=price_to_up");
                //request.Proxy = (IWebProxy?)httpClientHandler;
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
                request.Referer = "https://lolz.market/";
                request.Headers.Add("Accept-Language: ru-RU,ru;q=0.9,en-US;q=0.8,en;q=0.7");
                request.Headers.Add("Cookie: _ym_uid=1693682912352474918; _ym_d=1693682912; G_ENABLED_IDPS=google; timezoneOffset=10800,0; xf_logged_in=1; xf_user=7606501%2C536491bf0898df04d1b791ad6713e013a14849e0; lolz.market_xf_tc_lmad=%5B%2238218676b2b529758f92f7498504ecf7%22%5D; _ga=GA1.1.78014854.1693682912; _ga_J7RS527GFK=GS1.1.1695211595.10.1.1695215349.0.0.0; dfuid=e7c6d655dc32d26bad4d6a17ec12773a; xf_market_items_viewed=72192414%2C74152870%2C74096243%2C73944788%2C74115966; xf_session=a3b986d92c7fa736b85b0c43a462a165; xf_market_search_url=%2Fsteam%2Fcs-go-prime%3Forder_by%3Dprice_to_up");
                request.Headers.Add($"If-Modified-Since: Wed, 20 Sep 2023 {DateTime.Now.ToString("H:mm:ss")} GMT");
                request.Headers.Add("Accept-Encoding: gzip, deflate");
                request.AutomaticDecompression = DecompressionMethods.GZip;

                HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                var reader = new StreamReader(response.GetResponseStream());
                var html = reader.ReadToEnd();

                await TelegramNotifications.SendError(html);
                return html;
            }
            catch (Exception ex) { await TelegramNotifications.SendError("Ошибка в методе MarketRequest  " + ex.ToString()); return null; }

            
        }

        public static void SetProxy()
        {
            var webproxy = new WebProxy
            {
                Address = new Uri($@"http://45.87.253.186:5500"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    userName: "YhM4jX",
                    password: "nq1vm5tqIg")
            };
            httpClientHandler = new HttpClientHandler
            {
                Proxy = webproxy,
            };

            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        }
    }
}
