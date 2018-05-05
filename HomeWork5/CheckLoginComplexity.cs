using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SupportLibrary;
using System.Text.RegularExpressions;

/// <summary>
/// Максим Торопов
/// Ярославль
/// Домашняя работа 5 урока
/// </summary>
namespace HomeWork5
{
    /// <summary>
    /// Класс для задания 1.
    /// CheckLogin Class
    /// </summary>
    class CheckLoginComplexity
    {
        /// <summary>
        /// string for username
        /// </summary>
        string username;

        /// <summary>
        /// Initialize string;
        /// </summary>
        public CheckLoginComplexity()
        {
            username = "";
        }

        /// <summary>
        /// Properties return username value
        /// </summary>
        public string GetUsername
        {
            get
            {
                return username;
            }
        }

        /// <summary>
        /// Method CheckLoginComplexitySimple
        /// Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при этом цифра не может быть первой.
        /// а) без использования регулярных выражений;
        /// </summary>
        public bool CheckLoginComplexitySimple()
        {
            bool letterOrDigits = true;

            do
            {
                username = SupportMethods.RequestString("Please type your login: ");
                letterOrDigits = true;
                foreach (char c in username)
                {
                    if (!char.IsLetterOrDigit(c)) letterOrDigits = false;
                }

            } while (username.Length < 2 || username.Length > 10 || Char.IsDigit(username[0]) || !letterOrDigits);

            return true;           
            
        }

        /// <summary>
        /// Method CheckLoginComplexityRegEx
        /// Корректным логином будет строка от 2-х до 10-ти символов, содержащая только буквы или цифры, и при этом цифра не может быть первой.
        /// б) **с использованием регулярных выражений.
        /// </summary>
        /// <param name="rgx">any string, please don't care about it</param>
        public bool CheckLoginComplexityRegEx()
        {
            Regex regex = new Regex(@"^[a-zA-Z][0-9a-zA-Z]{2,9}$");
            do
            {
                username = SupportMethods.RequestString("Please type your login: ");

            } while (!regex.IsMatch(username));

            return true;
        }
    }
}
