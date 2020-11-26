using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    class TypeDBWrapper
    {
        public static readonly int nullId = -1;
        public int id = nullId;
        public String tipo = null;
        public TypeDBWrapper(String tipo)
        {
            this.tipo = tipo;
        }
    }
}
