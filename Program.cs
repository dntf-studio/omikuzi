using System;
using System.IO;
using System.Timers;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            //ルーレット
            int num_r = 0;
            string[] txt = new string[7];
            txt[0] = "??";
            txt[1] = "大吉";
            txt[2] = "中吉";
            txt[3] = "大凶";
            txt[4] = "大吉";
            txt[5] = "中吉";
            txt[6] = "大凶";

            //console.
            Console.WriteLine("MadeBy_dntf-studio\r");
            Console.WriteLine("-------------------------------------\n");
            Console.WriteLine("Press 's' to start");
            Console.WriteLine("Press 'm' to see you again ;D");
            Console.WriteLine("      /----------/\n");
            Console.WriteLine("      [          ]");
            Console.WriteLine("      [   <" + txt[num_r] + ">   ]");
            Console.WriteLine("      [          ]\n");
            Console.WriteLine("      /----------/");
            Console.WriteLine("Press 's' to start");
            //タイマー関連
            Timer timer = new Timer(200);
            int num = 0;
            timer.Elapsed += (sender, e) =>
            {
                if (num < 10)
                {
                    num++;
                }
                else
                {
                    timer.Stop();
                    Random();
                    Console.WriteLine("\n----------stopped-----------");
                    Omikuzi();
                }
            };

            Timer _timer = new Timer(170);
            _timer.Elapsed += (sender, e) =>
            {
                if (num_r < 7)
                {
                    Console.WriteLine("           [  " + txt[num_r] + "  ]\n");
                    num_r++;
                }
                else
                {
                    _timer.Stop();
                }
            };

            //キー取得
            string Read = Console.ReadLine();
            switch (Read)
            {
                case "s":
                    Console.WriteLine("----------start----------");
                    timer.Start();
                    _timer.Start();
                    break;
                case "m":
                    Console.WriteLine("---OK.SEE YOU AGAIN ;D---");
                    break;
                default:
                    Console.WriteLine("----------failed----------");
                    break;
            }

            Console.ReadKey();
        }

        static void Random()
        {
            //ランダム値
            int seed = Environment.TickCount;
            Random rnd = new Random(seed++);

            for (int j = 0; j < 200; j++)
            {
                Console.Write("{0}", rnd.Next(10, 100));
            }
        }

        static void Omikuzi()
        {
            //おみくじ
            Random rnd2 = new Random();
            int rnd_ = rnd2.Next(1, 4);
            switch (rnd_)
            {
                case 1:
                    Console.WriteLine("      /----------/\n");
                    Console.WriteLine("      [          ]");
                    Console.WriteLine("      [  <大吉>  ]");
                    Console.WriteLine("      [          ]\n");
                    Console.WriteLine("      /----------/");
                    break;
                case 2:
                    Console.WriteLine("      /----------/\n");
                    Console.WriteLine("      [          ]");
                    Console.WriteLine("      [  <中吉>  ]");
                    Console.WriteLine("      [          ]\n");
                    Console.WriteLine("      /----------/");
                    break;
                case 3:
                    Console.WriteLine("      /----------/\n");
                    Console.WriteLine("      [          ]");
                    Console.WriteLine("      [  <大凶>  ]");
                    Console.WriteLine("      [          ]\n");
                    Console.WriteLine("      /----------/");
                    break;
            }

            Console.WriteLine("Press AnyKey to close");
        }
    }

}
