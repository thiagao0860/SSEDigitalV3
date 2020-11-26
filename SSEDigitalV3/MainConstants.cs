using System;
using System.Globalization;
using System.Drawing;
using SSEDigitalV3.DataCore;
using SSEDigitalV3.UserDBConnector;

namespace SSEDigitalV3
{
    class MainConstants
    {
        public Color acent_color;
        public User loged_User;
        public int version_enabled;
        public string restApiURI;
        public CultureInfo culture;
        private static MainConstants ourInstance = new MainConstants();

        public static MainConstants getInstance() { return ourInstance; }
        private MainConstants()
        {
            this.loged_User = null;
            this.acent_color = Color.FromArgb(255, 153, 153);
            this.version_enabled = 1;
            this.culture = new CultureInfo("pt-BR");
            SQLiteUserConnector db = new SQLiteUserConnector();
            int returned = db.GetIntValue("version");
            Console.WriteLine(returned);
            if (returned > 0)
            {
                this.version_enabled = returned;
            }
            string restApiURIreturned = db.GetStringValue("restApiUri");
            if (restApiURIreturned != null)
            {
                this.restApiURI = restApiURIreturned;
            }
        }
    }
}
