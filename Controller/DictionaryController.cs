using System;
using System.Collections.Generic;
using Autopark.Creator;

namespace Autopark.Controller
{
    public class DictionaryController
    {
        private const string ORDERS_PATH = "orders.csv";

        public static void Start()
        {
            Dictionary<string, int> orders = new Dictionary<string, int>();

            string path = LoadFile.CreatePath(ORDERS_PATH);
            string text =  LoadFile.ReadAllText(path);

            var details = text.Split(new char[] { ',', '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

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
