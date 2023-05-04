using System;
using System.Threading;


namespace RozpSyst2
{
    class ThreadClass
    {
        public static double e;
        // Делегат для передачі необхідного методу (g1 та g2) до методу
        // calc()
        public delegate double MyFunc(double x);
        
        public static void Main(string[] args)
        {
            e = 0.01; // похибка у розрахунках
                      // Створюємо перший потік
            Thread thread1 = new Thread(ThreadFunction1);
            thread1.Start();
            // Створюємо другий потік
            Thread thread2 = new Thread(ThreadFunction2);
            thread2.Start();
            // Go() – статичний метод
            Thread t = new Thread(Go);
            // Виконати Go() в новому потоці
            t.Start();
            // Одночасно запустити Go() в головному потоці
            Go();
            Thread.Sleep(TimeSpan.FromSeconds(3)); // блокування на
                                                   // 3 сек.
            t.Join(); // очікуємо завершення потоку
            Console.ReadKey();
        }
        static bool done; // статичний тип
        static object locker = new object(); // статичний об’єкт
        static void Go()
        {
            lock (locker)
            {
                if (!done)
                {
                    Console.WriteLine("Done");
                    done = true;
                }
            }
        }
        // Реалізація функції f(x) = 2x - cos (x)
        public static double g1(double x)
        {
            double y = 0.5 * Math.Cos(x);
            return y;
        }
        // Реалізація функції f(x) = x + ln x
        public static double g2(double x)
        {
            double y = (2 * x - Math.Log(x)) / 3;
            return y;
        }
        // Основний метод з розрахунками
        public static double calc(double x, MyFunc g)
        {
            double temp, d;
            do
            {
                temp = g(x);
                d = Math.Abs(temp - x);
                x = temp;
                //Console.WriteLine (x);
            }
            while (d >= e);
            return (x);
        }
        // Організація потоків для функцій
        static void ThreadFunction1()

        {
            double x = 0.5;
            MyFunc g = g1;
            x = calc(x, g);
            //Console.WriteLine(x);
            Console.WriteLine("Education 2x - cos (x) = 0");
            Console.WriteLine("Answer: X= {0}, iquel {1}", x, e);
        }
        static void ThreadFunction2()
        {
            double x = 0.75;
            MyFunc g = g2;
            x = calc(x, g);
            Console.WriteLine("Education x + ln (x) = 0");
            Console.WriteLine("Answer: X= {0}, iquel {1}", x, e);
        }
    }
}
