using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SystemFlexModel.ViewModels
{
    public class PaymentTransactionModel
    {
        public int PaymentId { get; set; }

        public int CheckId { get; set; }

        public string NumberCard { get; set; }

        public DateTime Expiration { get; set; }

        public string Code { get; set; }
    }
}
