using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тортики
{
    internal class Serialization
    {
        public static void SaveOrder(Order order, string filePath)
        {
            // Сериализация заказа в JSON и сохранение на диск
            string json = JsonConvert.SerializeObject(order);
            File.AppendAllText(filePath, json + Environment.NewLine);
        }

        public static List<Order> LoadOrders(string filePath)
        {
            // Чтение файла с сохраненными заказами и десериализация из JSON
            List<Order> orders = new List<Order>();
            if (File.Exists(filePath))
            {
                string[] lines = File.ReadAllLines(filePath);
                foreach (string line in lines)
                {
                    orders.Add(JsonConvert.DeserializeObject<Order>(line));
                }
            }
            return orders;
        }
    }
}
}
