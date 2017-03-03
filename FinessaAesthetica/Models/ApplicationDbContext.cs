using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace FinessaAesthetica.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext() : base("DefaultConnection") { }

        public DbSet<Users> Users { get; set; }
        public DbSet<Supplier> Suppliers { get; set; }

        public DbSet<Status> Statuses { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }

        public DbSet<Color> Colors { get; set; }
        public DbSet<Branch> Branches { get; set; }
        public DbSet<Service> Services { get; set; }
        public DbSet<MainInventory> MainInventories { get; set; }
        public DbSet<BranchInventory> BranchInventories { get; set; }
        public DbSet<Consignee> Consignees { get; set; }

        public DbSet<PurchaseOrder> PurchaseOrders { get; set; }

        public DbSet<PurchaseOrderItems> PurchaseOrderItems { get; set; } 

    }
}