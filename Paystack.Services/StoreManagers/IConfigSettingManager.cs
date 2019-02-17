using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Business.StoreManagers
{
    public interface IConfigSettingManager
    {
        string Bearer { get; set; }
        string BaseUrl { get; set; }
        string SecKey { get; set; }
    }
}
