﻿using BookIt.Data.Models.Contracts;
using BookIt.Data.Models.Model;

namespace BookIt.Data.Models
{
    using System.Collections.Generic;

    public class Service : BookItEntity, IDeletableEntity, IBookItEntity
    {
        private ICollection<StaffUnit> providers;

        public Service()
        {
            this.providers = new HashSet<StaffUnit>();
        }

        //public int Id { get; set; }

        public int DurationInMinutes { get; set; }

        public decimal Price { get; set; }

        public int CategoryId { get; set; }

        public virtual Category Category { get; set; }

        public virtual ICollection<StaffUnit> Providers
        {
            get { return this.providers; }
            set { this.providers = value; }
        }
    }
}
