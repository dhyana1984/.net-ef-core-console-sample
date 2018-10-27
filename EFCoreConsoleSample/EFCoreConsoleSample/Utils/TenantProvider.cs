using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCoreConsoleSample.Utils
{
    public interface ItenantProvider
    {
        Guid GetTenantId();
    }
    class TenantProvider : ItenantProvider
    {
        public Guid GetTenantId()
        {
            return Guid.Parse("");
        }
    }
}
