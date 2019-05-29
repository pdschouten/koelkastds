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
            string[] arr = Console.ReadLine().Split(' ');
            int b = Int32.Parse(arr[0]);
            int h = Int32.Parse(arr[1]);
            string m = arr[2];
            string[,] map = new string[b, h];
            for (int i = 0; i < h; i++)
            {
                string line = Console.ReadLine();
                for (int j = 0; j < b; j++)
                {
                    map[j, i] = line[j].ToString();
                }
            }

            Point player = findIndex(map, "+");
            Point fridge = findIndex(map, "!");
            uint toestand = (((uint)player.X) << 24) + (((uint)player.Y) << 16) + (((uint)fridge.X) << 8) + (((uint)fridge.Y));
            Point goal = findIndex(map, "?");
            uint gtoestand = (((uint)goal.X) << 8) + (((uint)goal.Y));
            int aantalstappen = bfs(toestand, gtoestand, map);
            //Console.WriteLine(((toestand >> 24)));
            //Console.WriteLine((toestand >> 16) - ((toestand >> 24) << 8) + (uint)1);
            //Console.WriteLine(map[((toestand >> 24)), (toestand >> 16) - ((toestand >> 24) << 8) + (uint)1]);
            Console.WriteLine(aantalstappen);
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

        public static int bfs(uint t, uint gt, string[,] map)
        {
            List<uint> q = new List<uint>();
            Dictionary<uint, uint> geweest = new Dictionary<uint, uint>();
            q.Add(t);
            while (q.Count > 0)
            {
                uint u = q.First();
                foreach (uint x in succesors(u, map))
                {
                    if (!geweest.ContainsKey(x))
                    {
                        Console.WriteLine(x);
                        q.Add(x);
                        geweest.Add(x, u);
                        if (map[x >> 24, (x >> 16) - ((x >> 24) << 8)] == "!")
                        {
                            
                        }
                    }
                }
                q.RemoveAt(0);
            }
            return -1;
        }

        public static List<uint> succesors(uint t, string[,] map)
        {
            int[] d = new int[] { 1, 2, 3, 4 };
            List<uint> s = new List<uint>();
            uint x = t >> 24;
            uint y = (t >> 16) - ((t >> 24) << 8);
            for (int i = 0; i < d.Length; i++)
            {
                switch (d[i])
                {
                    case 1:
                        if (map[(x + (uint)1), y] == ".")
                        {
                            s.Add(t + (1 << 24));
                        }else if (map[(x + (uint)1), y] == "!")
                        {
                            fsuccesors(map, t,s,1,x,y);
                        }
                        break;
                    case 2:
                        if (map[(x - (uint)1), y] == "." || map[(x - (uint)1), y] == "!")
                        {
                            s.Add(t - (1 << 24));
                        }
                        break;
                    case 3:
                        if (map[x, y + (uint)1] == "." || map[x, y + (uint)1] == "!")
                        {
                            s.Add(t + (1 << 16));
                        }
                        break;
                    case 4:
                        if (map[x, y - (uint)1] == "."|| map[x, y - (uint)1] == "!")
                        {
                            s.Add(t - (1 << 16));
                        }
                        break;
                }
            }
            return s;
        }

        public static List<uint> fsuccesors(string[,] map, uint t, List<uint> s, int d, uint x, uint y)
        {
            switch (d)
            {
                case 1:
                    if(map[(x + (uint)2), y] == ".")
                    {
                        s.Add(t + (1 << 8) + (1<<24));
                    }
                    else if (map[(x + (uint)1), y + (uint)1] == ".")
                    {
                        s.Add(t + 1 + (1 << 24));
                    }else if (map[(x + (uint)1), y - (uint)1] == ".")
                    {

                    }
                    break;
            }
            

            return s;
        }

    }
}

