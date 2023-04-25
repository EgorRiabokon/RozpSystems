using System;
using System.Threading;

namespace RozpSyst1
{
    class MainClass
    {
        
        static double[] x = { 1, 2, 3, 4, 5 };
        static double[] y = { 7.1, 27.8, 62.1, 110, 161 };

        static int n = 0;
        static double a1, b1, a2, b2;
        static double d1, d2;
        public static void Main(string[] args)
        {
            if (x.Length == y.Length)
            {
                n = x.Length;
            };
            for (int i = 0; i < n; i++)
            {
                x[i] = Math.Log(x[i]);
            }
            Thread thread1 = new Thread(ThreadFunction1);
            thread1.Start();
            Thread thread2 = new Thread(ThreadFunction2);
            thread2.Start();
            if (d1 < d2)
            {
                Console.WriteLine("Result Point Vector: ");
                Console.WriteLine("y = " + a1 + "* lnx +" + b1);
            }
            else
            {
                Console.WriteLine("Result Point Vector: ");
                Console.WriteLine("y = " + Math.Pow(Math.E, a2) + " * x^" + b2);
            }
            Console.ReadKey();
        }
        static void ThreadFunction1()
        {
            double Xi = 0;
            double Xi2 = 0;
            double XiYi = 0;
            double Yi = 0;
            for (int i = 0; i < n; i++)
            {
                Xi += x[i];
                Xi2 += x[i] * x[i];
                XiYi += x[i] * y[i];
                Yi += y[i];
            }
            a1 = (Yi * Xi2 * n - XiYi * n * Xi) / (Xi2 * n * n - n * Xi * Xi);
            b1 = (XiYi * n - Yi * Xi) / (Xi2 * n - Xi * Xi);
            d1 = Math.Sqrt(((Yi - a1 * Xi - b1) * (Yi - a1 * Xi - b1)) / (Yi * Yi));
            Console.WriteLine("d1 = " + d1);
        }
        static void ThreadFunction2()
        {
            double Xi = 0;
            double Xi2 = 0;
            double XiYi = 0;

            double Yi = 0;
            for (int i = 0; i < n; i++)
            {
                y[i] = Math.Log(y[i]);
            }
            for (int i = 0; i < n; i++)
            {
                Xi += x[i];
                Xi2 += x[i] * x[i];
                XiYi += x[i] * y[i];
                Yi += y[i];
            }
            a2 = (Yi * Xi2 * n - XiYi * n * Xi) / (Xi2 * n * n - n * Xi * Xi);
            b2 = (XiYi * n - Yi * Xi) / (Xi2 * n - Xi * Xi);
            d2 = Math.Sqrt(((Yi - a2 * Xi - b2) * (Yi - a2 * Xi - b2)) / (Yi * Yi));
            Console.WriteLine("d2 = " + d2);
        }

    }

}

