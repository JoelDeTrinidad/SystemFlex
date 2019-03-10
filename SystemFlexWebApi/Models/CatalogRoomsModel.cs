using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemFlexWebApi.Models
{
    public class CatalogRoomsModel
    {
        public int RoomId { get; set; }
        public string Information { get; set; }
        public decimal Price { get; set; }
        public string ImageHbUrl { get; set; }
    }
}