using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Laptop : Describe
    {
        public string CPU { get; set; }
        public int Ram { get; set; }
        public string HardDisk { get; set; }
        public string GraphicsCard { get; set; }
    }
}
