using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lecture3HomeWorkClasses
{
    struct Complex
    {
        public double im; //Комплексная часть
        public double re; //Действительная часть
        
        /// <summary>
        /// Сложение комплексных чисел
        /// </summary>
        /// <param name="x">Слагаемое складываемое с исходным значением</param>
        /// <returns></returns>
        public Complex Plus(Complex x)
        {
            Complex y;
            y.im = im + x.im; // x1 + x2
            y.re = re + x.re; // y1 + y2
            return y;
        }
        
        /// <summary>
        /// Умножение комплексных чисел
        /// </summary>
        /// <param name="x">Множитель умножающий исходное значение</param>
        /// <returns></returns>
        public Complex Multi(Complex x)
        {
            Complex y;
            y.im = im * x.im - re * x.re;
            y.re = im * x.re + re * x.im;
            return y;
        }

        /// <summary>
        /// Вычитание комплексных чисел
        /// </summary>
        /// <param name="x">Вычитаемое из исходного значение</param>
        /// <returns></returns>
        public Complex Minus(Complex x)
        {
            Complex y;
            y.im = im - x.im;
            y.re = re - x.re;
            return y;
        }

        /// <summary>
        /// Деление комплексных чисел
        /// </summary>
        /// <param name="x">Делитель исходного комплексного числа</param>
        /// <returns></returns>
        public Complex Division(Complex x)
        {
            Complex y;
            y.im = (im * x.im + re * x.re) / (Math.Pow(x.im, 2) + Math.Pow(x.re, 2));
            y.re = (x.im * re - im * x.re) / (Math.Pow(x.im, 2) + Math.Pow(x.re, 2));
            return y;
        }

        public override string ToString()
        {
            return re + "+" + im + "i";
        }
    }

    public class Task2
    {
        /// <summary>
        /// Метод поределения и вывода всех нечетных положительных чисел.
        /// </summary>
        public static void InputValuesUntilNotZero()
        {
            int inputValue;
            int summ = 0;
            bool flag = false;

            do
            {
                Console.Write("Введите число (для завершеения введите 0): ");
                try
                {
                    flag = Int32.TryParse(Console.ReadLine(), out inputValue);
                    if (inputValue % 2 != 0 && inputValue > 0)
                    {
                        summ += inputValue;
                    }
                    else
                    {
                        summ += inputValue;
                        flag = true;
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Введено некорректное значение!!!");
                }
            }
            while (flag != true);

            Console.WriteLine("Сумма всех введенных положительных нечетных чисел: {0}", summ);
            Console.ReadKey();
        }
    }


    /// <summary>
    /// Класс дробей
    /// </summary>
    public class Fraction
    {
        public int upperValue; //Числитель
        public int lowValue; //Знаменатель

        public string toString()
        {
            return upperValue + "/" + lowValue;
        }

        /// <summary>
        /// Функция упрощения дроби
        /// </summary>
        /// <param name="x">Входящее значение дроби</param>
        /// <returns></returns>
        private static Fraction Simple(Fraction x)
        {
            Fraction y = new Fraction();
            bool flag = false;

            while (true)
            {
                if (x.upperValue % 2 == 0 && x.lowValue % 2 == 0) { x.upperValue = x.upperValue / 2; x.lowValue = x.lowValue / 2; flag = true; }
                if (x.upperValue % 3 == 0 && x.lowValue % 3 == 0) { x.upperValue = x.upperValue / 3; x.lowValue = x.lowValue / 3; flag = true; }
                if (x.upperValue % 5 == 0 && x.lowValue % 5 == 0) { x.upperValue = x.upperValue / 5; x.lowValue = x.lowValue / 5; flag = true; }
                if (x.upperValue % 7 == 0 && x.lowValue % 7 == 0) { x.upperValue = x.upperValue / 7; x.lowValue = x.lowValue / 7; flag = true; }

                if (flag == false)
                {
                    break;
                }
            }

            y.upperValue = x.upperValue;
            y.lowValue = x.lowValue;
            return y;
        }


        /// <summary>
        /// Суммирование дробей
        /// </summary>
        /// <param name="x">Слагаемое с которым происходит операциия суммирования</param>
        /// <returns></returns>
        public Fraction Summ(Fraction x)
        {
            Fraction y = new Fraction();

            //Приведение к общему знаменателю
            if (lowValue != x.lowValue && lowValue < x.lowValue)
            {
                int tempVal = lowValue;
                lowValue *= x.lowValue;
                x.lowValue *= tempVal;
                upperValue *= x.lowValue;
                x.upperValue *= tempVal; 

            }
            else if (lowValue != x.lowValue && lowValue > x.lowValue)
            {
                int tempVal = x.lowValue;
                x.lowValue *= lowValue;
                lowValue *= tempVal;
                x.upperValue *= lowValue;
                upperValue *= tempVal;
            }

            y.upperValue = upperValue + x.upperValue;
            y.lowValue = lowValue;

            y = Fraction.Simple(y);

            return y;
        }

        /// <summary>
        /// Вычитание дроби
        /// </summary>
        /// <param name="x">Вычитаемая дробь</param>
        /// <returns></returns>
        public Fraction Minus(Fraction x)
        {
            Fraction y = new Fraction(); ;

            //Приведение к общему знаменателю
            if (lowValue != x.lowValue && lowValue < x.lowValue)
            {
                int tempVal = lowValue;
                lowValue *= x.lowValue;
                x.lowValue *= tempVal;
                upperValue *= x.lowValue;
                x.upperValue *= tempVal;

            }
            else if (lowValue != x.lowValue && lowValue > x.lowValue)
            {
                int tempVal = x.lowValue;
                x.lowValue *= lowValue;
                lowValue *= tempVal;
                x.upperValue *= lowValue;
                upperValue *= tempVal;
            }

            y.upperValue = upperValue - x.upperValue;
            y.lowValue = lowValue;

            y = Fraction.Simple(y);

            return y;
        }

        /// <summary>
        /// Произведение дробей
        /// </summary>
        /// <param name="x">Дробь на которую происходит умножение исходной дроби</param>
        /// <returns></returns>
        public Fraction Multiple(Fraction x)
        {
            Fraction y = new Fraction(); ;

            y.upperValue = upperValue * x.upperValue;
            y.lowValue = lowValue * x.lowValue;

            y = Fraction.Simple(y);

            return y;
        }

        /// <summary>
        /// Деление дробей
        /// </summary>
        /// <param name="x">Дробь на которую происходит деление</param>
        /// <returns></returns>
        public Fraction Division(Fraction x)
        {
            Fraction y = new Fraction(); ;

            y.upperValue = upperValue * x.lowValue;
            y.lowValue = lowValue * x.upperValue;

            y = Fraction.Simple(y);

            return y;
        }
    }
}