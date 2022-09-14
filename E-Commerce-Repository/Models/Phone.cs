using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Phone:Describe 
    {
        public string ModelName { get; set; }
        public int Pin { get; set; }
        public string CellularTechnolory { get; set; }
        public string MemoryStorageCapcity { get; set; }
        public string Color { get; set; }
        public string ScreenSize { get; set; }
    }
}
