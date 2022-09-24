using E_Commerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Business_Logic.Admin
{
    public class BrandView
    {
        public List<Company> BrandsView()
        {
            // Get data from data base;

            List<Company> brands = new List<Company>();
            Company brand = new Company();
            brand.Id = 1;
            brand.Name = "DELL";
            brands.Add(brand);
            brands.Add(brand);
            brands.Add(brand); brands.Add(brand); brands.Add(brand);

            return brands;
        }

        // Return product in shopping card of Account
        
    }
}
