using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C__project_API.Models;
using Microsoft.EntityFrameworkCore;

namespace C__project_API.Contexts
{
    public class ItemContext : DbContext
    {
        public ItemContext(DbContextOptions<ItemContext> opt) : base(opt)
        {
            
        }

        public DbSet<Item> items { get; set;}
    }
}