using System.Net;
using System.Net.Http.Headers;
using System.Reflection;

namespace ConsoleApp2
{
    internal class Request
    {

        static HttpClientHandler httpClientHandler = new HttpClientHandler();
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        public static async Task<string> MarketRequest()
        {
            LogError log = new LogError(path + "\\Logs.txt");
            TelegramNotifications tg = new TelegramNotifications();
            try
            {
                SetProxy();

                string url = "https://lolz.market/steam/cs2-prime?order_by=pdate_to_down_upload";
                var client = new System.Net.Http.HttpClient();
                client = new System.Net.Http.HttpClient(httpClientHandler, true);

                client.DefaultRequestHeaders.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/116.0.0.0 Safari/537.36");
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                client.DefaultRequestHeaders.Connection.Add("keep-alive");
                client.DefaultRequestHeaders.Referrer = new Uri("https://lolz.market/");
                client.DefaultRequestHeaders.Add("DNT", "1");
                client.DefaultRequestHeaders.Add("X-Requested-With", "XMLHttpRequest");
                client.DefaultRequestHeaders.Add("Cookie", "_ym_uid=1693682912352474918; _ym_d=1693682912; G_ENABLED_IDPS=google; timezoneOffset=10800,0; xf_logged_in=1; xf_user=7606501%2C536491bf0898df04d1b791ad6713e013a14849e0; lolz.market_xf_tc_lmad=%5B%2238218676b2b529758f92f7498504ecf7%22%5D; _ga=GA1.1.78014854.1693682912; _ga_J7RS527GFK=GS1.1.1695211595.10.1.1695215349.0.0.0; xf_market_items_viewed=74348135%2C72192414%2C74152870%2C74096243%2C73944788; xf_market_search_url=%2Fsteam%2Fcs-go-prime%3Forder_by%3Dprice_to_up; dfuid=42ce72014f2ce49abdf537323ab7d29f; xf_session=e224f3cc708b953cfa873cec9b2ed7bf");
                client.DefaultRequestHeaders.Add("sec-ch-ua-platform", "\"Windows\"");
                client.DefaultRequestHeaders.Add("Upgrade-Insecure-Requests", "1");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Site", "same-origin");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Mode", "navigate");
                client.DefaultRequestHeaders.Add("Sec-Fetch-User", "?1");
                client.DefaultRequestHeaders.Add("Sec-Fetch-Dest", "document");

                var request = await client.GetAsync(url);
                var response = await request.Content.ReadAsStringAsync();
                
                return response.ToString();
                
            }
            catch (Exception ex) { log.WriteLog("Ошибка в методе MarketRequest  " + ex.Message); await MarketRequest(); return null; }

            

        }

        public static void SetProxy()
        {
            var webproxy = new WebProxy
            {
                Address = new Uri($@"http://212.116.242.22:2942"),
                BypassProxyOnLocal = false,
                UseDefaultCredentials = false,
                Credentials = new NetworkCredential(
                    userName: "user133284",
                    password: "03a5cl")
            };
            httpClientHandler = new HttpClientHandler
            {
                Proxy = webproxy,
            };

            httpClientHandler.ServerCertificateCustomValidationCallback = HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
        }
    }
}
