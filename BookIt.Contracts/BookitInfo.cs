﻿namespace BookIt.Contracts
{
    using System;
    using System.ComponentModel.DataAnnotations.Schema;

    public abstract class BookitInfo : IBookitInfo
    {
        public DateTime CreatedOn { get; set; }

        /// <summary>
        /// Specifies whether or not the CreatedOn property should be automatically set.
        /// </summary>
        [NotMapped]
        public bool PreserveCreatedOn { get; set; }

        public DateTime? ModifiedOn { get; set; }
    }
}
