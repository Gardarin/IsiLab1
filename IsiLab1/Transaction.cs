using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IsiLab1
{
    class Transaction
    {
        public int Id;
        public List<Item> Items{get;set;}

        public Transaction(int id,List<Item> items)
        {
            Id = id;
            Items = items;
        }
    }
}
