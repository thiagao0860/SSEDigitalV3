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

        public string Matricula { get => matricula; set => matricula = value; }
        public string Nome { get => nome; set => nome = value; }
        public string Ramal { get => ramal; set => ramal = value; }
        public Int32 CelulaInt  { get => celula; set => celula = value; }
        public String CelulaString { get => getSavebleCelula(celula); set => celula = parseCelulaValue(value); }
        public string Setor { get => setor ; set => setor = value; }
        public string Email { get => email ; set => email = value; }
        public Int32 Id { get => id; set => id = value; }

        public static Int32 parseCelulaValue(string value)
        {
            value = value.ToUpper();
            if (value.Equals("1A")) { return User.CelulaOpts.SMD_1A; }
            else if (value.Equals("1B")) { return User.CelulaOpts.SMD_1B; }
            else if (value.Equals("2A")) { return User.CelulaOpts.SMD_2A; }
            else if (value.Equals("2B")) { return User.CelulaOpts.SMD_2B; }
            else if (value.Equals("3A")) { return User.CelulaOpts.SMD_3A; }
            else if (value.Equals("3B")) { return User.CelulaOpts.SMD_3B; }
            else if (value.Equals("FMD1")) { return User.CelulaOpts.FMD_1; }
            else if (value.Equals("FMD2")) { return User.CelulaOpts.FMD_2; }
            else if (value.Equals("PMD1")) { return User.CelulaOpts.PMD_1; }
            else if (value.Equals("PMD2")) { return User.CelulaOpts.PMD_2; }
            else if (value.Equals("PMD3")) { return User.CelulaOpts.PMD_3; }
            else if (value.Equals("ALMOX")) { return User.CelulaOpts.ALMOX; }
            else if (value.Equals("SUBCONJUNTO")) { return User.CelulaOpts.SUBCONJUNTO; }
            else if (value.Equals("UTILIDADES")) { return User.CelulaOpts.UTILIDADES; }
            else if (value.Equals("EP")) { return User.CelulaOpts.EP; }
            else if (value.Equals("CAE")) { return User.CelulaOpts.CAE; }
            else if (value.Equals("EXP")) { return User.CelulaOpts.EXP; }
            else { return CelulaOpts.CELULA_INT_NULL_CODE; }
        }

        public static class CelulaOpts
        {
            //metodo de geracao de tipos baseado no teorema da fatoracao de base unica,
            //cada area possui um numero primo como base e seus valores seguem uma PG
            //ao final basta dividir o valor final pelo primo do grupo e o valor sera divisivel apenas
            //pelo valor do seu grupo, caso um valor pertenca a dois grupos basta multiplicar as duas bases

            public static readonly Int32 SMD_BASE = 2;
            public static readonly Int32 SMD_1A = (Int32)Math.Pow(SMD_BASE, 1);
            public static readonly Int32 SMD_1B = (Int32)Math.Pow(SMD_BASE, 2);
            public static readonly Int32 SMD_2A = (Int32)Math.Pow(SMD_BASE, 3);
            public static readonly Int32 SMD_2B = (Int32)Math.Pow(SMD_BASE, 4);
            public static readonly Int32 SMD_3A = (Int32)Math.Pow(SMD_BASE, 5);
            public static readonly Int32 SMD_3B = (Int32)Math.Pow(SMD_BASE, 6);

            public static readonly Int32 FMD_BASE = 3;
            public static readonly Int32 FMD_1 = (Int32)Math.Pow(FMD_BASE, 1);
            public static readonly Int32 FMD_2 = (Int32)Math.Pow(FMD_BASE, 2);

            public static readonly Int32 PMD_BASE = 5;
            public static readonly Int32 PMD_1 = (Int32)Math.Pow(PMD_BASE, 1);
            public static readonly Int32 PMD_2 = (Int32)Math.Pow(PMD_BASE, 2);
            public static readonly Int32 PMD_3 = (Int32)Math.Pow(PMD_BASE, 3);

            public static readonly Int32 ALMOX_BASE = 7;
            public static readonly Int32 ALMOX = (Int32)Math.Pow(ALMOX_BASE, 1);

            public static readonly Int32 SUBCONJUNTO_BASE = 11;
            public static readonly Int32 SUBCONJUNTO = (Int32)Math.Pow(SUBCONJUNTO_BASE, 1);


            public static readonly Int32 UTILIDADES_BASE = 13;
            public static readonly Int32 UTILIDADES = (Int32)Math.Pow(UTILIDADES_BASE, 1);

            public static readonly Int32 EP_BASE = 17;
            public static readonly Int32 EP = (Int32)Math.Pow(EP_BASE, 1);

            public static readonly Int32 CAE_BASE = 23;
            public static readonly Int32 CAE = (Int32)Math.Pow(CAE_BASE, 1);

            public static readonly Int32 EXP_BASE = 29;
            public static readonly Int32 EXP = (Int32)Math.Pow(EXP_BASE, 1);

            public static readonly int CELULA_INT_NULL_CODE = -1;
            public static readonly string CELULA_STRING_NULL_CODE = null;
        }

        public static String getSavebleCelula(Int32 celula)
        {
            if (celula == CelulaOpts.SMD_1A) return "1A";
            else if (celula == CelulaOpts.SMD_1B) return "1B";
            else if (celula == CelulaOpts.SMD_2A) return "2A";
            else if (celula == CelulaOpts.SMD_2B) return "2B";
            else if (celula == CelulaOpts.SMD_3A) return "3A";
            else if (celula == CelulaOpts.SMD_3B) return "3B";
            else if (celula == CelulaOpts.FMD_1) return "FMD1";
            else if (celula == CelulaOpts.FMD_2) return "FMD2";
            else if (celula == CelulaOpts.PMD_1) return "PMD1";
            else if (celula == CelulaOpts.PMD_2) return "PMD2";
            else if (celula == CelulaOpts.PMD_3) return "PMD3";
            else if (celula == CelulaOpts.ALMOX) return "ALMOX";
            else if (celula == CelulaOpts.SUBCONJUNTO) return "SUBCONJUNTO";
            else if (celula == CelulaOpts.UTILIDADES) return "UTILIDADES";
            else if (celula == CelulaOpts.EP) return "EP";
            else if (celula == CelulaOpts.CAE) return "CAE";
            else if (celula == CelulaOpts.EXP) return "EXP";
            else return CelulaOpts.CELULA_STRING_NULL_CODE;
        }


    }

}
