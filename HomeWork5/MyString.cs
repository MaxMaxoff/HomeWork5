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
/// </summary>
namespace HomeWork5
{
    /// <summary>
    /// Класс для задания 2
    /// MyString Class
    /// </summary>
    class MyString
    {
        /// <summary>
        /// String for message
        /// </summary>
        string message;

        /// <summary>
        /// Array of delimiters
        /// </summary>
        char[] delimiters = { ' ', ',', ';', ':', '.', '!', '?' };

        /// <summary>
        /// Initialize new message with default string
        /// Я вас любил: любовь еще, быть может,
        /// В душе моей угасла не совсем;
        /// Но пусть она вас больше не тревожит;
        /// Я не хочу печалить вас ничем.
        /// Я вас любил безмолвно, безнадежно,
        /// То робостью, то ревностью томим;
        /// Я вас любил так искренно, так нежно,
        /// Как дай вам бог любимой быть другим.
        /// </summary>
        public MyString()
        {
            message = "Я вас любил: любовь еще, быть может,\n" +
                "В душе моей угасла не совсем;\n" +
                "Но пусть она вас больше не тревожит;\n" +
                "Я не хочу печалить вас ничем.\n" +
                "Я вас любил безмолвно, безнадежно,\n" +
                "То робостью, то ревностью томим;\n" +
                "Я вас любил так искренно, так нежно,\n" +
                "Как дай вам бог любимой быть другим.";            
        }

        /// <summary>
        /// Initialize new message
        /// </summary>
        /// <param name="message"></param>
        public MyString(string msg)
        {
            message = SupportMethods.RequestString(msg);
        }

        /// <summary>
        /// Properties resturn message value
        /// </summary>
        public string GetMessage
        {
            get
            {
                return message;
            }
        }

        /// <summary>
        /// Method GetWords
        /// а) Вывести только те слова сообщения, которые содержат не более чем n букв;
        /// </summary>
        /// <param name="n">max word length</param>
        public void GetWords(int n)
        {
            //create array of strings
            string[] a;

            //split string to array of strings according to list of delimiters
            a = message.Split(delimiters);
            
            foreach(string element in a)
            {
                if (element.Length <= n && element.Length > 0 && Char.IsLetterOrDigit(element[0])) { Console.WriteLine(element); }
            }
        }

        /// <summary>
        /// Method DeleteWords
        /// б) Удалить из сообщения все слова, которые заканчиваются на заданный символ;
        /// </summary>
        /// <param name="ch">requested character</param>
        /// <returns>string str (updated message)</returns>
        public string DeleteWords(char ch)
        {
            //make a copy of the message
            string str = message;

            //create array of strings
            string[] a;

            //split string to array of strings according to list of delimiters
            a = str.Split(delimiters);
                        
            //check all words in array
            for (int i = 0; i < a.Length; i++)
            {
                //we should work only with non empty elements
                if (a[i].Length > 0)
                {
                    //If element of the string array ends with requested symbol then remove from string
                    if (a[i].EndsWith(ch.ToString()))
                    {
                        str = str.Remove(str.IndexOf(a[i]), a[i].Length);
                        //Console.WriteLine($"{a[i]} removed");
                    }
                }
            }
            return str;
        }

        /// <summary>
        /// Method GetMaxWord
        /// Найти самое длинное слово сообщения;
        /// </summary>
        /// <returns>Word with Max length</returns>
        public void GetMaxWord()
        {
                //int variable for determine max length of word
                int max = 0;

                //create array of strings
                string[] a;

                //split string to array of strings according to list of delimiters
                a = message.Split(delimiters);

                //find max length of the words
                foreach (string element in a)
                {
                    if (element.Length > max)
                    {
                        max = element.Length;
                    }
                }

                //print out words with max length
                foreach (string element in a)
                {
                    if (element.Length == max)
                    {
                        Console.WriteLine(element);
                    }
                }
        }
    }
}
