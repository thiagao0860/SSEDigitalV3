using SSEDigitalV3.MainDBConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    class CellDBWrapper
    {
        public static readonly int nullId = -1;
        public int id = nullId;
        public String name = null;
        public int setor = nullId;
        public CellDBWrapper(String name, int setor)
        {
            this.name = name;
            this.setor = setor;
        }
        public CellDBWrapper(String name, String setor)
        {
            this.name = name;
            SSEMainDBConnector connector = new SSEMainDBConnector();
            List<SetorDBWrapper> resultSetor = connector.findSections("s_id", setor);
            if (resultSetor.Count > 0)
            {
                this.setor = resultSetor.ElementAt(0).id;
            }else
            {
                throw new Exception("Impossible cell value");
            }

        }
        public CellDBWrapper(String name)
        {
            this.name = name;
        }
    }
}
