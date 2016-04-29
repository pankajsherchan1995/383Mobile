﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FinalWebAPI.Models.DTOs
{
    public class PurchaseDTO
    {
        public string Name { get; set; }

        public decimal Price { get; set; }

        public string type { get; set; }

        public string time { get; set;  }

        public int InventoryCount { get; set; }

        public string ScreenNumber { get; set; }
    }
}