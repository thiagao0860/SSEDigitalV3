using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    struct PORow
    {
        public String description;
        public Double amount;
        public String classificacaoFiscal_NCM;
        public String cenntro_de_Custo;
        public String codServico;
        public Double unitValue;   
        public String iSSMode;   
        public Double iSSAliq;   
        public String iCMSdest;   
        public Double iCMSaliq;
        public String iPIdest;
        public Double iPIaliq;
        public Double unitValueSAP;
        public String iCMSST;
    }
    class POWrapper
    {
        public String vPOONumber;
        public String fornecedor;
        public String vCNPJ;
        public Double grossValue;
        public Double netValue;
        public List<PORow> servicesInfo = new List<PORow>();

        public POWrapper()
        {

        }
    }
    
}
