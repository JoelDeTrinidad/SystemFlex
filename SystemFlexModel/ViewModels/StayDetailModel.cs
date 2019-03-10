using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemFlexModel.ViewModels
{
    public class StayDetailModel
    {
        public int DetailId { get; set; }
        public int UserId { get; set; }
        public int? CatalogId { get; set; }
        public DateTime InitialDate { get; set; }
        public DateTime EndDate { get; set; }
        public int? Days { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
