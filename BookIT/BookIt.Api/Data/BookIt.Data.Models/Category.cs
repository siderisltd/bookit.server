﻿using BookIt.Data.Models.Contracts;
using BookIt.Data.Models.Model;

namespace BookIt.Data.Models
{
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public class Category : BookItEntity, IBookItEntity
    {
        private ICollection<Service> services;
        private ICollection<Location> locations;

        public Category()
        {
            this.services = new HashSet<Service>();
            this.locations = new HashSet<Location>();
        }

        //public int Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Name { get; set; }

        public virtual ICollection<Service> Services
        {
            get { return this.services; }
            set { this.services = value; }
        }

        public virtual ICollection<Location> Locations
        {
            get { return this.locations; }
            set { this.locations = value; }
        }
    }
}
