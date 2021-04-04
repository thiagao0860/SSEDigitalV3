using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigital
{
    public class SSEBean 
    {
        public String id;
        private string tipo;
        private string fornecedor;
        private string requisitante;
        private string ordem;
        private string codigo;
        private string referencia;
        private string nota;
        private string ramal;
        private string celula;
        private string pedido;
        private string equipamento;
        private string prazo;
        private string prioridade;
        private string data;
        private string descricao;
        private string valor;
        private string valorOrc;
        private string peso;
        private string requisicao;
        private string quantidade;

        public string Tipo { get => tipo; set => tipo = value; }
        public string Fornecedor { get => fornecedor; set => fornecedor = value; }
        public string Requisitante { get => requisitante; set => requisitante = value; }
        public string Ordem { get => ordem; set => ordem = value; }
        public string Codigo { get => codigo; set => codigo = value; }
        public string Referencia { get => referencia; set => referencia = value; }
        public string Nota { get => nota; set => nota = value; }
        public string Ramal { get => ramal; set => ramal = value; }
        public string Celula { get => celula; set => celula = value; }
        public string Pedido { get => pedido; set => pedido = value; }
        public string Equipamento { get => equipamento; set => equipamento = value; }
        public string Prazo { get => prazo; set => prazo = value; }
        public string Prioridade { get => prioridade; set => prioridade = value; }
        public string  Data { get => data; set => data = value; }
        public string Descricao { get => descricao; set => descricao = value; }
        public string Valor { get => valor; set => valor = value; }
        public string ValorOrc { get => valorOrc; set => valorOrc = value; }
        public string Peso { get => peso; set => peso = value; }
        public string Requisicao { get => requisicao; set => requisicao = value; }
        public string Quantidade { get => quantidade; set => quantidade = value; }

        public SSEBean(String data)
        {
            this.Data = data;
            this.id = "-1";
        }

        public SSEBean(String id, String data)
        {
            this.id = id;
            this.Data = data;
        }

        public SSEBean()
        {
            this.id = "-1";
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
    }
}
