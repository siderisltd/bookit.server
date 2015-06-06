﻿namespace BookIt.Models
{
    public class Service
    {
        public int CategoryID { get; set; }

        public virtual Category Category { get; set; }

        public int Duration { get; set; }

        public decimal Price { get; set; }
    }
}
