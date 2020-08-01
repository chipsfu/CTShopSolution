using System;
using System.Collections.Generic;
using System.Text;

namespace CTShopSolution.Data.Entities
{
    public class OrderDetail
    {

        public int OrderId { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }
        // cau hinh khoa nhieu orderdetail chi co 1 order
        public Order Order { get; set; }
        //Cau hinh key
        //Phai tro den Product
        public Product Product { get; set; }

    }
}
