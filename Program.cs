using System;
using System.IO;
using System.Timers;
using System.Text;

namespace ConsoleApp1
{
    class Program
    {
        private static int mychoice;
        private static int result;
        private static int rate;
        

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
            Console.WriteLine("Press 's' to start OMIKUZI");
            Console.WriteLine("Press 'm' to see you again ;D");
            Console.WriteLine("Press 'j' to start JANKEN");
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
            //ジャンケン
            bool janken = false;
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
                case "j":
                    Console.WriteLine("--------ver1.2------------");
                    janken = true;
                    break;
                default:
                    Console.WriteLine("----------failed----------");
                    break;
            }

            //ジャンケン処理
            bool Opponent = false;
            if (janken)
            {
                SuperLines();
                Janken1();
                Opponent = true;
            }

            if (Opponent)
            {
                _Opponent();
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

        static void SuperLines()
        {
            Console.WriteLine("------------------------------------------------------------------------------------------\n");
            Console.WriteLine("------------------------------------------------------------------------------------------\n");
            Console.WriteLine("------------------------------------------------------------------------------------------\n");
            Console.WriteLine("------------------------------------------------------------------------------------------\n");
            Console.WriteLine("------------------------------------------------------------------------------------------\n");

            Timer j_timer = new Timer(100);
            int j_num = 0;
            string[] j_str = new string[4];
            j_str[0] = "  >>How To play<<  ";
            j_str[1] = "Press 'g' to グー  ";
            j_str[2] = "Press 't' to チョキ";
            j_str[3] = "Press 'p' to パー  ";
            j_timer.Elapsed += (sender, e) =>
            {
                if (j_num < 4)
                {
                    Console.WriteLine("             -----------------------------");
                    Console.WriteLine("             [                           ]");
                    Console.WriteLine("             [    "+j_str[j_num]+"    ]");
                    Console.WriteLine("             [                           ]");
                    Console.WriteLine("             -----------------------------");
                    j_num++;
                }
                else
                {
                    j_timer.Stop();
                }
            };
            j_timer.Start();
        }
        static void Janken1()
        {
            int? mine = null;
            string _read = Console.ReadLine();
            switch (_read)
            {
                case "g":
                    Lines();
                    Console.WriteLine("             -----------------------------");
                    Console.WriteLine("             [                           ]");
                    Console.WriteLine("             [   You selected 'グー'     ]");
                    Console.WriteLine("             [                           ]");
                    Console.WriteLine("             -----------------------------\n");
                    Console.WriteLine("                          VS              \n");
                    mine = 0;
                    break;
                case "t":
                    Lines();
                    Console.WriteLine("             -----------------------------");
                    Console.WriteLine("             [                           ]");
                    Console.WriteLine("             [   You selected 'チョキ'   ]");
                    Console.WriteLine("             [                           ]");
                    Console.WriteLine("             -----------------------------\n");
                    Console.WriteLine("                          VS              \n");
                    mine = 2;
                    break;
                case "p":
                    Lines();
                    Console.WriteLine("             -----------------------------");
                    Console.WriteLine("             [                           ]");
                    Console.WriteLine("             [   You selected 'パー'     ]");
                    Console.WriteLine("             [                           ]");
                    Console.WriteLine("             -----------------------------\n");
                    Console.WriteLine("                          VS              \n");

                    mine = 1;
                    break;
                default:
                    Console.WriteLine("----------Press any key to Close----------");
                    Console.ReadKey();
                    Environment.Exit(0);
                    break;
            }

            Encoding enc = Encoding.GetEncoding("Shift_JIS");
            StreamWriter writer = new StreamWriter(@"choice.txt", false, enc);
            switch (mine)
            {
                case 0:
                    writer.WriteLine("0");
                    writer.Close();
                    break;
                case 1:
                    writer.WriteLine("1");
                    writer.Close();
                    break;
                case 2:
                    writer.WriteLine("2");
                    writer.Close();
                    break;
            }


        }
        static void _Opponent()
        {
            Random alg = new Random();
            int jn = alg.Next(0, 3);
            string[] str_opponent = new string[3];
            str_opponent[0] = "  'グー'";
            str_opponent[1] = "  'パー'";
            str_opponent[2] = "'チョキ'";

            Console.WriteLine("             -----------------------------");
            Console.WriteLine("             [                           ]");
            Console.WriteLine("             [   Your Opponent" + str_opponent[jn] + "   ]");
            Console.WriteLine("             [                           ]");
            Console.WriteLine("             -----------------------------");

            StreamReader reader = new StreamReader(@"choice.txt", Encoding.GetEncoding("Shift_JIS"));
            string str = reader.ReadLine();
            reader.Close();
            int _str = int.Parse(str);
            int str2 = _str;
            switch (_str)
            {
                case 0:
                    mychoice = 0;
                    //Console.WriteLine("Player:ぐー");
                    break;
                case 1:
                    mychoice = 1;
                    //Console.WriteLine("Player:ぱー");
                    break;
                case 2:
                    mychoice = 2;
                    //Console.WriteLine("Player:ちょき");
                    break;
                default:
                    Console.WriteLine("Something went bad");
                    break;
            }
            Console.WriteLine("str = " + _str);
            Console.WriteLine("PLAYER'S = " + mychoice);

            int? choice_opponent = null;
            switch (jn)
            {
                case 0:
                    choice_opponent = 0;
                    break;
                case 1:
                    choice_opponent = 1;
                    break;
                case 2:
                    choice_opponent = 2;
                    break;

            }
            Console.WriteLine("OPPONENT'S = " + choice_opponent);

            // 0はグー、１はパー、２はチョキ
            // 1はあいこ、2はプレイヤーの勝利、３は敵の勝利
            if (choice_opponent == mychoice)
            {
                result = 1;
            }
            if (choice_opponent == 0 && mychoice == 1)
            {
                result = 2;
            }
            if (choice_opponent == 1 && mychoice == 0)
            {
                result = 3;
            }
            if (choice_opponent == 0 && mychoice == 2)
            {
                result = 3;
            }
            if (choice_opponent == 2 && mychoice == 0)
            {
                result = 2;
            }
            if (choice_opponent == 1 && mychoice == 2)
            {
                result = 2;
            }
            if (choice_opponent == 2 && mychoice == 1)
            {
                result = 3;
            }

            Console.WriteLine("result = " + result);

            StreamReader stream = new StreamReader(@"rate.txt", Encoding.GetEncoding("Shift_JIS"));
            string _rate = stream.ReadLine();
            stream.Close();
            int __rate = int.Parse(_rate);
            rate = __rate;

            switch (result)
            {
                case 1:
                    Console.WriteLine("'Same'code:1");
                    rate += 10;
                    Same();
                    break;
                case 2:
                    Console.WriteLine("'Win'code:2");
                    rate += 20;
                    Win();
                    break;
                case 3:
                    Console.WriteLine("'Lose'code:3");
                    if (rate > 1)
                    {
                        rate -= 10;
                        Lose();
                    }
                    break;
            }
            //Console.WriteLine("currenly rate = " + rate);
            Console.WriteLine("         [Your rating ==>{" + rate+"}]");

            Encoding encoding = Encoding.GetEncoding("Shift_JIS");
            StreamWriter streamWriter = new StreamWriter(@"rate.txt", false, encoding);
            streamWriter.WriteLine(rate);
            streamWriter.Close();
        }
        static void Same()
        {
            Console.WriteLine("             -----------------------------");
            Console.WriteLine("             [                           ]");
            Console.WriteLine("             [     あいこ！実質負け！    ]");
            Console.WriteLine("             [                           ]");
            Console.WriteLine("             -----------------------------\n");
        }
        static void Win()
        {
            Console.WriteLine("             -----------------------------");
            Console.WriteLine("             [                           ]");
            Console.WriteLine("             [     まあまあやるやん      ]");
            Console.WriteLine("             [                           ]");
            Console.WriteLine("             -----------------------------\n");
        }
        static void Lose()
        {
            Console.WriteLine("             -----------------------------");
            Console.WriteLine("             [                           ]");
            Console.WriteLine("             [     はい君の負けー^^      ]");
            Console.WriteLine("             [                           ]");
            Console.WriteLine("             -----------------------------\n");
        }

        static void Lines()
        {
            //とりまラインだけ格納
            Console.WriteLine("-------------------------------------------------------------------------------\n");
            Console.WriteLine("-------------------------------------------------------------------------------\n");
            Console.WriteLine("-------------------------------------------------------------------------------\n");
            Console.WriteLine("-------------------------------------------------------------------------------\n");
        }
    }

}
