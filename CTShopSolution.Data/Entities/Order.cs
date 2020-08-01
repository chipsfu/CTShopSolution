using System;
using System.Collections.Generic;
using System.Text;
using CTShopSolution.Data.Enum;

namespace CTShopSolution.Data.Entities
{
    public class Order
    {
        public int Id { set; get; }
        public DateTime OrderDate { set; get; }
        public Guid UserId { set; get; }
        public string ShipName { set; get; }
        public string ShipAddress { set; get; }
        public string ShipEmail { set; get; }
        public string ShipPhoneNumber { set; get; }
        public OrderStatus Status { set; get; }
        //Cau hinh khoa 1-nhieu , 1 order cos nhieu order details
        public List<OrderDetail> OrderDetails { get; set; }


        public AppUser AppUser { get; set; }
    }
}
