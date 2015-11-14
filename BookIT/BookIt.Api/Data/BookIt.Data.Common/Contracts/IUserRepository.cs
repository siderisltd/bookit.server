﻿namespace BookIt.Data.Common.Contracts
{
    using Microsoft.AspNet.Identity.EntityFramework;

    public interface IUsersRepository : IRepository<IdentityUser>
    {
        IdentityUser GetByUsername(string username);
    }
}
