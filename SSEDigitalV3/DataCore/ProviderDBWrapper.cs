using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    class ProviderDBWrapper
    {
        public static readonly int nullId =-1; 
        public int id = nullId;
        public String fornecedor = null;
        public ProviderDBWrapper(String fornecedor)
        {
            this.fornecedor = fornecedor;
        }
    }
}
