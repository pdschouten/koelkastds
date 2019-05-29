using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace Koelkast
{
    class Program
    {
        static void Main(string[] args)
        {
            List<string> geweest = new List<string>();
            List<string> rtoestand = new List<string>();
            int[] directions = new int[] { 1, 2, 3, 4 };
            string[] arr = Console.ReadLine().Split(' ');
            int b = Int32.Parse(arr[0]);
            int h = Int32.Parse(arr[1]);
            string m = arr[2];
            string[,] map = new string[h, b];
            for (int i = 0; i < h; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < b; j++)
                {
                    map[i, j] = line[j].ToString();
                }
            }

            Point player = findIndex(map, "+");
            Point fridge = findIndex(map, "!");
            Point goal = findIndex(map, "?");
            string t = move(player, directions, map, "", geweest, rtoestand);
            Console.WriteLine(t);
            Console.ReadLine();
        }

        public static Point findIndex(string[,] map, string value)
        {
            for (int x = 0; x < map.GetLength(0); x++)
            {
                for (int y = 0; y < map.GetLength(1); y++)
                {
                    if (map[x, y] == value)
                    {
                        return new Point(x, y);
                    }
                }
            }
            return new Point(0, 0);
        }

        public static string move(Point p, int[] d, string[,] map, string toestand, List<string> geweest, List<string> rtoestand)
        {
            for (int i = 0; i < 1; i++)
            {

                switch (d[i])
                {
                    case 1:
                        if (geweest.Contains(p.X.ToString() + (p.Y + 1)))
                        {

                            break;
                        }
                        else
                        {
                            if (map[p.X, p.Y + 1] == ".")
                            {
                                Console.WriteLine(p.X.ToString() + (p.Y + 1));
                                rtoestand.Add(toestand + "1");
                                break;
                            }
                            else if (map[p.X, p.Y + 1] == "!")
                            {
                                Console.WriteLine(p.X.ToString() + (p.Y + 1));
                                toestand = toestand + "1";
                                return toestand;
                            }
                            else
                            {
                                break;
                            }
                        }
                        //case 2:
                        //    if (geweest.Contains(p.X.ToString() + (p.Y - 1)))
                        //    {
                        //        break;
                        //    }
                        //    else { if(map[p.X, p.Y - 1] == ".")
                        //    {
                        //            toestand = toestand + "2";
                        //            geweest.Add(p.X.ToString() + p.Y);


                        //        }
                        //    else if (map[p.X, p.Y - 1] == "!")
                        //        {
                        //            toestand = toestand + "2";
                        //            rtoestand.Add(toestand);
                        //            return toestand;
                        //        }
                        //        else
                        //        {
                        //            break;
                        //        }
                        //        break;
                        //    }
                        //case 3:
                        //    if (geweest.Contains((p.X + 1).ToString() + p.Y))
                        //    {
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        if (map[p.X + 1, p.Y] == ".")
                        //        {
                        //            toestand = toestand + "3";
                        //            p.X += 1;
                        //            geweest.Add(p.X.ToString() + p.Y);


                        //        }
                        //        else if (map[p.X + 1, p.Y] == "!")
                        //        {
                        //            toestand = toestand + "3";
                        //            rtoestand.Add(toestand);
                        //            return toestand;
                        //        }
                        //        else
                        //        {
                        //            return " ";
                        //        }
                        //        break;
                        //    }
                        //case 4:
                        //    if (geweest.Contains((p.X - 1).ToString() + p.Y))
                        //    {
                        //        break;
                        //    }
                        //    else
                        //    {
                        //        if (map[p.X - 1, p.Y] == ".")
                        //        {
                        //            toestand = toestand + "4";
                        //            p.Y -= 1;
                        //            geweest.Add(p.X.ToString() + p.Y);


                        //        }
                        //        else if (map[p.X - 1, p.Y] == "!")
                        //        {
                        //            Console.WriteLine((p.X-1).ToString() + (p.Y));
                        //            toestand = toestand + "4";
                        //            rtoestand.Add(toestand);
                        //            return toestand;
                        //        }
                        //        else
                        //        {
                        //            return " ";
                        //        }
                        //        break;
                        //    }
                }
            }
            geweest.Add(p.X.ToString() + p.Y);
            for (int k = 0; k < 1; k++)
            {
                Console.WriteLine(p.Y);
                p.Y += rtoestand[k][0];
                Console.WriteLine(p.Y);
                toestand = move(p, d, map, rtoestand[0], geweest, rtoestand);
            }
            Console.WriteLine(toestand);
            return toestand;

        }
    }
}

