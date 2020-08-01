using System;
using System.Collections.Generic;
using System.Text;

namespace CTShopSolution.Data.Entities
{
    public class ProductInCategory
    {
        //tao khoa ngoai cho 2 bang product va category
        //
        public int ProductId { get; set; }

        public Product Product { get; set; }

        public int CategoryId { get; set; }

        public Category Category { get; set; }
    }
}
