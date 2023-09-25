
using System.Diagnostics;

namespace ConsoleApp2
{
    internal class ParsingLolzHtml
    {
        TelegramNotifications tg = new TelegramNotifications();
        public Dictionary<int,int> GetAccounts(string path)
        {

            int count_accounts = 0;
            int count = System.IO.File.ReadAllLines(path).Length;
            string[] worst_stroki = new string[count];
            string[] id_accounts = new string[0];
            string[] price_accounts = new string[0];

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default)) // получаем грязные строки с id товара
            {
                for (int i = 0; i < count; i++)
                {
                    worst_stroki[i] = sr.ReadLine();

                    if (worst_stroki[i] == "\t<div class=\"marketIndexItem--topContainer\">")
                    {
                        count_accounts++;
                        Array.Resize(ref id_accounts, count_accounts);
                        Array.Resize(ref price_accounts, count_accounts);
                        id_accounts[count_accounts - 1] = worst_stroki[i - 16];
                        price_accounts[count_accounts - 1] = worst_stroki[i - 10];
                        
                    }
                }
            }

            id_accounts = ParseIdAcccounts(id_accounts);
            price_accounts = ParsePriceAccounts(price_accounts);

            Dictionary<int, int> accounts = new Dictionary<int, int>();

            for (int i = 0; i < id_accounts.Length; i++)
            {
                accounts.Add(Convert.ToInt32(id_accounts[i]), Convert.ToInt32(price_accounts[i]));
            }


            return accounts;
        }

        private string[] ParsePriceAccounts(string[] price_accounts)
        {
            string temp = string.Empty;

            for (int i = 0; i < price_accounts.Length; i++)
            {
                temp = price_accounts[i];
                price_accounts[i] = string.Empty;
                for (int x = 1; x <= 10; x++)
                {
                    if (temp[temp.Length - x - 7] == ' ') { continue; }
                    if (temp[temp.Length - x - 7] == '>') { break; }
                    price_accounts[i] += temp[temp.Length - x - 7];
                    

                }

                char[] chars = price_accounts[i].ToCharArray();
                Array.Reverse(chars);
                price_accounts[i] = new string(chars);
            }

            return price_accounts;
        }

        private string[] ParseIdAcccounts(string[] id_accounts)
        {
            try
            {
                string temp = string.Empty;

                for (int i = 0; i < id_accounts.Length; i++)
                {
                    temp = id_accounts[i];
                    id_accounts[i] = string.Empty;

                    for (int x = 1; x <= 8; x++)
                    {
                        id_accounts[i] += temp[temp.Length - x - 1];
                    }

                    char[] chars = id_accounts[i].ToCharArray();
                    Array.Reverse(chars);
                    id_accounts[i] = new string(chars);
                }
            }
            catch (Exception ex) { tg.SendError("Ошибка в методе ParseIdAccounts  " + ex.ToString()); }


            return id_accounts;
        }
    }
}
