using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemFlexModel.ViewModels;

namespace SystemFlexModel.Interfaces
{
    public interface IVWStayDetailService
    {
        List<VWStayDetail> Getview();
        void DeleteStayDetail(int Id);
    }
}
