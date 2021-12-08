using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace base_Lesson21
{
    class Program
    {
        private static int[,] field;
        private static int sadfirst;
        private static int sadsecond;

        static void Main()
        {
            Console.WriteLine(" ******Введите размерность массива (поля) 2 числа (длина х ширина)******");
            sadsecond = Convert.ToInt32(Console.ReadLine());
            sadfirst = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine(" 1 садовник, обработавший свое поле обозначает его как 1 ");
            Console.WriteLine(" 2 садовник, обработавший свое поле обозначает его как 2 ");

            field = new int[sadsecond, sadfirst];

            Thread sadov1 = new Thread(sad1);
            Thread sadov2 = new Thread(sad2);

            sadov1.Start();
            sadov2.Start();

            sadov1.Join();
            sadov2.Join();

            for (int i = 0; i < sadsecond; i++)
            {
                for (int j = 0; j < sadfirst; j++) 
                {
                    Console.Write(field[i, j] + "   ");
                }
                Console.WriteLine();
            }

            Console.ReadLine();
        }

        private static void sad1()
        {
            for (int i = 0; i < sadsecond; i++)
            {
                for (int j = 0; j < sadfirst; j++)
                {
                    if (field[i, j] == 0)
                        field[i, j] = 1;
                    Thread.Sleep(1);
                }
            }
        }

        private static void sad2()
        {
            for (int i = sadfirst - 1; i > 0; i--)
            {
                for (int j = sadsecond - 1; j > 0; j--)
                {
                    if (field[j, i] == 0)
                        field[j, i] = 2;
                    Thread.Sleep(1);
                }
            }
        }
    }
}
