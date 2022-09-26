﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce_Repository.Models
{
    public class Wards
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public virtual Address Address { get; set; }

    }
}
