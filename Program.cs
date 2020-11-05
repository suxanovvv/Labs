using System;
using System.Drawing;
using System.Dynamic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Xml;
using System.Xml.Serialization;

namespace Lab_5
{
    class Program
    {

        class coordinates
        {
            private double[] x;
            
            public double[] pointx
            {
                get
                {
                    return x;
                }

                set
                {
                    x = value;
                }
            }

            private double[] y;

            public double[] pointy
            {
                get
                {
                    return y;
                }

                set
                {
                    y = value;
                }
            }
        }


        private static double[] FileMassive(string point)
        {

            string[] readd = File.ReadAllText(point).Split(",");
            double[] x = new double[readd.Length];

            for (int i = 0; i < readd.Length; i++)
            {

                try
                {
                    x[i] = Convert.ToDouble(readd[i]);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                }

            }

            return x;
        }


        private static double WriteMassive(string point, double x, double y)
        {

            string stringx;
            string strx = Convert.ToString(x);
            string stry = Convert.ToString(y);


            if (File.Exists(point))
            {
                stringx = "(" + strx + "; " + stry + ")";
                File.WriteAllText(point, stringx);
                Console.WriteLine("Координати заданої точки записано у файл!");
            }
            else
            {
                Console.WriteLine("Такого файлу не існує!");
            }
            return x;
        }


        private static double[] a = new double[1];
        private static double[] b = new double[1];

        private static int choice1(int num)
        {

            if (num == 1)
            {

                string x = @"C:\Users\пк\Desktop\Lab_4\x.txt";
                double[] x1 = FileMassive(x);

                for (int i = 0; i < a.Length; i++)
                {
                    a[i] = x1[0];
                }

                for (int i = 0; i < b.Length; i++)
                {
                    b[i] = x1[1];
                }

                Console.WriteLine("Координати точки з файлу: ");

                for (int i = 0; i < b.Length; i++)
                {
                    Console.WriteLine("(" + a[i] + ", " + b[i] + ")");
                }

                Console.WriteLine();

            }

            else if (num == 2)
            {

                Console.WriteLine("Вкажіть координату x Вашої початкової точки: ");

                double[] x1 = new double[1];

                for (int i = 0; i < 1; i++)
                {
                    x1[i] = Convert.ToDouble(Console.ReadLine());
                }

                Console.WriteLine("Вкажіть координату y Вашої початкової точки: ");

                double[] y1 = new double[1];

                for (int i = 0; i < 1; i++)
                {
                    y1[i] = Convert.ToDouble(Console.ReadLine());
                }

                for (int i = 0; i < 1; i++)
                {
                    Console.WriteLine("Координати заданої точки: (" + x1[i] + ", " + y1[i] + ")");
                }

                Console.WriteLine();

                a = x1;
                b = y1;
            }
        
            else
            {
                Console.WriteLine("Введіть цифру або 1, або 2!");
            }

            return (num);
        }


        private static double[] distance(double[] pointx, double[] pointx1, double[] pointy, double[] pointy1)
        {

            double[] dist = new double[1];
            double[] kvadr = new double[1];

            for (int i = 0; i < 1; i++)
            {
                dist[i] = ((pointx1[i] - pointx[i]) * (pointx1[i] - pointx[i])) + ((pointy1[i] - pointy[i]) * (pointy1[i] - pointy[i]));
                
                kvadr[i] = Math.Pow(dist[i], 0.5);

                Console.WriteLine();
                Console.WriteLine("Відстань від заданої точки до вказаної: " + kvadr[i]);
                Console.WriteLine();

            }

            return kvadr;

        }

        private static double[] max_min_distance(double[] pointx, double[] pointx1, double[] massivex, double[] massivey)
        {

            double max = 0;
            double min = 0;

            double[] res = new double[massivex.Length];

            for (int i = 0; i < massivex.Length; i++)
                for (int j = 0; j < pointx.Length; j++)
                {
                    {

                        res[i] = Math.Pow(((massivex[i] - pointx[j]) * (massivex[i] - pointx[j])) + ((massivey[i] - pointx1[j]) * (massivey[i] - pointx1[j])), 0.5);
                        if (max < res[i])
                        {
                            max = res[i];
                        }

                        min = res.Min();
                    }

                }

            Console.WriteLine();

            for (int j = 0; j < pointx.Length; j++)
                for (int i = 0; i < massivex.Length; i++)
                {
                    {
                        Console.WriteLine("Відстань від точки (" + pointx[j] + ", " + pointx1[j] + ") до точки: (" + massivex[i] + ", "+ massivey[i] + "): " + res[i]);
                    }
                }


            Console.WriteLine();


            for (int j = 0; j < pointx.Length; j++)
            {
                Console.WriteLine("Найбільша відстань від точки " + "(" + pointx[j] + ", " + pointx1[j] + "): " + max + ", а найменша: " + min);
            }

            return pointx;
        }


        static void Main(string[] args)
        {
            coordinates coord = new coordinates();
            while (true)
            {
                Console.OutputEncoding = System.Text.Encoding.UTF8;

                Console.WriteLine("Як ви хочете задати дані масиву? \n1 - з файлу; \n2 - писати вручну; \nВаша цифра:");
                try
                {

                    string input;
                    input = Console.ReadLine();
                    int digit1 = Convert.ToInt32(input);

                    choice1(digit1);
                }

                catch
                {
                    Console.WriteLine("Щось не так, перевірте правильність вводу даних!");
                    continue;
                }

                Console.WriteLine("Введіть координат точки, до якої хочете знайти відстань: ");


                try
                {
                    Console.WriteLine("Точка х: ");

                    double[] stringx = new double[1];

                    for (int i = 0; i < 1; i++)
                    {
                        stringx[i] = Convert.ToDouble(Console.ReadLine());
                    }

                    Console.WriteLine("Точка y: ");

                    double[] stringy = new double[1];
                    double[] z = new double[1];

                    for (int i = 0; i < 1; i++)
                    {

                        stringy[i] = Convert.ToDouble(Console.ReadLine());
                        Console.WriteLine("Координати другої точки: (" + stringx[i] + ", " + stringy[i] + ")");

                        //Записуємо дані у файл                    
                        string way = @"C:\Users\пк\Desktop\Lab_4\y.txt";

                        WriteMassive(way, stringx[i], stringy[i]);
                    }

                    distance(a, stringx, b, stringy);

                }

                catch
                {
                    Console.WriteLine("Щось не так, перевірте правильність вводу даних!");
                    continue;
                }



                Console.WriteLine("Виберіть кількість точок у масиві: ");
                try
                {

                    string inputn;
                    inputn = Console.ReadLine();
                    int n = Convert.ToInt32(inputn);

                    double[] massivei = new double[n];
                    double[] massivej = new double[n];

                    try
                    {
                        for (int i = 0; i < n; i++)
                        {

                            Console.WriteLine("Вкажіть координату x: ");
                            massivei[i] = Convert.ToDouble(Console.ReadLine());

                            Console.WriteLine("Вкажіть координату у: ");
                            massivej[i] = Convert.ToDouble(Console.ReadLine());

                        }

                        Console.WriteLine("Масив координат точок, які Ви обрали (x;y): ");

                        for (int i = 0; i < n; i++)
                        {
                            Console.WriteLine("(" + massivei[i] + ", " + massivej[i] + ")");
                        }
                    }

                    catch
                    {
                        Console.WriteLine("Щось не так, перевірте правильність вводу даних!");
                        continue;
                    }

                    max_min_distance(a, b, massivei, massivej);

                }

                catch
                {
                    Console.WriteLine("Щось не так, перевірте правильність вводу даних!");
                    continue;
                }



                Console.WriteLine("Введіть '1' щоб продовжити, інше - для виходу: ");

                string result;
                result = Console.ReadLine();

                if (result == "1")
                {
                    continue;
                }
                else
                {
                    break;
                }

                Console.ReadKey();
            }
        }
    }
}


