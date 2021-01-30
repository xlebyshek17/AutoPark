using System;
using System.Collections.Generic;
using Autopark.Creator;

namespace Autopark.Controller
{
    public class DictionaryController
    {
        private const string ORDERS_PATH = "orders.csv";
        private static char[] SEPARATOR = new char[] { ',', '\n', '\r' };

        public static void Start()
        {
            Dictionary<string, int> orders = new Dictionary<string, int>();

            string path = LoadFile.CreatePath(ORDERS_PATH);
            var details =  LoadFile.GetStrings(path, SEPARATOR);

            FillDictionary(ref orders, details);

            Console.WriteLine("Detail orders: ");
            PrintOrders(orders);
        }
        
        private static void FillDictionary(ref Dictionary<string, int> orders, string[] details)
        {
            for (int i = 0; i < details.Length; i++)
            {
                if (!orders.ContainsKey(details[i]))
                {
                    orders.Add(details[i], 1);
                }
                else
                    orders[details[i]]++;
            }
        }

        private static void PrintOrders(Dictionary<string, int> orders)
        {
            foreach (var order in orders)
            {
                Console.WriteLine($" {order.Key} - {order.Value}pcs");
            }
        }
    }
}
