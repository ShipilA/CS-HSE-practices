using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PeerReview4
{
    /// <summary>
    /// Класс для объекта склада.
    /// </summary>
    class Storage
    {
        int limit;
        double payment;
        List<Container> content;
        double sumPrice;
        double sumWeight;
        /// <summary>
        /// Конструктор склада.
        /// </summary>
        /// <param name="lim">Максимальная вместимость.</param>
        /// <param name="pay">Оплата за один контейнер.</param>
        public Storage(int lim, double pay)
        {
            limit = lim;
            payment = pay;
            content = new List<Container>(0);
            sumPrice = 0;
            sumWeight = 0;
        }
        /// <summary>
        /// Конструктор для чтения склада из файла.
        /// </summary>
        /// <param name="path"> Путь до файла.</param>
        /// <param name="ok"> Удачно ли чтение.</param>
        public Storage(string path, out bool ok)
        {
            string[] info = File.ReadAllLines(path);
            // Проверяем, соответствует ли файл формату.
            ok = (int.TryParse(info[0], out limit) && double.TryParse(info[1], out payment) && info.Length == 2);
            if (ok)
            {
                // Задаем параметры склада.
                content = new List<Container>(0);
                sumPrice = 0;
                sumWeight = 0;
            }
        }
        /// <summary>
        /// Добавление контейнера на склад.
        /// </summary>
        /// <param name="cont"> Контейнер для добавления.</param>
        public void AddContainer(Container cont)
        {
            // Добавляем контейнер и увеличиваем соответствующие параметры.
            content.Add(cont);
            sumWeight += cont.SumWeight;
            sumPrice += cont.SumPrice;

        }
        /// <summary>
        /// Удаление контейнера со склада.
        /// </summary>
        /// <param name="num"> Номер контейнера.</param>
        public void DeleteContainer(int num)
        {
            // Удаляем контейнер и уменьшаем соответствующие параметры.
            sumWeight -= content[num].SumWeight;
            sumPrice -= content[num].SumPrice;
            content.Remove(content[num]);
        }
        /// <summary>
        /// Получить контейнер.
        /// </summary>
        /// <param name="num"> Номер контейнера.</param>
        /// <returns></returns>
        public Container GetContainer(int num)
        {
            return content[num];
        }
        /// <summary>
        /// Получить суммарный вес овощей склада
        /// </summary>
        public double Weight
        {
            get
            {
                return sumWeight;
            }
        }
        /// <summary>
        /// Получить суммарную стоимость овощей на складе.
        /// </summary>
        public double Price
        {
            get
            {
                return sumPrice;
            }
        }
        /// <summary>
        /// Получить стоимость хранения одного контейнера.
        /// </summary>
        /// <returns></returns>
        public double Payment()
        {
            return payment;
        }
        /// <summary>
        /// Получить количество контейнеров на складе.
        /// </summary>
        public int Count
        {
            get
            {
                return content.Count;
            }
        }
        /// <summary>
        /// Получить строку с описанием склада.
        /// </summary>
        public override string ToString()
        {
            // Общая информация и содержимом склада.
            string ans = $"На складе расположено контейнеров: {content.Count}, общей стоимостью {sumPrice} (с учетом повреждений) и суммарным весом {sumWeight}.";
            for (int i = 0; i < content.Count; ++i)
            {
                // Информация об отдельном контейнере.
                Container cur = content[i];
                ans += $"\nКонтейнер {i + 1} содержит коробок: {cur.Count}, общей стоимостью {cur.SumPrice} (с учетом повреждения) и суммарным весом {cur.SumWeight}.";
                for (int j = 0; j < cur.Count; ++j)
                    // Информация об отдельном ящике.
                    if (cur.GetBox(j).Name != "")
                        ans += $"\nВ коробке {j + 1} контейнера {i + 1} овощи под названием \"{cur.GetBox(j).Name}\", массой {cur.GetBox(j).Weight} и общей стоимостью {cur.GetBox(j).Price} (с учетом повреждения).";
                    else
                        ans += $"\nВ коробке {j + 1} контейнера {i + 1} овощи массой {cur.GetBox(j).Weight} и общей стоимостью {cur.GetBox(j).Price} (с учетом повреждения).";
            }
            return ans;
        }
        /// <summary>
        /// Получить строку с названиями овощей склада.
        /// </summary>
        public string Names()
        {
            string ans = "";
            // Проходимся по контейнерам.
            for (int i = 0; i < content.Count; ++i)
            {
                Container cur = content[i];
                // Проходимся по ящикам и прибавляем названия в строку.
                for (int j = 0; j < cur.Count; ++j)
                {
                    string name = cur.GetBox(j).Name;
                    if (name == "")
                        continue;
                    if (ans.Length == 0)
                        ans += name;
                    else if (ans.IndexOf(name) == -1)
                        ans += ", " + name;
                }
            }
            return ans;
        }
    }
}
