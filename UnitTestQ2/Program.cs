using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net;
using System.Web;
using System.Text.RegularExpressions;

namespace PE21
{
    class Program
    {
        static int[,] AjMatrix = new int[,]
        {
            /*Red*/ /*Navy*/ /*Yellow*/ /*Green*/ /*Gray*/ /*Blue*/ /*Purple*/ /*Orange*/
            /*Red*/{ -1, 1, -1, -1, 5, -1, -1, -1},
            /*Navy*/{-1, -1, 8, -1, -1, 1, -1, -1 },
            /*Yellow*/{-1, -1, -1, 4, -1, -1, -1, -1 },
            /*Green*/{-1, -1, -1, -1, -1, -1, -1, -1 },
            /*Gray*/{-1, -1, -1, -1, -1, 0, -1, 1 },
            /*Blue*/{-1, 1, -1, -1, 0, -1, 1, -1 },
            /*Purple*/{-1, -1, 1, -1, -1, -1, -1, -1 },
            /*Orange*/{-1, -1, -1, -1, -1, -1, 1,-1 }
        };
        class AdjList
        {
            LinkedList<Tuple<int, int>>[] adjList;
            public AdjList(int ver)
            {
                adjList = new LinkedList<Tuple<int, int>>[ver];
                for (int i = 0; i < adjList.Length; ++i)
                {
                    adjList[i] = new LinkedList<Tuple<int, int>>();
                }
            }
            public void addEnd(int start, int end, int weight)
            {
                adjList[start].AddLast(new Tuple<int, int>(end, weight));
            }
            public int getNumber()
            {
                return adjList.Length;
            }
            public LinkedList<Tuple<int, int>> this[int i]
            {
                get
                {
                    LinkedList<Tuple<int, int>> edge = new LinkedList<Tuple<int, int>>(adjList[i]);
                    return edge;
                }
            }
            public void printList()
            {
                int i = 0;
                foreach (LinkedList<Tuple<int, int>> list in adjList)
                {
                    foreach (Tuple<int, int> edge in list)
                    {
                        Console.Write("{0} -> ", i);
                        Console.WriteLine(edge.Item1 + "(" + edge.Item2 + ")");
                    }
                    ++i;
                }
            }
        }
        static void Main()
        {
            AdjList adjList = new AdjList(8);
            for (int i = 0; i < 8; i++)
            {
                for (int j = 0; j < 8; j++)
                {
                    if (AjMatrix[i, j] > -1)
                    {
                        adjList.addEnd(i, j, AjMatrix[i, j]);
                    }
                }
            }
            adjList.printList();
            Console.WriteLine("DFS Print:");
            dfsPrint(adjList);
            Console.WriteLine("Shortedst path:");
            List<int> path = dij(adjList, 0, 3);
            foreach (var item in path)
            {
                Console.Write("{0} ", getColor(item));
            }
        }
        static void dfsPrint(AdjList l)
        {
            List<int> visited = new List<int>();
            for (int i = 0; i < l.getNumber(); i++)
            {
                foreach (Tuple<int, int> edge in l[i])
                {
                    if (!visited.Contains(i))
                    {
                        visited.Add(i);
                        Console.WriteLine(getColor(i));
                    }
                    if (!visited.Contains(edge.Item1))
                    {
                        visited.Add(edge.Item1);
                        Console.WriteLine(getColor(edge.Item1));
                    }
                }
            }
        }
        static List<int> dij(AdjList l, int start, int end)
        {
            int cost = int.MaxValue;
            List<int> path = new List<int>();
            List<int> visited = new List<int>();

            LinkedList<Tuple<int, int>> edge = l[start];
            int next = start;
            path.Add(next);
            while (next != end)
            {
                foreach (Tuple<int, int> item in edge)
                {
                    if (item.Item2 < cost)
                    {
                        if (!visited.Contains(item.Item1))
                        {
                            next = item.Item1;
                            cost = item.Item2;
                        }
                    }
                }
                visited.Add(next);
                path.Add(next);
                edge = l[next];
                cost = int.MaxValue;
            }
            return path;
        }
        static string getColor(int i)
        {
            /*Red*/ /*Navy*/ /*Yellow*/ /*Green*/ /*Gray*/ /*Blue*/ /*Purple*/ /*Orange*/
            switch (i)
            {
                case 0:
                    return "Red";
                case 1:
                    return "Navy";
                case 2:
                    return "Yellow";
                case 3:
                    return "Green";
                case 4:
                    return "Gray";
                case 5:
                    return "Blue";
                case 6:
                    return "Purple";
                case 7:
                    return "Orange";
                default:
                    return "";
            }
        }


    }
}