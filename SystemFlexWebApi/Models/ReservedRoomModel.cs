using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SystemFlexWebApi.Models
{
    public class ReservedRoomModel
    {
        public int ReservationId { get; set; }

        public int RoomId { get; set; }

        public int CheckId { get; set; }
    }
}