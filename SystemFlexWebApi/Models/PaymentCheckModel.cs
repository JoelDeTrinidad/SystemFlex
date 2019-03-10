using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemFlexWebApi.Models
{
    public class PaymentCheckModel
    {
        public int VoucherId { get; set; }
        public int DetailId { get; set; }
        public int UserId { get; set; }
        public int? CodeId { get; set; }
        public int? ExtraId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public decimal TotalPayment { get; set; }
        public bool? Payed { get; set; }
        public ReservedRoomModel Reserved { get; set; }
        public List<CatalogRoomsModel> CatalogRoom { get; set; }
        public PaymentTransactionModel PaymentTransaction { get; set; }
    }
}