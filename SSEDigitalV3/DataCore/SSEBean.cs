
using SSEDigitalV3.MainDBConnector;
using System;
using System.Collections.Generic;

namespace SSEDigitalV3.DataCore
{
    public class SSEBean 
    {
        public static readonly string  EMPTY_ID_CODE = "-1";
        public static readonly int  nullInteger = -1;
        public static readonly float  nullFloat = -1;

        public String id = SSEBean.EMPTY_ID_CODE;
        private Int16 tipo;
        private Int16 fornecedor;
        private User requisitante= new User();
        private String ordem;
        private String codigo;
        private String referencia;
        private String nota;
        private String equipamento;
        private DateTime prazo;
        private int prioridade;
        private DateTime data;
        private String descricao;
        private float valor;
        private float valorOrc;
        private float peso;
        private String requisicao;
        private int quantidade;

        public short Tipo { get => tipo; set => tipo = value; }
        public short Fornecedor { get => fornecedor; set => fornecedor = value; }
        public User Requisitante { get => requisitante; set => requisitante = value; }
        public string Ordem { get => ordem; set => ordem = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Referencia { get => referencia; set => referencia = value; }
        public string Nota { get => nota; set => nota = value; }
        public string Ramal { get => requisitante.Ramal; set => requisitante.Ramal = value; }
        public int CelulaInt { get => requisitante.CelulaInt; set => requisitante.CelulaInt = value; }
        public string CelulaString { get => requisitante.CelulaString; set => requisitante.CelulaString = value; }
        public string Equipamento { get => equipamento; set => equipamento = value; }
        public DateTime Prazo { get => prazo; set => prazo = value; }
        public int Prioridade { get => prioridade; set => prioridade = value; }
        public DateTime Data { get => data; set => data = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public float Valor { get => valor; set => valor = value; }
        public float ValorOrc { get => valorOrc; set => valorOrc = value; }
        public float Peso { get => peso; set => peso = value; }
        public string Requisicao { get => requisicao; set => requisicao = value; }
        public int Quantidade { get => quantidade; set => quantidade = value; }

        public SSEBean(DateTime data)
        {
            this.Data = data;
        }

        public SSEBean(String id)
        {
            this.id = id;
        }

        public SSEBean(String id, DateTime data)
        {
            this.id = id;
            this.Data = data;
        }

        public SSEBean(){}

        public SSEBean(User user)
        {
            this.requisitante = user;
        }

        public SSEBean(DateTime data, User user)
        {
            this.data = data;
            this.requisitante = user;
        }

        public SSEBean(String id, DateTime data, User user)
        {
            this.id = id;
            this.data = data;
            this.requisitante = user;
        }

        public override string ToString()
        {
            return "{[id: "+ id +"] ,"+
                "[tipo: " + tipo + "] ,"+
                "[fornecedor: " + fornecedor + "]}";
        }

        public override bool Equals(object obj)
        {
            if(obj is SSEBean)
            {
                SSEBean testValue = (SSEBean)obj;
                Boolean returnStatement = true;
                returnStatement = returnStatement && (testValue.id.Equals(this.id));
                return returnStatement;
            }
            else
            {
                base.Equals(obj);
            }
            return false;
        }

        public String getSavebleTipo()
        {
            SSEMainDBConnector db = new SSEMainDBConnector();
            List<TypeDBWrapper> types = db.findTypes("id", tipo);
            if (types.Count > 0)
            {
                Console.WriteLine(types[0].id);
                return types[0].tipo;
            }
            else
            {
                return SSEBean.TipoOpts.TIPO_STRING_NULL_CODE;
            }
        }

        public String getSavebleFornecedor()
        {
            SSEMainDBConnector db = new SSEMainDBConnector();
            List<ProviderDBWrapper> providers = db.findProviders("id", fornecedor);
            if (providers.Count > 0)
            {
                return providers[0].fornecedor;
            }
            else
            {
                return FornecedorOpts.FORNECEDOR_STRING_NULL_CODE;
            }
        }

        public static class TipoOpts
        {
            public static readonly Int32 MIN_INDEX_OPT = 0;
            public static readonly int TIPO_INT_NULL_CODE = -1;
            public static readonly string TIPO_STRING_NULL_CODE = null;
        }
        
        public static class FornecedorOpts
        {
            public static readonly Int32 MIN_INDEX_OPT = 0;
            public static readonly int FORNECEDOR_INT_NULL_CODE = -1;
            public static readonly string FORNECEDOR_STRING_NULL_CODE = null;
        }

        public static Int32 parseTipoValue(string value)
        {
            SSEMainDBConnector db = new SSEMainDBConnector();
            List<TypeDBWrapper> types = db.findTypes("sse_type", value);
            if (types.Count > 0)
            {
                Console.WriteLine(types[0].id);
                return types[0].id;
            }
            else {
                return SSEBean.TipoOpts.TIPO_INT_NULL_CODE;
            }
        }

        public static Int32 parseFornecedorValue(string value)
        {
            SSEMainDBConnector db = new SSEMainDBConnector();
            List<ProviderDBWrapper> providers = db.findProviders("provider", value);
            if (providers.Count > 0)
            {
                return providers[0].id;
            }
            else
            {
                return FornecedorOpts.FORNECEDOR_INT_NULL_CODE;
            }
        }
    }
}
