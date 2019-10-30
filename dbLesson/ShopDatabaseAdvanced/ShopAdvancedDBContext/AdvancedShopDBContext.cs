using ShopDatabaseAdvanced.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShopDatabaseAdvanced.ShopAdvancedDBContext
{
    class AdvancedShopDBContext : DbContext
    {
        public AdvancedShopDBContext() : base("AdvancedShopDatabase"){ }

        public DbSet<ShoppingCart> ShoppingCarts { get; set; }

        public DbSet<Food> Foods {get;set;}

    }
}
