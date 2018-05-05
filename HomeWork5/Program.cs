using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportLibrary;

/// <summary>
/// Максим Торопов
/// Ярославль
/// Домашняя работа 5 урока
/// 
/// Достаточно решить 3 задачи.
/// Старайтесь разбивать программы на подпрограммы.
/// Переписывайте в начало программы условие и свою фамилию.
/// Все программы сделать в одном решении.
/// Для решения задач используйте неизменяемые строки (string)
/// </summary>
namespace HomeWork5
{
    class Program
    {
        /// <summary>
        /// Main program
        /// </summary>
        static void Main()
        {
            do
            {
                SupportMethods.PrepareConsoleForHomeTask("1 - Task 1\n" +
                  "2 - Task 2\n" +
                  "3 - Task 3\n" +
                  "4 - Task 4\n" +
                  "0 (Esc) - Exit\n");
                ConsoleKeyInfo key = Console.ReadKey();
                Console.WriteLine();
                switch (key.Key)
                {
                    case ConsoleKey.D1:
                        Task1();
                        break;
                    case ConsoleKey.D2:
                        Task2();
                        break;
                    case ConsoleKey.D3:
                        Task3();
                        break;
                    case ConsoleKey.D4:
                        Task4();
                        break;
                    case ConsoleKey.D0:
                    case ConsoleKey.Escape:
                        return;
                    default:
                        break;
                }
            } while (true);
        }

        /// <summary>
        /// Задание 1.
        /// Создать программу, которая будет проверять корректность ввода логина.
        /// Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при этом цифра не может быть первой.
        /// а) без использования регулярных выражений;
        /// б) **с использованием регулярных выражений.
        /// </summary>
        static void Task1()
        {
            // Prepare console for Task1
            SupportMethods.PrepareConsoleForHomeTask($"Задание 1.\n" +
                "Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при этом цифра не может быть первой.\n" +
                "а) без использования регулярных выражений;");
            CheckLoginComplexity username = new CheckLoginComplexity();

            if (username.CheckLoginComplexitySimple()) { SupportMethods.Pause($"{username.GetUsername} Complexity is OK!"); }

            // Prepare console for Task1
            SupportMethods.PrepareConsoleForHomeTask("Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при этом цифра не может быть первой.\n" +
                "б) **с использованием регулярных выражений.");

            if (username.CheckLoginComplexityRegEx()) { SupportMethods.Pause($"{username.GetUsername} Complexity is OK!"); }

        }

        /// <summary>
        /// Задание 2.
        /// Разработать методы для решения следующих задач. Дано сообщение:
        /// а) Вывести только те слова сообщения, которые содержат не более чем n букв;
        /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
        /// в) Найти самое длинное слово сообщения;
        /// г) Найти все самые длинные слова сообщения.
        /// Постараться разработать класс MyString.
        /// </summary>
        static void Task2()
        {
            // Default message
            // Я вас любил: любовь еще, быть может,
            // В душе моей угасла не совсем;
            // Но пусть она вас больше не тревожит;
            // Я не хочу печалить вас ничем.
            // Я вас любил безмолвно, безнадежно,
            // То робостью, то ревностью томим;
            // Я вас любил так искренно, так нежно,
            // Как дай вам бог любимой быть другим.
            MyString message = new MyString();

            // Prepare console for Task2 with default message
            SupportMethods.PrepareConsoleForHomeTask($"Задание 2.\n" +
                $"Разработать методы для решения следующих задач. Дано сообщение:\n" +
                $"{message.GetMessage}\n" +
                $"а) Вывести только те слова сообщения, которые содержат не более чем n букв;\n");

            // Prepare console for а) Вывести только те слова сообщения, которые содержат не более чем n букв
            //SupportMethods.PrepareConsoleForHomeTask("Разработать методы для решения следующих задач. Дано сообщение:\n" +
            //    "а) Вывести только те слова сообщения, которые содержат не более чем n букв;");
            // MyString message = new MyString("Please type your message: ");
                        
            message.GetWords(SupportMethods.RequestIntValue("Please type max word length (n): "));
            SupportMethods.Pause();

            // Prepare console for б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
            SupportMethods.PrepareConsoleForHomeTask("Разработать методы для решения следующих задач. Дано сообщение:\n" +
                "б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;\n");
            SupportMethods.Pause($"Result:\n" +
                $"{message.DeleteWords(SupportMethods.RequestChar("Please type char: "))}");

            // Prepare console for б) в) Найти самое длинное слово сообщения;
            // г) Найти все самые длинные слова сообщения.
            SupportMethods.PrepareConsoleForHomeTask("Разработать методы для решения следующих задач. Дано сообщение:\n" +
                "в) Найти самое длинное слово сообщения;\n" +
                "г) Найти все самые длинные слова сообщения.\n");
            message.GetMaxWord();
            SupportMethods.Pause();
            
        }

        /// <summary>
        /// Задание 3.
        /// 3. *Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.
        /// а) с использованием методов C#
        /// б) *разработав собственный алгоритм
        /// Например:
        /// badc являются перестановкой abcd
        /// </summary>
        static void Task3()
        {
            // Prepare console for Task3
            SupportMethods.PrepareConsoleForHomeTask($"Задание 3.\n" +
                "*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.\n" +
                "а) с использованием методов C#\n");

            MyStrings str1 = new MyStrings("Please type first string: ");
            MyStrings str2 = new MyStrings("Please type second string: ");

            //using SortString Method
            if (str1.SortString() == str2.SortString())
            {
                SupportMethods.Pause($"Строка {str1.GetString} является перестановкой {str2.GetString}");
            }
            else
            {
                SupportMethods.Pause($"Строка {str1.GetString} не является перестановкой {str2.GetString}");
            }

            //using OrderBy & SequenceEqual            
            if (str1.GetString.OrderBy(x => x).SequenceEqual(str2.GetString.OrderBy(x => x)))
            {
                SupportMethods.Pause($"Строка {str1.GetString} является перестановкой {str2.GetString}");
            }
            else
            {
                SupportMethods.Pause($"Строка {str1.GetString} не является перестановкой {str2.GetString}");
            }

            SupportMethods.PrepareConsoleForHomeTask($"Задание 3.\n" +
                "*Для двух строк написать метод, определяющий, является ли одна строка перестановкой другой. Регистр можно не учитывать.\n" +
                "б) *разработав собственный алгоритм\n");
            //using MyStrings Class and CheckTransposition Method
            if (str1.CheckTransposition(str2.GetString))
            {
                SupportMethods.Pause($"Строка {str1.GetString} является перестановкой {str2.GetString}");
            }
            else
            {
                SupportMethods.Pause($"Строка {str1.GetString} не является перестановкой {str2.GetString}");
            }


        }

        /// <summary>
        /// Задание 4.
        /// *Задача ЕГЭ.
        /// На вход программе подаются сведения о сдаче экзаменов учениками 9-х классов некоторой средней школы.
        /// В первой строке сообщается количество учеников N, которое не меньше 10, но не превосходит 100, каждая из следующих N строк имеет следующий формат:
        /// <Фамилия> <Имя> <оценки>, где
        /// <Фамилия> – строка, состоящая не более чем из 20 символов,
        /// <Имя> – строка, состоящая не более чем из 15 символов,
        /// <оценки> – через пробел три целых числа, соответствующие оценкам по пятибалльной системе.
        /// <Фамилия> и <Имя>, а также <Имя> и <оценки> разделены одним пробелом.
        /// Пример входной строки: Иванов Петр 4 5 3
        /// Требуется написать как можно более эффективную программу, которая будет выводить на экран фамилии и имена трех худших по среднему баллу учеников.
        /// Если среди остальных есть ученики, набравшие тот же средний балл, что и один из трех худших, то следует вывести и их фамилии и имена.
        /// </summary>
        static void Task4()
        {
            // Prepare console for Task3
            SupportMethods.PrepareConsoleForHomeTask($"Задание 4.\n");

            // Comment next 2 strings if you want to fill strings randomly (example can be found in students.txt
            int n = SupportMethods.RequestIntValue("Please input first string (students quantity N): ");
            UnifiedStateExam records = new UnifiedStateExam(n);

            // UnComment nexy string if you want to fill strings randomly
            // UnifiedStateExam records = new UnifiedStateExam();

            SupportMethods.Pause($"\n" +
            $"{records.ToString()}");

            int m1, m2, m3;

            records.Get3MinimalAverageValues(out m1, out m2, out m3);
            records.PrintOutAllWorstStudents(m1, m2, m3);

            SupportMethods.Pause();



        }
    }
}
