using System;
using System.IO;
using System.Linq.Expressions;
using System.Reflection.Metadata;
using System.Threading;
using System.Xml.Serialization;

namespace Лабораторна_5
{
    class Program
    {

        public string path = @"C:\Users\пк\Desktop\Lab5\x.txt";
        private static double[] GivingEl(string way)
        {
            //string path = @"C:\Users\пк\Desktop\Lab5\x.txt";

            string[] readd = File.ReadAllText(way).Split(",");
            double[] xarray = new double[readd.Length];

            for (int i = 0; i < readd.Length; i++)
            {
                try
                {                                     
                    xarray[i] = Convert.ToDouble(readd[i]);
                }

                catch (Exception ex)
                {
                    Console.WriteLine("\n" + ex.Message);
                }
                
            }
            return(xarray);
        }


        public static void xarray_new(ref double[] xarray)
        {

            for (int i = 0; i < xarray.Length; i++)
            {
                if (xarray[i] < 0 && i % 2 == 0) 
                {
                    xarray[i] = xarray[i] * 2;
                }
            }
        }

        public static void zarray_new(ref double[] xarray, double[] yarray, double[] zarray)
        {

            for (int i=0; i<xarray.Length; i++)
            {
                if (yarray[i]!=0)
                {
                    zarray[i] = (xarray[xarray.Length - 1 - i]) / yarray[i];
                    
                }
                else
                {
                    Console.WriteLine("\n" + "Dividing by zero!");
                    continue;
                }
            }
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            string way_x = @"C:\Users\пк\Desktop\Lab5\x.txt";
            double[] xarray = GivingEl(way_x);

            Console.WriteLine("Massive from х.txt: ");

            for (int i = 0; i < xarray.Length; i++)
            {
                Console.Write("[" + xarray[i] + "] ");
            }

            xarray_new(ref xarray);
            Console.WriteLine("\n" + "Changed negative meanings massive x: ");

            for (int i = 0; i < xarray.Length; i++)
            {
                Console.Write("[" + xarray[i] + "] ");
            }

            string way_y = @"C:\Users\пк\Desktop\Lab5\y.txt";
            double[] yarray = GivingEl(way_y);
         
            Console.WriteLine("\n" + "Massive from у.txt: ");
            for (int i = 0; i < yarray.Length; i++)
            {
                Console.Write("[" + yarray[i] + "] ");
            }


            double[] zarray = new double[xarray.Length];

            zarray_new(ref xarray, yarray, zarray);
            Console.WriteLine("\n" + "Massive z: ");

            for (int i = 0; i < zarray.Length; i++)
            {
                Console.Write("["+ zarray[i] + "] ");
            }

            Console.ReadKey();
        }
    }
}
