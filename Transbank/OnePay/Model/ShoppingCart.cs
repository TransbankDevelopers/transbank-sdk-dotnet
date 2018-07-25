using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Transbank.OnePay.Exceptions;

namespace Transbank.OnePay.Model
{
    public sealed class ShoppingCart
    {
        private List<Item> _items;

        public long Total { get; private set; } = 0;

        public int ItemQuantity
        {
            get => _items.Count;
        }

        public ShoppingCart()
        {
            _items = new List<Item>();
        }

        public ReadOnlyCollection<Item> Items
        {
            get => new ReadOnlyCollection<Item>(_items);
        }

        public void Add(Item item)
        {
            long total = Total + (item.Amount * item.Quantity) ;
            if (total < 0)
                throw new AmountException("Total amount can't be less than zero");
            Total = total;
            _items.Add(item);
        }

        public void Remove(Item item)
        {
            long total = Total - (item.Amount * item.Quantity) ;
            if (total < 0)
                throw new AmountException("Total amount can't be less than zero");
            Total = total;
            _items.Remove(item);
        }
    }
}
