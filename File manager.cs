using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace PeerReview2
{
    class Program
    {
        public static string ReadFile()
        {
            //Просим ввести и считываем путь к файлу.
            string path;
            Console.WriteLine("Введите путь к нужному текстовому файлу.");
            path = Console.ReadLine();
            //Если файла нет, просим повторить ввод.
            while (!File.Exists(path))
            {
                Console.WriteLine("Ошибка, такого файла не существует. Попробуйте снова.\n" +
                    "Введите путь к нужному текстовому файлу.");
                path = Console.ReadLine();
            }
            //Когда пользователь ввел корректный путь к файлу, возвращаем текст файла.
            return File.ReadAllText(path);
        }
        public static bool DeleteFile()
        {
            string path;
            Console.WriteLine("Введите путь к нужному текстовому файлу.");
            path = Console.ReadLine();
            //Просимввести путь, пока пользователь не введет корректный.
            while (!File.Exists(path))
            {
                Console.WriteLine("Ошибка, такого файла не существует. Попробуйте снова.\n" +
                    "Введите путь к нужному текстовому файлу.");
                path = Console.ReadLine();
            }
            //Когда путь корректен, пытаемся удалить файл.
            try
            {
                File.Delete(path);
            }
            catch (IOException)
            {
                //Если файл уже используется, сообщаем об этом.
                Console.WriteLine("Не удалось удалить файл, т.к. он уже использутеся, нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
                return false;
            }
            catch (Exception e)
            {
                //Если файл не удаляется по иным причинам, сообщаем об этом.
                Console.WriteLine("Не удалось удалить файл, ошибка:\n"+ e.ToString() + "\nНажмите Enter, чтобы продолжить.");
                Console.ReadLine();
                return false;
            }
            //Если все хорошо, сообщаем об этом и просим подтвердить продолжение, чтобы меню не сразу выпадало.
            Console.WriteLine("Файл успешно удалён, нажмите Enter, чтобы продолжить.");
            Console.ReadLine();
            return true;
        }
        public static int ReadInt2()
        {
            //Считываем целое число >= 2.
            Console.WriteLine("Пожалуйста, введите натуральное число большее 1.");
            int n;
            //Пока ввод некорректен, просим повторить.
            while (!int.TryParse(Console.ReadLine(), out n) && n > 1)
            {
                Console.WriteLine("\nНекорректный ввод. Пожалуйста, введите натуральное число большее 1.");
            }
            //Возвращаем полученное значение.
            return n;
        }
        static void Main(string[] args)
        {
            //Создаем переменную для номера команды.
            int command_num;
            Console.WriteLine("Добро пожаловать в Файловый менеджер\n");
            do
            {
                //Считываем команду с клавиатуры с помощью специального метода.
                command_num = GetCommand();
                switch (command_num)
                {
                    case -1:
                        //Пользователь хочет выйти из программы, завершаем работу.
                        continue;
                    case 1:
                        //Просмотр списка дисков компьютера с помощью отдельной процедуры.
                        LookDisks();
                        //Выбор диска.
                        Console.WriteLine("Для выбора диска введите его название.\n");
                        string disk = Console.ReadLine();
                        //Выводим содержимое диска с помощью отдельной функции.
                        ViewDirectory(disk + Path.DirectorySeparatorChar);
                        break;
                    case 2:
                        //Переход в другую директорию (выбор папки).
                        Console.WriteLine("Для выбора папки введите путь.\n");
                        string path = Console.ReadLine();
                        //Информация о папке.
                        ViewDirectory(path);
                        break;
                    case 3:
                        //Просмотр списка файлов в директории.
                        Console.WriteLine("Вы выбрали просмотр списка файлов в директории.\nВведите путь, пожалуйста.");
                        string directory = Console.ReadLine();
                        //Просмотр содержимого директории.
                        ViewDirectory(directory);
                        break;
                    case 4:
                        //Вывод содержимого текстового файла в консоль в кодировке UTF-8.
                        Console.WriteLine("Вы выбрали вывод содержимого текстового файла в консоль в кодировке UTF-8.\n");
                        //Вывод считываемого в отдельной функции файла.
                        Console.WriteLine(ReadFile());
                        Console.WriteLine("\nНажмите Enter, чтобы продолжить.");
                        Console.ReadLine();
                        break;
                    case 5:
                        //Вывод содержимого текстового файла в консоль в выбранной кодировке с помощью отдельной функции.
                        WriteFile();
                        break;
                    case 6:
                        //Копирование файла с помощью отдельной функции.
                        CopyFile();
                        break;
                    case 7:
                        //Перемещение файла в выбранную пользователем директорию с помощью отдельной функции.
                        MoveFile();
                        break;
                    case 8:
                        //Удаление файла с помощью отдельной функции.
                        Console.WriteLine("Вы выбрали удаление файла.");
                        DeleteFile();
                        break;
                    case 9:
                        //Создание простого текстового файла в кодировке UTF-8 с помощью функции для создания файла.
                        NewFile(true);
                        break;
                    case 10:
                        //Создание простого текстового файла в выбранной пользователем кодировке с помощью функции для создания файла.
                        NewFile(false);
                        break;
                    case 11:
                        //Конкатенация содержимого двух или более текстовых файлов и вывод результата в консоль в кодировке UTF-8 с помощью отдельной функции.
                        Concat();
                        break;
                    case 12:
                        //Проверка, есть ли такой файл, с помощью отдельной функции.
                        FileExistention();
                        break;
                    case 13:
                        //Запись строки в существующий файл в выбранной кодировке с помощью отдельной функции.
                        AddLine();
                        break;
                }
            }
            while (command_num > -1);
            //Выход из цикла, если пользователь пожелал завершить работу.
        }

        private static void ViewDirectory(string path)
        {
            //Пытаемся посмотреть содержимое директории.
            try
            {
                string[] s = Directory.GetFiles(path);
                //Выводим все файлы и папки директории.
                Console.WriteLine("Содержимое:");
                foreach (string t in s)
                    Console.WriteLine(t);
            }
            catch (Exception e)
            {
                //Сообщаем об ошибке в случае неудачи.
                Console.WriteLine("Не удалось посмотреть файлы в выбранной директории, произошла ошибка: \n" + e.ToString());
            }
            //Просим подтвердить продолжение, чтобы меню не сразу выпадало.
            Console.WriteLine("\nНажмите Enter, чтобы продолжить.");
            Console.ReadLine();
        }

        private static void CopyFile()
        {
            Console.WriteLine("Вы выбрали копирование текстового файла в UTF-8.\nВведите путь к файлу, который хотите скопировать.");
            //Считываем путь к копируемому файлу, требуем, чтобы он существовал, иначе просим повторить ввод.
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.WriteLine("Ошибка, такого файла не существует. Попробуйте снова.\n" +
                    "Введите путь к нужному текстовому файлу.");
                path = Console.ReadLine();
            }
            //Считываем путь, если такой файл уже есть, просим повторить попытку, пока пользователь не введет новый файл.
            Console.WriteLine("\nВведите путь к новому файлу и его имя.");
            string path_copy = Console.ReadLine();
            while (File.Exists(path_copy))
            {
                Console.WriteLine("Ошибка, такой файл уже существует. Попробуйте снова.\n" +
                    "Введите путь к нужному текстовому файлу.");
                path_copy = Console.ReadLine();
            }
            //Пытаемся скопировать файл.
            try
            {
                File.Copy(path, path_copy);
                //Сообщаем, что копирование успешно, просим подтвердить продолжение, чтобы меню не сразу выпадало.
                Console.WriteLine("Файл успешно скопирован, нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                //Если не получилось, сообщаем об ошибке.
                Console.WriteLine("Не удалось скопировать файл, произошла ошибка: \n" + e.ToString());
                //Просим подтвердить продолжение, чтобы меню не сразу выпадало.
                Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
        }

        private static void MoveFile()
        {
            Console.WriteLine("Вы выбрали перемещение файла.\nВведите путь к файлу, который хотите переместить.");
            //Считываем путь к копируемому файлу, требуем, чтобы он существовал, иначе просим повторить ввод.
            string path = Console.ReadLine();
            while (!File.Exists(path))
            {
                Console.WriteLine("Ошибка, такого файла не существует. Попробуйте снова.\n" +
                    "Введите путь к нужному текстовому файлу.");
                path = Console.ReadLine();
            }
            Console.WriteLine("\nВведите путь, по которому хотите поместить файл (с его именем).");
            string path_move = Console.ReadLine();
            //Считываем путь, если такой файл уже есть, просим повторить попытку, пока пользователь не введет новый файл.
            while (File.Exists(path_move))
            {
                Console.WriteLine("Ошибка, такой файл уже существует. Попробуйте снова.\n" +
                    "Введите путь к нужному текстовому файлу.");
                path_move = Console.ReadLine();
            }
            //Пытаемся переместить файл.
            try
            {
                File.Move(path, path_move);
                //Сообщаем, что перемещение успешно, просим подтвердить продолжение, чтобы меню не сразу выпадало.
                Console.WriteLine("Файл успешно перемещен, нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                //Сообщаем об ошибке, если возникает ошибка
                Console.WriteLine("Не удалось переместить файл, произошла ошибка: \n" + e.ToString());
                //Просим подтвердить продолжение, чтобы меню не сразу выпадало.
                Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
        }

        private static void LookDisks()
        {
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            //Получаем список дисков.
            foreach (DriveInfo d in allDrives)
            {
                //Выводим информацию о дисках.
                Console.WriteLine("Drive {0}", d.Name);
                Console.WriteLine("Drive type: {0}", d.DriveType);
                if (d.IsReady == true)
                {
                    Console.WriteLine("Volume label: {0}", d.VolumeLabel);
                    Console.WriteLine("File system: {0}", d.DriveFormat);
                    Console.WriteLine("Available space to current user:{0, 15} bytes", d.AvailableFreeSpace);
                    Console.WriteLine("Total available space: {0, 15} bytes", d.TotalFreeSpace);
                    Console.WriteLine("Total size of drive: {0, 15} bytes ", d.TotalSize);
                }
            }
        }

        private static int GetCommand()
        {
            int command_num;
            //Пишем длинный текст о возможных командах.
            Console.WriteLine("\nВведите:\n" +
            "1 для просмотра списка дисков компьютера и выбора диска\n" +
            "2 для перехода в другую директорию (выбора папки)\n" +
            "3 для просмотра списка файлов в директории\n" +
            "4 для вывода содержимого текстового файла в консоль в кодировке UTF-8\n" +
            "5 для вывода содержимого текстового файла в консоль в другой кодировке(предоставляется не менее трех вариантов)\n" +
            "6 для копирования файла\n" +
            "7 для перемещения файла в выбранную пользователем директорию\n" +
            "8 для удаления файла\n" +
            "9 для создания простого текстового файла в кодировке UTF-8\n" +
            "10 для создания простого текстового файла в выбранной пользователем кодировке(предоставляется не менее трех вариантов)\n" +
            "11 для конкатенации содержимого двух или более текстовых файлов и вывод результата в консоль в кодировке UTF-8\n" +
            //дополнительные функции
            "12 для проверки существования файла\n" +
            "13 чтобы записать заданную вами строку в существующий файл в выбранной вами кодировке (старое содержимое файла пропадает)\n\n" +
            "-1 для выхода из программы\n");
            //Считываем команду, пока ввод не корректен, повторяем.
            while (!int.TryParse(Console.ReadLine(), out command_num) || command_num > 13 || command_num < -1)
                Console.WriteLine("Некорректный ввод, попробуйте ещё.");
            //Возвращаем номер команды.
            return command_num;
        }

        private static void WriteFile()
        {
            int n = 0;
            //Просим выбрать кодировку, пока ввод некорректен, просим повторить.
            Console.WriteLine("Вы выбрали вывод содержимого текстового файла в консоль. Выберите кодировку:\n" +
                    "для UTF-8 введите 0\n" +
                    "для ASCII введите 1\n" +
                    "для UTF-7 введите 2\n" +
                    "для UTF-16 (Unicode) введите 3\n" +
                    "для UTF-32 введите 4\n");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 4)
                Console.WriteLine("Некорректный ввод. Введите целое число от 0 до 4.\n");
            try
            {
                //Переводим текст в соответствующую кодировку.
                byte[] text;
                string s = ReadFile();
                if (n == 0)
                    text = new UTF8Encoding(true).GetBytes(s);
                else if (n == 1)
                    text = new ASCIIEncoding().GetBytes(s);
                else if (n == 2)
                    text = new UTF7Encoding(true).GetBytes(s);
                else if (n == 3)
                    text = new UnicodeEncoding().GetBytes(s);
                else
                    text = new UTF32Encoding().GetBytes(s);
                //Выводим текст.
                foreach (var x in text)
                    Console.Write(x);
                //Сообщаем, что успешно, и просим подтвердить продолжение, чтобы меню не сразу выпадало.
                Console.WriteLine("\nУспешно, нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                //Если возникла ошибка, сообщаем об этом пользователю.
                Console.WriteLine("Не удалось создать файл, произошла ошибка: \n" + e.ToString());
                //Просим подтвердить продолжение, чтобы меню не сразу выпадало.
                Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
            return;
        }

        private static void NewFile(bool utf8)
        {
            int n = 0;
            //В переменной utf8 содержится информация о том, хотел ли пользователь выбрать отличную от UTF-8 кодировку.
            if (!utf8)
            {
                //Просим ввести кодировку до тех пор, пока ввод не будет корректен.
                Console.WriteLine("Вы выбрали создание текстового файла. Выберите кодировку:\n" +
                    "для ASCII введите 1\n" +
                    "для UTF-7 введите 2\n" +
                    "для UTF-16 (Unicode) введите 3\n" +
                    "для UTF-32 введите 4\n");
                while (!int.TryParse(Console.ReadLine(), out n) || n < 1 || n > 4)
                    Console.WriteLine("Некорректный ввод. Введите целое число от 1 до 4.\n");
            }
            else
                Console.WriteLine("Вы выбрали создание текстового файла в UTF-8.");
            //Просим ввести путь к файлу.
            Console.WriteLine("Введите путь к файлу (с именем файла).");
            string path = Console.ReadLine();
            try
            {
                //Пытаемся создать файл в нужной кодировке.
                using (FileStream fs = File.Create(path))
                {
                    byte[] text;
                    if (utf8)
                        text = new UTF8Encoding(true).GetBytes("New file.");
                    else if (n == 1)
                        text = new ASCIIEncoding().GetBytes("New file.");
                    else if (n == 2)
                        text = new UTF7Encoding(true).GetBytes("New file.");
                    else if (n == 3)
                        text = new UnicodeEncoding().GetBytes("New file.");
                    else
                        text = new UTF32Encoding().GetBytes("New file.");
                    fs.Write(text, 0, text.Length);
                    //Сообщаем, что успешно, просим подтвердить продолжение, чтобы меню не сразу выпадало.
                    Console.WriteLine("Файл успешно создан, нажмите Enter, чтобы продолжить.");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                //Сообщаем об ошибке, если она возникла.
                Console.WriteLine("Не удалось создать файл, произошла ошибка: \n" + e.ToString());
                //Просим подтвердить продолжение, чтобы меню не сразу выпадало.
                Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
        }

        private static void Concat()
        {
            Console.WriteLine("Вы выбрали конкатенацию содержимого двух или более текстовых файлов и вывод результата в консоль в кодировке UTF-8.\n" +
                "Сколько файлов вы хотите сконкатенировать?");
            //Просим пользователя ввести число файлов (от 2х), для этого запускаем отдельную функцию.
            int n = ReadInt2(), i;
            Console.WriteLine($"Вы выбрали конкатенацию {n} файлов.");
            string ans = "";
            //Считываем содержимое файлов отдельной функцией.
            for (i = 0; i < n; ++i)
                ans += ReadFile();
            //Выводим результат
            Console.WriteLine(ans);
            //Просим подтвердить продолжение, чтобы меню не сразу выпадало.
            Console.WriteLine("\nНажмите Enter, чтобы продолжить.");
            Console.ReadLine();
        }
        private static void FileExistention()
        {
            Console.WriteLine("Вы выбрали проверку на существование файла.\nВведите путь к файлу, наличие которого хотите проверить.");
            //Считываем путь к файлу.
            string path = Console.ReadLine();
            //Сообщаем о (не)существовании
            if (File.Exists(path))
                Console.WriteLine("Такой файл существует.");
            else
                Console.WriteLine("Такого файла не существует.");
            //Просим подтвердить продолжение, чтобы меню не сразу выпадало.
            Console.WriteLine("\nНажмите Enter, чтобы продолжить.");
            Console.ReadLine();
        }
        private static void AddLine()
        {
            int n = 0;
            //Просим выбрать кодировку, пока ввод некорректен, просим повторить.
            Console.WriteLine("Вы выбрали запись строки в файл. Выберите кодировку:\n" +
                    "для UTF-8 введите 0\n" +
                    "для ASCII введите 1\n" +
                    "для UTF-7 введите 2\n" +
                    "для UTF-16 (Unicode) введите 3\n" +
                    "для UTF-32 введите 4\n");
            while (!int.TryParse(Console.ReadLine(), out n) || n < 0 || n > 4)
                Console.WriteLine("Некорректный ввод. Введите целое число от 0 до 4.\n");
            //Просим ввести путь к файлу.
            Console.WriteLine("Введите путь к файлу (с именем файла).");
            string path = Console.ReadLine();
            //Просить ввести строку для записи в файл.
            Console.WriteLine("Введите строку, которую хотите записать в файл.");
            string s = Console.ReadLine();
            try
            {
                //Пытаемся записать строку в нужной кодировке.
                using (FileStream fs = File.Create(path))
                {
                    byte[] text;
                    if (n == 0)
                        text = new UTF8Encoding(true).GetBytes(s);
                    else if (n == 1)
                        text = new ASCIIEncoding().GetBytes(s);
                    else if (n == 2)
                        text = new UTF7Encoding(true).GetBytes(s);
                    else if (n == 3)
                        text = new UnicodeEncoding().GetBytes(s);
                    else
                        text = new UTF32Encoding().GetBytes(s);
                    fs.Write(text, 0, text.Length);
                    //Сообщаем, что успешно, просим подтвердить продолжение, чтобы меню не сразу выпадало.
                    Console.WriteLine("Строка успешно записана, нажмите Enter, чтобы продолжить.");
                    Console.ReadLine();
                }
            }
            catch (Exception e)
            {
                //Сообщаем об ошибке, если она возникла.
                Console.WriteLine("Не удалось добавить строку, произошла ошибка: \n" + e.ToString());
                //Просим подтвердить продолжение, чтобы меню не сразу выпадало.
                Console.WriteLine("Нажмите Enter, чтобы продолжить.");
                Console.ReadLine();
            }
        }
    }
}
