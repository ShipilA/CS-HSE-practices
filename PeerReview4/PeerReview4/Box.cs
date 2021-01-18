using System;
using System.Collections.Generic;
using System.Text;

namespace PeerReview4
{
    /// <summary>
    /// Класс для ящиков с овощами.
    /// </summary>
    class Box
    {
        double weight, price;
        string name;
        /// <summary>
        /// Конструктор для ящика овощей.
        /// </summary>
        /// <param name="w">Вес.</param>
        /// <param name="p">Цена за кг.</param>
        /// <param name="vegName">Название овощей в ящике.</param>
        public Box(double w, double p, string vegName = "")
        {
            weight = w;
            price = p;
            name = vegName;
        }
        /// <summary>
        /// Масса ящика.
        /// </summary>
        public double Weight
        {
            get
            {
                return weight;
            }
        }
        /// <summary>
        /// Цена за кг овощей.
        /// </summary>
        public double Price
        {
            get
            {
                return price;
            }
        }
        /// <summary>
        /// Название овощей в ящике.
        /// </summary>
        public string Name
        {
            get
            {
                return name;
            }
        }
    }
}
