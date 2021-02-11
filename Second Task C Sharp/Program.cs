using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Second_Task_C_Sharp
{
    class Program
    {
        public void free_seats(int[,] srebmun)
        {
            for (int i = 0; i < srebmun.GetLength(0); i++)
            {
                for (int j = 0; j < srebmun.GetLength(1); j++)
                {
                    srebmun[i, j] = 0;
                }
            }

        }
        public void remember_seat(int[,] srebmun)
        {
            StreamWriter f = new StreamWriter(@"..\..\Seats.txt");
            for (int i = 0; i < srebmun.GetLength(0); i++)
            {
                for (int j = 0; j < srebmun.GetLength(1); j++)
                {
                    f.Write(srebmun[i, j]);
                }
                f.WriteLine();
                    
            }
            f.Close();
        }
        public void read_seat()
        { 
            StreamReader f = new StreamReader(@"..\..\Seats.txt", true);
            string a = f.ReadToEnd();
            Console.WriteLine(a);
            f.Close();
        }
        public void buy_seat(int [,] srebmun)
        {
            Console.Write("Row===");
            int rida = Convert.ToInt32(Console.ReadLine()) - 1;
            Console.Write("Seat===");
            int koht = Convert.ToInt32(Console.ReadLine()) - 1;
            if (srebmun[rida, koht] == 0)
            {
                Console.WriteLine("The seat is empty");
                srebmun[rida, koht] = 1;
                for (int i = 0; i < srebmun.GetLength(0); i++)
                {
                    for (int j = 0; j < srebmun.GetLength(1); j++)
                    {
                        Console.Write(srebmun[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("The seat is taken");
            }
        }
            static void Main(string[] args)
        {
            //Console.Write("A=");
            //int a = Convert.ToInt32(Console.ReadLine());
            //Console.Write("B=");
            //int b = Convert.ToInt32(Console.ReadLine());
            //Console.Write("C=");
            //int c = Convert.ToInt32(Console.ReadLine());
            //Console.WriteLine("\nA={0}\nB={1}\nC={2}", a.ToString(), b.ToString(), c.ToString());
            //int[] nums = new int[3] { a, b, c };
            //Console.WriteLine("Second Number in  the list is {0}",nums[1]);
            //foreach (int i in nums)
            //{
            //    Console.Write(i+" ");
            //}
            //Console.WriteLine(".(foreach)");
            //for (int i = 0; i < nums.Length; i++)
            //{
            //    Console.Write(nums[i]+" ");
            //}
            //Console.WriteLine(".(for)\n");
            //string[] texts = new string[4];
            //for (int i = 0; i < texts.GetLength(0); i++)
            //{
            //    Console.Write("{0} text=====", (i + 1).ToString());
            //    texts[i] = Console.ReadLine();
            //}
            //foreach (string item in texts)
            //{
            //    Console.Write(item + " ");
            //}
            //Console.WriteLine(".\n");
            ConsoleKeyInfo btn = new ConsoleKeyInfo();
            int [,] srebmun = new int[4, 7];
            Program prog = new Program();
            Console.Write("This was the last purchase.\n");
            prog.read_seat();
            prog.free_seats(srebmun);
            do
            {
                prog.buy_seat(srebmun);
                Console.WriteLine("If you wanna end your purchase press ESC");
                btn = Console.ReadKey();
                Console.WriteLine("");
                } while (btn.Key != ConsoleKey.Escape);
            Console.WriteLine("Thank You for Your purchase");
            prog.remember_seat(srebmun);
            Console.ReadLine();

        }
    }
}
