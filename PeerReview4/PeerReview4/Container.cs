using System;
using System.Collections.Generic;
using System.Text;

namespace PeerReview4
{
    /// <summary>
    /// Класс для контейнера склада.
    /// </summary>
    class Container
    {
        int limit;
        double damage;
        List<Box> content;
        double sumWeight;
        double sumPrice;
        /// <summary>
        /// Конструктор для контейнера.
        /// </summary>
        public Container()
        {
            var rand = new Random();
            // Задаем лимит массы и урон случайными числами от 50 до 1000 и от 0 до 0.5 соответственно.
            limit = rand.Next() % 951 + 50;
            damage = rand.NextDouble() / 2;
            content = new List<Box>(0);
            sumWeight = 0;
            sumPrice = 0;
        }
        /// <summary>
        /// Добавить ящик в контейнер. 
        /// </summary>
        /// <param name="weight">Вес ящика.</param>
        /// <param name="price">Цена за кг.</param>
        /// <param name="name">Название овощей в ящике.</param>
        /// <returns>Успешно ли.</returns>
        public bool AddBox(double weight, double price, string name = "")
        {
            // Проверяем, можем ли поместить этот ящик.
            if (sumWeight + weight - 1e-15 > limit)
                return false;
            // Добавляем.
            content.Add(new Box(weight, price, name));
            sumWeight += weight;
            sumPrice += price * weight * (1 - damage);
            return true;
        }
        /// <summary>
        /// Суммарная стоимость содержимого контейнера.
        /// </summary>
        public double SumPrice
        {
            get
            {
                return sumPrice;
            }
        }
        /// <summary>
        /// Суммарный вес контейнера.
        /// </summary>
        public double SumWeight
        {
            get
            {
                return sumWeight;
            }
        }
        /// <summary>
        /// Ограничение по весу.
        /// </summary>
        public int Limit()
        {
            return limit;
        }
        /// <summary>
        /// Повреждённость контейнера.
        /// </summary>
        public double Damage
        {
            get
            {
                return damage;
            }
        }
        /// <summary>
        /// Число ящиков в контейнере.
        /// </summary>
        public int Count
        {
            get
            {
                return content.Count;
            }
        }
        /// <summary>
        /// Получить ящик по номеру.
        /// </summary>
        /// <param name="num">Номер ящика.</param>
        /// <returns>Нужный ящик.</returns>
        public Box GetBox(int num)
        {
            return content[num];
        }
    }
}
