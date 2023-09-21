using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class ParsingLolzHtml
    {
        public Dictionary<int,int> GetAccounts(string path)
        {

            int count_accounts = 0;
            int count = System.IO.File.ReadAllLines(path).Length;
            string[] worst_stroki = new string[count];
            string[] id_accounts = new string[40];
            string[] price_accounts = new string[40];

            using (StreamReader sr = new StreamReader(path, System.Text.Encoding.Default)) // получаем грязные строки с id товара
            {
                for (int i = 0; i < count; i++)
                {
                    worst_stroki[i] = sr.ReadLine();

                    if (worst_stroki[i] == "\t<div class=\"marketIndexItem--topContainer\">")
                    {
                        id_accounts[count_accounts] = worst_stroki[i - 16];
                        price_accounts[count_accounts] = worst_stroki[i - 10];
                        count_accounts++;
                        if (count_accounts > 40) { break; }
                    }
                }

            }

            id_accounts = ParseIdAcccounts(id_accounts);
            price_accounts = ParsePriceAccounts(price_accounts);

            Dictionary<int, int> accounts = new Dictionary<int, int>();

            for (int i = 0; i < 40; i++)
            {
                accounts.Add(Convert.ToInt32(id_accounts[i]), Convert.ToInt32(price_accounts[i]));
            }


            return accounts;
        }

        private string[] ParsePriceAccounts(string[] price_accounts)
        {
            string s = string.Empty;

            for (int i = 0; i < 40; i++)
            {
                s = price_accounts[i];
                price_accounts[i] = string.Empty;
                for (int x = 1; x <= 3; x++)
                {
                    price_accounts[i] += s[s.Length - x - 7];

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
                string s = string.Empty;

                for (int i = 0; i < 40; i++)
                {
                    s = id_accounts[i];
                    id_accounts[i] = string.Empty;
                    for (int x = 1; x <= 8; x++)
                    {
                        id_accounts[i] += s[s.Length - x - 1];

                    }

                    char[] chars = id_accounts[i].ToCharArray();
                    Array.Reverse(chars);
                    id_accounts[i] = new string(chars);
                }
            }
            catch (Exception ex) { TelegramNotifications.SendError("Ошибка в методе ParseIdAccounts  " + ex.ToString()); }


            return id_accounts;
        }
    }
}
