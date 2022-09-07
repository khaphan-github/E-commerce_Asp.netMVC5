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
            List<String> result = new List<string>();
            result.Add("Phone");
            result.Add("Laptop");
            return result;

        }
    }
}
