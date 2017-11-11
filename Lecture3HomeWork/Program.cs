using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using Lecture3HomeWorkClasses;

namespace Lecture3HomeWork
{
    class Program
    {
        private static char Choice()
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-4]";

            Console.WriteLine("Выберите операцию которую хотите провести:");
            Console.WriteLine("\t1. Сложение");
            Console.WriteLine("\t2. Вычитание");
            Console.WriteLine("\t3. Умножение");
            Console.WriteLine("\t4. Деление");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                return selectedTask.KeyChar;
            }
            else
            {
                return '0';
            }
        }

        public static void TaskN1()
        {
            Complex x;
            Complex y;

            try
            {
                Console.Write("Введите действительную часть первого значения: ");
                x.im = int.Parse(Console.ReadLine());
                Console.Write("Введите комплексную часть первого значения: ");
                x.re = int.Parse(Console.ReadLine());
                Console.Write("Введите действительную часть второго значения: ");
                y.im = int.Parse(Console.ReadLine());
                Console.Write("Введите комлпексную часть второго значения: ");
                y.re = int.Parse(Console.ReadLine());

                switch (Choice())
                {
                    case '1':
                        x = x.Plus(y);
                        Console.WriteLine("Результат: " + x.ToString());
                        break;
                    case '2':
                        x = x.Minus(y);
                        Console.WriteLine("Результат: " + x.ToString());
                        break;
                    case '3':
                        x = x.Multi(y);
                        Console.WriteLine("Результат: " + x.ToString());
                        break;
                    case '4':
                        x = x.Division(y);
                        Console.WriteLine("Результат: " + x.ToString());
                        break;
                    default:
                        Console.WriteLine("Введено некорректное значение!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        public static void TaskN2()
        {
            Task2.InputValuesUntilNotZero();
        }

        public static void TaskN3()
        {
            Fraction x = new Fraction(); ;
            Fraction y = new Fraction();;

            try
            {
                Console.Write("Введите числитель первой дроби: ");
                x.upperValue = int.Parse(Console.ReadLine());
                Console.Write("Введите знаменатель первой дроби: ");
                x.lowValue = int.Parse(Console.ReadLine());
                Console.Write("Введите числитель второй дроби: ");
                y.upperValue = int.Parse(Console.ReadLine());
                Console.Write("Введите знаменатель второй дроби: ");
                y.lowValue = int.Parse(Console.ReadLine());

                switch (Choice())
                {
                    case '1':
                        x = x.Summ(y);
                        Console.WriteLine("Результат: " + x.ToString());
                        break;
                    case '2':
                        x = x.Minus(y);
                        Console.WriteLine("Результат: " + x.ToString());
                        break;
                    case '3':
                        x = x.Multiple(y);
                        Console.WriteLine("Результат: " + x.ToString());
                        break;
                    case '4':
                        x = x.Division(y);
                        Console.WriteLine("Результат: " + x.ToString());
                        break;
                    default:
                        Console.WriteLine("Введено некорректное значение!");
                        break;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Ошибка: " + e.Message);
            }
        }

        static void Main(string[] args)
        {
            ConsoleKeyInfo selectedTask;
            var rule = @"[1-7]";

            Console.WriteLine("Добрый день, уважаемый пользователь. Демонстрацию работы какой программы вы бы хотели увидеть?");
            Console.WriteLine("\t1. Программа проведения арифметических операций с комплексными числами.");
            Console.WriteLine("\t2. Программа подсчета суммы всех нечетных положительных чисел введенных пользователем.");
            Console.WriteLine("\t3. Программа проведения арифметических операций с дробями.");
            selectedTask = Console.ReadKey(true);
            if (Regex.IsMatch(selectedTask.KeyChar.ToString(), rule))
            {
                switch (selectedTask.KeyChar)
                {
                    case '1':
                        TaskN1();
                        break;
                    case '2':
                        TaskN2();
                        break;
                    case '3':
                        TaskN3();
                        break;
                }
            }
        }
    }
}
