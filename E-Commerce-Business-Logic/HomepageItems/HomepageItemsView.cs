using E_Commerce_Repository.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.HomepageItems
{
    public class HomepageItemsView
    {
        public List<String> CategoryView()
        {
            ProductRepository repository = new ProductRepository();
            List<String> product = new List<string>();
            product.Add(repository.GetProducts().ToString());
            return product;
        }
    }
}
