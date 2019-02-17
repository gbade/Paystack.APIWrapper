using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Paystack.Business.StoreManagers
{
    public class ConfigSettingManager : IConfigSettingManager
    {
        public string Bearer { get; set; }
        public string BaseUrl { get; set; }
        public string SecKey { get; set; }
    }
}
