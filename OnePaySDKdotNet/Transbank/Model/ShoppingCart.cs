using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Transbank.Exceptions;

namespace Transbank.Model
{
    public sealed class ShoppingCart
    {
        private List<Item> Items;
        public long Total { get; private set; } = 0;

        public ShoppingCart()
        {
            Items = new List<Item>();
        }

        public ReadOnlyCollection<Item> GetItems()
        {
            return new ReadOnlyCollection<Item>(Items);
        }

        public void Add(Item item)
        {
            long total = Total + item.Amount;
            if (total < 0)
                throw new AmountException(-1,"Total amount can't be less than zero");
            Total = total;
            Items.Add(item);
        }

        public void Remove(Item item)
        {
            long total = Total - item.Amount;
            if (total < 0)
                throw new AmountException(-1, "Total amount can't be less than zero");
            Total = total;
            Items.Remove(item);
        }

        public int GetItemQuantity()
        {
            return Items.Count;
        }
    }
}
