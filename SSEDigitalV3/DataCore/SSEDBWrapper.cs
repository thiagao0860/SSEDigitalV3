using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    public class SSEDBWrapper
    {
        public static readonly DateTime nullDateTime = DateTime.MinValue;
        public static readonly int null_id = -1;
        
        private SSEBean iSSEBean = null;

        public long id = null_id;
        public String iss=null;
        public String codigo_do_servico=null ;
        public String codigo_do_produto=null ;
        public String numero_do_orcamento=null ;
        public String numero_da_PO = null ;
        public DateTime data_recebimento= nullDateTime;
        public float valor_do_orcamento_retorno = -1;
        public SSEBean  ISSEBean { get => iSSEBean; set => iSSEBean = value; }

        public SSEDBWrapper(SSEBean sse)
        {
            iSSEBean = sse;
        }
    }
}
