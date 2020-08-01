using System;

namespace CTShopSolution.Data.Entities
{
    public class Cart
    {
        public int Id { set; get; }
        public int ProductId { set; get; }
        public int Quantity { set; get; }
        public decimal Price { set; get; }

        public Guid UserId { get; set; }

        public Product Product { get; set; }

        public DateTime DateCreated { get; set; }

        //khi tao app user thi phai tro den khoa ngoai
        public AppUser AppUser { get; set; }
    }
}
