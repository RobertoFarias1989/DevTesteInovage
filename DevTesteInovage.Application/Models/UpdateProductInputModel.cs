﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevTesteInovage.Application.Models
{
    public class UpdateProductInputModel
    {
        public int Id { get;  set; }
        public string Description { get;  set; }
        public decimal Price { get;  set; }
    }
}
