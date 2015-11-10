using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiLab1
{
    class Program
    {
        static List<Transaction> Transactions = new List<Transaction>();
        static List<Item> Items = new List<Item>();
        static List<Item> UItems = new List<Item>();
        static int[,] Array;

        static void Main(string[] args)
        {
            Items.Add(new Item("Q", 1));
            Items.Add(new Item("W", 1));
            Items.Add(new Item("E", 1));
            Items.Add(new Item("R", 1));
            Transactions.Add(new Transaction(0, Items.ToList<Item>()));
            Transactions.Add(new Transaction(1, Items.ToList<Item>()));
            Transactions.Add(new Transaction(2, Items.ToList<Item>()));
            Items.Clear();
            Items.Add(new Item("T", 1));
            Items.Add(new Item("Y", 1));
            Items.Add(new Item("U", 1));
            Transactions.Add(new Transaction(3, Items.ToList<Item>()));



            foreach (Transaction t in Transactions)
            {
                foreach (Item i in t.Items)
                {
                    if (!UItems.Contains(i))
                    {
                        UItems.Add(i);
                    }
                }
            }

            Array = new int[UItems.Count, Transactions.Count];
            Array.Initialize();

            for (int i = 0; i < Transactions.Count; ++i)
            {
                for (int j = 0; j < Transactions[i].Items.Count; ++j)
                {
                    int ii = UItems.IndexOf(Transactions[i].Items[j]);
                    Array[ii, i] = 1;
                }
            }

            for (int i = 0; i < Transactions.Count; ++i)
            {
                for (int j = 0; j < UItems.Count; ++j)
                {
                    Console.Write(Array[j, i]);
                    Console.Write(" ");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine();

            int[] ar;
            for (int q = 2; q < 5; ++q)
            {
                ar = new int[q];
                for (int i = 0; ; )
                {
                    if (i >= ar.Length)
                    {
                        Print(ar.ToList<int>());
                        i--;
                        continue;
                    }
                    if (i == 0 && ar[i] + ar.Length > UItems.Count)
                    {
                        break;
                    }
                    if (ar[i] + 1 > UItems.Count)
                    {
                        ar[i] = ar[i - 1] + 1;
                        i--;
                        continue;
                    }
                    else
                    {
                        ar[i]++;
                    }


                    if (i == 0)
                    {
                        i++;
                    }
                    if (ar[i - 1] < ar[i])
                    {
                        i++;
                    }
                }
            }
            Console.WriteLine();
            Console.WriteLine();
            List<int> li = new List<int>();
            for (int i = 0; i < UItems.Count; ++i)
            {
                for (int j = i + 1; j < UItems.Count; ++j)
                {
                    li = new List<int>() { i + 1, j + 1 };
                    Print(li);
                }
            }

            li = new List<int>();
            for (int i = 0; i < UItems.Count; ++i)
            {
                for (int j = i + 1; j < UItems.Count; ++j)
                {
                    for (int k = j + 1; k < UItems.Count; ++k)
                    {
                        li = new List<int>() { i + 1, j + 1, k + 1 };
                        Print(li);
                    }
                }
            }

            li = new List<int>();
            for (int i = 0; i < UItems.Count; ++i)
            {
                for (int j = i + 1; j < UItems.Count; ++j)
                {
                    for (int k = j + 1; k < UItems.Count; ++k)
                    {
                        for (int n = k + 1; n < UItems.Count; ++n)
                        {
                            li = new List<int>() { i + 1, j + 1, k + 1, n + 1 };
                            Print(li);
                        }
                    }
                }
            }
        }

        static void Print(List<int> li)
        {
            int support = FindSupport(li);
            if (support > 0)
            {
                Console.Write("( ");
                foreach (int a in li)
                {
                    Console.Write(UItems[a-1].Name + " ");
                }
                Console.Write(")");
                Console.WriteLine(" " + support + " " + ((float)support / Transactions.Count) * 100+"%");
            }
        }

        static public int FindSupport(List<int> li)
        {
            int support = 0;
            for (int j = 0; j < Transactions.Count; ++j)
            {
                bool b = true;
                foreach (int a in li)
                {
                    if (Array[a-1, j] != 1)
                    {
                        b = false;
                        break;
                    }
                }
                if (b)
                {
                    support++;
                }
            }
            return support;
        }
    }
}
