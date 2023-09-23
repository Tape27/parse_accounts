using System.Net.Http.Headers;
using System.Net.Http;
using System.Net;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;
using System.Reflection;

namespace ConsoleApp2
{
    internal class Program
    {
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static Dictionary<int, int> load_accounts = new Dictionary<int, int>();
        
        public static async Task Main()
        {
            await Start();
        }
        public static async Task Start()
        {
            bool loadbase = false;
            ParsingLolzHtml parsing = new ParsingLolzHtml();

            for (int i = 0; i < 100000000; i++)
            {
                Console.WriteLine(i);
                Thread.Sleep(8000);
                Console.WriteLine(1);
                string s = await Request.MarketRequest();
                Console.WriteLine(2);
                System.IO.File.WriteAllText(path + "\\data.txt", s);
                Console.WriteLine(3);
                Dictionary<int, int> accounts = parsing.GetAccounts(path + "\\data.txt");

                foreach (var account in accounts)
                {
                    if(loadbase == false) { load_accounts = accounts; loadbase = true; break; }

                    if(!load_accounts.ContainsKey(account.Key)) 
                    { 
                        load_accounts.Add(account.Key, account.Value); 
                        await TelegramNotifications.SendAccount(account.Key, account.Value);
                    }                 
                }
            }
            
        }

    }
}