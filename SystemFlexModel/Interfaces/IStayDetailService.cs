using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.ViewModels;

namespace SystemFlexModel.Interfaces
{
    public interface IStayDetailService
    {
       string CreateStayDetail(StayDetailModel Detail);
    }
}
