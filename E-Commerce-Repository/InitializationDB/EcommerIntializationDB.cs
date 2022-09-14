using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.InitializationDB
{
    internal class EcommerIntializationDB :DbContext
    {
        internal EcommerIntializationDB()
                    : base("name=EcommerIntializationDB")
            {
            var intialization = new DropCreateDatabaseAlways<EcommerIntializationDB>();
            Database.SetInitializer(intialization);
            }
        internal DbSet<Product> Products { get; set; }
        internal DbSet<TypeProduct> TypeProducts { get; set; }
        
    }
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new EcommerIntializationDB())
            {
                db.Database.Initialize(force: false);
            }
        }
    }

}
