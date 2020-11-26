using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    class SetorDBWrapper
    {
        public static readonly int nullId = -1;
        public int id = nullId;
        public String name = null;
        public SetorDBWrapper(String name)
        {
            this.name = name;
        }
    }
}
