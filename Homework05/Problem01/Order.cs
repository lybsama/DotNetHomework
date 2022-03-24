using System;
using System.Collections.Generic;

namespace Problem01
{
    [Serializable]
    public class Order : IComparable
    {
        public int id { get; set; }
        public string customerName { get; set; }
        public double totalPrice { get; set; }

        private List<OrderDetails> orderItems = new List<OrderDetails>();

        public List<OrderDetails> OrderItems
        {
            get
            {
                return orderItems;
            }
            set
            {
                orderItems = value;
            }
        }
        public Order()
        {
            this.id = 0;
            this.customerName = string.Empty;
            this.totalPrice = 0;

        }
        public Order(int id, string customerName)
        {
            this.id = id;
            this.customerName = customerName;
        }

        public override bool Equals(object obj) 
        {
            Order a = obj as Order;
            return this.id == a.id;
        }

        public override int GetHashCode()
        {
            return this.id;
        }
        public int CompareTo(object obj)
        {
            return id.CompareTo(obj);
        }

        public void getAllPrice() 
        {
            double i = 0;
            foreach (OrderDetails a in this.orderItems)
            {
                i = i + a.getTotalPriceOftheItem();
            }
            this.totalPrice = i;
        }

        public void addItemToOrder(string name, int number, double price)  
        {
            OrderDetails anItemToAdd = new OrderDetails(name, number, price);
            this.orderItems.Add(anItemToAdd);
        }
        public void RemoveItemFromOrder(int id)
        {
            try
            {
                Console.WriteLine("删除成功");
                this.orderItems.RemoveAt(id);
            }
            catch
            {
                Console.WriteLine("输入序号错误");
            }
        }
        public void showOrderItem() 
        {
            Console.WriteLine("       序号 名称 数量 单价");
            Console.WriteLine("       ---------------------");
            foreach (OrderDetails anItemToShow in this.orderItems)
            {
                Console.WriteLine("       {0}    {1}  {2}    {3}", this.orderItems.IndexOf(anItemToShow), anItemToShow.ItemName, anItemToShow.AmountBought, anItemToShow.PerPrice);
            }
        }
    }
}