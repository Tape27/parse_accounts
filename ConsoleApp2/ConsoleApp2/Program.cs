using System.Reflection;

namespace ConsoleApp2
{
    internal class Program
    {
        public static string path = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public static Dictionary<int, int> loadAccounts = new Dictionary<int, int>();

        public static async Task Main()
        {
            await StartAsync();
        }
        public static async Task StartAsync()
        {
            int countIterations = 0;
            bool loadBase = false;
            ParsingLolzHtml parsing = new ParsingLolzHtml();
            TelegramNotifications telegram = new TelegramNotifications(400);

            while (true)
            {
                Thread.Sleep(5000);
                countIterations++;
                Console.WriteLine(DateTime.Now + ":  " + countIterations);

                string html = await Request.MarketRequest();
                if (html == null) { continue; }

                System.IO.File.WriteAllText(path + "\\data.txt", html);

                Dictionary<int, int> accounts = parsing.GetAccounts(path + "\\data.txt");

                foreach (var account in accounts)
                {
                    if (loadBase == false) { loadAccounts = accounts; loadBase = true; break; }

                    if (!loadAccounts.ContainsKey(account.Key))
                    {
                        loadAccounts.Add(account.Key, account.Value);
                        await telegram.SendAccount(account.Key, account.Value);
                    }
                }
                if (countIterations == 1) { await telegram.SendError("Начал работу!"); }
            }

        }

    }
}
