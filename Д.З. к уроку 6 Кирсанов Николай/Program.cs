
//Изменить программу вывода таблицы функции так, чтобы можно было передавать функции типа double (double, double). 
//Продемонстрировать работу на функции с функцией a*x^2 и функцией a*sin(x).

 

using System;

namespace Д.З.к_уроку_6_Кирсанов_Николай_задание_1
{
   
    public delegate double Fun(double a, double x);

    class Program
    {
        
        public static void Table(Fun F, double a, double x, double b)
        {
            Console.WriteLine("----- A ------- X -------- Y -----");
            while (x <= b)
            {
                Console.WriteLine("| {0,8:0.000} | {1,8:0.000} | {2,8:0.000} |", a, x, F(a, x));
                x += 1;
            }
            Console.WriteLine("-----------------------------------");
        }

       
        public static double MyFunc(double a, double x)
        {
            return a * x * x;
        }

       
        public static double MySin(double a, double x)
        {
            return a * Math.Sin(x);
        }

        static void Main()
        {
            
            Console.WriteLine("Таблица функции a*x^2:");
            
            Table(new Fun(MyFunc), -1.5, -2, 2);

            Console.WriteLine("Таблица функции a*sin(x):");
            Table(new Fun(MyFunc), 3, -2, 2);

            Console.ReadKey();
        }
    }

}
