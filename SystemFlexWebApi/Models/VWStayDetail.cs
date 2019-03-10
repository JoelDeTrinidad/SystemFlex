﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemFlexWebApi.Models
{
    public class VWStayDetail
    {
        public int DetailId { get; set; }
        public int UserId { get; set; }
        public DateTime DateCreation { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Days { get; set; }
        public int? CatalogId { get; set; }
        public int? roomQuantity { get; set; }
        public int? roomQuantityCatalog { get; set; }
    }
}