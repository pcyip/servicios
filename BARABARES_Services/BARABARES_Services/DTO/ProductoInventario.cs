﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BARABARES_Services.DTO
{
    public class ProductoInventario
    {
        public int idProducto { get; set; }
        public string nombre { get; set; }
        public int stock { get; set; }
    }
}