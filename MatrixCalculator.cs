using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO.Pipes;
using System.Linq;
using System.Reflection.Metadata;

namespace PeerReview3
{
    class Program
    {
        ///<summary>
        ///Функция считывания действительного числа с клавиатуры.
        ///</summary>
        public static double ReadNum()
        {
            // Инициализируем переменную для ответа.
            double ans;
            Console.WriteLine("Введите число.");
            // Вводим, пока не корректно.
            while (!double.TryParse(Console.ReadLine(), out ans))
                Console.WriteLine("Некорректный ввод, пожалуйста, введите число (если вы вводили число с запятой, попробуйте с точкой, и наоборот).");
            return ans;
        }
        ///<summary>
        ///Функция считывания квадратной матрицы с клавиатуры.
        ///</summary>
        public static List<List<double>> ReadSquareMatrix(int size = 0)
        {
            // Инициализируем матрицу для ответа.
            List<List<double>> ans = new List<List<double>>();
            int i, j;
            // Если не передан размер, считываем.
            if (size == 0)
            {
                Console.WriteLine("Сначала выберите размеры (количество строк, оно же - столбцов) новой матрицы, для этого введите натуральное число от 1 до 10.");
                while (!int.TryParse(Console.ReadLine(), out size) || size > 10 || size < 1)
                    Console.WriteLine("Некорректный ввод, введите натуральное число от 1 до 10.");
            }
            Console.WriteLine("Теперь вводите элементы новой матрицы по одному в строке.");
            for (i = 0; i < size; ++i)
            {
                ans.Add(new List<double>());
                for (j = 0; j < size; ++j)
                {
                    // Считываем элементы матрицы по одному.
                    Console.WriteLine($"Введите элемент {i+1}-ой строки {j+1}-ого столбца.");
                    ans[i].Add(ReadNum());
                }
            }
            // Вывод результата.
            Console.WriteLine("Вы ввели матрицу: ");
            PrintMatrix(ans);
            return ans;
        }
        ///<summary>
        ///Функция считывания матрицы с клавиатуры.
        ///</summary>
        public static List<List<double>> ReadMatrix(int rowCnt = 0, int colCnt = 0)
        {
            // Инициализируем матрицу для ответа.
            List<List<double>> ans = new List<List<double>>();
            int i, j;
            // Если не передано колиество столбцов, считываем.
            if (colCnt == 0)
            {
                Console.WriteLine("Введите натуральное число от 1 до 10 - число столбцов новой матрицы.");
                while (!int.TryParse(Console.ReadLine(), out colCnt) || colCnt > 10 || colCnt < 1)
                    Console.WriteLine("Некорректный ввод, введите натуральное число от 1 до 10.");
            }
            // Если не передано колиество строк, считываем.
            if (rowCnt == 0)
            {
                Console.WriteLine("Введите натуральное число от 1 до 10 - число строк новой матрицы.");
                while (!int.TryParse(Console.ReadLine(), out rowCnt) || rowCnt > 10 || rowCnt < 1)
                    Console.WriteLine("Некорректный ввод, введите натуральное число от 1 до 10.");
            }
            Console.WriteLine("Теперь вводите элементы новой матрицы по одному в строке.");
            for (i = 0; i < rowCnt; ++i)
            {
                ans.Add(new List<double>());
                for (j = 0; j < colCnt; ++j)
                {
                    // Считываем элементы матрицы по одному.
                    Console.WriteLine($"Введите элемент {i+1}-ой строки {j+1}-ого столбца.");
                    ans[i].Add(ReadNum());
                }
            }
            //Вывод результата.
            Console.WriteLine("Вы ввели матрицу: ");
            PrintMatrix(ans);
            return ans;
        }
        ///<summary>
        ///Функция вывода матрицы на экран.
        ///</summary>
        public static void PrintMatrix(List<List<double>> matrix)
        {
            int i, j;
            // Проходимся по матрице.
            for (i = 0; i < matrix.Count; ++i)
            {
                for (j = 0; j < matrix[i].Count; ++j)
                {
                    // Выводим элементы одной строки в одну строку.
                    Console.Write(matrix[i][j]);
                    Console.Write(" ");
                }
                // Переводим строку для новой строки матрицы.
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        ///<summary>
        ///Функция вычисления следа квадратной матрицы.
        ///</summary>
        public static double Trace(List<List<double>> matrix)
        {
            // Инициализируем переменную для ответа.
            double ans = 0;
            // Считаем след.
            for (int i = 0; i < Math.Min(matrix.Count, matrix[0].Count); ++i)
                ans += matrix[i][i];
            // Возвращаем результат.
            return ans;
        }
        ///<summary>
        ///Функция транспонирования матрицы.
        ///</summary>
        public static List<List<double>> Transpose(List<List<double>> matrix)
        {
            // Инициализируем матрицу для ответа.
            List<List<double>> ansMatrix = new List<List<double>>();
            // Проходимся по столбцам.
            for (int i = 0; i < matrix[0].Count; ++i)
            {
                // Создаем ячейки в матрице ответов.
                ansMatrix.Add(new List<double>());
                for (int j = 0; j < matrix.Count; ++j)
                    ansMatrix[i].Add(0);
                // Проходимся по строкам и присваиваем значение.
                for (int j = 0; j < matrix.Count; ++j)
                    ansMatrix[i][j] = matrix[j][i];
            }
            return ansMatrix;
        }
        ///<summary>
        ///Функция сложения двух матриц.
        ///</summary>
        public static List<List<double>> Sum(List<List<double>> matrixFirst, List<List<double>> matrixSecond)
        {
            // Инициализируем матрицу для ответа.
            List<List<double>> ansMatrix = new List<List<double>>();
            for (int i = 0; i < matrixFirst.Count; ++i)
            {
                // Суммируем поэлементно
                ansMatrix.Add(new List<double>());
                for (int j = 0; j < matrixFirst[i].Count; ++j)
                    ansMatrix[i].Add(matrixFirst[i][j] + matrixSecond[i][j]);
            }
            return ansMatrix;
        }
        ///<summary>
        ///Функция умножения двух матриц.
        ///</summary>
        public static List<List<double>> Multiplication(List<List<double>> matrixFirst, List<List<double>> matrixSecond)
        {
            //Инициализируем матрицу для ответа.
            List<List<double>> ansMatrix = new List<List<double>>();
            // Проходимся по строкам новой матрицы
            for (int i = 0; i < matrixFirst.Count; ++i)
            {
                ansMatrix.Add(new List<double>(matrixFirst.Count));
                // Проходимся по столбцам итоговой матрицы
                for (int j = 0; j < matrixSecond[0].Count; ++j)
                {
                    //Считаем каждый элемент отдельно, умножая строку первой матрицы на столбец второй поэлементно.
                    double cntCell = 0;
                    for (int k = 0; k < matrixSecond.Count; ++k)
                        cntCell += matrixFirst[i][k] * matrixSecond[k][j];
                    // Присваиваем ячейке соответствующее значение.
                    ansMatrix[i].Add(cntCell);
                }
                //  ansMatrix[i][j] = matrixFirst[i][j] + matrixSecond[i][j];
            }
            return ansMatrix;
        }
        ///<summary>
        ///Функция умножения матрицы на число.
        ///</summary>
        public static List<List<double>> Multiplication(List<List<double>> matrix, double number)
        {
            //Инициализируем матрицу для ответа.
            List<List<double>> ansMatrix = new List<List<double>>();
            // Проходимся по строкам
            for (int i = 0; i < matrix.Count; ++i)
            {
                ansMatrix.Add(new List<double>());
                // Проходимся по столбцам.
                for (int j = 0; j < matrix[i].Count; ++j)
                    // Умножаем каждый элемент на число.
                    ansMatrix[i].Add(number * matrix[i][j]);
            }
            return ansMatrix;
        }
        ///<summary>
        ///Функция получает из матрицы нужный минор и возвращает его
        ///</summary>
        public static List<List<double>> Minor(List<List<double>> matrix, int row, int col)
        {
            //Инициализируем матрицу для ответа.
            List<List<double>> ansMatrix = new List<List<double>>();
            for (int i = 0; i < matrix.Count; ++i)
                // Добавляем элемент в минор, если подходящая строка.
                if (i != row)
                {
                    ansMatrix.Add(new List<double>());
                    for (int j = 0; j < matrix[i].Count; ++j)
                        // Добавляем элемент в минор, если подходящий столбец.
                        if (j != col)
                            ansMatrix[i < row ? i : i - 1].Add(matrix[i][j]);
                }
            return ansMatrix;
        }
        ///<summary>
        ///Функция для определния знака в разложении для соотвествующей ячецки матрицы.
        ///</summary>
        public static int Sign(int sum)
        {
            //(-1)^(i + j)
            return sum % 2 == 0 ? 1 : -1;
        }
        ///<summary>
        ///Функция для подсчета детерминанта квадратной матрицы.
        ///</summary>
        public static double Determinant(List<List<double>> matrix)
        {
            // Если матрица 1х1, считаем вручную.
            if (matrix.Count == 1)
                return matrix[0][0];
            // Если матрица 2х2, тоже считаем вручную.
            if (matrix.Count == 2)
                return matrix[0][0] * matrix[1][1] - matrix[1][0] * matrix[0][1];
            double det = 0;
            // Если матрица больше, чем 2х2, раскладываем по строке.
            for (int i = 0; i < matrix.Count; ++i)
                // Считаем определители миноров рекурсивно.
                det += matrix[0][i] * Sign(i + 0) * Determinant(Minor(matrix, 0, i));
            return det;
        }
        ///<summary>
        ///Функция для создания вектора конкретного размера с заданными элементами типа double.
        ///</summary>
        public static List<double> NewList(int size, double elem)
        {
            // Создает вектор для ответа.
            List<double> ans = new List<double>();
            // Заполняем вектор элементами.
            for (int i = 0; i < size; ++i)
                ans.Add(elem);
            return ans;
        }
        ///<summary>
        ///Функция для создания вектора конкретного размера с заданными элементами типа int.
        ///</summary>
        public static List<int> NewList(int size, int elem)
        {
            // Создает вектор для ответа.
            List<int> ans = new List<int>();
            // Заполняем вектор элементами.
            for (int i = 0; i < size; ++i)
                ans.Add(elem);
            return ans;
        }
        ///<summary>
        ///Функция для решения СЛАУ методом Гаусса.
        ///</summary>
        public static void SolvSLE()
        {
            Console.WriteLine("Вы выбрали команду вычисления корней СЛАУ по соответствующей матрице.");
            // Инициализируем массивы ответов и для решения, размер матрицы и число переменных, считываем матрицу уравнения.
            List<List<double>> matrix = ReadMatrix();
            int size = matrix.Count, xCnt = matrix[0].Count - 1;
            List<double> ans = NewList(xCnt, 0.0);
            List<int> rows = NewList(xCnt, -1);
            // Реализуем метод Гаусса.
            for (int col = 0, row = 0; col < xCnt && row < size; ++col)
            {
                int sel = row;
                for (int i = row; i < size; ++i)
                    if (Math.Abs(matrix[i][col]) > Math.Abs(matrix[sel][col]))
                        sel = i;
                if (Math.Abs(matrix[sel][col]) < double.Epsilon)
                    continue;
                for (int i = col; i <= xCnt; ++i)
                {
                    double t = matrix[sel][i];
                    matrix[sel][i] = matrix[row][i];
                    matrix[row][i] = t;
                }
                rows[col] = row;
                for (int i = 0; i < size; ++i)
                    if (i != row)
                    {
                        double c = matrix[i][col] / matrix[row][col];
                        for (int j = col; j <= xCnt; ++j)
                            matrix[i][j] -= matrix[row][j] * c;
                    }
                ++row;
            }
            // Вычисляем итоговое решение СЛАУ.
            for (int i = 0; i < xCnt; ++i)
                if (rows[i] != -1)
                    ans[i] = matrix[rows[i]][xCnt] / matrix[rows[i]][i];
            // Выводим решение.
            PrintSolution(matrix, ans, size, xCnt, rows);
        }

        ///<summary>
        ///Функция вывода решений СЛАУ.
        ///</summary>
        private static void PrintSolution(List<List<double>> matrix, List<double> ans, int n, int m, List<int> rows)
        {
            // Проверяем не 0 ли решений у уравнения.
            for (int i = 0; i < n; ++i)
            {
                double sum = 0;
                for (int j = 0; j < m; ++j)
                    sum += ans[j] * matrix[i][j];
                if (Math.Abs(sum - matrix[i][m]) > double.Epsilon)
                {
                    // Сообщаем, что нет решений.
                    Console.WriteLine("Нет решений.");
                    return;
                }
            }
            // Проверяем, если решений бесконечно много.
            for (int i = 0; i < m; ++i)
                if (rows[i] == -1)
                {
                    // Сообщаем, что решений бесконечно много.
                    Console.WriteLine("Решений бесконечно много.");
                    return;
                }
            // Если решений не 0 и не бесконечно, оно одно (по известной теореме), выводим его.
            Console.WriteLine("Одно решение.");
            for (int i = 0; i < ans.Count; ++i)
                Console.WriteLine($"x{i + 1} = {ans[i]}");
        }

        ///<summary>
        ///Функция вывода списка команд.
        ///</summary>
        public static void WriteCommandList()
        {
            Console.WriteLine("Введите -1, чтобы завершить программу,\n" +
                "1, чтобы найти след матрицы,\n" +
                "2, чтобы транспонировать матрицу,\n"+
                "3, чтобы посчитать сумму двух матриц,\n"+
                "4, чтобы посчитать разность двух матриц,\n"+
                "5, чтобы посчитать произведение двух матриц,\n"+
                "6, чтобы умножить матрицу на число,\n" +
                "7, чтобы посчитать определитель матрицы.\n"+
                "8, чтобы вычислить корни СЛАУ по соответствующей матрице.\n");
        }
        ///<summary>
        ///Функция выбора команды.
        ///</summary>
        public static bool Command()
        {
            string command = GetCommand();
            switch (command)
            {
                case "?":
                    WriteCommandList();
                    break;
                case "1":
                    // Вычисляем след матрицы.
                    TraceCommand();
                    break;
                case "2":
                    // Транспонируем матрицу.
                    TCommand();
                    break;
                case "3":
                    // Считаем сумму двух матриц.
                    SumCommand();
                    break;
                case "4":
                    // Считаем разность двух матриц.
                    SubtrCommand();
                    break;
                case "5":
                    // Произведение матриц.
                    MultiplicationMatricesCommand();
                    break;
                case "6":
                    // Произведение матрицы на число.
                    MultiplicationMatrixNumberCommand();
                    break;
                case "7":
                    // Определитель матрицы.
                    DetCommand();
                    break;
                case "8":
                    // Решение СЛАУ методом Гаусса.
                    SolvSLE();
                    break;
                case "-1":
                    // Выход из прогрммы.
                    return false;
                default:
                    // Когда ввели неправильный номер команды, сообщаем, что комманды нет.
                    Console.WriteLine("Такой команды нет.");
                    break;
            }
            return true;
        }

        ///<summary>
        ///Функция для выполнения 7-ой команды - вычисления определителя.
        ///</summary>
        private static void DetCommand()
        {
            Console.WriteLine("Вы выбрали команду вычисления определителя матрицы.");
            Console.WriteLine($"Определитель введенной вами матрицы равен {Determinant(ReadSquareMatrix())}.\n");
        }

        ///<summary>
        ///Функция для выполнения 6-ой команды - произведения матрицы на число.
        ///</summary>
        private static void MultiplicationMatrixNumberCommand()
        {
            Console.WriteLine("Вы выбрали команду произведения матрицы на число.");
            // Просим ввести матрицу, потом число и выводим.
            PrintMatrix(Multiplication(ReadMatrix(), ReadNum()));
        }

        ///<summary>
        ///Функция для выполнения 5-ой команды - произведения матриц.
        ///</summary>
        private static void MultiplicationMatricesCommand()
        {
            Console.WriteLine("Вы выбрали команду произведения двух матриц. Количетво столбцов первой должно совпадать с количеством строк второй.");
            // Просим ввести матрицы, потом считаем произведение и выводим.
            List<List<double>> lleftMatrix = ReadMatrix();
            // Сначала считываем первую матрицу, чтобы вторую считать с правильными размерами.
            PrintMatrix(Multiplication(lleftMatrix, ReadMatrix(lleftMatrix[0].Count)));
        }

        ///<summary>
        ///Функция для выполнения 4-ой команды - разности матриц.
        ///</summary>
        private static void SubtrCommand()
        {
            Console.WriteLine("Вы выбрали команду разности двух матриц. Введите, пожалуйста, матрицы одинаковых размеров.");
            // Просим ввести матрицы, потом вычитаем одну из другой и выводим.
            List<List<double>> leftMatrix = ReadMatrix();
            // Сначала считываем первую матрицу, чтобы вторую считать с теми же размерами, потом вычитаем - суммируем, умножив на (-1).
            PrintMatrix(Sum(leftMatrix, Multiplication(ReadMatrix(leftMatrix.Count, leftMatrix[0].Count), -1)));
        }

        ///<summary>
        ///Функция для выполнения 3-ой команды - суммы матриц.
        ///</summary>
        private static void SumCommand()
        {
            Console.WriteLine("Вы выбрали команду суммирования двух матриц. Введите, пожалуйста, матрицы одинаковых размеров.");
            // Просим ввести матрицы, потом суммируем их и выводим.
            List<List<double>> firstMatrix = ReadMatrix();
            // Сначала считываем первую матрицу, чтобы вторую считать с теми же размерами, потом суммируем и выводим.
            PrintMatrix(Sum(firstMatrix, ReadMatrix(firstMatrix.Count, firstMatrix[0].Count)));
        }

        ///<summary>
        ///Функция для выполнения 2-ой команды - транспонирования.
        ///</summary>
        private static void TCommand()
        {
            Console.WriteLine("Вы выбрали команду транспонирования матрицы.");
            // Просим ввести матрицу, потом транспонируем её и выводим.
            PrintMatrix(Transpose(ReadMatrix()));
        }

        ///<summary>
        ///Функция для ввода матрицы и вывода следа.
        ///</summary>
        private static void TraceCommand()
        {
            Console.WriteLine("Вы выбрали команду вычисления следа матрицы.");
            // Просим ввести матрицу, потом от нее считаем след и выводим.
            Console.WriteLine($"След введенной вами матрицы равен {Trace(ReadSquareMatrix())}.\n");
        }

        ///<summary>
        ///Функция для считывания команды.
        ///</summary>
        private static string GetCommand()
        {
            string command;
            do
            {
                // Сообщаем пользоваелю, что делать и считываем команду, пока вводено не целое число и не ?.
                Console.WriteLine("Выберите целое число - номер команды, которую хотите выполнить,\nили введите \"-1\" для выхода\nили \"?\" для получения информации о возможных командах.");
                command = Console.ReadLine();
            }
            while (command != "?" && !(int.TryParse(command, out _)));
            return command;
        }
        ///<summary>
        ///Основная функция программы.
        ///</summary>
        static void Main(string[] args)
        {
            // Вывод приветствия пользователя.
            Console.WriteLine("Добро пожаловать в калькулятор матриц.\nДля получения информации о возможных командах введите \"?\"");
            // Пользователь выбирает команду, пока не решит выйти из программы.
            while (Command()) { };
        }
    }
}
