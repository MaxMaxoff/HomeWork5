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
    /// Класс для задания 4.
    /// </summary>
    class UnifiedStateExam
    {
        /// <summary>
        /// Array of studients
        /// </summary>
        string[] students;

        /// <summary>
        /// Array of values
        /// </summary>
        int[,] values;

        /// <summary>
        /// Arrays of mediana
        /// </summary>
        decimal[] mediana;

        /// <summary>
        /// Initialize arrays with default values for 10 persons
        /// </summary>
        public UnifiedStateExam()
        {
            int n = 120;

            students = new string[n];
            values = new int[n, 3];
            mediana = new decimal[n];

            Random random = new Random();
            for (int i = 0; i < n; i++)
            {
                students[i] = $"Иванов Иван{i}";
                values[i, 0] = random.Next(1, 6);
                values[i, 1] = random.Next(1, 6);
                values[i, 2] = random.Next(1, 6);
                mediana[i] = (values[i, 0] + values[i, 1] + values[i, 2]) / 3M;
            }
        }

        /// <summary>
        /// Initialize arrays with requested values for requested count of person
        /// </summary>
        /// <param name="n"></param>
        public UnifiedStateExam(int n)
        {
            students = new string[n];
            values = new int[n, 3];
            mediana = new decimal[n];
            //TODO: input from string
            int i = 0;
            do
            {
                //string[] a = SupportMethods.RequestString("Please input next string: ").Split(' ');
                string[] a = SupportMethods.RequestString("").Split(' ');
                students[i] = $"{a[0]} {a[1]}";
                values[i, 0] = Int32.Parse(a[2]);
                values[i, 1] = Int32.Parse(a[3]);
                values[i, 2] = Int32.Parse(a[4]);
                mediana[i] = (values[i, 0] + values[i, 1] + values[i, 2]) / 3M;
                i++;

            } while (i < n);
        }

        /// <summary>
        /// Method Get3MinimalAverageValues
        /// Get 3 minimal average values (mediana)
        /// </summary>
        /// <param name="m1">int</param>
        /// <param name="m2">int</param>
        /// <param name="m3">int</param>
        public void Get3MinimalAverageValues(out int m1, out int m2, out int m3)
        {
            //work 100%
            //m1 = 0;
            //for (int i = m1; i < students.Length; i++)
            //    if (mediana[i] < mediana[m1]) m1 = i;

            //m2 = 0;
            //if (m1 == m2) m2++;

            //for (int i = m2; i < students.Length; i++)
            //    if (mediana[i] < mediana[m2] && m1 != i) m2 = i;

            //m3 = 0;
            //if (m3 == m1 || m3 == m2) m3++;
            //if (m3 == m1 || m3 == m2) m3++;

            //for (int i = m3; i < students.Length; i++)
            //    if (mediana[i] < mediana[m3] && m1 != i && m2 != i) m3 = i;
            //work 100%

            //more optimal
            m1 = 2;
            m2 = 1;
            m3 = 0;
            for (int i = m1; i < students.Length; i++)
            {
                if (mediana[i] < mediana[m1])
                {                    
                    if (mediana[m1] < mediana[m2])
                    {
                        if (mediana[m2] < mediana[m3]) m3 = m2;
                        m2 = m1;
                    } else if (mediana[m1] < mediana[m3])
                    {
                        m3 = m1;
                    }
                    m1 = i;
                }
                if (mediana[i] < mediana[m2] && m1 != i)
                {
                    if (mediana[m2] < mediana[m3]) m3 = m2;
                    m2 = i;
                }
                if (mediana[i] < mediana[m3] && m1 != i && m2 != i)
                {
                    m3 = i;
                }

            }

        }

        /// <summary>
        /// Method
        /// Print out all students with requested mediana
        /// </summary>
        /// <param name="m1">int</param>
        /// <param name="m2">int</param>
        /// <param name="m3">int</param>
        public void PrintOutAllWorstStudents(int m1, int m2, int m3)
        {
            for (int i = 0; i < students.Length; i++)
            {
                if ((mediana[i] == mediana[m1]) || (mediana[i] == mediana[m2]) || (mediana[i] == mediana[m3]))
                {
                    Console.WriteLine($"Студент {students[i]} с оценками {values[i, 0]}, {values[i, 1]} и {values[i, 2]} имеет худшую среднюю оценку {mediana[i]:f2}");
                }
            }
        }

        /// <summary>
        /// Method override ToString()
        /// </summary>
        /// <returns>table</returns>
        public override string ToString()
        {
            string t = string.Empty;
            for (int i = 0; i < students.Length; i++)
            {
                t = t + $"{students[i]} {values[i, 0]} {values[i, 1]} {values[i, 2]} ср: {mediana[i]:f2}\n";
            }

            return t;
        }
    }
}
