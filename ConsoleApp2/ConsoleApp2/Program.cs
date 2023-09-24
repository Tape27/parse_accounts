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
            TelegramNotifications tg = new TelegramNotifications(400);

            for (int i = 0; i < 100000000; i++)
            {
                Console.WriteLine(i);

                string html = await Request.MarketRequest();
                if (html == null) { continue; }

                System.IO.File.WriteAllText(path + "\\data.txt", html);

                Dictionary<int, int> accounts = parsing.GetAccounts(path + "\\data.txt");

                foreach (var account in accounts)
                {
                    if(loadbase == false) { load_accounts = accounts; loadbase = true; break; }

                    if(!load_accounts.ContainsKey(account.Key)) 
                    { 
                        load_accounts.Add(account.Key, account.Value); 
                        await tg.SendAccount(account.Key, account.Value);
                    }
                }
            }
            
        }

    }
}