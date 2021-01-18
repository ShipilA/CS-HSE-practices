using System;
using System.IO;
using System.Collections.Generic;

namespace PeerReview4
{
    class Program
    {
        /// <summary>
        /// Чтение целого неотрицательного числа.
        /// </summary>
        /// <returns>Считанное число.</returns>
        public static int ReadInt()
        {
            int ans;
            Console.WriteLine("Введите целое неотрицательное число.");
            string input = Console.ReadLine();
            // Просим повторять попытку, пока ввод не корректен.
            while (!int.TryParse(input, out ans) || ans < 0)
            {
                Console.WriteLine("Некорректный ввод. Введите целое неотрицательное число.");
                input = Console.ReadLine();
            }
            return ans;
        }
        /// <summary>
        /// Чтение действительного неотрицательного числа.
        /// </summary>
        /// <returns>Считанное число.</returns>
        public static double ReadDouble()
        {
            double ans;
            Console.WriteLine("Введите неотрицательное число.");
            string input = Console.ReadLine();
            // Просим повторять попытку, пока ввод не корректен.
            while (!double.TryParse(input, out ans) || ans < 0)
            {
                Console.WriteLine("Некорректный ввод. Введите неотрицательное число.");
                input = Console.ReadLine();
            }
            return ans;
        }
        /// <summary>
        /// Выполнение программы, считывающей всё с клавиатуры.
        /// </summary>
        public static void ConsoleReading()
        {
            // Задание параметров склада.
            int command;
            Storage stockroom = StorageFromConsole();
            do
            {
                Console.WriteLine("Теперь для добавления контейнера введите 1,\nДля удаления контейнера: 2,\nдля вывода названий овощей, имеющихся на складе: 3,\nи для завершения построения склада: 4 (тогда на консоль выведится информация о складе).");
                // Считываем команду.
                if (!int.TryParse(Console.ReadLine(), out command))
                {
                    Console.WriteLine("Некорректный ввод, введите целое число от 1 до 4.");
                    command = -1;
                    continue;
                }
                switch (command)
                {
                    case 1:
                        // Добавление контейнера.
                        AddContainerFromConsole(stockroom);
                        break;
                    case 2:
                        // Удаление контейнера.
                        DeleteContainerFromConsole(stockroom);
                        break;
                    case 3:
                        // Вывод данных о том, какие овощи есть на складе (доп. функционал).
                        Console.WriteLine("На складе есть овощи со следующими названиями: " + stockroom.Names() + ".\n");
                        break;
                    case 4:
                        // Конец. => Вывод данных о складе.
                        Console.WriteLine(stockroom.ToString());
                        break;
                    default:
                        // Неправильный ввод.
                        Console.WriteLine("Нет команды с таким номером.");
                        break;
                }
            }
            while (command != 4);
        }
        /// <summary>
        /// Команда удаления контейнера по введенным через консоль данным.
        /// </summary>
        /// <param name="stockroom">Склад.</param>
        private static void DeleteContainerFromConsole(Storage stockroom)
        {
            Console.WriteLine($"Для удаления контейнера выберите номер ящик (целое число от 1 до {stockroom.Count}).\nПорядок нумерации соответствует порядку добавления.");
            int num = ReadInt();
            // Проверяем, что контейнер есть и его можно удалить.
            if (num > stockroom.Count || num < 1)
                Console.WriteLine("Контейнера с таким номером нет.");
            stockroom.DeleteContainer(num - 1);
        }
        /// <summary>
        /// Добавляем контейнер, считывая данные из консоли.
        /// </summary>
        /// <param name="stockroom">Склад.</param>
        private static void AddContainerFromConsole(Storage stockroom)
        {
            Container newCont = new Container();
            Console.WriteLine($"Создан контейнер с максимальной массой {newCont.Limit()} и степенью повреждения {newCont.Damage}.\nЗадайте, пожалуйста, количество ящиков в контейнере (натуральное число).");
            int n = ReadInt(), i;
            // Считываем ящики по одному.
            for (i = 0; i < n; ++i)
            {
                Console.WriteLine($"Задайте массу овощей в ящике {i + 1}.");
                double weight = ReadDouble();
                Console.WriteLine($"Задайте цену за килограмм овощей в ящике {i + 1}.");
                double price = ReadDouble();
                Console.WriteLine($"Введите название овощей в ящике {i + 1} (дополнительный функционал), или нажмите enter, чтобы не называть их.");
                // Сообщаем, получится ли добавить ящик.
                if (newCont.AddBox(weight, price, Console.ReadLine()))
                    Console.WriteLine("Ящик успешно добавлен.");
                else
                    Console.WriteLine("Не удалось добавить ящик, превышен лимит общей массы контейнера.");

            }
            // Сообщаем, получится ли добавить контейнер.
            if (newCont.SumPrice + 1e-15 < stockroom.Payment())
                Console.WriteLine("Стоимость хранения контейнера превышает стоимость содержимого, поэтому контейнер на склад не добавляется.");
            else
            {
                stockroom.AddContainer(newCont);
                Console.WriteLine("Новый контейнер успешно добавлен.\n");
            }
        }
        /// <summary>
        /// Считываем склад с клавиатуры.
        /// </summary>
        /// <returns>Склад.</returns>
        private static Storage StorageFromConsole()
        {
            // Считываем данные и сообщаем, что получилось.
            Console.WriteLine("Для создания склада выберите характеристики.\nСначaла задайте вместимость склада.");
            int lim = ReadInt();
            Console.WriteLine("Задайте цену хранения одного контейнера на складе.");
            double pay = ReadDouble();
            Storage stockroom = new Storage(lim, pay);
            Console.WriteLine("Склад создан.");
            return stockroom;
        }

        /// <summary>
        /// Чтение пути до файла с клавиатуры.
        /// </summary>
        /// <returns>Путь.</returns>
        public static string ReadPath()
        {
            string path = Console.ReadLine();
            // Выпытываем путь до файла, пока пользователь не введет нечто корректное.
            while (!File.Exists(path))
            {
                Console.WriteLine("Такого файла не существует, попробуйте снова.");
                path = Console.ReadLine();
                File.WriteAllText(path, "!");
            }
            return path;
        }
        /// <summary>
        /// Вывод данных о складе.
        /// </summary>
        /// <param name="stockroom">Склад.</param>
        private static void PrintStorage(Storage stockroom)
        {
            string ansFile;
            bool ok = false;
            while (!ok)
            {
                Console.WriteLine("Введите путь до файла для вывода данных о складе.");
                ansFile = Console.ReadLine();
                // Вывод данных о складе.
                try
                {
                    File.WriteAllText(ansFile, stockroom.ToString());
                    ok = true;
                }
                catch (Exception)
                {
                    // Если пользователь ввел некорректный путь, будем ещё его мучить и просим повторить.
                    Console.WriteLine("Некорректный путь, попробуйте снова.\n");
                    ok = false;
                }
            }
        }
        /// <summary>
        /// Выполнение программы, используя данные из 3х файлов.
        /// </summary>
        public static void FileReading()
        {
            bool ok;
            Console.WriteLine("Нужно три файла: с описанием склада (в первой строке - вместимость (натуральное число), во второй - цена хранения (неотрицательное число),\n" +
                "с описанием действий - в отдельной строке 1 для добавления контейнера (тогда описание в третьем файле),\n" +
                "2 для удаления контейнера (тогда в следующей строке номер контейнера - порядок нумерации соответствует порядку добавления контейнеров с 1),\n" +
                "и третий файл с описанием контейнеров по порядку добавления: число ящиков (n) и тогда соответственно 2n строк, в первой строке - масса первого ящика, во второй - цена первого, в слеудующих двух строках - второго и т.д.\n");
            Console.WriteLine("Для считывания из файлов задайте пути до файлов (в первой строке до файла с описанием склада, во второй - действий, и в третьей - контейнеров.");
            // Считываем пути.
            string path1 = ReadPath(), path2 = ReadPath(), path3 = ReadPath();
            Storage stockroom = new Storage(path1, out ok);
            // Проверяем, сможем ли продолжить решать задачу.
            if (!ok)
            {
                Console.WriteLine("В первом файле данные записаны некорректно. Невозможно создать склад, программа завершает построения склада .");
                return;
            }
            // Читаем список команд и данных о контейнерах.
            string[] commands = File.ReadAllLines(path2), info = File.ReadAllLines(path3);
            ok = true;
            for (int i = 0, j = 0; i < commands.Length && ok; ++i)
            {
                switch (commands[i])
                {
                    case "1":
                        // Добавление контейнера.
                        Container newCont = new Container();
                        int n;
                        // Пытаемся считать число ящиков, сообщаем, если ввод некорректен.
                        if (!int.TryParse(info[j], out n))
                        {
                            Console.WriteLine("Некорректное описание в третьем файле, завершение построения склада на данной позиции.");
                            ok = false;
                            break;
                        }
                        ++j;
                        // Пробегаемся по ящикам.
                        for (int k = 0; k < n && ok; ++k, j += 2)
                        {
                            double weight, price;
                            // Пытаемся считать информацию о ящике, сообщаем, если безуспешно.
                            if (!double.TryParse(info[j], out weight) || !double.TryParse(info[j + 1], out price))
                            {
                                ok = false;
                                break;
                            }
                            // Добавляем ящик.
                            newCont.AddBox(weight, price);
                        }
                        // Проверяем, что контейнер оставлять выгодно.
                        if (newCont.SumPrice > 1e-15 + stockroom.Payment() && ok)
                            stockroom.AddContainer(newCont);
                        break;
                    case "2":
                        // Удаляем контейнер.
                        ++i;
                        int num;
                        // Проверяем на корректность.
                        if (!int.TryParse(commands[i], out num) || num > stockroom.Count || num < 1)
                        {
                            Console.WriteLine("Некорректная команда во втором файле, завершение построения склада на данной позиции.");
                            ok = false;
                            break;
                        }
                        // Удаляем контейнер.
                        stockroom.DeleteContainer(num - 1);
                        break;
                    default:
                        // Завершение программы, т.к. непонятно, как интерпретировать дальнейшую информацию в файле.
                        Console.WriteLine("Некорректная команда во втором файле, завершение построения склада на данной позиции.");
                        ok = false;
                        break;
                }
            }
            // Вывод данных о складе.
            PrintStorage(stockroom);
        }
        static void Main(string[] args)
        {
            int mode;
            string input;
            Console.WriteLine("Здравствуйте!\nВ данной программе вам предлагается создать склад с контейнерами с коробками.\n" +
                "Выберите, пожалуйста, способ ввода.");
            // Повтор решения, пока пользователь не попросит выйти.
            do
            {
                // Выпытываем способ ввода, пока пользователь не введет нечто корректное.
                do
                {
                    Console.WriteLine("\nВведите 1, если хотите вводить все параметры с клавиатуры." +
                    "\nВведите 2, если хотите, чтобы программа считывала данные через файлы." +
                    "\nВведите 3, если хотите, чтобы программа завершилась.");
                    input = Console.ReadLine();
                }
                while (!int.TryParse(input, out mode) || mode > 3 || mode < 1);
                // В зависимости от выбора пользователя, получаем информацию из файлов или с клавиатуры или завершаем работу.
                switch (mode)
                {
                    case 1:
                        // Ввод с клавиатуры.
                        ConsoleReading();
                        break;
                    case 2:
                        // Чтение данных из файла.
                        FileReading();
                        break;
                    default:
                        // Завершение работы.
                        break;
                }

            } while (mode != 3);
        }
    }
}
