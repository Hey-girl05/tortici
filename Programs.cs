using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace тортики
{
    internal class Programs
    {
        static void Main(string[] args)
        {
            List<MenuItem> shapes = new List<MenuItem>
        {
            new MenuItem("Круглая", 100),
            new MenuItem("Прямоугольная", 150),
            new MenuItem("Сердце", 200)
        };

            List<MenuItem> sizes = new List<MenuItem>
        {
            new MenuItem("Маленький", 50),
            new MenuItem("Средний", 100),
            new MenuItem("Большой", 150)
        };

            List<MenuItem> flavors = new List<MenuItem>
        {
            new MenuItem("Шоколадный", 20),
            new MenuItem("Ванильн
ый", 15),
            new MenuItem("Клубничный", 25)
        };

            List<MenuItem> frostings = new List<MenuItem>
        {
            new MenuItem("Шоколадная", 10),
            new MenuItem("Ванильная", 8),
            new MenuItem("Крем-сыр", 12)
        };

            List<MenuItem> decorations = new List<MenuItem>
        {
            new MenuItem("Фрукты", 5),
            new MenuItem("Орехи", 7),
            new MenuItem("Шоколадные стружки", 3)
        };

            List<string> mainMenuOptions = new List<string>
        {
            "Форма",
            "Размер",
            "Вкус",
            "Количество",
            "Глазурь",
            "Декорации",
            "Заказать",
            "Выход"
        };

            Menu mainMenu = new Menu(mainMenuOptions);
            Order order = new Order();
            bool ordering = true;

            while (ordering)
            {
                int mainMenuResult = mainMenu.Display();
                switch (mainMenuResult)
                {
                    case 0:
                        Menu shapeMenu = new Menu(shapes.Select(s => $"{s.Description} - {s.Price} руб.").ToList());
                        int shapeMenuResult = shapeMenu.Display();
                        if (shapeMenuResult >= 0)
                        {
                            order.Shape = shapes[shapeMenuResult].Description;
                            order.Price += shapes[shapeMenuResult].Price;
                        }
                        break;
                    case 1:
                        Menu sizeMenu = new Menu(sizes.Select(s => $"{s.Description} - {s.Price} руб.").ToList());
                        int sizeMenuResult = sizeMenu.Display();
                        if (sizeMenuResult >= 0)
                        {
                            order.Size = sizes[sizeMenuResult].Description;
                            order.Price += sizes[sizeMenuResult].Price;
                        }
                        break;
                    case 2:
                        Menu flavorMenu = new Menu(flavors.Select(f => $"{f.Description} - {f.Price} руб.").ToList());
                        int flavorMenuResult = flavorMenu.Display();
                        if (flavorMenuResult >= 0)
                        {
                            order.Flavor = flavors[flavorMenuResult].Description;
                            order.Price += flavors[flavorMenuResult].Price;
                        }
                        break;
                    case 3:
                        Console.Clear();
                        Console.WriteLine("Введите количество:");
                        int quantity;
                        while (!int.TryParse(Console.ReadLine(), out quantity) || quantity <= 0)
                        {
                            Console.WriteLine("Некорректное количество. Попробуйте еще раз.");
                        }
                        order.Quantity = quantity;
                        break;
                    case 4:
                        Menu frostingMenu = new Menu(frostings.Select(f => $"{f.Description} - {f.Price} руб.").ToList());
                        int frostingMenuResult = frostingMenu.Display();
                        if (frostingMenuResult >= 0)
                        {
                            order.Frosting = frostings[frostingMenuResult].Description;
                            order.Price += frostings[frostingMenuResult].Price;
                        }
                        break;
                    case 5:
                        Menu decorationsMenu = new Menu(decorations.Select(d => $"{d.Description} - {d.Price} руб.").ToList());
                        int decorationsMenuResult = decorationsMenu.Display();
                        if (decorationsMenuResult >= 0)
                        {
                            order.Decorations = decorations[decorationsMenuResult].Description;
                            order.Price += decorations[decorationsMenuResult].Price;
                        }
                        break;
                    case 6:
                        if (order.Shape != null && order.Size != null && order.Flavor != null && order.Quantity > 0)
                        {
                            Console.Clear();
                            Console.WriteLine($"Ваш заказ: {order.Quantity} {order.Size} {order.Shape} торт(ов) со вкусом {order.Flavor}, глазурью {order.Frosting} и декорациями {order.Decorations}. Цена: {order.Price * order.Quantity} руб.");
                            Console.WriteLine("Введите ваше имя:");
                            string name = Console.ReadLine();
                            order.Price *= order.Quantity;
                            Serialization.SaveOrder(order, "orders.txt");
                            Console.WriteLine($"Спасибо за заказ, {name}! Ваш заказ сохранен в файл.");
                            Console.ReadKey(true);
                            order = new Order();
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine("Заказ не полный. Пожалуйста, выберите все параметры.");
                            Console.ReadKey(true);
                        }
                        break;
                    case 7:
                        ordering = false;
                        break;
                }
            }
        }
    }
}
}
