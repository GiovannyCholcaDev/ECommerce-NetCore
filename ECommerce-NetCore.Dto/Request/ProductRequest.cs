﻿namespace ECommerceAPI.Dto.Request
{
    public class ProductRequest
    {
        public string Name { get; set; }

        public string Description { get; set; }

        public string CategoryId { get; set; }

        public decimal UnitPrice { get; set; }

        public string FileName { get; set; }

        public bool Active { get; set; }
    }
}