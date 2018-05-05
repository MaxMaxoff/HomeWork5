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
    /// Класс для задания 3
    /// MyStrings Class
    /// </summary>
    class MyStrings
    {
        /// <summary>
        /// String
        /// </summary>
        string str;

        /// <summary>
        /// Properties resturn str value
        /// </summary>
        public string GetString
        {
            get
            {
                return str;
            }
        }

        /// <summary>
        /// Initialize empty string
        /// </summary>
        public MyStrings()
        {
            str = String.Empty;            
        }

        /// <summary>
        /// Initialize string using RequestString from SupportedLibrary
        /// </summary>
        /// <param name="message"></param>
        public MyStrings(string message)
        {
            str = SupportMethods.RequestString(message);
        }

        /// <summary>
        /// Method CheckTransposition
        /// badc являются перестановкой abcd
        /// </summary>
        /// <param name="str">second string</param>
        /// <returns>true if this.str transpose str</returns>
        public bool CheckTransposition(string str)
        {
            int[] a = new int[256];
            int[] b = new int[256];

            //Fill frequency array of the first string
            foreach (char ch in this.str)
            {
                a[(int)ch]++;
            }

            //Fill frequency array of the second string
            foreach (char ch in str)
            {
                b[(int)ch]++;
            }

            //Compare each elements of arrays
            for (int i = 0; i < 256; i++)
            {
                if (a[i] != b[i])
                {
                    return false;
                }
            }

            return true;
        }

        /// <summary>
        /// Method Sort String
        /// </summary>
        /// <returns>sorted string</returns>
        public string SortString()
        {
            //string to array
            char[] ch = str.ToArray();

            //sort array
            Array.Sort(ch);

            //return new sorted string
            return new string(ch);
        }
    }
}
