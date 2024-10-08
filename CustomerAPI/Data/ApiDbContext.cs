﻿using Microsoft.EntityFrameworkCore;
namespace CustomerAPI.Data
{
    public class ApiDbContext : DbContext
    {
        public ApiDbContext(DbContextOptions<ApiDbContext> options) : base(options)
        {

        }
        public DbSet<Customer> Customers { get; set; }
    }
}

