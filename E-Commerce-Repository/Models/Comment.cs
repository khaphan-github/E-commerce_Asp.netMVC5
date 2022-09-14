using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    internal class Comment
    {
        public string Description { get; set; }

        public AccountConsumer AccountConsumer { get; set; }
    }
}
