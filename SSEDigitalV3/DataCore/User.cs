using SSEDigitalV3.MainDBConnector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSEDigitalV3.DataCore
{
    public class User
    {
        private Int32 id;
        private string matricula =null;
        private string nome =null;
        private string ramal = null;
        private Int32 celula = CelulaOpts.CELULA_INT_NULL_CODE;
        private string email = null;
        private string setor = null;
        private bool superuser = false;

        public string Matricula { get => matricula; set => matricula = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Ramal { get => ramal; set => ramal = value; }
        public Int32 CelulaInt  { get => celula; set => celula = value; }
        public String CelulaString { get => getSavebleCelula(celula); set => celula = parseCelulaValue(value); }
        public string Setor { get => setor ; set => setor = value; }
        public string Email { get => email ; set => email = value; }
        public bool Superuser { get => superuser ; set => superuser = value; }
        public Int32 Id { get => id; set => id = value; }

        public static Int32 parseCelulaValue(string value)
        {
            value = value.ToUpper();
            SSEMainDBConnector db = new SSEMainDBConnector();
            List<CellDBWrapper> types = db.findCells("Cell_name", value);
            if (types.Count > 0)
            {
                Console.WriteLine(types[0].id);
                return types[0].id;
            }
            else
            {
                return User.CelulaOpts.CELULA_INT_NULL_CODE;
            }
        }

        public static class CelulaOpts
        {
            public static readonly int CELULA_INT_NULL_CODE = -1;
            public static readonly string CELULA_STRING_NULL_CODE = null;
        }

        public static String getSavebleCelula(Int32 celula)
        {
            SSEMainDBConnector db = new SSEMainDBConnector();
            List<CellDBWrapper> types = db.findCells("id", celula);
            if (types.Count > 0)
            {
                Console.WriteLine(types[0].id);
                return types[0].name;
            }
            else
            {
                return User.CelulaOpts.CELULA_STRING_NULL_CODE;
            }
        }


    }

}
